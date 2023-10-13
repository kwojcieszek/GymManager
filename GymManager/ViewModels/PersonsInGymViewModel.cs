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
using GymManager.Views;

namespace GymManager.ViewModels
{
    public class PersonsInGymViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ChangeCabinetKeyCommand =>
            _changeCabinetKeyCommand ??= new RelayCommand(
                x =>
                {
                    if(SelectedItem == null)
                    {
                        return;
                    }

                    var view = new CabinetKeysAvailableView();
                    var dx = view.DataContext as CabinetKeysAvailableViewModel;

                    var result = view.ShowDialog();

                    if(result.HasValue && result.Value && dx?.SelectedItem != null)
                    {
                        _model.ChangeCabinetKey(SelectedItem, dx.SelectedItem);
                        _model.GetEntriesRegistry();
                        OnPropertyChange(nameof(EntriesRegistry));
                    }
                });

        public ICommand CloseCommand =>
            _closeCommand ??= new RelayCommand(
                x => { Window.DialogResult = false; });

        public ICommand CloseRowCommand =>
            _closeRowCommand ??= new RelayCommand(
                x =>
                {
                    if(CloseRow())
                    {
                        _model.GetEntriesRegistry();
                        OnPropertyChange(nameof(EntriesRegistry));
                    }
                });

        public ICommand EditCommand =>
            _editCommand ??= new RelayCommand(
                x =>
                {
                    if(!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.EditMembers))
                    {
                        return;
                    }

                    Edit();
                });

        public List<EntryRegistry> EntriesRegistry =>
            _model.EntriesRegistry
                .Like(_searchText, "Member.Id", "Member.FirstName", "Member.LastName", "CabinetKey.Name")
                .OrderByDescending(m => m.EntryDate).ToList();

        public ICommand PreviewCommand =>
            _previewCommand ??= new RelayCommand(
                x =>
                {
                    if(!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.PreviewMembers))
                    {
                        return;
                    }

                    Preview();
                });

        public ICommand RefreshCommand =>
            _refreshCommand ??= new RelayCommand(
                x =>
                {
                    _model.GetEntriesRegistry();
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

        public ICommand SearchTextCommand =>
            _searchTextCommand ??= new RelayCommand(
                x => { OnPropertyChange(nameof(EntriesRegistry)); });

        public EntryRegistry SelectedItem { get; set; }

        public Window Window => Helper.GetWindow(this);
        private ICommand _changeCabinetKeyCommand;
        private ICommand _closeCommand;
        private ICommand _closeRowCommand;
        private ICommand _editCommand;
        private readonly PersonsInGymModel _model = new();
        private ICommand _previewCommand;
        private ICommand _refreshCommand;
        private string _searchText = string.Empty;
        private ICommand _searchTextCommand;

        private bool CloseRow()
        {
            if(SelectedItem == null)
            {
                return false;
            }

            var message =
                $"CZY NA PEWNO ZAMKNĄĆ REKORD OSOBY\n{SelectedItem.Member.FirstName} {SelectedItem.Member.LastName} [{SelectedItem.Member.Id}] ?";

            if(MessageView.MessageBoxQuestionView(Window, message))
            {
                try
                {
                    _model.CloseRow(SelectedItem);
                }
                catch(Exception ex)
                {
                    if(ex?.InnerException != null)
                    {
                        MessageView.MessageBoxInfoView(Window, ex?.InnerException.Message, true);
                    }

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
                var memberEditView = new MemberEditView();
                var model = memberEditView.DataContext as MemberEditViewModel;
                model.Owner = Window;
                model.SetEditObject(SelectedItem.MemberID);

                var result = memberEditView.ShowDialog()!.Value;

                if(result && model.Member.PassID != null &&
                   PassesHelper.GetCurrentPassRegistry(model.Member.MemberID) == null)
                {
                    if(MessageView.MessageBoxQuestionView(Window,
                           $"CZY CHCESZ DODAĆ NOWY KARNET DLA CZŁONKA\n{model.Member.FirstName} {model.Member.LastName} [{model.Member.Id}]?"))
                    {
                        var passEditView = new PassesMembersEditView();
                        var passesMembersEditViewModel = passEditView.DataContext as PassesMembersEditViewModel;
                        passesMembersEditViewModel!.Owner = Window;
                        passesMembersEditViewModel.MemberInit = model.Member;
                        passEditView.ShowDialog();
                    }
                }

                return result;
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

        private bool Preview()
        {
            if(SelectedItem == null)
            {
                return false;
            }

            try
            {
                var memberEditView = new MemberPreviewView();
                var model = memberEditView.DataContext as MemberEditViewModel;
                model!.Owner = Window;
                model.SetEditObject(SelectedItem.MemberID);

                var result = memberEditView.ShowDialog()!.Value;

                return result;
            }
            catch(Exception ex)
            {
                MessageView.MessageBoxInfoView(Window, ex.Message, true);

                return false;
            }
        }
    }
}