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

public class CabinetKeyEditViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand ApplyCommand =>
        _applyCommand ??= new RelayCommand(
            x =>
            {
                if (CheckCabinetKey(_model.CabinetKey))
                    try
                    {
                        _model.SaveChanges();

                        Window.DialogResult = true;
                    }
                    catch (Exception ex)
                    {
                        MessageView.MessageBoxInfoView(Window, ex?.InnerException.Message, true);
                    }
            });

    public CabinetKey CabinetKey => _model.CabinetKey;

    public ICommand CancelCommand =>
        _cancelCommand ??= new RelayCommand(
            x => { Window.DialogResult = false; });

    public ICommand ContentRenderedCommand =>
        _contentRenderedCommand ??= new RelayCommand(
            x =>
            {
                if (_model.CabinetKey == null)
                {
                    Title = "DODAWANIE KLUCZA DO SZAFKI";

                    _model.SetNewObject();
                }
                else
                {
                    Title = $"EDYCJA KLUCZA DO SZAFKI [{_model.CabinetKey.Name}]";
                }

                OnPropertyChange(nameof(CabinetKey));
                OnPropertyChange(nameof(Title));
            });

    public List<Gender> Genders => _model.Genders;

    public Window Owner
    {
        set => Window.Owner = value;
        get => Window.Owner;
    }

    public string Title { get; set; }
    public Window Window => Helper.GetWindow(this);
    private ICommand _applyCommand;
    private ICommand _cancelCommand;
    private ICommand _contentRenderedCommand;
    private readonly CabinetKeyEditModel _model = new();

    public void SetEditObject(int cabinetKeyID)
    {
        _model.SetEditObject(cabinetKeyID);
    }

    private bool CheckCabinetKey(CabinetKey cabinetKey)
    {
        string message = null;
        string filed;

        if (_model.CabinetKey == null)
            return false;
        if (string.IsNullOrEmpty(cabinetKey.Name))
            filed = "NAZWA [NUMER KLUCZYKA]";
        else if (cabinetKey.Gender == null)
            filed = "PŁEĆ";
        else
            return true;

        MessageBoxDb.FieldMustBeCompleted(Window, filed, message);

        return false;
    }

    private void OnPropertyChange([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}