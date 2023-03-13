using GymManager.Common;

namespace GymManager.DbModels.Engines
{
    public class SqliteContext : GymManagerContext
    {
        public override void Migrate()
        {
            base.Migrate();
        }

        public SqliteContext() : base(DatabaseTypes.Sqlite)
        {
        }
    }
}