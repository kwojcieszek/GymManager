using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.Models;

namespace GymManager.ViewModels
{
    public class MessageBoxQuestionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Message
        {
            get => _model.Message;
            set
            {
                _model.Message = value;
                OnPropertyChange();
            }
        }

        public ICommand NoCommand =>
            _noCommand ??= new RelayCommand(
                x => { Window.DialogResult = false; });

        public Window Window => Helper.GetWindow(this);

        public ICommand YesCommand =>
            _yesCommand ??= new RelayCommand(
                x => { Window.DialogResult = true; });

        private readonly MessageBoxQuestionModel _model = new();
        private ICommand _noCommand;
        private ICommand _yesCommand;

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}