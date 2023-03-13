using System;
using System.IO;
using Newtonsoft.Json;

namespace GymManager.Common
{
    public partial class Settings
    {
        public event EventHandler SettingsChanged;
        private static readonly string filePath = $"{Path.ApplicationData}\\settings.db";
        private static Settings instance;

        public static Settings App => instance ??= new Settings();

        [JsonIgnore]
        public bool IsExistSettingsFile => File.Exists(filePath);

        public static void Read()
        {
            var settingsJson = ReadFile();

            if (settingsJson == null)
            {
                return;
            }

            settingsJson = Cryptography.XorEncryptDecrypt(settingsJson, KEY);

            var settings = JsonConvert.DeserializeObject<Settings>(settingsJson);

            if (settings == null)
            {
                return;
            }

            instance = settings;
        }

        public static void Write()
        {
            var settingsJson = JsonConvert.SerializeObject(instance);

            settingsJson = Cryptography.XorEncryptDecrypt(settingsJson, KEY);

            WriteFile(settingsJson);

            App.SettingsChanged?.Invoke(App, EventArgs.Empty);
        }

        private static string ReadFile()
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            return File.ReadAllText(filePath);
        }

        private static void WriteFile(string source)
        {
            var direcotry = System.IO.Path.GetDirectoryName(filePath);

            if (!Directory.Exists(direcotry))
            {
                Directory.CreateDirectory(direcotry);
            }

            File.WriteAllText(filePath, source);
        }

        [JsonIgnore]
        private const int KEY = 734798442;

        private Settings()
        {
        }
    }
}