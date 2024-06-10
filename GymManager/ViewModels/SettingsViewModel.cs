using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.Models;
using Microsoft.Win32;

namespace GymManager.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly SettingsModel _model = new();
        private ICommand _adobeApplicationPathCommand;
        private ICommand _applyCommand;
        private ICommand _cancelCommand;
        private ICommand _logoImagePathCommand;
        private ICommand _samplesDataCommand;

        public ICommand AdobeApplicationPathCommand =>
            _adobeApplicationPathCommand ??= new RelayCommand(
                x =>
                {
                    var op = new OpenFileDialog
                    {
                        Title = "WYBIERZ PLIK PROGRAMU ADOBE ACROBAT READER DC",
                        Filter = "exe|*.exe"
                    };

                    if(op.ShowDialog() == true)
                    {
                        _model.AppSettings.Reports.AdobeApplicationPath = op.FileName;

                        OnPropertyChange(nameof(AppSettings));
                    }
                });

        public ICommand ApplyCommand =>
            _applyCommand ??= new RelayCommand(
                x =>
                {
                    _model.Save();

                    Window.DialogResult = true;
                });

        public Settings AppSettings => _model.AppSettings;
        public List<int> BaudRates => _model.BaudRates;

        public ICommand CancelCommand =>
            _cancelCommand ??= new RelayCommand(
                x =>
                {
                    _model.Restore();

                    Window.DialogResult = false;
                });

        public ICommand LogoImagePathCommand =>
            _logoImagePathCommand ??= new RelayCommand(
                x =>
                {
                    var op = new OpenFileDialog
                    {
                        Title = "WYBIERZ PLIK Z LOGO FIRMY",
                        Filter = "png|*.png"
                    };

                    if(op.ShowDialog() == true)
                    {
                        _model.AppSettings.LogoImagePath = op.FileName;

                        OnPropertyChange(nameof(AppSettings));
                    }
                });

        public Window Owner
        {
            set => Window.Owner = value;
            get => Window.Owner;
        }

        public List<string> PortNames => _model.PortNames;

        public ICommand SamplesDataCommand =>
            _samplesDataCommand ??= new RelayCommand(
                x =>
                {
                    new SamplesData().CreateSamplesData(12, 50, 500, 10000);
                    Window.DialogResult = false;
                });

        public Visibility VisibleButtonSamplesData { get; }
        public Window Window => Helper.GetWindow(this);

        public SettingsViewModel()
        {
#if DEBUG
            VisibleButtonSamplesData = Visibility.Visible;
#else
            this.VisibleButtonSamplesData = Visibility.Hidden;
#endif
        }

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}