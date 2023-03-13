namespace GymManager.Common
{
    public partial class Settings
    {
        public CabinetKeyMode CabinetkeysAlgorithm { get; set; } = CabinetKeyMode.InLoop;
        public DatabasesSettings Databases { get; set; } = new();
        public IdentifierDevices IdentifierDevice { get; set; } = IdentifierDevices.None;
        public string LogoImagePath { get; set; } = null;
        public int MaximumDaysSubscriptionSuspension { get; set; } = 20;
        public Reports Reports { get; set; } = new();
        public RfidReader RfidReader { get; set; } = new();
        public SerialPortSettings RFIDSerialPort { get; set; } = new();
        public bool SendMessagesFromThisComputer { get; set; } = true;
        public int TimeToCloseEntranceMembersMinutes { get; set; } = 300;
    }
}