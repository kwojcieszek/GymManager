using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Common;
using GymManager.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class PassesMembersEditModel
    {
        private readonly GymManagerContext _db = new();
        public List<Pass> Passes => _db.Passes.ToList();
        public PassRegistry PassRegistry { get; private set; }

        public string GetContinuationText()
        {
            var member = PassRegistry?.Member;

            if (member == null)
            {
                return string.Empty;
            }

            var continuation = PassesHelper.ContinuousPass(member.MemberID, PassRegistry.StartDate);

            if (continuation > 0)
            {
                return continuation == 1 ? $"{continuation} MIESIĄC" : $"{continuation} MIESIĄCE";
            }

            return "BRAK KONTYNUACJI";
        }

        public string GetLastPassText()
        {
            var member = PassRegistry?.Member;

            if (member == null)
            {
                return string.Empty;
            }

            var pass = PassesHelper.GetLastPassRegistry(member.MemberID);

            var summaryOfDaysSubscriptionSuspension =
                PassesHelper.GetSummaryOfDaysSubscriptionSuspension(member.MemberID, DateTime.Now.Year, 0);

            if (pass == null)
            {
                return string.Empty;
            }

            return
                $"OSTATNI KARNET: {pass.Pass.Name} ID: {pass.PassRegistryID}\nWYDANY W DNIU: {pass.DateAdded:D}\nWAŻNY OD: {pass.StartDate:D}\nWAŻNY DO: {pass.EndDate:D}\nILOŚĆ DNI ZAWIESZENIA KARNETU: {summaryOfDaysSubscriptionSuspension}";
        }

        public Member GetMember(string IdentifierKey)
        {
            var identifier = _db.Identifiers
                .FirstOrDefault(i => i.Key == IdentifierKey);

            if (identifier != null)
            {
                return _db.Members
                    .Include(i => i.Pass)
                    .FirstOrDefault(m => m.MemberID == identifier.MemberID);
            }

            return null;
        }

        public void ReloadEntry(object entry)
        {
            _db.Entry(entry).Reload();
        }

        public void SaveChanges()
        {
            if (PassRegistry.PassID != 99)
            {
                PassesHelper.SetEndDate(PassRegistry);
            }

            _db.SaveChanges<PassRegistry>();
        }

        public PassRegistry SetEditObject(int passRegistryID)
        {
            var passRegistry = _db
                .PassesRegistry
                .Where(p => p.PassRegistryID == passRegistryID)
                .Include(p => p.Pass)
                .Include(m => m.Member)
                .FirstOrDefault();

            PassRegistry = passRegistry;

            return passRegistry;
        }

        public PassRegistry SetNewObject(int memberID = 0)
        {
            if (PassRegistry != null)
            {
                throw new Exception("Object is exist!");
            }

            PassRegistry = new PassRegistry
            {
                DateAdded = DateTime.Now,
                AddedBy = CurrentUser.User.UserID,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                PaymentDate = DateTime.Now,
                Continuation = true
            };

            if (memberID > 0)
            {
                SetPassRegistry(memberID);
            }

            _db.Add(PassRegistry);

            return PassRegistry;
        }

        public void SetPassRegistry(int memberID)
        {
            if (PassRegistry != null)
            {
                var member = _db
                    .Members
                    .Where(m => m.MemberID == memberID)
                    .Include(p => p.Pass)
                    .FirstOrDefault();

                PassRegistry.Member = member;

                if (member?.Pass != null)
                {
                    PassRegistry.Pass = member.Pass;
                    PassRegistry.PassID = member.Pass.PassID;
                }

                PassRegistry.Continuation = PassesHelper.ContinuousPass(memberID) > 0;

                PassesHelper.SetStartAndEndDate(PassRegistry, PassesHelper.GetLastPassRegistry(member?.MemberID));
            }
        }
    }
}