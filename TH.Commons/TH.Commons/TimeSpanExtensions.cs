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
    }
} 