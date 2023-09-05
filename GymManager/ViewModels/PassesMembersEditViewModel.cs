using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.DbModels;
using GymManager.Models;
using GymManager.Views;

namespace GymManager.ViewModels
{
    public class PassesMembersEditViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ApplyCommand =>
            _applyCommand ??= new RelayCommand(
                x =>
                {
                    if(CheckPassRegistry(_model.PassRegistry))
                    {
                        try
                        {
                            _model.SaveChanges();

                            Window.DialogResult = true;
                        }
                        catch(Exception ex)
                        {
                            if(ex?.InnerException != null)
                            {
                                MessageView.MessageBoxInfoView(Window, ex?.InnerException.Message, true);
                            }
                        }
                    }
                });

        public ICommand CancelCommand =>
            _cancelCommand ??= new RelayCommand(
                x => { Window.DialogResult = false; });

        public ICommand ContentRenderedCommand =>
            _contentRenderedCommand ??= new RelayCommand(
                x =>
                {
                    if(_model.PassRegistry == null)
                    {
                        Title = "DODAWANIE KARNETU DLA CZŁONKA";

                        _model.SetNewObject(MemberInit?.MemberID ?? 0);

                        if(MemberInit != null)
                        {
                            _model.SetPassRegistry(MemberInit.MemberID);

                            VisibilityButtonsMember = Visibility.Hidden;

                            VisibilityButtonsMemberEdit = Visibility.Hidden;
                        }
                    }
                    else
                    {
                        Title = "EDYCJA KARNETU CZŁONKA";

                        VisibilityButtonsMember = Visibility.Hidden;

                        if(CurrentUser.CheckAccess(Permissions.EditMembers))
                        {
                            VisibilityButtonsMemberEdit = Visibility.Visible;
                        }
                    }

                    LastPassText = _model.GetLastPassText();
                    ContinuationText = _model.GetContinuationText();

                    OnPropertyChange(nameof(PassRegistry));
                    OnPropertyChange(nameof(LastPassText));
                    OnPropertyChange(nameof(ContinuationText));
                    OnPropertyChange(nameof(VisibilityButtonsMember));
                    OnPropertyChange(nameof(VisibilityButtonsMemberEdit));
                    OnPropertyChange(nameof(Title));
                });

        public string ContinuationText { get; set; }

        public ICommand DateChangedCommand =>
            _dateChangedCommand ??= new RelayCommand(
                x =>
                {
                    if(_model.PassRegistry.Member != null)
                    {
                        PassesHelper.SetEndDate(_model.PassRegistry);

                        ContinuationText = _model.GetContinuationText();

                        OnPropertyChange(nameof(ContinuationText));
                        OnPropertyChange(nameof(PassRegistry));
                    }
                });

        public string LastPassText { get; private set; }

        public ICommand MemberCommand =>
            _memberCommand ??= new RelayCommand(
                x =>
                {
                    var view = new MembersView
                    {
                        Owner = Window
                    };

                    var model = view.DataContext as MembersViewModel;
                    model.CloseWhenDoubleClick = true;
                    view.ShowDialog();

                    if(model.SelectedItem != null)
                    {
                        _model.SetPassRegistry(model.SelectedItem.MemberID);

                        LastPassText = _model.GetLastPassText();
                        ContinuationText = _model.GetContinuationText();

                        if(CurrentUser.CheckAccess(Permissions.EditMembers))
                        {
                            VisibilityButtonsMemberEdit = Visibility.Visible;
                        }

                        OnPropertyChange(nameof(LastPassText));
                        OnPropertyChange(nameof(ContinuationText));
                        OnPropertyChange(nameof(PassRegistry));
                        OnPropertyChange(nameof(VisibilityButtonsMemberEdit));
                    }
                });

        public ICommand MemberEditCommand =>
            _memberEditCommand ??= new RelayCommand(
                x =>
                {
                    if(!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.EditMembers))
                    {
                        return;
                    }

                    var view = new MemberEditView
                    {
                        Owner = Window
                    };

                    var model = view.DataContext as MemberEditViewModel;
                    model.SetEditObject(_model.PassRegistry.Member.MemberID);
                    view.ShowDialog();

                    _model.ReloadEntry(_model.PassRegistry.Member);

                    OnPropertyChange(nameof(PassRegistry));
                });

        public Member MemberInit { get; set; }

        public Window Owner
        {
            set => Window.Owner = value;
            get => Window.Owner;
        }

        public List<Pass> Passes => _model.Passes;

        public PassRegistry PassRegistry => _model.PassRegistry;

        public ICommand RfidCommand =>
            _rfidCommand ??= new RelayCommand(
                x =>
                {
                    var view = new RfidView
                    {
                        Owner = Window
                    };

                    view.ShowDialog();

                    if(view.DataContext is RfidViewModel rfidViewModel)
                    {
                        if(!string.IsNullOrEmpty(rfidViewModel.Identifier))
                        {
                            var member = _model.GetMember(rfidViewModel.Identifier);

                            if(member != null)
                            {
                                var memberID = member.MemberID;

                                _model.SetPassRegistry(memberID);

                                LastPassText = _model.GetLastPassText();
                                ContinuationText = _model.GetContinuationText();

                                if(CurrentUser.CheckAccess(Permissions.EditMembers))
                                {
                                    VisibilityButtonsMemberEdit = Visibility.Visible;
                                }

                                OnPropertyChange(nameof(PassRegistry));
                                OnPropertyChange(nameof(ContinuationText));
                                OnPropertyChange(nameof(LastPassText));
                                OnPropertyChange(nameof(VisibilityButtonsMemberEdit));
                            }
                        }
                    }
                });

        public ICommand SelectionChangedCommand =>
            _selectionChangedCommand ??= new RelayCommand(
                x =>
                {
                    if(_model.PassRegistry.Pass != null)
                    {
                        _model.PassRegistry.PassID = _model.PassRegistry.Pass.PassID;
                    }

                    PassesHelper.SetStartDate(_model.PassRegistry);

                    PassesHelper.SetEndDate(_model.PassRegistry);

                    OnPropertyChange(nameof(PassRegistry));
                });

        public string Title { get; set; }
        public Visibility VisibilityButtonsMember { get; set; } = Visibility.Visible;
        public Visibility VisibilityButtonsMemberEdit { get; set; } = Visibility.Hidden;
        public Window Window => Helper.GetWindow(this);
        private ICommand _applyCommand;
        private ICommand _cancelCommand;
        private ICommand _contentRenderedCommand;
        private ICommand _dateChangedCommand;
        private ICommand _memberCommand;
        private ICommand _memberEditCommand;
        private readonly PassesMembersEditModel _model = new();
        private ICommand _rfidCommand;
        private ICommand _selectionChangedCommand;

        public void SetEditObject(int passRegistryID)
        {
            _model.SetEditObject(passRegistryID);
        }

        private bool CheckPassRegistry(PassRegistry passRegistry)
        {
            if(passRegistry is null)
            {
                throw new ArgumentNullException(nameof(passRegistry));
            }

            string filed = null;
            string message = null;

            if(_model.PassRegistry == null)
            {
                return false;
            }

            if(_model.PassRegistry.Suspension && !_model.PassRegistry.StartSuspensionDate.HasValue)
            {
                message = "NALEŻY PODAĆ DATĘ ROZPOCZĘCIA ZAWIESZENIA KARNTU";
            }
            else if(_model.PassRegistry.Suspension && !_model.PassRegistry.EndSuspensionDate.HasValue)
            {
                message = "NALEŻY PODAĆ DATĘ ZAKOŃCZENIA ZAWIESZENIA KARNETU";
            }
            else if(_model.PassRegistry.Suspension &&
                    (_model.PassRegistry.EndSuspensionDate.Value - _model.PassRegistry.StartSuspensionDate.Value)
                    .TotalDays < 0)
            {
                message =
                    "DATA ZAKOŃCZENIA ZAWIESZENIA KARNETU NIE MOŻE BYĆ\nMNIEJSZA NIŻ DATA ROZPOCZĘCIA ZAWIESZENIA";
            }
            else if(_model.PassRegistry.Suspension &&
                    (_model.PassRegistry.StartSuspensionDate.Value < _model.PassRegistry.StartDate ||
                     _model.PassRegistry.StartSuspensionDate.Value > _model.PassRegistry.EndDate.Value))
            {
                message = "DATA ROZPOCZĘCIA ZAWIESZENIA KARNETU MUSI ZAWIERAĆ SIĘ\nW DACIE KARNETU";
            }
            else if(_model.PassRegistry.Suspension &&
                    (_model.PassRegistry.EndSuspensionDate.Value < _model.PassRegistry.StartDate ||
                     _model.PassRegistry.EndSuspensionDate.Value > _model.PassRegistry.EndDate.Value))
            {
                message = "DATA ZAKOŃCZENIA ZAWIESZENIA KARNETU MUSI ZAWIERAĆ SIĘ\nW DACIE KARNETU";
            }
            else if(_model.PassRegistry.Suspension && PassesHelper.GetSummaryOfDaysSubscriptionSuspension(
                        _model.PassRegistry.MemberID, _model.PassRegistry.StartDate.Year,
                        _model.PassRegistry.PassRegistryID) +
                    (_model.PassRegistry.EndSuspensionDate.Value - _model.PassRegistry.StartSuspensionDate.Value)
                    .TotalDays > Settings.App.MaximumDaysSubscriptionSuspension)
            {
                message =
                    $"MAKSYMALNA LICZBA DNI ZAWIESZENIA KARNETU\nWYNOSI {Settings.App.MaximumDaysSubscriptionSuspension} W DANYM ROKU KALENDARZOWYM";
            }
            else if(_model.PassRegistry.Member == null)
            {
                filed = "CZŁONEK [ID,IMIĘ,NAZWISKO]";
            }
            else if(_model.PassRegistry.Pass == null)
            {
                filed = "KARNET";
            }
            else if(_model.PassRegistry.PassID == 1)
            {
                message = "NALEŻY WYBRAĆ RODZAJ KARNETU";
            }
            else
            {
                return true;
            }

            MessageBoxDb.FieldMustBeCompleted(Window, filed, message);

            return false;
        }

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}