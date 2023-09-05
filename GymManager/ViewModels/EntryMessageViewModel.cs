using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using GymManager.Common;
using GymManager.DbModels;
using GymManager.Models;

namespace GymManager.ViewModels
{
    public class EntryMessageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CloseCommand =>
            _closeCommand ??= new RelayCommand(
                x =>
                {
                    _isClosed = true;

                    Window?.Close();
                });

        public ICommand ContentRenderedCommand =>
            _contentRenderedCommand ??= new RelayCommand(
                x => { Message(new EventArgsResult(_model.IdentifierResult)); });

        public Visibility EntryOK { get; set; } = Visibility.Hidden;
        public Visibility EntryStop { get; set; } = Visibility.Hidden;
        public Visibility ExitOK { get; set; } = Visibility.Hidden;
        public EntryRegistry LastEntryRegistry => _model.LastEntryRegistry;
        public byte[] MemberPhoto { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public string Message3 { get; set; }
        public string Message4 { get; set; }

        public Window Window => Helper.GetWindow(this);
        private ICommand _closeCommand;
        private ICommand _contentRenderedCommand;
        private bool _isClosed;
        private readonly EntryMessageModel _model = new();
        private readonly DispatcherTimer _timer = new();
        private readonly int _timeVisibilityMessageSeconds = 10;

        public EntryMessageViewModel()
        {
            _timer.Interval = new TimeSpan(0, 0, _timeVisibilityMessageSeconds);
            _timer.Tick += (o, e) =>
            {
                if(!_isClosed)
                {
                    Helper.Invoke(() => Window?.Close());
                }
            };
            _timer.Start();
        }

        private void Message(EventArgsResult e)
        {
            if(e.Result == null)
            {
                return;
            }

            if(e.Result.Message == IdentifierMessage.AccessEntry)
            {
                EntryOK = Visibility.Visible;
                ExitOK = Visibility.Hidden;
                EntryStop = Visibility.Hidden;

                var age = PassesHelper.GetMemberAge(e.Result.Member);

                Message1 = $"WEJŚCIE: {e.Result.Member.FirstName} {e.Result.Member.LastName} [{e.Result.Member.Id}]" +
                           (age.HasValue ? $" [{age} LATA]" : string.Empty);
                Message2 = $"NUMER KLUCZYKA: {e.Result.CabinetKey?.Name}";
                Message3 =
                    $"KARNET '{e.Result.PassRegistry?.Pass.Name}' WAŻNY DO: {e.Result.PassRegistry?.EndDate:dd-MM-yyyy}";
                Message3 =
                    $"OSTATNI KARNET '{e.Result.EndOfPassRegistry?.Pass.Name}' WAŻNY DO: {e.Result.EndOfPassRegistry?.EndDate:dd-MM-yyyy}";

                new Audio().Play("beep", "entry");
            }
            else if(e.Result.Message == IdentifierMessage.AccessExit)
            {
                EntryOK = Visibility.Hidden;
                ExitOK = Visibility.Visible;
                EntryStop = Visibility.Hidden;

                Message1 = $"WYJŚCIE: {e.Result.Member.FirstName} {e.Result.Member.LastName} [{e.Result.Member.Id}]";
                Message2 = $"NUMER KLUCZYKA: {e.Result.CabinetKey?.Name}";
                Message3 = $"CZAS POBYTU: {EntityMethodsHelper.GetHourFromMinutes(e.Result.EntryRegistry.VisitTime)}";
                Message4 =
                    $"OSTATNI KARNET '{e.Result.EndOfPassRegistry.Pass.Name}' WAŻNY DO: {e.Result.EndOfPassRegistry.EndDate:dd-MM-yyyy}";
            }
            else
            {
                EntryOK = Visibility.Hidden;
                ExitOK = Visibility.Hidden;
                EntryStop = Visibility.Visible;

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
                        ? $"KARNET ZAWIESZONO DO DNIA: {e.Result.PassRegistry.EndSuspensionDate:dd-MM-yyyy}"
                        : "BRAK KARNETU";
                }
                else if(e.Result.Message == IdentifierMessage.UnknowError)
                {
                    Message1 = "BRAK DOSTĘPU";
                    Message2 = "NIEZNANY BŁĄD";
                    Message3 = "";
                    Message4 = "";
                }
            }

            if(e.Result.Member != null)
            {
                MemberPhoto = _model.GetPhoto(e.Result.Member.MemberID);
            }

            OnPropertyChange(nameof(LastEntryRegistry));
            OnPropertyChange(nameof(EntryStop));
            OnPropertyChange(nameof(EntryOK));
            OnPropertyChange(nameof(ExitOK));
            OnPropertyChange(nameof(MemberPhoto));
            OnPropertyChange(nameof(Message1));
            OnPropertyChange(nameof(Message2));
            OnPropertyChange(nameof(Message3));
            OnPropertyChange(nameof(Message4));
        }

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}