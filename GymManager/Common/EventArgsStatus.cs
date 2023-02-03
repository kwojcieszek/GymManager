using System;

namespace GymManager.Common;

public class EventArgsStatus : EventArgs
{
    public StatusDevice Status { get; init; }

    public EventArgsStatus(StatusDevice status)
    {
        Status = status;
    }
}