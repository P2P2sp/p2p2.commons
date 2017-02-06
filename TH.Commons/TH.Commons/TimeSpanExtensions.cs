using System;

namespace TH.Commons
{
    public static class TimeSpanExtensions
    {
        public static string ToString(this TimeSpan? d, string format)
        {
            return ToString(d, format, "");
        }

        public static string ToString(this TimeSpan? d, string format, string defaultValue)
        {
            return d?.ToString(format) ?? defaultValue;
        }

        public static string ToReadableAgeString(this TimeSpan span)
        {
            return $"{span.Days / 365.25:0}";
        }

        /// <summary>
        /// Displays days if any, and after that hours if not zero, then minutes if not zero, and finally seconds if not zero.
        /// Each part of TimeSpan is checked for zero individually and is displayed only id > 0. 
        /// If param is zero displays 0s.
        /// </summary>
        public static string ToReadableString(this TimeSpan span)
        {
            var formatted = string.Format("{0}{1}{2}{3}",
                span.Duration().Days > 0 ? $"{span.Days:0}d. " : string.Empty,
                span.Duration().Hours > 0 ? $"{span.Hours:0}g " : string.Empty,
                span.Duration().Minutes > 0 ? $"{span.Minutes:0}min " : string.Empty,
                span.Duration().Seconds > 0 ? $"{span.Seconds:0}s" : string.Empty);
            if (formatted.EndsWith(" ")) formatted = formatted.TrimEnd();
            if (string.IsNullOrEmpty(formatted)) formatted = "0s";
            return formatted;
        }

        /// <summary>
        /// Displays days if any, and after that hours if them or minutes or second are not zero, then minutes if them or seconds are not zero, 
        /// and finally seconds if not zero. So only hours (when mins or secs > 0) and minutes (when seconds > 0) can be displayed even if zero. 
        /// If param is zero displays 0s.
        /// </summary>
        public static string ToReadableStringNoGaps(this TimeSpan span)
        {
            var duration = span.Duration();
            var formatted = string.Format("{0}{1}{2}{3}",
                duration.Days > 0 ? $"{span.Days:0}d. " : string.Empty,
                duration.Hours > 0 || (duration.Days > 0 && (duration.Minutes > 0 || duration.Seconds > 0)) ?
                    $"{span.Hours:0}g " : string.Empty,
                duration.Minutes > 0 || (duration.Seconds > 0 && (duration.Days > 0 || duration.Hours > 0)) ? 
                    $"{span.Minutes:0}min " : string.Empty,
                duration.Seconds > 0 ? $"{span.Seconds:0}s" : string.Empty);
            if (formatted.EndsWith(" ")) formatted = formatted.TrimEnd();
            if (string.IsNullOrEmpty(formatted)) formatted = "0s";
            return formatted;
        }
    }
}