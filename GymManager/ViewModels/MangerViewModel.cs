using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.Models;
using GymManager.Views;

namespace GymManager.ViewModels;

public class MangerViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand AboutCommand =>
        _aboutCommand ??= new RelayCommand(
            x =>
            {
                new AboutView
                    {
                        Owner = Window
                    }
                    .ShowDialog();
            });

    public ICommand AddCabinetKeysCommand =>
        _addCabinetKeysCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AddCabinetKeys))
                    return;

                new CabinetKeysViewModel().Add(Window);
            });

    public ICommand AddEntryWithoutIdentifierCommand =>
        _addEntryWithoutIdentifierCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AddEntryWithoutIdentifier))
                    return;

                var view = new MembersView
                {
                    Owner = Window
                };

                var dx = view.DataContext as MembersViewModel;
                dx.CloseWhenDoubleClick = true;

                var result = view.ShowDialog();

                if (result.HasValue & result.Value && dx.SelectedItem != null)
                {
                    var entryRegistry = PassesHelper.GetActiveEntryRegistry(dx.SelectedItem);

                    if (entryRegistry == null &&
                        new IdentifiersService().Identifier(dx.SelectedItem.MemberID, checkAndWrite: false).Message !=
                        IdentifierMessage.AccessEntry)
                    {
                        if (MessageView.MessageBoxQuestionView(Window,
                                $"BRAK WAŻNEGO KARNETU!\nMIMO TO CZY CHCESZ DODAĆ '{(entryRegistry == null ? "WEJŚCIE" : "WYJŚCIE")}' DLA\n{dx.SelectedItem.FirstName} {dx.SelectedItem.LastName} [{dx.SelectedItem.Id}] ?"))
                            EntryService.GetInstance().Entry(dx.SelectedItem, true);
                    }
                    else
                    {
                        if (MessageView.MessageBoxQuestionView(Window,
                                $"CZY CHCESZ DODAĆ '{(entryRegistry == null ? "WEJŚCIE" : "WYJŚCIE")}' DLA\n{dx.SelectedItem.FirstName} {dx.SelectedItem.LastName} [{dx.SelectedItem.Id}] ?"))
                            EntryService.GetInstance().Entry(dx.SelectedItem);
                    }
                }
            });

    public ICommand AddMembersViewCommand =>
        _addMembersViewCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AddMembers))
                    return;

                new MembersViewModel().Add(Window);
            });

    public ICommand AddPassesCommand =>
        _addPassesCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AddPasses))
                    return;

                new PassesViewModel().Add(Window);
            });

    public ICommand AddPassesMembersCommand =>
        _addPassesMembersCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AddPassesRegistry))
                    return;

                new PassesMembersViewModel().Add(Window);
            });

    public ICommand AddUsersViewCommand =>
        _addUsersViewCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AddUsers))
                    return;

                new UsersViewModel().Add(Window);
            });

    public ICommand CabinetKeysCommand =>
        _cabinetKeysCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AddCabinetKeys))
                    return;

                new CabinetKeysView
                    {
                        Owner = Window
                    }
                    .ShowDialog();
            });

    public ICommand ChangePasswordCommand =>
        _changePasswordCommand ??= new RelayCommand(
            x =>
            {
                new ChangePasswordView
                    {
                        Owner = Window
                    }
                    .ShowDialog();
            });

    public ICommand ClosePersonInGymCommand =>
        _closePersonInGymCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.CloseMembersInGym))
                    return;

                if (MessageView.MessageBoxQuestionView(Window, "CZY CHCESZ ZAMKNĄĆ WSZYSTKIE WEJŚCIA CZŁONKÓW ?"))
                    new IdentifiersService().CloseRegistry(0);
            });

    public ICommand ContentRenderedCommand =>
        _contentRenderedCommand ??= new RelayCommand(
            x => { Login(); });

    public string DatabaseName => _model.DatabaseName;

    public ICommand DatabasesSettingsCommand =>
        _databasesSettingsCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AccessSettings))
                    return;

                new DatabasesSettingsView
                    {
                        Owner = Window
                    }
                    .ShowDialog();
            });

    public DateTime? DataTimeLogin => _model.DataTimeLogin;

    public ICommand DataTrackingsCommand =>
        _dataTrackingsCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AccessDataTrackings))
                    return;

                new DataTrackingsView
                    {
                        Owner = Window
                    }
                    .ShowDialog();
            });

    public ICommand EntriesRegistryCommand =>
        _entriesRegistryCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AccessEntriesRegistryView))
                    return;

                new EntriesRegistryView
                    {
                        Owner = Window
                    }
                    .ShowDialog();
            });

    public bool ExpanderOthersIsExpanded
    {
        get => _expanderOthersIsExpanded;
        set
        {
            _expanderOthersIsExpanded = value;

            if (value)
            {
                _expanderRecordsIsExpanded = _expanderRegistersIsExpanded = false;

                OnPropertyChange(nameof(ExpanderRecordsIsExpanded));
                OnPropertyChange(nameof(ExpanderRegistersIsExpanded));
            }
        }
    }

    public bool ExpanderRecordsIsExpanded
    {
        get => _expanderRecordsIsExpanded;
        set
        {
            _expanderRecordsIsExpanded = value;

            if (value)
            {
                _expanderRegistersIsExpanded = _expanderOthersIsExpanded = false;

                OnPropertyChange(nameof(ExpanderRegistersIsExpanded));
                OnPropertyChange(nameof(ExpanderOthersIsExpanded));
            }
        }
    }

    public bool ExpanderRegistersIsExpanded
    {
        get => _expanderRegistersIsExpanded;
        set
        {
            _expanderRegistersIsExpanded = value;

            if (value)
            {
                _expanderRecordsIsExpanded = _expanderOthersIsExpanded = false;

                OnPropertyChange(nameof(ExpanderRecordsIsExpanded));
                OnPropertyChange(nameof(ExpanderOthersIsExpanded));
            }
        }
    }

    public string FullName => _model.FullName;

    public ICommand GotFocusCommand =>
        _gotFocusCommand ??= new RelayCommand(
            x => { App.ApplicationMainWindowIsActive = true; });

    public ICommand LogoutCommand =>
        _logoutCommand ??= new RelayCommand(
            x => { Logout(); });

    public ICommand LostFocusCommand =>
        _lostFocusCommand ??= new RelayCommand(
            x => { App.ApplicationMainWindowIsActive = false; });

    public ICommand MembersViewCommand =>
        _membersViewCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AccessMembers))
                    return;

                new MembersView
                    {
                        Owner = Window
                    }
                    .ShowDialog();
            });

    public ICommand PassesCommand =>
        _passesCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AccessPasses))
                    return;

                new PassesView
                    {
                        Owner = Window
                    }
                    .ShowDialog();
            });

    public ICommand PassesMembersCommand =>
        _passesMembersCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AccessPassesRegistry))
                    return;

                new PassesMembersView
                    {
                        Owner = Window
                    }
                    .ShowDialog();
            });

    public ICommand PersonInGymCommand =>
        _personInGymCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AccessPersonsInGym))
                    return;

                new PersonsInGymView
                    {
                        Owner = Window
                    }
                    .ShowDialog();
            });

    public ICommand SearchMemberViewCommand =>
        _searchMemberViewCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.EditMembers))
                    return;

                var view = new SearchDataView();
                var dx = view.DataContext as SearchDataViewModel;
                dx.Title = "WYSZUKAJ CZŁONKA DO EDYCJI";
                dx.Description = "WPROWADŹ KOD PRACOWNIKA";
                dx.Execute = id =>
                {
                    if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.EditMembers))
                        return true;

                    var memberId = new MembersModel().GetMemberById(id);

                    if (memberId == null)
                    {
                        var msg = new MessageBoxInfoView();
                        var mdx = msg.DataContext as MessageBoxInfoViewModel;
                        mdx.Message = "NIE ZNALEZIONO KODU CZŁONKOWSKIEGO";
                        mdx.IsWarrning = true;
                        msg.Owner = Window;
                        msg.ShowDialog();
                        return false;
                    }

                    var memberEditView = new MemberEditView();
                    var model = memberEditView.DataContext as MemberEditViewModel;
                    model.Owner = Window;
                    model.SetEditObject(memberId.MemberID);

                    memberEditView.ShowDialog();

                    return true;
                };
                view.Owner = Window;
                view.ShowDialog();
            });

    public ICommand SettingsCommand =>
        _settingsCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AccessSettings))
                    return;

                new SettingsView
                    {
                        Owner = Window
                    }
                    .ShowDialog();
            });

    public string SystemStatusName => _model.SystemStatusName;

    public ICommand TeamViewerCommand =>
        _teamViewerCommand ??= new RelayCommand(
            x => { new TeamViewer().Run(); });

    public string Title => $"GYM MANAGER [{_model.AssemblyVersion}]";
    public string UserName => _model.UserName;

    public ICommand UsersViewCommand =>
        _usersViewCommand ??= new RelayCommand(
            x =>
            {
                if (!PermissionView.MessageBoxCheckPermissionView(Window, Permissions.AccessUsers))
                    return;

                new UsersView
                    {
                        Owner = Window
                    }
                    .ShowDialog();
            });

    public Window Window => Helper.GetWindow(this);

    public ICommand WindowClosedCommand =>
        _windowClosedCommand ??= new RelayCommand(
            x => { Application.Current.Shutdown(); });

    public ICommand WindowClosingCommand { get; set; }
    private ICommand _aboutCommand;
    private ICommand _addCabinetKeysCommand;
    private ICommand _addEntryWithoutIdentifierCommand;
    private ICommand _addMembersViewCommand;
    private ICommand _addPassesCommand;
    private ICommand _addPassesMembersCommand;
    private ICommand _addUsersViewCommand;
    private ICommand _cabinetKeysCommand;
    private ICommand _changePasswordCommand;
    private ICommand _closePersonInGymCommand;
    private ICommand _contentRenderedCommand;
    private ICommand _databasesSettingsCommand;
    private ICommand _dataTrackingsCommand;
    private ICommand _entriesRegistryCommand;
    private bool _expanderOthersIsExpanded;
    private bool _expanderRecordsIsExpanded = true;
    private bool _expanderRegistersIsExpanded;
    private ICommand _gotFocusCommand;
    private ICommand _logoutCommand;
    private ICommand _lostFocusCommand;
    private ICommand _membersViewCommand;
    private readonly MangerModel _model = new();
    private ICommand _passesCommand;
    private ICommand _passesMembersCommand;
    private ICommand _personInGymCommand;
    private ICommand _searchMemberViewCommand;
    private ICommand _settingsCommand;
    private ICommand _teamViewerCommand;
    private ICommand _usersViewCommand;
    private ICommand _windowClosedCommand;

    public MangerViewModel()
    {
        WindowClosingCommand = new RelayCommand(WindowClosing);
    }

    private void Login()
    {
        new LoginView
            {
                Owner = Window
            }
            .ShowDialog();

        if (CurrentUser.User == null)
        {
            Window?.Close();
        }
        else
        {
            _model.DataTimeLogin = DateTime.Now;

            OnPropertyChange(nameof(DataTimeLogin));
            OnPropertyChange(nameof(FullName));
        }
    }

    private void Logout()
    {
        new CurrentUser().Logout();

        _model.DataTimeLogin = null;

        OnPropertyChange(nameof(DataTimeLogin));
        OnPropertyChange(nameof(FullName));

        Login();
    }

    private void OnPropertyChange([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void WindowClosing(object e)
    {
        if (e is CancelEventArgs cancelEventArgs)
            if (!MessageView.MessageBoxQuestionView(Window, "CZY NA PEWNO CHCESZ ZAMKNĄĆ PROGRAM ?"))
                cancelEventArgs.Cancel = true;
    }
}