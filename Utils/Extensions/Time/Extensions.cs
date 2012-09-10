using System;

namespace Utils.Extensions.Time
{
    public static class Extensions
    {
        public static TimeSpan Since(this DateTime start)
        {
            return DateTime.Now - start;
        }

        public static string ToNiceString(this TimeSpan span)
        {
            //const int MILLISECOND = 1;
            const int SECOND = 1 * 1000;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            // const int MONTH = 30 * DAY;

            var delta = span.TotalMilliseconds;

            if (delta > MINUTE)
                return span.TotalMinutes + " min";

            if (delta > 1 * SECOND)
            {
                return span.TotalSeconds + " sec";
            }

            return span.TotalMilliseconds + " ms";
        }
    }
}