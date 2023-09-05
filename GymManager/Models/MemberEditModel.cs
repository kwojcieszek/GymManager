using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Common;
using GymManager.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class MemberEditModel
    {
        public List<EntryRegistry> EntriesRegistry
        {
            get
            {
                if(Member == null)
                {
                    return null;
                }

                return new GymManagerContext()
                    .EntriesRegistry
                    .Where(m => m.Member.MemberID == Member.MemberID)
                    .Include(m => m.Member)
                    .Include(c => c.CabinetKey)
                    .Include(p => p.Pass)
                    .ToList();
            }
        }

        public List<Gender> Genders => _db.Genders.ToList();

        public string IdentifierKey
        {
            get => Identifier != null ? Identifier.Key : string.Empty;
            set
            {
                if(Identifier != null)
                {
                    Identifier.Key = value;
                }
                else
                {
                    var identifier = new Identifier
                    {
                        Member = Member,
                        MediaCarrierID = 1,
                        IsAcive = true,
                        DateAdded = DateTime.Now,
                        Key = value,
                        AddedBy = CurrentUser.User.UserID
                    };

                    _db.Identifiers.Add(identifier);

                    Identifier = identifier;
                }
            }
        }

        public Member Member { get; private set; }

        public List<Pass> Passes => _db.Passes.ToList();

        public List<PassRegistry> PassesRegistry
        {
            get
            {
                if(Member == null)
                {
                    return null;
                }

                return new GymManagerContext()
                    .PassesRegistry
                    .Where(m => m.Member.MemberID == Member.MemberID)
                    .Include(m => m.Member)
                    .Include(p => p.Pass)
                    .Include(a => a.AddedByUser)
                    .Include(m => m.ModifiedByUser)
                    .ToList();
            }
        }

        public byte[] PhotoData
        {
            get => Photo != null ? Photo.Data : null;
            set
            {
                if(Photo != null)
                {
                    Photo.Data = value;
                }
                else
                {
                    var photo = new Photo
                    {
                        Member = Member,
                        DateAdded = DateTime.Now,
                        Data = value,
                        AddedBy = CurrentUser.User.UserID
                    };

                    _db.Photos.Add(photo);

                    Photo = photo;
                }
            }
        }

        private Identifier Identifier { get; set; }

        private Photo Photo { get; set; }
        private readonly GymManagerContext _db = new();

        public string GetContinuationText()
        {
            if(Member == null)
            {
                return string.Empty;
            }

            var continuation = PassesHelper.ContinuousPass(Member.MemberID);

            if(continuation > 0)
            {
                return continuation == 1
                    ? $"KONTYNUACJA {continuation} MIESIĄC"
                    : $"KONTYNUACJA {continuation} MIESIĄCE";
            }

            return "BRAK KONTYNUACJI";
        }

        public string GetSummaryOfDaysSubscriptionSuspensionText()
        {
            if(Member == null)
            {
                return string.Empty;
            }

            var summaryOfDaysSubscriptionSuspension =
                PassesHelper.GetSummaryOfDaysSubscriptionSuspension(Member.MemberID, DateTime.Now.Year, 0);

            return $"ILOŚĆ DNI ZAWIESZENIA KARNETU: {summaryOfDaysSubscriptionSuspension}";
        }

        public void RemoveIdentifier()
        {
            if(Identifier != null)
            {
                _db.Remove(Identifier);
            }

            Identifier = null;
        }

        public void RemovePhoto()
        {
            if(Photo != null)
            {
                _db.Remove(Photo);
            }

            Photo = null;
        }

        public void SaveChanges()
        {
            _db.SaveChanges<Member, Identifier, Photo>();
        }

        public Member SetEditObject(int memberID)
        {
            if(Member != null)
            {
                throw new Exception("Object is exist!");
            }

            Member = _db.Members
                .Where(m => m.MemberID == memberID)
                .Include(g => g.Gender)
                .Include(p => p.Pass)
                .FirstOrDefault();

            Identifier = _db
                .Identifiers
                .Where(i => i.MemberID == Member.MemberID)
                .FirstOrDefault();

            Photo = _db
                .Photos
                .Where(i => i.MemberID == Member.MemberID)
                .FirstOrDefault();

            Member.DateModified = DateTime.Now;
            Member.ModifiedBy = CurrentUser.User.UserID;

            return Member;
        }

        public bool SetMemberPesel()
        {
            if(Member.Pesel.Length != 11)
            {
                return false;
            }

            var pesel = new Pesel();

            if(pesel.IsValid(Member.Pesel.ToCharArray()))
            {
                Member.BirthDate = pesel.GetBirthDate(Member.Pesel.ToCharArray()).Value;

                Member.GenderID = (int)pesel.GetGender(Member.Pesel.ToCharArray()).Value;
                Member.Gender = Genders.Where(g => g.GenderID == Member.GenderID).FirstOrDefault();

                return true;
            }

            return false;
        }

        public Member SetNewObject()
        {
            if(Member != null)
            {
                throw new Exception("Object is exist!");
            }

            Member = new Member
            {
                DateAdded = DateTime.Now,
                AddedBy = CurrentUser.User.UserID
            };

            _db.Add(Member);

            return Member;
        }
    }
}