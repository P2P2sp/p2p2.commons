using System;

namespace TH.Commons
{
    /// <summary>
    /// Extenstion methods for DateTime type
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts datetime to string in datetime2(7) sql data format (with 100ns precision)
        /// </summary>
        public static string ToStringDatetime2(this DateTime value)
        {
            return value.ToString("yyyy.MM.dd HH:mm:ss.fffffff");
        }

        /// <summary>
        /// Returns true if both datetimes are equal from Date, through Hours and Minutes, to Seconds (so it allows mismatch from miliseconds forwards)
        /// </summary>
        public static bool AreEqualToTheSeconds(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1.Date == dateTime2.Date
                && dateTime1.Hour == dateTime2.Hour
                && dateTime1.Minute == dateTime2.Minute
                && dateTime1.Second == dateTime2.Second;
        }

        /// <summary>
        /// Returns true if both datetimes are equal from Date, through Hours and Minutes, to Seconds (so it allows mismatch from miliseconds forwards)
        /// </summary>
        public static bool AreEqualToTheSeconds(DateTime? dateTime1, DateTime? dateTime2)
        {
            if (dateTime1 == null || dateTime2 == null) return false;
            return AreEqualToTheSeconds(dateTime1.Value, dateTime2.Value);
        }
    }
}