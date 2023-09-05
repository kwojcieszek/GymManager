using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Common.Extensions;
using GymManager.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class EntriesRegistryModel
    {
        public List<EntryRegistry> EntriesRegistry
        {
            get
            {
                if(_entriesRegistry == null)
                {
                    GetEntriesRegistry();
                }

                return _entriesRegistry.ToList();
            }
        }

        private List<EntryRegistry> _entriesRegistry;

        public List<EntryRegistry> GetEntriesRegistry(DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            if(dateFrom == null || dateTo == null)
            {
                _entriesRegistry = new GymManagerContext()
                    .EntriesRegistry
                    .Include(m => m.Member)
                    .Include(c => c.CabinetKey)
                    .Include(p => p.Pass)
                    .ToList();
            }
            else
            {
                dateFrom = dateFrom.Value.AbsoluteStart();
                dateTo = dateTo.Value.AbsoluteEnd();

                _entriesRegistry = new GymManagerContext()
                    .EntriesRegistry
                    .Where(pr => pr.EntryDate >= dateFrom && pr.EntryDate <= dateTo)
                    .Include(m => m.Member)
                    .Include(c => c.CabinetKey)
                    .Include(p => p.Pass)
                    .ToList();
            }

            return _entriesRegistry;
        }
    }
}