using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Common;
using GymManager.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class MembersModel
    {
        private List<Member> _members;

        public List<MembersStatus> ListOfStatus =>
            new()
            {
                new MembersStatus { Id = 1, Name = "WSZYSCY" },
                new MembersStatus { Id = 2, Name = "AKTYWNI" },
                new MembersStatus { Id = 3, Name = "NIEAKTYWNI" }
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