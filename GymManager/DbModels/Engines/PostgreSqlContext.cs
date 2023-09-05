using GymManager.Common;

namespace GymManager.DbModels.Engines
{
    public class PostgreSqlContext : GymManagerContext
    {
        public PostgreSqlContext() : base(DatabaseTypes.PostgreSql)
        {
        }

        public override void Migrate()
        {
            base.Migrate();
        }
    }
}