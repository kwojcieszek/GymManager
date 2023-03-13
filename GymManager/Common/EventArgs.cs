using System;

namespace GymManager.Common
{
    public class EventArgs<T> : EventArgs
    {
        public T Value { get; init; }

        public EventArgs(T value)
        {
            Value = value;
        }
    }
}