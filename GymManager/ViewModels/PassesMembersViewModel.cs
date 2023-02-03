using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.DbModels;
using GymManager.Models;
using GymManager.Views;

namespace GymManager.ViewModels;

public class PassesMembersViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand AddCommand =>
        _addCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AddPassesRegistry))
                    return;

                if (Add())
                {
                    _model.GetPassRegistry(DateFrom, DateTo);
                    OnPropertyChange(nameof(PassesRegistry));
                }
            });

    public ICommand CloseCommand =>
        _closeCommand ??= new RelayCommand(
            x => { Window.DialogResult = false; });

    public DateTime DateFrom
    {
        get => _dateFrom;
        set
        {
            _dateFrom = value;
            _model.GetPassRegistry(_dateFrom, _dateTo);
            OnPropertyChange(nameof(PassesRegistry));
        }
    }

    public DateTime DateTo
    {
        get => _dateTo;
        set
        {
            _dateTo = value;
            _model.GetPassRegistry(_dateFrom, _dateTo);
            OnPropertyChange(nameof(PassesRegistry));
        }
    }

    public ICommand DeleteCommand =>
        _deleteCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.DeletePassesRegistry))
                    return;

                if (Delete())
                {
                    _model.GetPassRegistry(DateFrom, DateTo);
                    OnPropertyChange(nameof(PassesRegistry));
                }
            });

    public ICommand EditCommand =>
        _editCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.EditPassesRegistry))
                    return;

                if (Edit())
                {
                    _model.GetPassRegistry(DateFrom, DateTo);
                    OnPropertyChange(nameof(PassesRegistry));
                }
            });

    public List<PassRegistry> PassesRegistry =>
        _model.PassRegistry
            .Like(_searchText, "PassRegistryID", "Pass.Name", "Member.FirstName", "Member.LastName", "Member.Id",
                "AddedByUser.FirstName", "AddedByUser.LastName",
                "ModifiedByUser.FirstName", "ModifiedByUser.LastName")
            .ToList();

    public ICommand RefreshCommand =>
        _refreshCommand ??= new RelayCommand(
            x =>
            {
                _model.GetPassRegistry(DateFrom, DateTo);
                OnPropertyChange(nameof(PassesRegistry));
            });

    public string SearchText
    {
        set
        {
            _searchText = value;

            OnPropertyChange(nameof(PassesRegistry));
        }
    }

    public ICommand SearchTextCommand =>
        _searchTextCommand ??= new RelayCommand(
            x => { OnPropertyChange(nameof(PassesRegistry)); });

    public PassRegistry SelectedItem { get; set; }

    public Window Window => Helper.GetWindow(this);
    private ICommand _addCommand;
    private ICommand _closeCommand;
    private DateTime _dateFrom = DateTime.Now.Date;
    private DateTime _dateTo = DateTime.Now.Date;
    private ICommand _deleteCommand;
    private ICommand _editCommand;
    private readonly PassesMembersModel _model = new();
    private ICommand _refreshCommand;
    private string _searchText = string.Empty;
    private ICommand _searchTextCommand;

    public PassesMembersViewModel()
    {
        _model.GetPassRegistry(DateFrom, DateTo);
    }

    public bool Add(Window window = null)
    {
        window ??= Window;

        try
        {
            var passEditView = new PassesMembersEditView();
            var model = passEditView.DataContext as PassesMembersEditViewModel;
            model.Owner = window;
            var result = passEditView.ShowDialog().Value;

            if (result && model.PassRegistry.Pass.AskAddEntry.HasValue && model.PassRegistry.Pass.AskAddEntry.Value)
                if (MessageView.MessageBoxQuestionView(window,
                        $"CZY CHCESZ DODAĆ WEJŚCIE DLA CZŁONKA\n{model.PassRegistry.Member.FirstName} {model.PassRegistry.Member.LastName} [{model.PassRegistry.Member.Id}]?"))
                {
                    var entryService = EntryService.GetInstance();

                    entryService.Entry(model.PassRegistry.Member);
                }

            return result;
        }
        catch (Exception ex)
        {
            MessageView.MessageBoxInfoView(window, ex.Message, true);

            return false;
        }
    }

    private bool Delete()
    {
        if (SelectedItem == null)
            return false;

        var message =
            $"CZY NA PEWNO USUNĄĆ WPIS KARNETU\nID {SelectedItem.PassID} DLA {SelectedItem.Member.FirstName} {SelectedItem.Member.LastName} ?";

        if (MessageView.MessageBoxQuestionView(Window, message))
        {
            try
            {
                _model.Delete(SelectedItem);
            }
            catch (Exception ex)
            {
                MessageView.MessageBoxInfoView(Window, ex?.InnerException.Message, true);

                return false;
            }

            return true;
        }

        return false;
    }

    private bool Edit()
    {
        if (SelectedItem == null)
            return false;

        try
        {
            var passEditView = new PassesMembersEditView();
            var model = passEditView.DataContext as PassesMembersEditViewModel;
            model.Owner = Window;
            model.SetEditObject(SelectedItem.PassRegistryID);
            return passEditView.ShowDialog().Value;
        }
        catch (Exception ex)
        {
            MessageView.MessageBoxInfoView(Window, ex.Message, true);

            return false;
        }
    }

    private void OnPropertyChange([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}