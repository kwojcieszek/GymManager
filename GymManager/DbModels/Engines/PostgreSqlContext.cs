using GymManager.Common;

namespace GymManager.DbModels.Engines
{
    public class PostgreSqlContext : GymManagerContext
    {
        public override void Migrate()
        {
            base.Migrate();
        }

        public PostgreSqlContext() : base(DatabaseTypes.PostgreSql)
        {
        }
    }
}