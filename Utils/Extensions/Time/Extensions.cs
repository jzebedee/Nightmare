using System;

namespace Utils.Extensions.Time
{
    public static class Extensions
    {
        const int
            SECOND = 1 * 1000,
            MINUTE = 60 * SECOND,
            HOUR = 60 * MINUTE,
            DAY = 24 * HOUR;

        public static TimeSpan Since(this DateTime start)
        {
            return DateTime.Now - start;
        }

        public static string ToNiceString(this TimeSpan span)
        {
            var delta = span.TotalMilliseconds;

            if (delta > MINUTE)
                return span.TotalMinutes + " min";

            if (delta > SECOND)
                return span.TotalSeconds + " sec";

            return span.TotalMilliseconds + " ms";
        }
    }
}