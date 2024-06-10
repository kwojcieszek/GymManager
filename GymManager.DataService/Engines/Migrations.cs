using GymManager.DataService.Common;

namespace GymManager.DataService.Engines
{
    public static class Migrations
    {
        public static void Migration(DatabaseTypes databaseTypes)
        {
            switch(databaseTypes)
            {
                case DatabaseTypes.Memory:
                    new MemoryContext().Migrate();

                    break;
                case DatabaseTypes.SqlServer:
                    new SqlServerContext().Migrate();

                    break;
                case DatabaseTypes.Sqlite:
                    new SqliteContext().Migrate();

                    break;
                case DatabaseTypes.PostgreSql:
                    new PostgreSqlContext().Migrate();

                    break;
                case DatabaseTypes.MySql:
                    new MySqlContext().Migrate();

                    break;
            }

            ;
        }
    }
}