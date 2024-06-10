using GymManager.DataService.Common;

namespace GymManager.DataService.Engines
{
    public class PostgreSqlContext : GymManagerContext
    {
        public PostgreSqlContext() : base(DatabaseTypes.PostgreSql) { }

        public override void Migrate()
        {
            base.Migrate();
        }
    }
}