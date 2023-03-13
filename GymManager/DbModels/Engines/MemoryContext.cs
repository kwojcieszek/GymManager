using GymManager.Common;

namespace GymManager.DbModels.Engines
{
    public class MemoryContext : GymManagerContext
    {
        public override void Migrate()
        {
            base.Migrate();
        }

        public MemoryContext() : base(DatabaseTypes.Memory)
        {
        }
    }
}