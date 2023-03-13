using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using GymManager.Common;

namespace GymManager.Models
{
    public class StartModel
    {
        public event EventHandler<string> JobDescriptionChanged;
        public event EventHandler<Result> JobFinished;
        private string _jobDescription;
        private readonly List<StartJob> _jobs = new();

        public bool IsExistSettingsFile => Settings.App.IsExistSettingsFile;

        public bool IsRunning { get; set; } = true;

        public string JobDescription
        {
            get => _jobDescription;
            private set
            {
                _jobDescription = value;

                JobDescriptionChanged?.Invoke(this, _jobDescription);
            }
        }

        public void StartJobs()
        {
            try
            {
                foreach (var job in _jobs)
                {
                    JobDescription = job.Description;

                    job.Action();
                }

                JobFinished?.Invoke(this, new Result(Results.OK));
            }
            catch (DatabaseTestException ex)
            {
                JobFinished?.Invoke(this, new Result(Results.DatabaseConnectionError, ex.Message));
            }
            catch (Exception ex)
            {
                JobFinished?.Invoke(this, new Result(Results.OtherError, ex.Message));
            }
        }

        private void JobCloseRegistry()
        {
            new IdentifiersService().CloseRegistry(Settings.App.TimeToCloseEntranceMembersMinutes);
        }

        private void JobCulture()
        {
            var newCulture = new CultureInfo("pl-PL");

            newCulture.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";

            CultureInfo.DefaultThreadCurrentCulture = newCulture;
            CultureInfo.DefaultThreadCurrentUICulture = newCulture;

            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            Thread.CurrentThread.CurrentCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
        }

        private void JobDatabase()
        {
            try
            {
                DbModels.Engines.Migrations.Migration(Settings.App.Databases.DatabaseType);
            }
            catch (Exception exp)
            {
                throw new DatabaseTestException(exp);
            }
        }

        private void JobIdentifierService()
        {
            var identifierServiceInstances = new IdentifierServiceInstances();

            if (Settings.App.IdentifierDevice == IdentifierDevices.RFIDSerialPort)
            {
                var identifierService = IdentifierServiceBuilder.CreateFromRFIDSerialPort(Settings.App.RFIDSerialPort,
                    Settings.App.RfidReader.RfidReaderConverterType, Settings.App.RfidReader.SuffixCRLF,
                    Settings.App.RfidReader.MaxLenghtData, Settings.App.RfidReader.Endianness);

                identifierServiceInstances.Add(identifierService, "main");

                identifierServiceInstances.GetIdentifierService("main").Start();
            }
        }

        private void JobSettings()
        {
            SettingsConfiguration.Set();

            Path.ClearTemporaryFiles();
        }

        public StartModel()
        {
            _jobs.Add(new StartJob(JobSettings, "Wczytywanie ustawień programu"));
            _jobs.Add(new StartJob(JobIdentifierService, "Konfigurowanie urządzeń"));
            _jobs.Add(new StartJob(JobCulture, "Wczytywanie ustawień regionalnych"));
            _jobs.Add(new StartJob(JobDatabase, "Konfigurowanie bazy danych"));
            _jobs.Add(new StartJob(JobCloseRegistry, "Konfigurowanie zadań"));
        }
    }
}