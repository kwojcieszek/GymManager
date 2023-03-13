using System;

namespace GymManager.Common
{
    public class StartJob
    {
        public Action Action { get; }
        public string Description { get; }

        public StartJob(Action action, string description)
        {
            Action = action;
            Description = description;
        }
    }
}