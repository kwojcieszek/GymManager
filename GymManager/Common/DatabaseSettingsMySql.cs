namespace GymManager.Common
{
    public class DatabaseSettingsMySql
    {
        public string Name { get; set; } = "GymManager";
        public string Password { get; set; } = string.Empty;
        public int PortNumber { get; set; } = 3306;
        public string Server { get; set; } = "localhost";
        public string UserId { get; set; } = "root";
    }
}