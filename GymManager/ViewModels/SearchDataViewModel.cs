using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;

namespace GymManager.ViewModels
{
    public class SearchDataViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _closeCommand;
        private string _description;
        private ICommand _searchCommand;

        public ICommand CloseCommand =>
            _closeCommand ??= new RelayCommand(
                x => { Window.Close(); });

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChange();
            }
        }

        public Func<string, bool> Execute { get; set; }

        public ICommand SearchCommand =>
            _searchCommand ??= new RelayCommand(
                x =>
                {
                    if(Execute(SearchText))
                    {
                        Window.Close();
                    }
                });

        public string SearchText { get; set; }

        public string Title { get; set; }
        public Window Window => Helper.GetWindow(this);

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}