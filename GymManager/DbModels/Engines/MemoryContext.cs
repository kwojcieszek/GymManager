using GymManager.Common;

namespace GymManager.DbModels.Engines
{
    public class MemoryContext : GymManagerContext
    {
        public MemoryContext() : base(DatabaseTypes.Memory) { }

        public override void Migrate()
        {
            base.Migrate();
        }
    }
}