using System;

namespace GymManager.Common;

public interface IIdentifierDevice
{
    public event EventHandler<EventArgsIdentifier> IdentifierReceived;
    public event EventHandler<EventArgsStatus> StateChanged;
    public void Start();
    public void Stop();
}