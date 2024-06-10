using System;

namespace GymManager.Common.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     Gets the 11:59:59 instance of a DateTime
        /// </summary>
        public static DateTime AbsoluteEnd(this DateTime dateTime)
        {
            return AbsoluteStart(dateTime).AddDays(1).AddTicks(-1);
        }

        /// <summary>
        ///     Gets the 12:00:00 instance of a DateTime
        /// </summary>
        public static DateTime AbsoluteStart(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        public static long TotalMinutes(this DateTime dateTime)
        {
            return (long)new TimeSpan(dateTime.Ticks).TotalMinutes;
        }
    }
}