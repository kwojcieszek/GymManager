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

public class UsersViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand AddCommand =>
        _addCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AddUsers))
                    return;

                if (Add())
                    OnPropertyChange(nameof(Users));
            });

    public ICommand CloseCommand =>
        _closeCommand ??= new RelayCommand(
            x => { Window.DialogResult = false; });

    public ICommand DeleteCommand =>
        _deleteCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.DeleteUsers))
                    return;

                if (Delete())
                {
                    _model.GetUsers(OnlyActives);
                    OnPropertyChange(nameof(Users));
                }
            });

    public ICommand EditCommand =>
        _editCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.EditUsers))

                    return;
                if (Edit())
                {
                    _model.GetUsers(OnlyActives);
                    OnPropertyChange(nameof(Users));
                }
            });

    public bool OnlyActives
    {
        get => _model.OnlyActives;
        set => _model.OnlyActives = value;
    }

    public ICommand RefreshCommand =>
        _refreshCommand ??= new RelayCommand(
            x =>
            {
                _model.GetUsers(OnlyActives);
                OnPropertyChange(nameof(Users));
            });

    public string SearchText
    {
        set
        {
            _searchText = value;

            OnPropertyChange(nameof(Users));
        }
    }

    public ICommand SearchTextCommand =>
        _searchTextCommand ??= new RelayCommand(
            x => { OnPropertyChange(nameof(User)); });

    public User SelectedItem { get; set; }

    public List<User> Users => _model.GetUsers(OnlyActives)
        .Like(_searchText, "UserName", "FirstName", "LastName", "Email", "Phone",
            "AddedByUser.FirstName", "AddedByUser.LastName", "ModifiedBy.FirstName", "ModifiedBy.LastName");

    public Window Window => Helper.GetWindow(this);
    private ICommand _addCommand;
    private ICommand _closeCommand;
    private ICommand _deleteCommand;
    private ICommand _editCommand;
    private readonly UsersModel _model = new();
    private ICommand _refreshCommand;
    private string _searchText = string.Empty;
    private ICommand _searchTextCommand;

    public bool Add(Window window = null)
    {
        window ??= Window;

        try
        {
            var userEditView = new UsersEditView();
            var model = userEditView.DataContext as UserEditViewModel;
            model.Owner = window;
            return userEditView.ShowDialog().Value;
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
            $"CZY NA PEWNO USUNĄĆ UŻYTKOWNIKA\n{SelectedItem.FirstName} {SelectedItem.LastName} [{SelectedItem.UserName}] ?";

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
            var userEditView = new UsersEditView();
            var model = userEditView.DataContext as UserEditViewModel;
            model.Owner = Window;
            model.SetEditObject(SelectedItem.UserID);
            return userEditView.ShowDialog().Value;
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