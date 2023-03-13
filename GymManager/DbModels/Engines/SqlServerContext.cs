using GymManager.Common;

namespace GymManager.DbModels.Engines
{
    public class SqlServerContext : GymManagerContext
    {
        public override void Migrate()
        {
            base.Migrate();
        }

        public SqlServerContext() : base(DatabaseTypes.SqlServer)
        {
        }
    }
}