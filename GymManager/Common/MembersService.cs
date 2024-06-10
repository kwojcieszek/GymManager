using System;
using System.Linq;
using GymManager.DataModel.Models;
using GymManager.DataService;

namespace GymManager.Common
{
    public class MembersService
    {
        public void DeactivateMembersWhenNonActiveSpecifiedDuringDays(int days)
        {
            if(days <= 0)
                return;

            var db = new GymManagerContext();

            var passesRegistry = (from passRegistry in db.PassesRegistry
                where passRegistry.EndDate.HasValue && passRegistry.EndDate.Value.Date > DateTime.Now.AddDays(-days)
                group passRegistry by passRegistry.MemberID
                into g
                select g.Key).ToList();

            var members = db.Members.Where(m => m.IsAcive);

            foreach(var member in members)
            {
                member.IsAcive = passesRegistry.Contains(member.MemberID);
            }

            db.SaveChanges();
        }
    }
}