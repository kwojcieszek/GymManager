using GymManager.DataService.Common;

namespace GymManager.DataService.Engines
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