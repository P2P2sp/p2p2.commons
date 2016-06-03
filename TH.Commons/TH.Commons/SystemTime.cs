using System;

namespace TH.Commons
{
    public static class SystemTime
    {
        private static DateTime? value;

        public static DateTime Now
        {
            get { return value ?? DateTime.Now; }
        }

        public static DateTime UtcNow
        {
            get { return value ?? DateTime.UtcNow; }
        }

        public static DateTime Today
        {
            get { return (value ?? DateTime.Today).Date; }
        }

        public static DateTime GetInitialDate()
        {
            return new DateTime(1970, 1, 1);
        }

        public static DateTime ReplaceTime(this DateTime dt, DateTime time)
        {
            return dt.Date.AddHours(time.Hour).AddMinutes(time.Minute).AddSeconds(time.Second);
        }

        public static DateTime? ReplaceTime(this DateTime? dt, DateTime time)
        {
            if (!dt.HasValue) return null;
            return ReplaceTime(dt.Value, time);
        }

        public static void SetDateTime(DateTime newValue)
        {
            value = newValue;
        }

        public static void Reset()
        {
            value = null;
        }
    }
}