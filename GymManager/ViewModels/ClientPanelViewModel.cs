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

        public ICommand ContentRenderedCommand =>
            _contentRenderedCommand ??= new RelayCommand(
                x => { OnPropertyChange(nameof(DataContext)); });

        public object DataContext => Window?.Tag;

        public Window Owner
        {
            set => Window.Owner = value;
            get => Window.Owner;
        }

        public ICommand Test =>
            test ??= new RelayCommand(
                x =>
                {
                    var secondaryScreenLeft = SystemParameters.PrimaryScreenWidth - SystemParameters.VirtualScreenWidth;

                    Window.WindowStartupLocation = WindowStartupLocation.Manual;
                    Window.Left = secondaryScreenLeft;
                    Window.Top = 0;
                });

        public Window Window => Helper.GetWindow(this);
        private ICommand _contentRenderedCommand;
        private ICommand test;

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}