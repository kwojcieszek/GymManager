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
    public class PassEditViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _applyCommand;
        private ICommand _cancelCommand;
        private ICommand _contentRenderedCommand;
        private readonly PassEditModel _model = new();
        private ICommand _passChanged;

        public ICommand ApplyCommand =>
            _applyCommand ??= new RelayCommand(
                x =>
                {
                    if(CheckPass(_model.Pass))
                    {
                        try
                        {
                            if(_model.Pass.PassTime.PassTimeID != 99)
                            {
                                _model.Pass.PassTimeDays = null;
                            }

                            _model.SaveChanges();

                            Window.DialogResult = true;
                        }
                        catch(Exception ex)
                        {
                            if(ex?.InnerException != null)
                            {
                                MessageView.MessageBoxInfoView(Window, ex?.InnerException.Message, true);
                            }
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
                    if(_model.Pass == null)
                    {
                        Title = "DODAWANIE KARNETU";

                        _model.SetNewObject();
                    }
                    else
                    {
                        Title = $"EDYCJA KARNETU [{_model.Pass.Name}]";
                    }

                    OnPropertyChange(nameof(Pass));
                    OnPropertyChange(nameof(PassTimeDaysEnable));
                    OnPropertyChange(nameof(Title));
                });

        public Window Owner
        {
            set => Window.Owner = value;
            get => Window.Owner;
        }

        public Pass Pass => _model.Pass;

        public ICommand PassChanged =>
            _passChanged ??= new RelayCommand(
                x =>
                {
                    _model.CalculatePriceFromBrutto(_model.Pass);
                    OnPropertyChange(nameof(PassTimeDaysEnable));
                    OnPropertyChange(nameof(Pass));
                });

        public bool PassTimeDaysEnable => Pass?.PassTime?.PassTimeID == 99;
        public List<PassTime> PassTimes => _model.PassTimes;
        public List<Tax> Taxes => _model.Taxes;
        public string Title { get; set; }
        public Window Window => Helper.GetWindow(this);

        public void SetEditObject(int passID)
        {
            _model.SetEditObject(passID);
        }

        private bool CheckPass(Pass pass)
        {
            string filed = null;
            string message = null;

            if(_model.Pass == null)
            {
                return false;
            }

            if(string.IsNullOrEmpty(pass.Name))
            {
                filed = "NAZWA";
            }
            else if(string.IsNullOrEmpty(pass.Description))
            {
                filed = "OPIS";
            }
            else if(pass.Tax == null)
            {
                filed = "STAWKA VAT";
            }
            else if(pass.PassTime == null)
            {
                filed = "OKRES KARNETU";
            }
            else if(pass.PassTime.PassTimeID == 99 && (pass.PassTimeDays == null || pass.PassTimeDays <= 0))
            {
                filed = "OKRES DNI MUSI BYĆ ZDEFINIOWANY I WIĘKSZY OD ZERA";
            }
            else if(pass.AccessTimeFrom == null && pass.AccessTimeTo != null)
            {
                filed = "OBOWIĄZUJE W GODZINACH OD";
            }
            else if(pass.AccessTimeFrom != null && pass.AccessTimeTo == null)
            {
                filed = "OBOWIĄZUJE W GODZINACH DO";
            }
            else if(pass.AccessTimeFrom != null && pass.AccessTimeTo != null &&
                    pass.AccessTimeFrom.Value.TimeOfDay.TotalSeconds > pass.AccessTimeTo.Value.TimeOfDay.TotalSeconds)
            {
                message = "CZAS 'OBOWIĄZUJE W GODZINACH OD' JEST WIĘKSZY NIŻ\n'OBOWIĄZUJE W GODZINACH DO'!";
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