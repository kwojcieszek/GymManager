using GymManager.DataService.Common;

namespace GymManager.DataService.Engines
{
    public class SqlServerContext : GymManagerContext
    {
        public SqlServerContext() : base(DatabaseTypes.SqlServer) { }

        public override void Migrate()
        {
            base.Migrate();
        }
    }
}