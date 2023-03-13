using GymManager.Common;

namespace GymManager.Models
{
    public class DatabaseSettingsModel
    {
        public DatabasesSettings DatabaseSettings => Settings.App.Databases;

        public void Restore()
        {
            Settings.Read();
        }

        public void Save()
        {
            Settings.Write();
        }
    }
}