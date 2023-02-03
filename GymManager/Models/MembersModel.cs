using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models;

public class MembersModel
{
    public List<Member> Members
    {
        get
        {
            if (_members == null)
                GetMembers(OnlyActives);

            return _members.ToList();
        }
    }

    public bool OnlyActives { get; set; } = true;
    private List<Member> _members;

    public void Delete(Member member)
    {
        if (member == null)
            throw new ArgumentNullException("Element do usunięcia jest pusty.");

        var db = new GymManagerContext();

        db.Members.Remove(member);

        db.SaveChanges<Member, Identifier>();
    }

    public Member GetMemberById(string id)
    {
        var member = new GymManagerContext()
            .Members
            .Where(m => m.Id == id)
            .FirstOrDefault();

        return member;
    }

    public List<Member> GetMembers(bool onlyActives)
    {
        _members = new GymManagerContext()
            .Members
            .Where(m => m.IsAcive == true || m.IsAcive == onlyActives)
            .Include(p => p.Pass)
            .Include(g => g.Gender)
            .Include(u => u.AddedByUser)
            .Include(u => u.ModifiedByUser)
            .ToList();

        return _members;
    }
}