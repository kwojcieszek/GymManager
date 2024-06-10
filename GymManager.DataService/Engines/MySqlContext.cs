using GymManager.DataService.Common;

namespace GymManager.DataService.Engines
{
    public class MySqlContext : GymManagerContext
    {
        public MySqlContext() : base(DatabaseTypes.MySql) { }

        public override void Migrate()
        {
            base.Migrate();
        }
    }
}