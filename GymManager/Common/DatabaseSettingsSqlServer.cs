namespace GymManager.Common
{
    public class DatabaseSettingsSqlServer
    {
        public string Name { get; set; } = "GymManager";
        public string Password { get; set; } = string.Empty;
        public string Server { get; set; } = "localhost";
        public bool Trusted { get; set; } = true;
        public string UserId { get; set; } = string.Empty;
    }
}