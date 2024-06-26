﻿using System;
using GymManager.DataModel.Models;

namespace GymManager.Common
{
    public class EntryService
    {
        public event EventHandler<EventArgsResult> EventResult;
        public event EventHandler<EventArgsStatus> EventStateChanged;

        public static IdentifierDevices DefaultIdentifierDevices { get; set; }
        private static EntryService instance;
        private readonly EventHandler<EventArgsIdentifier> _eventArgsIdentifier;
        private readonly IdentifierService _identifierService;

        private EntryService()
        {
            _eventArgsIdentifier = EventRfid;

            if(DefaultIdentifierDevices == IdentifierDevices.RFIDSerialPort)
            {
                _identifierService = new IdentifierServiceInstances().GetIdentifierService("main");

                _identifierService.EventPush(_eventArgsIdentifier);

                _identifierService.StateChanged += (o, e) => EventStateChanged?.Invoke(o, e);
            }
        }

        public void Entry(Member member, bool access = false)
        {
            var ids = new IdentifiersService();
            var result = ids.Identifier(member.MemberID, access: access);

            EventResult?.Invoke(this, new EventArgsResult(result));
        }

        public static EntryService GetInstance()
        {
            return instance ??= new EntryService();
        }

        private void EventRfid(object sender, EventArgsIdentifier e)
        {
            var ids = new IdentifiersService();
            var result = ids.Identifier(e.Identifier);

            EventResult?.Invoke(this, new EventArgsResult(result));
        }
    }
}