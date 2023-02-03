using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.DbModels;
using GymManager.Models;
using GymManager.Views;

namespace GymManager.ViewModels;

public class MembersViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand AddCommand =>
        _addCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AddMembers))
                    return;

                if (Add())
                {
                    _model.GetMembers(OnlyActives);

                    OnPropertyChange(nameof(Members));
                }
            });

    public ICommand CloseCommand =>
        _closeCommand ??= new RelayCommand(
            x => { Window.DialogResult = false; });

    public bool CloseWhenDoubleClick { get; set; }

    public ICommand DeleteCommand =>
        _deleteCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.DeleteMembers))
                    return;

                if (Delete())
                {
                    _model.GetMembers(OnlyActives);

                    OnPropertyChange(nameof(Members));
                }
            });

    public ICommand DoubleClickCommand =>
        _doubleClickCommand ??= new RelayCommand(
            x =>
            {
                if (CloseWhenDoubleClick)
                {
                    Window.DialogResult = true;
                }
                else
                {
                    Edit();

                    _model.GetMembers(OnlyActives);

                    OnPropertyChange(nameof(Members));
                }
            });

    public ICommand EditCommand =>
        _editCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.EditMembers))
                    return;

                if (Edit())
                {
                    _model.GetMembers(OnlyActives);

                    OnPropertyChange(nameof(Members));
                }
            });

    public List<Member> Members => _model.Members
        .Like(_searchText, "Id", "FirstName", "LastName", "Street1", "Street2", "City", "PostCode", "Phone", "Email",
            "Gender.Name",
            "Pass.Name", "AddedByUser.FirstName", "AddedByUser.LastName", "ModifiedBy.FirstName",
            "ModifiedBy.LastName");

    public bool OnlyActives
    {
        get => _model.OnlyActives;
        set => _model.OnlyActives = value;
    }

    public ICommand RefreshCommand =>
        _refreshCommand ??= new RelayCommand(
            x =>
            {
                _model.GetMembers(OnlyActives);

                OnPropertyChange(nameof(Members));
            });

    public string SearchText
    {
        set
        {
            _searchText = value;

            OnPropertyChange(nameof(Members));
        }
    }

    public Member SelectedItem { get; set; }

    public Window Window => Helper.GetWindow(this);
    private ICommand _addCommand;
    private ICommand _closeCommand;
    private ICommand _deleteCommand;
    private ICommand _doubleClickCommand;
    private ICommand _editCommand;
    private readonly MembersModel _model = new();
    private ICommand _refreshCommand;
    private string _searchText = string.Empty;

    public bool Add(Window window = null)
    {
        window ??= Window;

        try
        {
            var memberEditView = new MemberEditView();
            var model = memberEditView.DataContext as MemberEditViewModel;
            model.Owner = window;
            var result = memberEditView.ShowDialog().Value;

            if (result && model.Member.Pass != null)
                if (MessageView.MessageBoxQuestionView(window,
                        $"CZY CHCESZ DODAĆ NOWY KARNET DLA CZŁONKA\n{model.Member.FirstName} {model.Member.LastName} [{model.Member.Id}]?"))
                {
                    var passEditView = new PassesMembersEditView();
                    var passesMembersEditViewModel = passEditView.DataContext as PassesMembersEditViewModel;
                    passesMembersEditViewModel.Owner = window;
                    passesMembersEditViewModel.MemberInit = model.Member;
                    passEditView.ShowDialog();
                }

            if (result)
            {
                var dialogResult = true;
                ;

                if (Settings.App.Reports.ShowPrintDialogAfterAddingMember)
                    dialogResult =
                        MessageView.MessageBoxQuestionView(window, "CZY CHCESZ WYDRUKOWAĆ DOKUMENTY CZŁONKOWSKIE?");

                if (Settings.App.Reports.PrintDocumentsAfterAddingMember && dialogResult)
                {
                    var pdf = new ReportsPdf();

                    foreach (var report in pdf.MemberDocuemnts(model.Member))
                        pdf.Print(report);
                }
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
            $"CZY NA PEWNO USUNĄĆ OSOBĘ\n{SelectedItem.FirstName} {SelectedItem.LastName} [{SelectedItem.Id}] ?";

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
            var memberEditView = new MemberEditView();
            var model = memberEditView.DataContext as MemberEditViewModel;
            model.Owner = Window;
            model.SetEditObject(SelectedItem.MemberID);

            var result = memberEditView.ShowDialog().Value;

            if (result && model.Member.PassID != null &&
                PassesHelper.GetCurrentPassRegistry(model.Member.MemberID) == null)
                if (MessageView.MessageBoxQuestionView(Window,
                        $"CZY CHCESZ DODAĆ NOWY KARNET DLA CZŁONKA\n{model.Member.FirstName} {model.Member.LastName} [{model.Member.Id}]?"))
                {
                    var passEditView = new PassesMembersEditView();
                    var passesMembersEditViewModel = passEditView.DataContext as PassesMembersEditViewModel;
                    passesMembersEditViewModel.Owner = Window;
                    passesMembersEditViewModel.MemberInit = model.Member;
                    passEditView.ShowDialog();
                }

            return result;
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