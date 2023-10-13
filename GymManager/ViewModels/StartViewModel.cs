using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using GymManager.Common;
using GymManager.Models;
using GymManager.Views;

namespace GymManager.ViewModels
{
    public class StartViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ClosingCommand =>
            _closingCommand ??= new RelayCommand(
                x => { _model.IsRunning = false; });

        public ICommand ContentRenderedCommand =>
            _contentRenderedCommand ??= new RelayCommand(
                x =>
                {
                    if(_model.IsExistSettingsFile)
                    {
                        Start();
                    }
                    else
                    {
                        Start(true);
                    }
                });

        public string JobDescription { get; private set; }
        public string PathGif => $"{Path.ApplicationDirectory}\\Images\\Waiting_circle.gif";
        public string Title => "GYM MANGER";

        public Window Window => Helper.GetWindow(this);
        private ICommand _closingCommand;
        private ICommand _contentRenderedCommand;
        private readonly StartModel _model = new();
        private DispatcherTimer _timerStartDatabasesSettings;
        private DispatcherTimer _timerStartMain;

        public StartViewModel()
        {
            _model.JobDescriptionChanged += (sender, e) =>
            {
                JobDescription = e;

                OnPropertyChange(nameof(JobDescription));
            };

            _model.JobFinished += (sender, e) =>
            {
                if(e.ResultValue != Results.OK && e.ResultValue == Results.OtherError)
                {
                    Task.Factory.StartNew(() =>
                    {
                        for(var i = 0; i < 5; i++)
                        {
                            JobDescription =
                                $"START SYSTEMU ZAKOŃCZONY NIEPOWODZENIEM\nAPLIKACJA ZAKOŃCZY PRACĘ ZA {5 - i} SEKUND";

                            OnPropertyChange(nameof(JobDescription));

                            Task.Delay(1000).Wait();
                        }

                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                        {
                            Window.Close();

                            Application.Current.Shutdown();
                        }));
                    });
                }
                else if(e.ResultValue != Results.OK && e.ResultValue == Results.DatabaseConnectionError)
                {
                    Task.Factory.StartNew(() =>
                    {
                        JobDescription = e.ExceptionMessage;

                        OnPropertyChange(nameof(JobDescription));

                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                            new ThreadStart(delegate { _timerStartDatabasesSettings.Start(); }));
                    });
                }
                else if(e.ResultValue == Results.OK)
                {
                    _timerStartMain.Start();
                }
            };
        }

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Start(bool databasesSettings = false)
        {
            if(!databasesSettings)
            {
                Task.Factory.StartNew(() => _model.StartJobs());
            }

            _timerStartMain = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 10)
            };

            _timerStartMain.Tick += (o, e) => StartMainWiwndow();

            _timerStartDatabasesSettings = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 10)
            };

            _timerStartDatabasesSettings.Tick += (o, e) => StartDatabasesSettingsWiwndow();

            if(databasesSettings)
            {
                _timerStartDatabasesSettings.Start();
            }
        }

        private void StartDatabasesSettingsWiwndow()
        {
            _timerStartDatabasesSettings.Stop();

            var view = new DatabasesSettingsView();
            var model = view.DataContext as DatabasesSettingsViewModel;
            model.Owner = Window;
            var result = view.ShowDialog();

            if(result.HasValue && result.Value)
            {
                Start();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        private void StartMainWiwndow()
        {
            _timerStartMain.Stop();

            Helper.Invoke(() => Window.Hide());

            new MangerView().Show();
        }
    }
}