namespace GymManager.Common
{
    public class DatabaseSettingsPostgreSql
    {
        public string Name { get; set; } = "GymManager";
        public string Password { get; set; } = string.Empty;
        public int PortNumber { get; set; } = 5432;
        public string Server { get; set; } = "localhost";
        public bool SSL { get; set; } = true;
        public string UserId { get; set; } = "postgres";
    }
}