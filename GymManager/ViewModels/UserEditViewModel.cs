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

namespace GymManager.ViewModels
{
    public class UserEditViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ApplyCommand =>
            _applyCommand ??= new RelayCommand(
                x =>
                {
                    if(CheckUser(_model.User))
                    {
                        try
                        {
                            if(_passwordChanged)
                            {
                                User.Password = Cryptography.MD5Hash(_password1);
                            }

                            _model.SaveChanges();

                            Window.DialogResult = true;
                        }
                        catch(Exception ex)
                        {
                            MessageView.MessageBoxInfoView(Window, ex?.InnerException.Message, true);
                        }
                    }
                });

        public ICommand CancelCommand =>
            _cancelCommand ??= new RelayCommand(
                x => { Window.DialogResult = false; });

        public ICommand ContentRenderedCommand =>
            _contentRenderedCommand ??= new RelayCommand(
                x =>
                {
                    if(_model.User == null)
                    {
                        Title = "DODAWANIE UŻYTKOWNIKA";

                        _model.SetNewObject();
                    }
                    else
                    {
                        Title = $"EDYCJA UŻYTKOWNIKA [{_model.User.FirstName} {_model.User.LastName}]";
                    }

                    OnPropertyChange(nameof(User));
                    OnPropertyChange(nameof(PermissionsListUser));
                    OnPropertyChange(nameof(Password1));
                    OnPropertyChange(nameof(Password2));
                    OnPropertyChange(nameof(Title));
                });

        public Window Owner
        {
            set => Window.Owner = value;
            get => Window.Owner;
        }

        public string Password1
        {
            get => _password1 ??= _model.User?.Password;
            set
            {
                _password1 = value;
                _passwordChanged = true;
            }
        }

        public string Password2
        {
            get => _password2 ??= _model.User?.Password;
            set
            {
                _password2 = value;
                _passwordChanged = true;
            }
        }

        public List<PermissionListUser> PermissionsListUser => _model.PermissionsListUser;
        public string Title { get; set; }

        public User User => _model.User;

        public Window Window => Helper.GetWindow(this);
        public bool _passwordChanged;
        private ICommand _applyCommand;
        private ICommand _cancelCommand;
        private ICommand _contentRenderedCommand;
        private readonly UserEditModel _model = new();
        private string _password1;
        private string _password2;

        public void SetEditObject(int userID)
        {
            _model.SetEditObject(userID);
        }

        private bool CheckUser(User user)
        {
            string filed = null;
            string message = null;

            if(user == null)
            {
                return false;
            }

            if(string.IsNullOrEmpty(user.UserName))
            {
                filed = "LOGIN";
            }
            else if(string.IsNullOrEmpty(user.FirstName))
            {
                filed = "IMIE";
            }
            else if(string.IsNullOrEmpty(user.LastName))
            {
                filed = "NAZWISKO";
            }
            else if(string.IsNullOrEmpty(user.Email))
            {
                filed = "EMAIL";
            }
            else if(string.IsNullOrEmpty(user.Phone))
            {
                filed = "TELEFON";
            }
            else if(string.IsNullOrEmpty(_password1) || string.IsNullOrEmpty(_password2))
            {
                filed = "HASŁO";
            }
            else if(_password1 != _password2)
            {
                message = "POLA HASŁA NIE POSIADJĄ TEGO SAMEGO HASŁA";
            }
            else if(_password1.Length < _model.PasswordMinLenght)
            {
                message = $"ZBYT KRÓTKIE HASŁO\nMINIMALNA DŁUGOŚĆ HASŁA WYNOSI {_model.PasswordMinLenght} ZNAKÓW";
            }
            else if(!string.IsNullOrEmpty(user.Email) && !EmailValidator.EmailIsValid(user.Email))
            {
                message = $"EMAIL '{user.Email}' MA NIEPRAWIDŁOWY FORMAT";
            }
            else
            {
                return true;
            }

            MessageBoxDb.FieldMustBeCompleted(Window, filed, message);

            return false;
        }

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}