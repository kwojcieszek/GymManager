using System;
using System.Collections.Generic;

namespace GymManager.Common;

public class IdentifierService
{
    public event EventHandler<EventArgsStatus> StateChanged;
    private readonly Stack<EventHandler<EventArgsIdentifier>> _events = new();
    private readonly IIdentifierDevice _identifierDevice;

    public IdentifierService(IIdentifierDevice identifierDevice)
    {
        _identifierDevice = identifierDevice ?? throw new ArgumentNullException();

        _identifierDevice.IdentifierReceived += IdentifierDevice_IdentifierReceived;

        _identifierDevice.StateChanged += StateChangedEvent;
    }

    public void EventPop()
    {
        _events.Pop();
    }

    public void EventPush(EventHandler<EventArgsIdentifier> e)
    {
        _events.Push(e);
    }

    public void Start()
    {
        _identifierDevice?.Start();
    }

    public void Stop()
    {
        _identifierDevice?.Stop();
    }

    private void IdentifierDevice_IdentifierReceived(object sender, EventArgsIdentifier e)
    {
        if (_events.Count == 0)
            return;

        var env = _events.Peek();

        env?.Invoke(this, e);
    }

    private void StateChangedEvent(object sender, EventArgsStatus e)
    {
        StateChanged?.Invoke(this, e);
    }
}