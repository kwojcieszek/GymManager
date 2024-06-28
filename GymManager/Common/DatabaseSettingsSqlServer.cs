namespace GymManager.Common
{
    public class DatabaseSettingsSqlServer
    {
        public string Name { get; set; } = "GymManager";
        public string Password { get; set; }
        public string Server { get; set; } = "localhost";
        public bool Trusted { get; set; } = true;
        public string UserId { get; set; }
    }
}