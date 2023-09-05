using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace GymManager.Common
{
    public class CameraService
    {
        public string MyPicturesLibraryFileName
        {
            set => _fullPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\\{value}";
        }

        public string PathExecute { get; set; }
        private string _fullPath;

        public byte[] Start()
        {
            CleanData();

            var process = Process.Start(PathExecute);

            process?.WaitForExit(1000 * 60);

            var data = GetData();

            Task.Factory.StartNew(CleanData);

            return data;
        }

        private void CleanData()
        {
            try
            {
                File.Delete(_fullPath);
            }
            catch
            {
            }
        }

        private byte[] GetData()
        {
            try
            {
                return File.ReadAllBytes(_fullPath);
            }
            catch
            {
                return null;
            }
        }
    }
}