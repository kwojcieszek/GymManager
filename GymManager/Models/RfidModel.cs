using System;
using GymManager.Common;

namespace GymManager.Models
{
    public class RfidModel
    {
        public event EventHandler EventNewIdentifier;
        private readonly EventHandler<EventArgsIdentifier> _eventArgsIdentifier;
        private readonly IdentifierService _identifierService;

        public string Identifier { get; set; }

        public void CloseIdentifierService()
        {
            _identifierService.EventPop();
        }

        public RfidModel()
        {
            _eventArgsIdentifier = (o, e) =>
            {
                Identifier = e.Identifier;

                EventNewIdentifier?.Invoke(this, e);
            };

            _identifierService = new IdentifierServiceInstances().GetIdentifierService("main");

            _identifierService.EventPush(_eventArgsIdentifier);
        }
    }
}