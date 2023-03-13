using System;

namespace GymManager.Common
{
    public class EventArgsResult : EventArgs
    {
        public IdentifierResult Result { get; init; }

        public EventArgsResult(IdentifierResult result)
        {
            Result = result;
        }
    }
}