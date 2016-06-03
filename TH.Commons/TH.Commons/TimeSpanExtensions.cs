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
            return d.HasValue ? d.Value.ToString(format) : defaultValue;
        }

        public static string FormatDuration(this TimeSpan duration)
        {
            if (duration.TotalHours > 24)
            {
                return String.Format("{0}g. {1}min", Math.Floor(duration.TotalHours), duration.Minutes);
            }
            if (duration.Hours > 0 && duration.Minutes != 0)
            {
                return String.Format("{0}g. {1}min", duration.Hours, duration.Minutes);
            }
            if (duration.Hours > 0 && duration.Minutes == 0)
            {
                return String.Format("{0}g.", duration.Hours);
            }
            return String.Format("{0}min", duration.Minutes);
        }

        public static string FormatDurationLong(this TimeSpan duration)
        {
            if (duration.TotalHours > 24)
            {
                var hours = (int)Math.Floor(duration.TotalHours);
                return String.Format("{0} {1} {2} {3}",
                    hours,
                    hours.ToString("godzina", "godziny", "godzin"),
                    duration.Minutes,
                    duration.Minutes.ToString("minuta", "minuty", "minut"));
            }
            if (duration.Hours > 0 && duration.Minutes != 0)
            {
                return String.Format("{0} {1} {2} {3}",
                    duration.Hours,
                    duration.Hours.ToString("godzina", "godziny", "godzin"),
                    duration.Minutes,
                    duration.Minutes.ToString("minuta", "minuty", "minut"));
            }
            if (duration.Hours > 0 && duration.Minutes == 0)
            {
                return String.Format("{0} {1}", duration.Hours, duration.Hours.ToString("godzina", "godziny", "godzin"));
            }
            return String.Format("{0} {1}", duration.Minutes, duration.Minutes.ToString("minuta", "minuty", "minut"));
        }
    }
} 