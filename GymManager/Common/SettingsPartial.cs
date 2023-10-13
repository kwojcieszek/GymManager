using System;
using System.IO;
using Newtonsoft.Json;

namespace GymManager.Common
{
    public partial class Settings
    {
        public event EventHandler SettingsChanged;

        public static Settings App => _instance ??= new Settings();
        private static Settings _instance;
        private static readonly string FilePath = $"{Path.ApplicationData}\\settings.db";

        [JsonIgnore]
        private const int KEY = 734798442;

        [JsonIgnore]
        public bool IsExistSettingsFile => File.Exists(FilePath);

        private Settings() { }

        public static void Read()
        {
            var settingsJson = ReadFile();

            if(settingsJson == null)
            {
                return;
            }

            settingsJson = Cryptography.XorEncryptDecrypt(settingsJson, KEY);

            var settings = JsonConvert.DeserializeObject<Settings>(settingsJson);

            if(settings == null)
            {
                return;
            }

            _instance = settings;
        }

        public static void Write()
        {
            var settingsJson = JsonConvert.SerializeObject(_instance);

            settingsJson = Cryptography.XorEncryptDecrypt(settingsJson, KEY);

            WriteFile(settingsJson);

            App.SettingsChanged?.Invoke(App, EventArgs.Empty);
        }

        private static string ReadFile()
        {
            if(!File.Exists(FilePath))
            {
                return null;
            }

            return File.ReadAllText(FilePath);
        }

        private static void WriteFile(string source)
        {
            var direcotry = System.IO.Path.GetDirectoryName(FilePath);

            if(direcotry != null && !Directory.Exists(direcotry))
            {
                Directory.CreateDirectory(direcotry);
            }

            File.WriteAllText(FilePath, source);
        }
    }
}