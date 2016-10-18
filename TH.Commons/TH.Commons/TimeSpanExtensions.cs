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

        /// <summary>
        /// Polish format
        /// </summary>
        public static string FormatDuration(this TimeSpan duration)
        {
            if (duration.TotalHours > 24)
            {
                return $"{Math.Floor(duration.TotalHours)}g. {duration.Minutes}min";
            }
            if (duration.Hours > 0 && duration.Minutes != 0)
            {
                return $"{duration.Hours}g. {duration.Minutes}min";
            }
            if (duration.Hours > 0 && duration.Minutes == 0)
            {
                return $"{duration.Hours}g.";
            }
            return $"{duration.Minutes}min";
        }

        /// <summary>
        /// Polish format
        /// </summary>
        public static string FormatDurationLong(this TimeSpan duration)
        {
            if (duration.TotalHours > 24)
            {
                var hours = (int)Math.Floor(duration.TotalHours);
                return $"{hours} {hours.ToString("godzina", "godziny", "godzin")} {duration.Minutes} {duration.Minutes.ToString("minuta", "minuty", "minut")}";
            }
            if (duration.Hours > 0 && duration.Minutes != 0)
            {
                return $"{duration.Hours} {duration.Hours.ToString("godzina", "godziny", "godzin")} {duration.Minutes} {duration.Minutes.ToString("minuta", "minuty", "minut")}";
            }
            if (duration.Hours > 0 && duration.Minutes == 0)
            {
                return $"{duration.Hours} {duration.Hours.ToString("godzina", "godziny", "godzin")}";
            }
            return $"{duration.Minutes} {duration.Minutes.ToString("minuta", "minuty", "minut")}";
        }
    }
} 