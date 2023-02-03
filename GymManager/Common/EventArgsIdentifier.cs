using System;

namespace GymManager.Common;

public class EventArgsIdentifier : EventArgs
{
    public string Identifier { get; init; }

    public EventArgsIdentifier(string identifier)
    {
        Identifier = identifier;
    }
}