using System.Linq;
using GymManager.Common;
using GymManager.DataModel.Models;
using GymManager.DataService;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class EntryMessageModel
    {
        public IdentifierResult IdentifierResult => IdentifiersService.LastIdentifierResult;

        public EntryRegistry LastEntryRegistry =>
            new GymManagerContext()
                .EntriesRegistry
                .Include(m => m.Member)
                .Include(c => c.CabinetKey)
                .Include(p => p.Pass)
                .OrderByDescending(r => r.EntryDate)
                .Take(1).FirstOrDefault();

        public int NumersOfPeopeInGym =>
            new GymManagerContext()
                .EntriesRegistry
                .Count(r => r.IsAcive);

        public byte[] GetPhoto(int memberID)
        {
            var photo = new GymManagerContext()
                .Photos
                .FirstOrDefault(m => m.MemberID == memberID);

            return photo != null ? photo.Data : new byte[] { };
        }
    }
}