using System.Collections.Generic;
using System.Linq;
using GymManager.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class CabinetKeysAvailableModel
    {
        private List<CabinetKey> _cabinetKeys;

        public List<CabinetKey> CabinetKeys
        {
            get
            {
                if (_cabinetKeys == null)
                {
                    GetCabinetKeys(OnlyActives);
                }

                return _cabinetKeys.ToList();
            }
        }

        public bool OnlyActives { get; set; } = true;

        public List<CabinetKey> GetCabinetKeys(bool onlyActives)
        {
            var db = new GymManagerContext();

            var keys = db.EntriesRegistry
                .Where(er => er.IsAcive && er.CabinetKeyID.HasValue)
                .Select(s => s.CabinetKeyID);

            _cabinetKeys = db.CabinetKeys
                .Include(g => g.Gender)
                .Where(c => (c.IsAcive == true || c.IsAcive == onlyActives) && !keys.Contains(c.CabinetKeyID))
                .ToList();

            return _cabinetKeys;
        }
    }
}