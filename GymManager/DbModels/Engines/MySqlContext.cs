using GymManager.Common;

namespace GymManager.DbModels.Engines
{
    public class MySqlContext : GymManagerContext
    {
        public override void Migrate()
        {
            base.Migrate();
        }

        public MySqlContext() : base(DatabaseTypes.MySql)
        {
        }
    }
}