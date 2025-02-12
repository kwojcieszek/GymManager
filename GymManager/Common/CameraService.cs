using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace GymManager.Common
{
    public class CameraService
    {
        public event EventHandler<byte[]> OnDataReceived;
        public bool IsRunning { get; private set; }
        private bool _isStop;
        private string _fullPath;
        private Process _process;

        public string MyPicturesLibraryFileName
        {
            set => _fullPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\\{value}";
        }

        public string PathExecute { get; set; }

        public void Start()
        {
            _isStop = false;

            CleanData();

            _process = Process.Start(PathExecute);

            Task.Factory.StartNew(StartMonitoring);

            IsRunning = true;
        }

        public void ReStart()
        {
            Stop();

            Task.Delay(200).Wait();

            Start();
        }

        public void Stop()
        {
            _isStop = true;
        }

        private void StartMonitoring()
        {
            while(!_isStop)
            {
                Task.Delay(100).Wait();

                var data = GetData();

                if (data.Length > 0)
                {
                    OnDataReceived?.Invoke(this, data);

                    Task.Factory.StartNew(CleanData);

                    _isStop = true;

                    IsRunning = false;
                }
                else if(_process.HasExited)
                {
                    _isStop = true;

                    IsRunning = false;
                }
            }

            try
            {
                _process?.Kill();
            }
            catch
            {
                // ignored
            }
        }

        private void CleanData()
        {
            try
            {
                File.Delete(_fullPath);
            }
            catch { }
        }

        private byte[] GetData()
        {
            try
            {
                return File.ReadAllBytes(_fullPath);
            }
            catch
            {
                return [];
            }
        }
    }
}