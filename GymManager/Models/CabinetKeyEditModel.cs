﻿using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Common;
using GymManager.DataModel.Models;
using GymManager.DataService;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class CabinetKeyEditModel
    {
        private readonly GymManagerContext _db = new();
        public CabinetKey CabinetKey { get; private set; }
        public List<Gender> Genders => _db.Genders.OrderBy(p => p.GenderID).ToList();

        public void SaveChanges()
        {
            _db.SaveChanges<CabinetKey>();
        }

        public CabinetKey SetEditObject(int cabinetKeyID)
        {
            if(CabinetKey != null)
            {
                throw new Exception("Object is exist!");
            }

            CabinetKey = _db.CabinetKeys
                .Where(c => c.CabinetKeyID == cabinetKeyID)
                .Include(g => g.Gender)
                .FirstOrDefault();

            CabinetKey.DateModified = DateTime.Now;
            CabinetKey.ModifiedBy = CurrentUser.User.UserID;

            return CabinetKey;
        }

        public CabinetKey SetNewObject()
        {
            if(CabinetKey != null)
            {
                throw new Exception("The object exists!");
            }

            CabinetKey = new CabinetKey
            {
                DateAdded = DateTime.Now,
                AddedBy = CurrentUser.User.UserID
            };

            _db.Add(CabinetKey);

            return CabinetKey;
        }
    }
}