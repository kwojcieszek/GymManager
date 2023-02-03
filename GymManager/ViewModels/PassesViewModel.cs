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

public class PassesViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand AddCommand =>
        _addCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AddPasses))
                    return;

                if (Add())
                {
                    _model.GetPasses(OnlyActives);

                    OnPropertyChange(nameof(Passes));
                }
            });

    public ICommand CloseCommand =>
        _closeCommand ??= new RelayCommand(
            x => { Window.DialogResult = false; });

    public ICommand DeleteCommand =>
        _deleteCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.DeletePasses))
                    return;

                if (Delete())
                {
                    _model.GetPasses(OnlyActives);

                    OnPropertyChange(nameof(Passes));
                }
            });

    public ICommand EditCommand =>
        _editCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.EditPasses))
                    return;

                if (Edit())
                {
                    _model.GetPasses(OnlyActives);

                    OnPropertyChange(nameof(Passes));
                }
            });

    public bool OnlyActives
    {
        get => _model.OnlyActives;
        set => _model.OnlyActives = value;
    }

    public List<Pass> Passes =>
        _model.Passes
            .Like(_searchText, "Name", "PassTime.Name", "Tax.Rate", "AddedByUser.FirstName", "AddedByUser.LastName",
                "ModifiedByUser.FirstName", "ModifiedByUser.LastName")
            .OrderBy(m => m.Name).ToList();

    public ICommand RefreshCommand =>
        _refreshCommand ??= new RelayCommand(
            x =>
            {
                _model.GetPasses(OnlyActives);

                OnPropertyChange(nameof(Passes));
            });

    public string SearchText
    {
        set
        {
            _searchText = value;

            OnPropertyChange(nameof(Passes));
        }
    }

    public ICommand SearchTextCommand =>
        _searchTextCommand ??= new RelayCommand(
            x => { OnPropertyChange(nameof(Passes)); });

    public Pass SelectedItem { get; set; }

    public Window Window => Helper.GetWindow(this);
    private ICommand _addCommand;
    private ICommand _closeCommand;
    private ICommand _deleteCommand;
    private ICommand _editCommand;
    private readonly PassesModel _model = new();
    private ICommand _refreshCommand;
    private string _searchText = string.Empty;
    private ICommand _searchTextCommand;

    public bool Add(Window window = null)
    {
        window ??= Window;

        try
        {
            var passEditView = new PassEditView();
            var model = passEditView.DataContext as PassEditViewModel;
            model.Owner = window;
            return passEditView.ShowDialog().Value;
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

        var message = $"CZY NA PEWNO USUNĄĆ KARNET\n{SelectedItem.Name} ?";

        if (MessageView.MessageBoxQuestionView(Window, message))
        {
            try
            {
                _model.Delete(SelectedItem);
            }
            catch (Exception ex)
            {
                if (ex?.InnerException != null)
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
            var passEditView = new PassEditView();
            var model = passEditView.DataContext as PassEditViewModel;
            model.Owner = Window;
            model.SetEditObject(SelectedItem.PassID);
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