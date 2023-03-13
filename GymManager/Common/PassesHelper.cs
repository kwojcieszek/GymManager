using System;
using System.Linq;
using GymManager.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Common
{
    public static class PassesHelper
    {
        public static int ContinuousPass(int memberID, DateTime? lastDate = null)
        {
            var db = new GymManagerContext();

            var continuation = 0;

            var passes = db.PassesRegistry
                .Where(m => m.MemberID == memberID)
                .OrderByDescending(p => p.EndDate.Value.Date);

            foreach (var pass in passes)
            {
                lastDate ??= pass.StartDate.Date;

                var diffDays = pass.EndDate.HasValue ? (pass.EndDate.Value.Date - lastDate.Value.Date).TotalDays : -1;

                if (diffDays < -1)
                {
                    continue;
                }

                if (pass.PassID < 99)
                {
                    continuation++;
                }

                lastDate = pass.StartDate.Date;
            }

            return continuation;
        }

        public static EntryRegistry GetActiveEntryRegistry(Member member)
        {
            var db = new GymManagerContext();

            return db
                .EntriesRegistry
                .Where(e => e.MemberID == member.MemberID && e.IsAcive)
                .Include(p => p.Pass)
                .FirstOrDefault();
        }

        public static PassRegistry GetCurrentPassRegistry(int memberID)
        {
            var db = new GymManagerContext();

            return db.PassesRegistry
                .Where(p => p.MemberID == memberID)
                .Where(p => p.StartDate.Date > DateTime.Now.Date ||
                            (p.EndDate.HasValue && p.EndDate.Value.Date > DateTime.Now.Date))
                .FirstOrDefault();
        }

        public static PassRegistry GetLastPassRegistry(int? memberID)
        {
            if (memberID == null)
            {
                return null;
            }

            var db = new GymManagerContext();

            return db.PassesRegistry
                .Where(m => m.MemberID == memberID && m.EndDate.HasValue)
                .Include(p => p.Pass)
                .OrderByDescending(p => p.EndDate.Value.Date)
                .FirstOrDefault();
        }

        public static int? GetMemberAge(Member member)
        {
            if (!member.BirthDate.HasValue)
            {
                return null;
            }

            var age = DateTime.Now.Year - member.BirthDate.Value.Year;

            if (member.BirthDate.Value.Date > DateTime.Now.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public static int GetSummaryOfDaysSubscriptionSuspension(int memberID, int year, int passesRegistryID)
        {
            var db = new GymManagerContext();

            var summary = db.PassesRegistry
                .Where(m => m.MemberID == memberID && m.Suspension && m.StartDate.Year == year &&
                            m.PassRegistryID != passesRegistryID)
                .Select(m => new { EndDate = m.EndSuspensionDate.Value, StartDate = m.StartSuspensionDate.Value });

            var quantity = 0;

            foreach (var pass in summary)
            {
                quantity += (int)(pass.EndDate - pass.StartDate).TotalDays;
            }

            return quantity;
        }

        public static void SetEndDate(PassRegistry passRegistry)
        {
            if (passRegistry.Pass == null)
            {
                return;
            }

            if (passRegistry.Pass.PassTimeID == 1)
            {
                passRegistry.EndDate = passRegistry.StartDate.AddDays(0);
            }
            else if (passRegistry.Pass.PassTimeID == 2)
            {
                passRegistry.EndDate = passRegistry.StartDate.AddDays(6);
            }
            else if (passRegistry.Pass.PassTimeID == 3)
            {
                passRegistry.EndDate = passRegistry.StartDate.AddMonths(1).AddDays(-1);
            }
            else if (passRegistry.Pass.PassTimeID == 4)
            {
                passRegistry.EndDate = passRegistry.StartDate.AddYears(1).AddDays(-1);
            }
            else if (passRegistry.Pass.PassTimeID == 99)
            {
                passRegistry.EndDate = passRegistry.StartDate.AddDays(passRegistry!.Pass!.PassTimeDays!.Value - 1);
            }

            if (passRegistry.Suspension && passRegistry.EndDate.HasValue && passRegistry.StartSuspensionDate.HasValue &&
                passRegistry.EndSuspensionDate.HasValue)
            {
                passRegistry.EndDate = passRegistry.EndDate.Value.AddDays(
                    (passRegistry.EndSuspensionDate.Value - passRegistry.StartSuspensionDate.Value).TotalDays + 1);
            }
        }

        public static void SetStartAndEndDate(PassRegistry passRegistry, PassRegistry lastPassRegistry)
        {
            if (passRegistry == null)
            {
                return;
            }

            if (lastPassRegistry == null)
            {
                passRegistry.StartDate = DateTime.Now.Date;
            }
            else
            {
                passRegistry.StartDate = lastPassRegistry.EndDate.Value.AddDays(1).Date;
            }

            SetEndDate(passRegistry);
        }

        public static void SetStartDate(PassRegistry passRegistry)
        {
            if (passRegistry.Pass == null)
            {
                return;
            }

            if (!passRegistry.Pass.Continuation)
            {
                passRegistry.StartDate = DateTime.Now.Date;
            }
        }

        public static void UpdateEndDate()
        {
            var db = new GymManagerContext();

            var passed = db.PassesRegistry
                .Include(p => p.Pass);

            foreach (var pass in passed)
            {
                SetEndDate(pass);
                db.PassesRegistry.Update(pass);
            }

            db.SaveChanges();
        }
    }
}