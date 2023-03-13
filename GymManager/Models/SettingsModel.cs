using System.Collections.Generic;
using System.Linq;
using GodSharp.SerialPort;
using GymManager.Common;

namespace GymManager.Models
{
    public class SettingsModel
    {
        public Settings AppSettings => Settings.App;
        public List<int> BaudRates => new() { 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200 };
        public List<string> PortNames => GodSerialPort.GetPortNames().ToList();

        public void Restore()
        {
            Settings.Read();
        }

        public void Save()
        {
            Settings.Write();

            SettingsConfiguration.Set();
        }
    }
}