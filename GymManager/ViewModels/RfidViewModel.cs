﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.Models;

namespace GymManager.ViewModels
{
    public class RfidViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _closeCommand;
        private ICommand _closedCommand;
        private readonly RfidModel _model = new();

        public ICommand CloseCommand =>
            _closeCommand ??= new RelayCommand(
                x => { Window?.Close(); });

        public ICommand ClosedCommand =>
            _closedCommand ??= new RelayCommand(
                x => { _model.CloseIdentifierService(); });

        public string Identifier => _model.Identifier;

        public string PathGif => $"{Path.ApplicationDirectory}\\Images\\Waiting_circle.gif";
        public Window Window => Helper.GetWindow(this);

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RfidViewModel()
        {
            _model.EventNewIdentifier += (o, e) =>
            {
                new Audio().Play("beep", true);

                Helper.Invoke(() => Window?.Close());
            };
        }
    }
}