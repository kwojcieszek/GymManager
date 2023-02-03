using GymManager.Common;

namespace GymManager.DbModels.Engines;

public class MySqlContext : GymManagerContext
{
    public MySqlContext() : base(DatabaseTypes.MySql)
    {
    }

    public override void Migrate()
    {
        base.Migrate();
    }
}