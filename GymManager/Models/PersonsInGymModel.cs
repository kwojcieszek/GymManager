using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Common;
using GymManager.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class PersonsInGymModel
    {
        private List<EntryRegistry> _entriesRegistry;

        public List<EntryRegistry> EntriesRegistry
        {
            get
            {
                if(_entriesRegistry == null)
                {
                    GetEntriesRegistry();
                }

                return _entriesRegistry;
            }
        }

        public void ChangeCabinetKey(EntryRegistry entryRegistry, CabinetKey cabinetKey)
        {
            new IdentifiersService().ChangeCabinetKey(entryRegistry, cabinetKey);
        }

        public void CloseRow(EntryRegistry entryRegistry)
        {
            if(entryRegistry == null)
            {
                throw new ArgumentNullException("Element do usunięcia jest pusty.");
            }

            var db = new GymManagerContext();

            entryRegistry.IsAcive = false;

            db.EntriesRegistry.Remove(entryRegistry);

            db.SaveChanges();
        }

        public List<EntryRegistry> GetEntriesRegistry()
        {
            _entriesRegistry = new GymManagerContext()
                .EntriesRegistry
                .Where(e => e.IsAcive)
                .Include(m => m.Member)
                .Include(c => c.CabinetKey)
                .Include(p => p.Pass)
                .ToList();

            return _entriesRegistry;
        }
    }
}