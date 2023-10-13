using GymManager.Common;

namespace GymManager.DbModels.Engines
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