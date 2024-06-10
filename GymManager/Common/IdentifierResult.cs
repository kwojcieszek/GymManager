using GymManager.DataModel.Models;

namespace GymManager.Common
{
    public class IdentifierResult
    {
        public CabinetKey CabinetKey { get; set; }
        public PassRegistry EndOfPassRegistry { get; set; }
        public EntryRegistry EntryRegistry { get; set; }
        public Member Member { get; set; }
        public IdentifierMessage Message { get; set; }
        public PassRegistry PassRegistry { get; set; }

        public IdentifierResult(IdentifierMessage message, EntryRegistry entryRegistry, Member member,
            PassRegistry passRegistry, CabinetKey cabinetKey, PassRegistry endOfPassRegistry)
        {
            Message = message;
            EntryRegistry = entryRegistry;
            Member = member;
            PassRegistry = passRegistry;
            CabinetKey = cabinetKey;
            EndOfPassRegistry = endOfPassRegistry;
        }
    }
}