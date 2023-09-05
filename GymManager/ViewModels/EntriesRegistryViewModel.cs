using System;
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
    public class EntriesRegistryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CloseCommand =>
            _closeCommand ??= new RelayCommand(
                x => { Window.DialogResult = false; });

        public DateTime DateFrom
        {
            get => _dateFrom;
            set
            {
                _dateFrom = value;
                _model.GetEntriesRegistry(_dateFrom, _dateTo);

                OnPropertyChange(nameof(EntriesRegistry));
            }
        }

        public DateTime DateTo
        {
            get => _dateTo;
            set
            {
                _dateTo = value;
                _model.GetEntriesRegistry(_dateFrom, _dateTo);

                OnPropertyChange(nameof(EntriesRegistry));
            }
        }

        public List<EntryRegistry> EntriesRegistry =>
            _model.EntriesRegistry
                .Like(_searchText, "Member.FirstName", "Member.LastName", "Member.Id", "CabinetKey.Name")
                .ToList();

        public ICommand RefreshCommand =>
            _refreshCommand ??= new RelayCommand(
                x =>
                {
                    _model.GetEntriesRegistry(_dateFrom, _dateTo);

                    OnPropertyChange(nameof(EntriesRegistry));
                });

        public string SearchText
        {
            set
            {
                _searchText = value;

                OnPropertyChange(nameof(EntriesRegistry));
            }
        }

        public EntryRegistry SelectedItem { get; set; }

        public Window Window => Helper.GetWindow(this);
        private ICommand _closeCommand;
        private DateTime _dateFrom = DateTime.Now.Date;
        private DateTime _dateTo = DateTime.Now.Date;
        private readonly EntriesRegistryModel _model = new();
        private ICommand _refreshCommand;
        private string _searchText = string.Empty;

        public EntriesRegistryViewModel()
        {
            _model.GetEntriesRegistry(_dateFrom, _dateTo);
        }

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}