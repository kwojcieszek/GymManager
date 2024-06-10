using System;
using System.Linq;
using GymManager.DataModel.Models;
using GymManager.DataService;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Common
{
    public class IdentifiersService
    {
        public event EventHandler<IdentifierMessage> EventMessage;
        public static CabinetKeyMode DefaultCabinetKeyMode { get; set; } = CabinetKeyMode.InLoop;

        public static IdentifierResult LastIdentifierResult { get; private set; }

        public void ChangeCabinetKey(EntryRegistry entryRegistry, CabinetKey cabinetKey)
        {
            if(entryRegistry == null)
            {
                return;
            }

            var db = new GymManagerContext();

            entryRegistry.CabinetKey = cabinetKey;

            db.EntriesRegistry.Update(entryRegistry);

            db.SaveChanges();
        }

        public void CloseRegistry(int timeoutTinutes)
        {
            var db = new GymManagerContext();

            var entryRegistry = db
                .EntriesRegistry
                .Where(e => e.IsAcive);

            foreach(var entry in entryRegistry)
            {
                if(new TimeSpan(DateTime.Now.Ticks - entry.EntryDate.Ticks).TotalMinutes > timeoutTinutes)
                {
                    entry.IsAcive = false;
                    db.EntriesRegistry.Update(entry);
                }
            }

            db.SaveChanges();
        }

        public IdentifierResult Identifier(string key)
        {
            IdentifierResult idresult;

            var db = new GymManagerContext();

            var identifier = db
                .Identifiers
                .FirstOrDefault(i => i.IsAcive && i.Key == key);

            if(identifier == null)
            {
                LastIdentifierResult =
                    idresult = new IdentifierResult(IdentifierMessage.NoIdentifier, null, null, null, null, null);

                return idresult;
            }

            return Identifier(identifier.MemberID, identifier);
        }

        public IdentifierResult Identifier(int memberID, Identifier identifier = null, bool checkAndWrite = true,
            bool access = false)
        {
            IdentifierResult idresult;

            var db = new GymManagerContext();

            var member = db.Members.FirstOrDefault(i => i.MemberID == memberID);

            var passesRegistry = db.PassesRegistry
                .Where(p => p.MemberID == memberID)
                .Include(a => a.Pass)
                .Include(m => m.Member)
                .OrderByDescending(o => o.EndDate)
                .Take(24);

            var endOfPassesRegistry = db.PassesRegistry
                .Where(p => p.MemberID == memberID)
                .Include(a => a.Pass)
                .Include(m => m.Member)
                .OrderByDescending(o => o.EndDate)
                .Take(1);

            var activeEntries = db
                .EntriesRegistry
                .Count(e => e.MemberID == memberID && e.IsAcive);

            if(access && checkAndWrite)
            {
                LastIdentifierResult =
                    idresult = CreateEntry(identifier, null, passesRegistry.FirstOrDefault(), member);

                return idresult;
            }

            if(activeEntries > 0)
            {
                if(checkAndWrite)
                {
                    LastIdentifierResult =
                        idresult = CreateEntry(identifier, null, passesRegistry.FirstOrDefault(), member);
                }
                else
                {
                    idresult = new IdentifierResult(IdentifierMessage.AccessEntry, null, member, null, null,
                        endOfPassesRegistry.FirstOrDefault());
                }

                return idresult;
            }

            foreach(var passRegistry in passesRegistry)
            {
                if(passRegistry.EndDate.HasValue && DateTime.Now.Date >= passRegistry.StartDate.Date &&
                   DateTime.Now.Date <= passRegistry.EndDate.Value.Date)
                {
                    var pass = passRegistry.Pass;

                    //suspended
                    if(passRegistry.Suspension && passRegistry.StartSuspensionDate.HasValue &&
                       passRegistry.EndSuspensionDate.HasValue &&
                       DateTime.Now.Date >= passRegistry.StartSuspensionDate.Value.Date &&
                       DateTime.Now.Date <= passRegistry.EndSuspensionDate.Value.Date)
                    {
                        idresult = new IdentifierResult(IdentifierMessage.SubscriptionSuspension, null, member,
                            passRegistry, null, endOfPassesRegistry.FirstOrDefault());

                        if(checkAndWrite)
                        {
                            LastIdentifierResult = idresult;
                        }

                        return idresult;
                    }

                    //Check time
                    if(pass.AccessTimeFrom.HasValue && pass.AccessTimeTo.HasValue &&
                       (DateTime.Now.TimeOfDay.TotalSeconds <
                        pass.AccessTimeFrom.Value.TimeOfDay.TotalSeconds ||
                        DateTime.Now.TimeOfDay.TotalSeconds > pass.AccessTimeTo.Value.TimeOfDay.TotalSeconds))
                    {
                        idresult = new IdentifierResult(IdentifierMessage.OutOfTime, null, member, passRegistry, null,
                            endOfPassesRegistry.FirstOrDefault());

                        if(checkAndWrite)
                        {
                            LastIdentifierResult = idresult;
                        }

                        return idresult;
                    }

                    if(checkAndWrite)
                    {
                        LastIdentifierResult = idresult =
                            CreateEntry(identifier, passRegistry, passesRegistry.FirstOrDefault(), member);
                    }
                    else
                    {
                        idresult = new IdentifierResult(IdentifierMessage.AccessEntry, null, member, passRegistry, null,
                            endOfPassesRegistry.FirstOrDefault());
                    }

                    return idresult;
                }
            }

            idresult = new IdentifierResult(IdentifierMessage.PassExpiration, null, member,
                passesRegistry.FirstOrDefault(),
                null, endOfPassesRegistry.FirstOrDefault());

            if(checkAndWrite)
            {
                LastIdentifierResult = idresult;
            }

            return idresult;
        }

        public IdentifierResult IdentifierResultCreate(IdentifierMessage identifierMessage, int entryRegistryID,
            PassRegistry passRegistry, PassRegistry endOfPassRegistry)
        {
            var db = new GymManagerContext();

            CabinetKey cabinetKey = null;

            var entryRegistry = db.EntriesRegistry
                .FirstOrDefault(e => e.EntryRegistryID == entryRegistryID);

            var member = db.Members
                .FirstOrDefault(m => m.MemberID == entryRegistry.MemberID);

            if(entryRegistry != null && entryRegistry.CabinetKeyID.HasValue)
            {
                cabinetKey = db.CabinetKeys
                    .FirstOrDefault(c => c.CabinetKeyID == entryRegistry.CabinetKeyID);
            }

            return new IdentifierResult(identifierMessage, entryRegistry, member, passRegistry, cabinetKey,
                endOfPassRegistry);
        }

        private IdentifierResult CreateEntry(Identifier identifier, PassRegistry passRegistry,
            PassRegistry endOfPassRegistry, Member member = null)
        {
            var db = new GymManagerContext();

            if(member == null)
            {
                member = db
                    .Members
                    .FirstOrDefault(m => m.MemberID == identifier.MemberID);
            }

            if(member == null)
            {
                return new IdentifierResult(IdentifierMessage.UnknowError, null, null, null, null, null);
            }

            var entryRegistry = db
                .EntriesRegistry
                .Where(e => e.MemberID == member.MemberID && e.IsAcive)
                .Include(p => p.Pass)
                .FirstOrDefault();

            if(entryRegistry != null)
            {
                entryRegistry.ExitDate = DateTime.Now;
                entryRegistry.IsAcive = false;
                entryRegistry.VisitTime = (int)(entryRegistry.ExitDate.Value - entryRegistry.EntryDate).TotalMinutes;
            }
            else
            {
                entryRegistry = new EntryRegistry
                {
                    MemberID = member.MemberID,
                    IsAcive = true,
                    EntryDate = DateTime.Now,
                    CabinetKey = GetAvailableCabinetKey(member),
                    Pass = passRegistry?.Pass
                };

                db.EntriesRegistry.Update(entryRegistry);

                if(entryRegistry.CabinetKey != null)
                {
                    entryRegistry.CabinetKey.LastUsedDate = DateTime.Now;
                    db.CabinetKeys.Update(entryRegistry.CabinetKey);
                }
            }

            db.SaveChanges();

            return IdentifierResultCreate(
                entryRegistry.IsAcive ? IdentifierMessage.AccessEntry : IdentifierMessage.AccessExit,
                entryRegistry.EntryRegistryID, passRegistry, endOfPassRegistry);
        }

        private CabinetKey GetAvailableCabinetKey(Member member)
        {
            if(member == null)
            {
                return null;
            }

            var db = new GymManagerContext();

            var cabinetKeys = db.EntriesRegistry
                .Where(er => er.IsAcive && er.CabinetKeyID.HasValue)
                .Select(s => s.CabinetKeyID);

            if(DefaultCabinetKeyMode == CabinetKeyMode.FirstAvailable)
            {
                return db.CabinetKeys
                    .Where(ck => ck.IsAcive && ck.GenderID == member.GenderID && !cabinetKeys.Contains(ck.CabinetKeyID))
                    .OrderBy(o => o.CabinetKeyID)
                    .FirstOrDefault();
            }

            if(DefaultCabinetKeyMode == CabinetKeyMode.InLoop)
            {
                return db.CabinetKeys
                    .Where(ck => ck.IsAcive && ck.GenderID == member.GenderID && !cabinetKeys.Contains(ck.CabinetKeyID))
                    .OrderBy(o => o.LastUsedDate)
                    .FirstOrDefault();
            }

            return null;
        }

        private void OnMessage(object sender, EventArgs<IdentifierMessage> e)
        {
            EventMessage?.Invoke(sender, e.Value);
        }
    }
}