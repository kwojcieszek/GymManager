using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Common;
using GymManager.DbModels;
using GymManager.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class MembersModel
    {
        public List<MembersStatus> ListOfStatus =>
            new()
            {
                new() { Id = 1, Name = "WSZYSCY" },
                new() { Id = 2, Name = "AKTYWNI" },
                new() { Id = 3, Name = "NIEAKTYWNI" }
            };

        public List<Member> Members
        {
            get
            {
                if(_members == null)
                {
                    GetMembers(SelectedStatus);
                }

                return _members!.ToList();
            }
        }

        public int SelectedStatus { get; set; } = 2;

        private List<Member> _members;

        public void Delete(Member member)
        {
            if(member == null)
            {
                throw new ArgumentNullException("Element do usunięcia jest pusty.");
            }

            var db = new GymManagerContext();

            db.Members.Remove(member);

            db.SaveChanges<Member, Identifier>();
        }

        public Member GetMemberById(string id)
        {
            var member = new GymManagerContext()
                .Members
                .FirstOrDefault(m => m.Id == id);

            return member;
        }

        public List<Member> GetMembers(int status)
        {
            var isActive = status is 1 or 2;
            var isNonActive = status is 1 or 3;

            _members = new GymManagerContext()
                .Members
                .Where(m => m.IsAcive == isActive || m.IsAcive == !isNonActive)
                .Include(p => p.Pass)
                .Include(g => g.Gender)
                .Include(u => u.AddedByUser)
                .Include(u => u.ModifiedByUser)
                .ToList();

            return _members;
        }
    }
}