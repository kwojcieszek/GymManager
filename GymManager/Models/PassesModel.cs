﻿using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.DataModel.Models;
using GymManager.DataService;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class PassesModel
    {
        private List<Pass> _passes;
        public bool OnlyActives { get; set; } = true;

        public List<Pass> Passes => _passes ?? GetPasses(OnlyActives);

        public void Delete(Pass pass)
        {
            if(pass == null)
            {
                throw new ArgumentNullException("Element do usunięcia jest pusty.");
            }

            if(_passes == null)
            {
                throw new ArgumentNullException("Źródło danych ma pustą wartość.");
            }

            var db = new GymManagerContext();

            db.Passes.Remove(pass);

            db.SaveChanges<Pass>();
        }

        public List<Pass> GetPasses(bool onlyActives)
        {
            _passes = new GymManagerContext()
                .Passes
                .Where(m => m.IsAcive == true || m.IsAcive == onlyActives)
                .Include(t => t.Tax)
                .Include(p => p.PassTime)
                .Include(a => a.AddedByUser)
                .Include(m => m.ModifiedByUser).ToList();

            return _passes;
        }
    }
}