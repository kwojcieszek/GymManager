using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.DbModels;
using GymManager.Models;

namespace GymManager.ViewModels
{
    public class CabinetKeysAvailableViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _doubleClickCommand;
        private readonly CabinetKeysAvailableModel _model = new();
        private ICommand _refreshCommand;
        private string _searchText = string.Empty;
        private ICommand _searchTextCommand;

        public List<CabinetKey> CabinetKeys =>
            _model.GetCabinetKeys(OnlyActives)
                .Like(_searchText, "Name", "Gender.Name")
                .ToList();

        public ICommand DoubleClickCommand =>
            _doubleClickCommand ??= new RelayCommand(
                x =>
                {
                    if(SelectedItem == null)
                    {
                        return;
                    }

                    Window.DialogResult = true;
                });

        public bool OnlyActives
        {
            get => _model.OnlyActives;
            set => _model.OnlyActives = value;
        }

        public ICommand RefreshCommand =>
            _refreshCommand ??= new RelayCommand(
                x =>
                {
                    _model.GetCabinetKeys(OnlyActives);

                    OnPropertyChange(nameof(CabinetKeys));
                });

        public string SearchText
        {
            set
            {
                _searchText = value;

                OnPropertyChange(nameof(CabinetKeys));
            }
        }

        public ICommand SearchTextCommand =>
            _searchTextCommand ??= new RelayCommand(
                x => { OnPropertyChange(nameof(CabinetKeys)); });

        public CabinetKey SelectedItem { get; set; }

        public Window Window => Helper.GetWindow(this);

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}