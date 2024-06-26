﻿using System;
using System.Threading;
using System.Windows.Threading;

namespace GymManager.Common.DataGrid
{
    /// <summary>
    ///     Implements a throttle that uses the dispatcher to delay the target action.
    /// </summary>
    public class DispatcherThrottle
    {
        private int _counter;
        private readonly Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;
        private readonly DispatcherPriority _priority;
        private readonly Action _target;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DispatcherThrottle" /> class.
        /// </summary>
        /// <param name="priority">The priority of the dispatcher.</param>
        /// <param name="target">The target action to invoke when the throttle condition is hit.</param>
        public DispatcherThrottle(DispatcherPriority priority, Action target)
        {
            _target = target;
            _priority = priority;
        }

        /// <summary>
        ///     Ticks this instance to trigger the throttle.
        /// </summary>
        public void Tick()
        {
            Interlocked.Increment(ref _counter);

            _dispatcher.BeginInvoke(_priority, (Action)delegate
            {
                if(Interlocked.Decrement(ref _counter) != 0)
                {
                    return;
                }

                _target();
            });
        }
    }
}