﻿using System;
// ReSharper disable UnusedMember.Global

namespace P2P2.Commons
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

        /// <summary>
        /// Returns new DateTime with only year and month from original value, and day set to first day.
        /// </summary>
        public static DateTime GetMonthAndYear(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }

        /// <summary>
        /// For given DateTime value, method returns the closest date after, which DayOfWeek property equal to given dayOfWeek parameter, 
        /// or returns given DateTime value, if its DayOfWeek equals given dayOfWeek parameter.
        /// </summary>
        public static DateTime GetDateNextOrCurrent(this DateTime value, DayOfWeek dayOfWeek)
        {
            var date = value.Date;
            var dif = dayOfWeek - date.DayOfWeek;
            if (dif < 0) dif += 7;
            return date.AddDays(dif);
        }

        /// <summary>
        /// For given DateTime value, method returns the closest date after, which DayOfWeek property equal to given dayOfWeek parameter.
        /// </summary>
        public static DateTime GetDateNext(this DateTime value, DayOfWeek dayOfWeek)
        {
            var date = value.Date;
            var dif = dayOfWeek - date.DayOfWeek;
            if (dif <= 0) dif += 7;
            return date.AddDays(dif);
        }

        /// <summary>
        /// For given DateTime value, method returns the closest date before, which DayOfWeek property equal to given dayOfWeek parameter, 
        /// or returns given DateTime value, if its DayOfWeek equals given dayOfWeek parameter.
        /// </summary>
        public static DateTime GetDatePreviousOrCurrent(this DateTime value, DayOfWeek dayOfWeek)
        {
            var date = value.Date;
            var dif = dayOfWeek - date.DayOfWeek;
            if (dif > 0) dif -= 7;
            return date.AddDays(dif);
        }

        /// <summary>
        /// For given DateTime value, method returns the closest date before, which DayOfWeek property equal to given dayOfWeek parameter.
        /// </summary>
        public static DateTime GetDatePrevious(this DateTime value, DayOfWeek dayOfWeek)
        {
            var date = value.Date;
            var dif = dayOfWeek - date.DayOfWeek;
            if (dif >= 0) dif -= 7;
            return date.AddDays(dif);
        }

        /// <summary>
        /// Returns true if DayOfWeek part of provided DateTime is saturday or sunday.
        /// </summary>
        public static bool IsWeekend(this DateTime value)
        {
            return value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Rounds given datetime to closest full hour but only if rounding is less or equal to given limit in max minutes gap parameter.
        /// It doesn't take seconds into consideration. Only raw Minutes value of provided DateTime value.
        /// So given 15 as max minutes gap: for 14:15 will return 14:00, for 14:16 will return 14:16, for 12:45 will return 13:00, and for 12:40 will return 12:40.
        /// When max minutes gap parameter equals zero, returns original value.
        /// </summary>
        public static DateTime RoundToFullHour(this DateTime value, int maxMinutesGap)
        {
            if (maxMinutesGap == 0)
                return value;
            if (value.Minute <= maxMinutesGap)
                return new DateTime(value.Year, value.Month, value.Day, value.Hour, 0, 0);
            if (value.Minute >= 60 - maxMinutesGap)
                return new DateTime(value.Year, value.Month, value.Day, value.Hour, 0, 0).AddHours(1);
            return value;
        }

        //public static DateTime RoundDown(this DateTime dt, TimeSpan rounding)
        //{
        //    return new DateTime((dt.Ticks / rounding.Ticks) * rounding.Ticks, dt.Kind);
        //}

        //public static DateTime RoundUp(this DateTime dt, TimeSpan rounding)
        //{
        //    return new DateTime((dt.Ticks + rounding.Ticks - 1) / rounding.Ticks * rounding.Ticks, dt.Kind);
        //}
    }
}