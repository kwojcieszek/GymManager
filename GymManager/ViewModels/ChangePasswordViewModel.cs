using System;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.Models;
using GymManager.Views;

namespace GymManager.ViewModels
{
    public class ChangePasswordViewModel
    {
        private ICommand _applyCommand;
        private ICommand _cancelCommand;
        private readonly UserEditModel _model = new();

        public ICommand ApplyCommand =>
            _applyCommand ??= new RelayCommand(
                x =>
                {
                    try
                    {
                        if(CheckUser())
                        {
                            _model.ChangePassword(CurrentUser.User.UserID, Password1);

                            MessageView.MessageBoxInfoView(Window, "HASŁO ZOSTAŁO ZMIENIONE");

                            Window.DialogResult = true;
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageView.MessageBoxInfoView(Window, ex?.InnerException.Message, true);
                    }
                });

        public ICommand CancelCommand =>
            _cancelCommand ??= new RelayCommand(
                x => { Window.DialogResult = false; });

        public string CurrentPassword { get; set; }

        public Window Owner
        {
            set => Window.Owner = value;
            get => Window.Owner;
        }

        public string Password1 { get; set; }
        public string Password2 { get; set; }
        public Window Window => Helper.GetWindow(this);

        private bool CheckUser()
        {
            string filed = null;
            string message = null;

            if(string.IsNullOrEmpty(CurrentPassword))
            {
                filed = "OBECNE HASŁO";
            }
            else if(string.IsNullOrEmpty(Password1) || string.IsNullOrEmpty(Password2))
            {
                filed = "NOWE HASŁO";
            }
            else if(!_model.CheckCorrectPassword(_model.GetUser(CurrentUser.User.UserID), CurrentPassword))
            {
                message = "OBECNE HASŁO JEST NIEPRAWIDŁOWE";
            }
            else if(Password1 != Password2)
            {
                message = "POLA HASŁA NIE POSIADJĄ TEGO SAMEGO HASŁA";
            }
            else if(Password1.Length < _model.PasswordMinLenght)
            {
                message = $"ZBYT KRÓTKIE HASŁO\nMINIMALNA DŁUGOŚĆ HASŁA WYNOSI {_model.PasswordMinLenght} ZNAKÓW";
            }
            else
            {
                return true;
            }

            MessageBoxDb.FieldMustBeCompleted(Window, filed, message);

            return false;
        }
    }
}