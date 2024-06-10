using GymManager.DataModel.Models;
using GymManager.DataService;

namespace GymManager.Common
{
    public static class SettingsConfiguration
    {
        public static void Set()
        {
            GymManagerContext.DefaultDatabaseType = Settings.App.Databases.DatabaseType;

            PdfFromHtml.DefaultAdobeApplicationPath = Settings.App.Reports.AdobeApplicationPath;

            IdentifiersService.DefaultCabinetKeyMode = Settings.App.CabinetkeysAlgorithm;

            EntryService.DefaultIdentifierDevices = Settings.App.IdentifierDevice;
        }
    }
}