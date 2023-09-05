using System;
using System.Linq;
using GymManager.Common;
using GymManager.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class EntryPanelModel
    {
        public event EventHandler<EventArgsResult> EventResult;
        public event EventHandler<EventArgsStatus> EventStateChanged;

        public bool IsIdentifierDevice => EntryService.DefaultIdentifierDevices != IdentifierDevices.None;

        public EntryRegistry LastEntryRegistry =>
            new GymManagerContext()
                .EntriesRegistry
                .Where(d => d.EntryDate.Date == DateTime.Now.Date)
                .Include(m => m.Member)
                .Include(c => c.CabinetKey)
                .OrderByDescending(r => r.EntryDate)
                .Take(1).FirstOrDefault();

        public int NumersOfPeopeInGym =>
            new GymManagerContext()
                .EntriesRegistry
                .Count(r => r.IsAcive);

        private readonly EntryService _entryService = EntryService.GetInstance();

        public EntryPanelModel(bool isDesignMode = false)
        {
            if(isDesignMode)
            {
                return;
            }

            _entryService.EventResult += (s, e) => EventResult?.Invoke(this, e);
            _entryService.EventStateChanged += (s, e) => EventStateChanged?.Invoke(this, e);
        }

        public void ChangeCabinetKey(EntryRegistry entryRegistry, CabinetKey cabinetKey)
        {
            new IdentifiersService().ChangeCabinetKey(entryRegistry, cabinetKey);
        }

        public byte[] GetPhoto(int memberID)
        {
            var photo = new GymManagerContext()
                .Photos
                .FirstOrDefault(m => m.MemberID == memberID);

            return photo != null ? photo.Data : new byte[] { };
        }
    }
}