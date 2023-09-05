using System;
using System.IO;
using System.Reflection;

namespace GymManager.Common
{
    public static class Path
    {
        public static string ApplicationData => $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\GymManager";

        public static string ApplicationDirectory => System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string ApplicationTempData => $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\GymManager\\Temp";

        static Path()
        {
            if(!Directory.Exists(ApplicationDirectory))
            {
                Directory.CreateDirectory(ApplicationDirectory);
            }

            if(!Directory.Exists(ApplicationTempData))
            {
                Directory.CreateDirectory(ApplicationTempData);
            }
        }

        public static void ClearTemporaryFiles()
        {
            foreach(var file in Directory.GetFiles(ApplicationTempData))
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {
                }
            }
        }
    }
}