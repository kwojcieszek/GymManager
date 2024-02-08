using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.Models;

namespace GymManager.ViewModels
{
    public class MessageBoxInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _closeCommand;
        private bool _isWarrning;
        private readonly MessageBoxInfoModel _model = new();

        public ICommand CloseCommand =>
            _closeCommand ??= new RelayCommand(
                x => { Window?.Close(); });

        public bool IsWarrning
        {
            get => _isWarrning;
            set
            {
                _isWarrning = value;
                OnPropertyChange();
            }
        }

        public string Message
        {
            get => _model.Message;
            set
            {
                _model.Message = value;
                OnPropertyChange();
            }
        }

        public Window Window => Helper.GetWindow(this);

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}