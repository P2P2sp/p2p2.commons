using System;

namespace TH.Commons
{
    public static class SystemTime
    {
        private static DateTime? value;

        public static DateTime Now => value ?? DateTime.Now;

        public static DateTime UtcNow => value ?? DateTime.UtcNow;

        public static DateTime Today => (value ?? DateTime.Today).Date;

        public static DateTime GetEpohDate()
        {
            return new DateTime(1970, 1, 1);
        }

        public static DateTime ReplaceTime(this DateTime dt, DateTime time)
        {
            return dt.Date.AddTicks(time.TimeOfDay.Ticks);
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