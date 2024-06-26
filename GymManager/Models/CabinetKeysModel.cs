﻿using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.DataModel.Models;
using GymManager.DataService;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class CabinetKeysModel
    {
        private List<CabinetKey> _cabinetKeys;

        public List<CabinetKey> CabinetKeys
        {
            get
            {
                if(_cabinetKeys == null)
                {
                    GetCabinetKeys(OnlyActives);
                }

                return _cabinetKeys.ToList();
            }
        }

        public bool OnlyActives { get; set; } = true;

        public void Delete(CabinetKey cabinetKey)
        {
            if(cabinetKey == null)
            {
                throw new ArgumentNullException("Element do usunięcia jest pusty.");
            }

            var db = new GymManagerContext();

            db.CabinetKeys.Remove(cabinetKey);

            db.SaveChanges<CabinetKey>();
        }

        public List<CabinetKey> GetCabinetKeys(bool onlyActives)
        {
            _cabinetKeys = new GymManagerContext()
                .CabinetKeys
                .Include(g => g.Gender)
                .Where(m => m.IsAcive == true || m.IsAcive == onlyActives)
                .ToList();

            return _cabinetKeys;
        }
    }
}