using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Common;
using GymManager.DbModels;

namespace GymManager.Models
{
    public class PassEditModel
    {
        private readonly GymManagerContext _db = new();
        public Pass Pass { get; private set; }
        public List<PassTime> PassTimes => _db.PassTimes.OrderBy(p => p.PassTimeID).ToList();

        public List<Tax> Taxes => _db.Taxes.OrderBy(p => p.TaxID).ToList();

        public void CalculatePriceFromBrutto(Pass pass)
        {
            if (pass == null || pass.Tax == null)
            {
                return;
            }

            var rate = pass.Tax.Rate;

            pass.NetPrice = Math.Round(pass.Price / (1M + rate / 100M), 2);

            pass.EntryNetPrice = Math.Round(pass.EntryPrice / (1M + rate / 100M), 2);
        }

        public void SaveChanges()
        {
            CalculatePriceFromBrutto(Pass);

            _db.SaveChanges<Pass>();
        }

        public Pass SetEditObject(int passID)
        {
            if (Pass != null)
            {
                throw new Exception("Object is exist!");
            }

            Pass = _db.Passes
                .Where(p => p.PassID == passID)
                .FirstOrDefault();

            Pass.DateModified = DateTime.Now;
            Pass.ModifiedBy = CurrentUser.User.UserID;

            return Pass;
        }

        public Pass SetNewObject()
        {
            if (Pass != null)
            {
                throw new Exception("Object is exist!");
            }

            Pass = new Pass
            {
                DateAdded = DateTime.Now,
                AddedBy = CurrentUser.User.UserID
            };

            _db.Add(Pass);

            return Pass;
        }
    }
}