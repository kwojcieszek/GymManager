﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.Models;
using GymManager.Views;

namespace GymManager.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly LoginModel _model = new();
        public string Password { get; set; }
        public string UserName { get; set; }

        private ICommand _cancelCommand;
        public ICommand LoginCommand { get; set; }

        public ICommand CancelCommand =>
            _cancelCommand ??= new RelayCommand(
                x => { Application.Current.Shutdown(); });

        public Window Window => Helper.GetWindow(this);

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        public void LoginUser(string username, string password)
        {
            if(_model.Login(username, password ?? string.Empty))
            {
                GymManager.DataService.Common.TrackingDatabase.SetCurrentUser(CurrentUser.User.UserID);

                Window?.Close();
            }
            else
            {
                MessageView.MessageBoxInfoView(Window, "Nieudane logowanie.\nNieprawidłowy login lub hasło.", true);

                Password = string.Empty;

                OnPropertyChange(nameof(Password));
            }
        }

        private void Login(object obj)
        {
            if(obj is object[] user)
            {
                if(user.Length == 2 && user[0] is string userName && user[1] is string password)
                {
                    LoginUser(userName, password);
                }
            }
        }

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}