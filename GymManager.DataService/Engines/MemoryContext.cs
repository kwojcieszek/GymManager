using GymManager.DataService.Common;

namespace GymManager.DataService.Engines
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