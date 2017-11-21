using System;

namespace TH.Commons
{
    /// <summary>
    /// Extension methods for TimeSpan and TimeSpan? types
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// ToString for nullable TimeSpan
        /// </summary>
        public static string ToString(this TimeSpan? d, string format)
        {
            return ToString(d, format, "");
        }

        /// <summary>
        /// ToString for nullable TimeSpan with default output text in case of null
        /// </summary>
        public static string ToString(this TimeSpan? d, string format, string defaultValue)
        {
            return d?.ToString(format) ?? defaultValue;
        }

        /// <summary>
        /// Display approximate number of years in given TimeSpan
        /// </summary>
        public static string ToReadableAgeString(this TimeSpan span)
        {
            return $"{span.Days / 365.25:0}";
        }

        /// <summary>
        /// Displays days if any, and after that hours if not zero, then minutes if not zero, and finally seconds if not zero.
        /// Each part of TimeSpan is checked for zero individually and is displayed only if > 0. 
        /// If provided timespan is zero displays 0s.
        /// Displays - sign if param is less than 0.
        /// </summary>
        public static string ToReadableString(this TimeSpan span)
        {
            if (span == TimeSpan.Zero) return "0s";
            var duration = span.Duration();
            var formatted = string.Format("{0}{1}{2}{3}{4}",
                span < TimeSpan.Zero ? "- " : string.Empty,
                duration.Days > 0 ? $"{duration.Days:0}d. " : string.Empty,
                duration.Hours > 0 ? $"{duration.Hours:0}g " : string.Empty,
                duration.Minutes > 0 ? $"{duration.Minutes:0}m " : string.Empty,
                duration.Seconds > 0 ? $"{duration.Seconds:0}s" : string.Empty);
            if (formatted.EndsWith(" ")) formatted = formatted.TrimEnd();
            return formatted;
        }

        /// <summary>
        /// Displays days if any, and after that hours if not zero, then minutes if not zero, and finally seconds if not zero.
        /// Each part of TimeSpan is checked for zero individually and is displayed only if > 0. 
        /// If provided timespan is zero displays 0s.
        /// Displays always positive time span (duration)
        /// </summary>
        public static string ToReadableDurationString(this TimeSpan span)
        {
            if (span == TimeSpan.Zero) return "0s";
            var duration = span.Duration();
            var formatted = string.Format("{0}{1}{2}{3}",
                duration.Days > 0 ? $"{duration.Days:0}d. " : string.Empty,
                duration.Hours > 0 ? $"{duration.Hours:0}g " : string.Empty,
                duration.Minutes > 0 ? $"{duration.Minutes:0}m " : string.Empty,
                duration.Seconds > 0 ? $"{duration.Seconds:0}s" : string.Empty);
            if (formatted.EndsWith(" ")) formatted = formatted.TrimEnd();
            return formatted;
        }

        /// <summary>
        /// Displays days if any, and after that hours if not zero, then minutes if not zero, and finally seconds if not zero.
        /// Each part of TimeSpan is checked for zero individually and is displayed only if > 0. 
        /// If provided timespan is zero displays 0s.
        /// Displays - sign if param is less than 0 OR + sign if param is greater than 0.
        /// </summary>
        public static string ToReadableSignedString(this TimeSpan span)
        {
            if (span == TimeSpan.Zero) return "0s";
            var duration = span.Duration();
            var formatted = string.Format("{0}{1}{2}{3}{4}",
                span < TimeSpan.Zero ? "- " : "+ ",
                duration.Days > 0 ? $"{duration.Days:0}d. " : string.Empty,
                duration.Hours > 0 ? $"{duration.Hours:0}g " : string.Empty,
                duration.Minutes > 0 ? $"{duration.Minutes:0}m " : string.Empty,
                duration.Seconds > 0 ? $"{duration.Seconds:0}s" : string.Empty);
            if (formatted.EndsWith(" ")) formatted = formatted.TrimEnd();
            return formatted;
        }

        /// <summary>
        /// Displays days if any, and after that hours if them or minutes or second are not zero, then minutes if them or seconds are not zero, 
        /// and finally seconds if not zero. So only hours (when mins or secs > 0 and days > 0) and minutes (when seconds > 0 and hours or days > 0) can be displayed even if zero.
        /// If provided timespan is zero displays 0s.
        /// Displays - sign if param is less than 0.
        /// </summary>
        public static string ToReadableStringNoGaps(this TimeSpan span)
        {
            var duration = span.Duration();
            var formatted = string.Format("{0}{1}{2}{3}{4}",
                span < TimeSpan.Zero ? "- " : string.Empty,
                duration.Days > 0 ? $"{duration.Days:0}d. " : string.Empty,
                duration.Hours > 0 || (duration.Days > 0 && (duration.Minutes > 0 || duration.Seconds > 0)) ?
                    $"{duration.Hours:0}g " : string.Empty,
                duration.Minutes > 0 || (duration.Seconds > 0 && (duration.Days > 0 || duration.Hours > 0)) ?
                    $"{duration.Minutes:0}m " : string.Empty,
                duration.Seconds > 0 ? $"{duration.Seconds:0}s" : string.Empty);
            if (formatted.EndsWith(" ")) formatted = formatted.TrimEnd();
            if (string.IsNullOrEmpty(formatted)) formatted = "0s";
            return formatted;
        }

        /// <summary>
        /// Displays days if any, and after that hours if them or minutes or second are not zero, then minutes if them or seconds are not zero, 
        /// and finally seconds if not zero. So only hours (when mins or secs > 0 and days > 0) and minutes (when seconds > 0 and hours or days > 0) can be displayed even if zero.
        /// If provided timespan is zero displays 0s.
        /// Displays always positive time span (duration)
        /// </summary>
        public static string ToReadableDurationStringNoGaps(this TimeSpan span)
        {
            var duration = span.Duration();
            var formatted = string.Format("{0}{1}{2}{3}",
                duration.Days > 0 ? $"{duration.Days:0}d. " : string.Empty,
                duration.Hours > 0 || (duration.Days > 0 && (duration.Minutes > 0 || duration.Seconds > 0)) ?
                    $"{duration.Hours:0}g " : string.Empty,
                duration.Minutes > 0 || (duration.Seconds > 0 && (duration.Days > 0 || duration.Hours > 0)) ?
                    $"{duration.Minutes:0}m " : string.Empty,
                duration.Seconds > 0 ? $"{duration.Seconds:0}s" : string.Empty);
            if (formatted.EndsWith(" ")) formatted = formatted.TrimEnd();
            if (string.IsNullOrEmpty(formatted)) formatted = "0s";
            return formatted;
        }

        /// <summary>
        /// Displays days if any, and after that hours if them or minutes or second are not zero, then minutes if them or seconds are not zero, 
        /// and finally seconds if not zero. So only hours (when mins or secs > 0 and days > 0) and minutes (when seconds > 0 and hours or days > 0) can be displayed even if zero.
        /// If provided timespan is zero displays 0s.
        /// Displays - sign if param is less than 0 OR + sign if param is greater than 0.
        /// </summary>
        public static string ToReadableSignedStringNoGaps(this TimeSpan span)
        {
            var duration = span.Duration();
            var formatted = string.Format("{0}{1}{2}{3}{4}",
                span < TimeSpan.Zero ? "- " : "+ ",
                duration.Days > 0 ? $"{duration.Days:0}d. " : string.Empty,
                duration.Hours > 0 || (duration.Days > 0 && (duration.Minutes > 0 || duration.Seconds > 0)) ?
                    $"{duration.Hours:0}g " : string.Empty,
                duration.Minutes > 0 || (duration.Seconds > 0 && (duration.Days > 0 || duration.Hours > 0)) ?
                    $"{duration.Minutes:0}m " : string.Empty,
                duration.Seconds > 0 ? $"{duration.Seconds:0}s" : string.Empty);
            if (formatted.EndsWith(" ")) formatted = formatted.TrimEnd();
            if (string.IsNullOrEmpty(formatted)) formatted = "0s";
            return formatted;
        }

        /// <summary>
        /// Displays time span rounded to full hours and minutes in format "Xh Ymin", where X(double) are total hours truncated, and Y(int) are minutes.
        /// </summary>
        public static string ToReadableStringHoursAndMinutes(this TimeSpan span)
        {
            return $"{Math.Floor(span.TotalHours.Truncate()):F0}h {span.Minutes}min";
        }

        /// <summary>
        /// Rounds given time span to minutes. Up from 30 seconds and more. Down from 29 seconds and less.
        /// </summary>
        public static TimeSpan RoundToMinutesHalfUp(this TimeSpan t)
        {
            var duration = t.Duration();
            var days = duration.Days;
            var hours = duration.Hours;
            var minutes = duration.Minutes;
            if (duration.Seconds >= 30)
            {
                minutes++;
                if (minutes == 60)
                {
                    minutes = 0;
                    hours++;
                    if (hours == 24)
                    {
                        hours = 0;
                        days++;
                    }
                }
            }
            var sign = t < TimeSpan.Zero ? -1 : 1;
            return new TimeSpan(sign * days, sign * hours, sign * minutes, 0);
        }

        /// <summary>
        /// Rounds given time span to minutes. Up from 31 seconds and more. Down from 30 seconds and less.
        /// </summary>
        public static TimeSpan RoundToMinutesHalfDown(this TimeSpan t)
        {
            var duration = t.Duration();
            var days = duration.Days;
            var hours = duration.Hours;
            var minutes = duration.Minutes;
            if (duration.Seconds > 30)
            {
                minutes++;
                if (minutes == 60)
                {
                    minutes = 0;
                    hours++;
                    if (hours == 24)
                    {
                        hours = 0;
                        days++;
                    }
                }
            }
            var sign = t < TimeSpan.Zero ? -1 : 1;
            return new TimeSpan(sign * days, sign * hours, sign * minutes, 0);
        }
    }
}