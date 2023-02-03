using System.ComponentModel.DataAnnotations;

namespace GymManager.Common;

public enum IdentifierDevices
{
    [Display(Name = "BRAK")]
    None = 0,

    [Display(Name = "RFID NA PORCIE SZEREGOWYM [EMULACJA PORTU]")]
    RFIDSerialPort = 1
}