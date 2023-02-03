namespace GymManager.Common;

public class DatabasesSettings
{
    public DatabaseTypes DatabaseType { get; set; } = DatabaseTypes.SqlServer;
    public DatabaseSettingsMySql MySql { get; set; } = new();
    public DatabaseSettingsPostgreSql PostgreSql { get; set; } = new();
    public DatabaseSettingsSqlite Sqlite { get; set; } = new();
    public DatabaseSettingsSqlServer SqlServer { get; set; } = new();
}