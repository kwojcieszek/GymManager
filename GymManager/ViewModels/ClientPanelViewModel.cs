using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;

namespace GymManager.ViewModels
{
    public class ClientPanelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _contentRenderedCommand;
        public ICommand ContentRenderedCommand =>
            _contentRenderedCommand ??= new RelayCommand(
                x => { OnPropertyChange(nameof(DataContext)); });

        public object DataContext => Window?.Tag;

        public Window Owner
        {
            set => Window.Owner = value;
            get => Window.Owner;
        }

        public Window Window => Helper.GetWindow(this);

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}