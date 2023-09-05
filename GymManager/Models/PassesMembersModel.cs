using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Common.Extensions;
using GymManager.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class PassesMembersModel
    {
        public List<PassRegistry> PassRegistry
        {
            get
            {
                if(_passRegistry == null)
                {
                    GetPassRegistry();
                }

                return _passRegistry.ToList();
            }
        }

        private List<PassRegistry> _passRegistry;

        public void Delete(PassRegistry pass)
        {
            if(pass == null)
            {
                throw new Exception("Element do usunięcia jest pusty.");
            }

            var db = new GymManagerContext();

            db.PassesRegistry.Remove(pass);

            db.SaveChanges<PassRegistry>();
        }

        public List<PassRegistry> GetPassRegistry(DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            if(dateFrom == null || dateTo == null)
            {
                _passRegistry = new GymManagerContext()
                    .PassesRegistry
                    .Include(m => m.Member)
                    .Include(p => p.Pass)
                    .Include(a => a.AddedByUser)
                    .Include(m => m.ModifiedByUser)
                    .ToList();
            }
            else
            {
                dateFrom = dateFrom.Value.AbsoluteStart();
                dateTo = dateTo.Value.AbsoluteEnd();

                _passRegistry = new GymManagerContext()
                    .PassesRegistry
                    .Where(pr => pr.DateAdded >= dateFrom && pr.DateAdded <= dateTo)
                    .Include(m => m.Member)
                    .Include(p => p.Pass)
                    .Include(a => a.AddedByUser)
                    .Include(m => m.ModifiedByUser)
                    .OrderByDescending(o => o.PassRegistryID)
                    .ToList();
            }

            return _passRegistry;
        }
    }
}