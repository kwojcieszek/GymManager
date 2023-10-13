using GymManager.Common;

namespace GymManager.DbModels.Engines
{
    public class SqliteContext : GymManagerContext
    {
        public SqliteContext() : base(DatabaseTypes.Sqlite) { }

        public override void Migrate()
        {
            base.Migrate();
        }
    }
}