using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.DataModel.Models;
using GymManager.Models;
using GymManager.Views;
using GymManager.DataService.Common;

namespace GymManager.ViewModels
{
    public class CabinetKeysViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly CabinetKeysModel _model = new();
        private string _searchText = string.Empty;
        private ICommand _addCommand;
        private ICommand _closeCommand;
        private ICommand _deleteCommand;
        private ICommand _editCommand;
        private ICommand _refreshCommand;
        
        public ICommand AddCommand =>
            _addCommand ??= new RelayCommand(
                x =>
                {
                    if(!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AddCabinetKeys))
                    {
                        return;
                    }

                    if(Add())
                    {
                        _model.GetCabinetKeys(OnlyActives);

                        OnPropertyChange(nameof(CabinetKeys));
                    }
                });

        public List<CabinetKey> CabinetKeys =>
            _model.CabinetKeys
                .Like(_searchText, "Name", "Gender.Name")
                .ToList();

        public ICommand CloseCommand =>
            _closeCommand ??= new RelayCommand(
                x => { Window.DialogResult = false; });

        public ICommand DeleteCommand =>
            _deleteCommand ??= new RelayCommand(
                x =>
                {
                    if(!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.DeleteCabinetKeys))
                    {
                        return;
                    }

                    if(Delete())
                    {
                        _model.GetCabinetKeys(OnlyActives);

                        OnPropertyChange(nameof(CabinetKeys));
                    }
                });

        public ICommand EditCommand =>
            _editCommand ??= new RelayCommand(
                x =>
                {
                    if(!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.EditCabinetKeys))
                    {
                        return;
                    }

                    if(Edit())
                    {
                        _model.GetCabinetKeys(OnlyActives);

                        OnPropertyChange(nameof(CabinetKeys));
                    }
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

        public CabinetKey SelectedItem { get; set; }

        public Window Window => Helper.GetWindow(this);

        public bool Add(Window window = null)
        {
            window ??= Window;

            try
            {
                var cabinetKeyEditView = new CabinetKeyEditView();
                var model = cabinetKeyEditView.DataContext as CabinetKeyEditViewModel;
                model.Owner = window;

                return cabinetKeyEditView.ShowDialog().Value;
            }
            catch(Exception ex)
            {
                MessageView.MessageBoxInfoView(window, ex.Message, true);

                return false;
            }
        }

        private bool Delete()
        {
            if(SelectedItem == null)
            {
                return false;
            }

            var message = $"CZY NA PEWNO USUNĄĆ KLUCZYK DO SZAFKI\n{SelectedItem.Name} ?";

            if(MessageView.MessageBoxQuestionView(Window, message))
            {
                try
                {
                    _model.Delete(SelectedItem);
                }
                catch(Exception ex)
                {
                    MessageView.MessageBoxInfoView(Window, ex?.InnerException.Message, true);

                    return false;
                }

                return true;
            }

            return false;
        }

        private bool Edit()
        {
            if(SelectedItem == null)
            {
                return false;
            }

            try
            {
                var cabinetKeyEditView = new CabinetKeyEditView();
                var model = cabinetKeyEditView.DataContext as CabinetKeyEditViewModel;
                model.Owner = Window;
                model.SetEditObject(SelectedItem.CabinetKeyID);

                return cabinetKeyEditView.ShowDialog().Value;
            }
            catch(Exception ex)
            {
                MessageView.MessageBoxInfoView(Window, ex.Message, true);

                return false;
            }
        }

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}