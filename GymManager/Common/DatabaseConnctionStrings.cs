using System;

namespace GymManager.Common;

public static class DatabaseConnctionStrings
{
    public static string ConnectionString(DatabaseTypes databaseTypes)
    {
        return databaseTypes switch
        {
            DatabaseTypes.Memory => "GymManager",
            DatabaseTypes.SqlServer => Settings.App.Databases.SqlServer.Trusted
                ? $"Server={Settings.App.Databases.SqlServer.Server};Database={Settings.App.Databases.SqlServer.Name};Trusted_Connection=True;MultipleActiveResultSets=True;"
                : $"Server={Settings.App.Databases.SqlServer.Server};Database={Settings.App.Databases.SqlServer.Name};User Id={Settings.App.Databases.SqlServer.UserId};Password={Settings.App.Databases.SqlServer.Password};",
            DatabaseTypes.Sqlite =>
                $"Data Source={Settings.App.Databases.Sqlite.Directory}\\{Settings.App.Databases.Sqlite.FileName};",
            DatabaseTypes.PostgreSql =>
                $"Server={Settings.App.Databases.PostgreSql.Server};Port= {Settings.App.Databases.PostgreSql.PortNumber};Database= {Settings.App.Databases.PostgreSql.Name};User Id={Settings.App.Databases.PostgreSql.UserId};Password={Settings.App.Databases.PostgreSql.Password};",
            DatabaseTypes.MySql =>
                $"Server={Settings.App.Databases.MySql.Server};Port={Settings.App.Databases.MySql.PortNumber};Database={Settings.App.Databases.MySql.Name};Uid={Settings.App.Databases.MySql.UserId};Pwd={Settings.App.Databases.MySql.Password};",
            _ => throw new Exception("")
        };
    }
}