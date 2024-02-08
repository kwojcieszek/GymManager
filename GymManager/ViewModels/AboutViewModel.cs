using System.Reflection;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;

namespace GymManager.ViewModels
{
    public class AboutViewModel
    {
        private ICommand _closingCommand;

        public ICommand ClosingCommand =>
            _closingCommand ??= new RelayCommand(
                x => { Window.Close(); });

        public string Title => "O PROGRAMIE";
        public string VersionApp => $"WERSJA: {Assembly.GetEntryAssembly()?.GetName().Version}";
        public Window Window => Helper.GetWindow(this);
    }
}