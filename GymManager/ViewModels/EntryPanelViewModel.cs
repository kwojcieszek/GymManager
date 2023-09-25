using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;
using GymManager.Common;
using GymManager.DbModels;
using GymManager.Models;
using GymManager.Views;

namespace GymManager.ViewModels
{
    public class EntryPanelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static string Time => DateTime.Now.ToLongTimeString();
        public static int UnreadMessages => 0;

        public ICommand AddEntryWithoutIdentifierCommand =>
            _addEntryWithoutIdentifierCommand ??= new RelayCommand(
                x => CommonViewModel.AddEntryWithoutIdentifierCommand());

        public ICommand ChangeCabinetKeyCommand =>
            _changeCabinetKeyCommand ??= new RelayCommand(
                x =>
                {
                    lock(_model)
                    {
                        var selectedItem = _model.LastEntryRegistry;

                        if(selectedItem == null)
                        {
                            return;
                        }

                        var view = new CabinetKeysAvailableView();
                        var dx = view.DataContext as CabinetKeysAvailableViewModel;

                        var result = view.ShowDialog();

                        if(result.HasValue && result.Value && dx?.SelectedItem != null)
                        {
                            _model.ChangeCabinetKey(selectedItem, dx.SelectedItem);

                            Message2 = $"NUMER KLUCZYKA: {dx.SelectedItem.Name}";

                            OnPropertyChange(nameof(LastEntryRegistry));
                            OnPropertyChange(nameof(Message2));
                        }
                    }
                });

        public ICommand ContentRenderedCommand
        {
            get =>
                _contentRenderedCommand ??= new RelayCommand(
                    x =>
                    {
#if DEBUGA
                       this._timer = new DispatcherTimer();
                       this._timer.Interval = new TimeSpan(0, 0, 1);
                       this._timer.Tick += (o, e) =>
                       {
                           OnPropertyChange(nameof(Time));
                       };
                       this._timer.Start();

                       var view = new ClientPanelView();                   
                      view.Tag = this;
                       /*
                       var secondaryScreenLeft = SystemParameters.PrimaryScreenWidth - SystemParameters.VirtualScreenWidth;

                       view.WindowStartupLocation = WindowStartupLocation.Manual;
                       view.Left = secondaryScreenLeft;
                       view.Top = 0;*/
                       //view.Show();

#endif
                    });
        }

        public Visibility EntryOK { get; set; } = Visibility.Hidden;
        public Visibility EntryStop { get; set; } = Visibility.Hidden;
        public Visibility EntryWaiting { get; set; }

        public Visibility EntryWaitingNegative => EntryWaiting == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;

        public Visibility Error { get; set; } = Visibility.Hidden;
        public string ErrorMessage { get; set; }
        public Visibility ExitOK { get; set; } = Visibility.Hidden;
        public string ImageLogoPath => Settings.App.LogoImagePath;
        public bool IsIdentifierDevice => _model.IsIdentifierDevice;
        public EntryRegistry LastEntryRegistry => _model.LastEntryRegistry;
        public byte[] MemberPhoto { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public string Message3 { get; set; }
        public string Message4 { get; set; }
        public int NumersOfPeopeInGym => _model.NumersOfPeopeInGym;

        public Visibility VisibleMemberPhoto { get; set; }
        private ICommand _changeCabinetKeyCommand;
        private ICommand _contentRenderedCommand;

        private readonly EntryPanelModel _model =
            new((bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue);

        private int _taskStackMessage;
#pragma warning disable CS0169
#pragma warning disable IDE0051
        private readonly DispatcherTimer _timer;
#pragma warning restore IDE0051
#pragma warning restore CS0169
        private readonly int _timeVisibilityMessage = 10000;
        private ICommand _addEntryWithoutIdentifierCommand;

        public EntryPanelViewModel()
        {
            _model.EventResult += EventResult;
            _model.EventStateChanged += EventStateChanged;

            Settings.App.SettingsChanged += (sender, args) => { OnPropertyChange(nameof(ImageLogoPath)); };

            EntryWaiting = IsIdentifierDevice ? Visibility.Visible : Visibility.Hidden;
        }

        private void EventResult(object sender, EventArgsResult e)
        {
            if(e.Result.Message == IdentifierMessage.AccessEntry)
            {
                EntryOK = Visibility.Visible;
                VisibleMemberPhoto = Visibility.Visible;
                ExitOK = Visibility.Hidden;
                EntryStop = Visibility.Hidden;
                EntryWaiting = Visibility.Hidden;

                var age = PassesHelper.GetMemberAge(e.Result.Member);

                Message1 = $"WEJŚCIE: {e.Result.Member.FirstName} {e.Result.Member.LastName} [{e.Result.Member.Id}]" +
                           (age.HasValue ? $" [{age} LATA]" : string.Empty);
                Message2 = $"NUMER KLUCZYKA: {e.Result.CabinetKey?.Name}";
                Message3 =
                    $"KARNET '{e.Result.PassRegistry?.Pass.Name}' WAŻNY DO: {e.Result.PassRegistry?.EndDate:dd-MM-yyyy}";
                Message4 =
                    $"OSTATNI KARNET '{e.Result.EndOfPassRegistry?.Pass.Name}' WAŻNY DO: {e.Result.EndOfPassRegistry?.EndDate:dd-MM-yyyy}";

                new Audio().Play("beep", "entry");
            }
            else if(e.Result.Message == IdentifierMessage.AccessExit)
            {
                EntryOK = Visibility.Hidden;
                ExitOK = Visibility.Visible;
                VisibleMemberPhoto = Visibility.Visible;
                EntryStop = Visibility.Hidden;
                EntryWaiting = Visibility.Hidden;

                Message1 = $"WYJŚCIE: {e.Result.Member.FirstName} {e.Result.Member.LastName} [{e.Result.Member.Id}]";
                Message2 = $"NUMER KLUCZYKA: {e.Result.CabinetKey?.Name}";
                Message3 = $"CZAS POBYTU: {EntityMethodsHelper.GetHourFromMinutes(e.Result.EntryRegistry.VisitTime)}";
                Message4 =
                    $"OSTATNI KARNET '{e.Result.EndOfPassRegistry?.Pass.Name}' WAŻNY DO: {e.Result.EndOfPassRegistry?.EndDate:dd-MM-yyyy}";

                new Audio().Play("beep", "exit");
            }
            else
            {
                EntryOK = Visibility.Hidden;
                ExitOK = Visibility.Hidden;
                EntryStop = Visibility.Visible;
                VisibleMemberPhoto = Visibility.Hidden;
                EntryWaiting = Visibility.Hidden;

                if(e.Result.Message == IdentifierMessage.NoIdentifier)
                {
                    Message1 = "BRAK DOSTĘPU";
                    Message2 = "NIEZNANY IDENTYFIKATOR";
                    Message3 = "";
                    Message4 = "";
                }
                else if(e.Result.Message == IdentifierMessage.PassExpiration ||
                        e.Result.Message == IdentifierMessage.OutOfTime)
                {
                    Message1 = "BRAK DOSTĘPU";
                    Message3 =
                        $"CZŁONEK: {e.Result.Member.FirstName} {e.Result.Member.LastName} [{e.Result.Member.Id}]";
                    Message4 = "UWAGI:";

                    if(e.Result.Message == IdentifierMessage.PassExpiration)
                    {
                        Message2 = e.Result.PassRegistry != null
                            ? $"KARNET STACIŁ WAŻNOŚĆ W DNIU: {e.Result.PassRegistry.EndDate:dd-MM-yyyy}"
                            : "BRAK KARNETU";
                    }
                    else if(e.Result.Message == IdentifierMessage.OutOfTime)
                    {
                        Message2 =
                            $"KARNET '{e.Result.PassRegistry.Pass.Name}' WAŻNY W GODZINACH OD {e.Result.PassRegistry.Pass.AccessTimeFrom:HH:mm} DO {e.Result.PassRegistry.Pass.AccessTimeTo:HH:mm}";
                    }
                }
                else if(e.Result.Message == IdentifierMessage.SubscriptionSuspension)
                {
                    Message1 = "BRAK DOSTĘPU";
                    Message3 =
                        $"CZŁONEK: {e.Result.Member.FirstName} {e.Result.Member.LastName} [{e.Result.Member.Id}]";
                    Message4 = "UWAGI:";

                    Message2 = e.Result.PassRegistry != null
                        ? $"KARNET ZAWIESZONO DO DNIA {e.Result.PassRegistry.EndSuspensionDate:dd-MM-yyyy}"
                        : "BRAK KARNETU";
                }
                else if(e.Result.Message == IdentifierMessage.UnknowError)
                {
                    Message1 = "BRAK DOSTĘPU";
                    Message2 = "NIEZNANY BŁĄD";
                    Message3 = "";
                    Message4 = "";
                }

                new Audio().Play("warning");
            }


            if(e.Result.Member != null)
            {
                MemberPhoto = _model.GetPhoto(e.Result.Member.MemberID);
            }

            OnPropertyChange(nameof(NumersOfPeopeInGym));
            OnPropertyChange(nameof(UnreadMessages));
            OnPropertyChange(nameof(LastEntryRegistry));
            OnPropertyChange(nameof(EntryStop));
            OnPropertyChange(nameof(EntryOK));
            OnPropertyChange(nameof(ExitOK));
            OnPropertyChange(nameof(VisibleMemberPhoto));
            OnPropertyChange(nameof(MemberPhoto));
            OnPropertyChange(nameof(Message1));
            OnPropertyChange(nameof(Message2));
            OnPropertyChange(nameof(Message3));
            OnPropertyChange(nameof(Message4));
            OnPropertyChange(nameof(EntryWaiting));
            OnPropertyChange(nameof(EntryWaitingNegative));
            OnPropertyChange(nameof(Error));

            if(!Helper.GetApplicationActive())
            {
                Task.Factory.StartNew(() =>
                {
                    Helper.Invoke(() =>
                    {
                        var view = new EntryMessageView
                        {
                            WindowStartupLocation = WindowStartupLocation.Manual,
                            Left = 5
                        };
                        view.Top = Helper.GetTaskBarStart() - view.Height - 5;
                        view.Show();

                        User32.AllowSetForegroundWindow((uint)Process.GetCurrentProcess().Id);
                        var handle = new WindowInteropHelper(view).Handle;
                        User32.SetForegroundWindow(handle);
                        User32.ShowWindow(handle, User32.SW_SHOWNORMAL);
                    });
                });
            }

            Task.Factory.StartNew(() =>
            {
                _taskStackMessage++;

                Task.Delay(_timeVisibilityMessage).Wait();

                _taskStackMessage--;

                if(_taskStackMessage == 0)
                {
                    EntryOK = Visibility.Hidden;
                    ExitOK = Visibility.Hidden;
                    EntryStop = Visibility.Hidden;

                    if(IsIdentifierDevice)
                    {
                        EntryWaiting = Visibility.Visible;
                    }

                    OnPropertyChange(nameof(EntryStop));
                    OnPropertyChange(nameof(EntryOK));
                    OnPropertyChange(nameof(ExitOK));
                    OnPropertyChange(nameof(VisibleMemberPhoto));
                    OnPropertyChange(nameof(MemberPhoto));
                    OnPropertyChange(nameof(Message1));
                    OnPropertyChange(nameof(Message2));
                    OnPropertyChange(nameof(Message3));
                    OnPropertyChange(nameof(Message4));
                    OnPropertyChange(nameof(EntryWaiting));
                    OnPropertyChange(nameof(EntryWaitingNegative));
                }
            });
        }

        private void EventStateChanged(object sender, EventArgsStatus e)
        {
            if(e.Status.IsWorking)
            {
                Error = Visibility.Hidden;
                EntryOK = Visibility.Hidden;
                ExitOK = Visibility.Hidden;
                EntryStop = Visibility.Hidden;
                VisibleMemberPhoto = Visibility.Hidden;

                if(IsIdentifierDevice)
                {
                    EntryWaiting = Visibility.Visible;
                }
            }
            else
            {
                Error = Visibility.Visible;
                EntryOK = Visibility.Hidden;
                ExitOK = Visibility.Hidden;
                EntryStop = Visibility.Hidden;
                EntryWaiting = Visibility.Hidden;
                VisibleMemberPhoto = Visibility.Hidden;
                ErrorMessage = string.Empty;
                ErrorMessage = e.Status.Message;
            }

            OnPropertyChange(nameof(EntryStop));
            OnPropertyChange(nameof(EntryOK));
            OnPropertyChange(nameof(ExitOK));
            OnPropertyChange(nameof(VisibleMemberPhoto));
            OnPropertyChange(nameof(MemberPhoto));
            OnPropertyChange(nameof(EntryWaiting));
            OnPropertyChange(nameof(EntryWaitingNegative));
            OnPropertyChange(nameof(Error));
            OnPropertyChange(nameof(ErrorMessage));
        }

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}