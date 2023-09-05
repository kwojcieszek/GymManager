using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.DbModels;
using GymManager.Models;

namespace GymManager.ViewModels
{
    public class DataTrackingsPreviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CloseCommand =>
            _closeCommand ??= new RelayCommand(
                x => { Window.DialogResult = true; });

        public ICommand ContentRenderedCommand =>
            _contentRenderedCommand ??= new RelayCommand(
                x =>
                {
                    if(_model.DataTracking?.DataTrackingOperation.DataTrackingOperationID == 3)
                    {
                        IsViewNewData = false;
                    }

                    OnPropertyChange(nameof(IsViewNewData));
                    OnPropertyChange(nameof(DataTracking));
                    OnPropertyChange(nameof(DataTrackingDefinitions));
                });

        public DataTracking DataTracking
        {
            get => _model.DataTracking;
            set => _model.DataTracking = value;
        }

        public List<DataTrackingDefinition> DataTrackingDefinitions => _model.DataTrackingDefinitions;
        public bool IsViewNewData { get; set; } = true;

        public Window Owner
        {
            set => Window.Owner = value;
            get => Window.Owner;
        }

        public Window Window => Helper.GetWindow(this);
        private ICommand _closeCommand;
        private ICommand _contentRenderedCommand;
        private readonly DataTrackingsPreviewModel _model = new();

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}