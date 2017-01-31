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
    }
}
