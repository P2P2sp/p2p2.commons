using System;
using System.Collections.Generic;

namespace P2P2.Commons
{
    public class PairDates
    {
        public PairDates(DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate) throw new ArgumentException($"Date from '{fromDate:d}' cannot be later than date to '{toDate:d}'.");
            FromDate = fromDate.Date;
            ToDate = toDate.Date;
        }

        public DateTime FromDate { get; }
        public DateTime ToDate { get; }
        public DateTime GetToDateExclusive() => ToDate.AddDays(1);

        public override string ToString()
        {
            return $"{FromDate:dd.MM.yyyy} - {ToDate:dd.MM.yyyy}";
        }

        public IEnumerable<DateTime> GetMonths()
        {
            return GetMonths(FromDate, ToDate);
        }

        public static IEnumerable<DateTime> GetMonths(DateTime fromDate, DateTime toDate)
        {
            var monthYear = fromDate.GetMonthAndYear();
            var toMonthYear = toDate.GetMonthAndYear();
            while (monthYear <= toMonthYear)
            {
                yield return monthYear;
                monthYear = monthYear.AddMonths(1);
            }
        }

        /// <summary>
        /// Returns list of dates segments, that groups given date range (from-to) into weeks (default monday-sunday).
        /// </summary>
        public List<PairDates> GetWeeks()
        {
            return GetWeeks(this);
        }

        /// <summary>
        /// Returns list of dates segments, that groups given date range (from-to) into weeks (default monday-sunday).
        /// </summary>
        public static List<PairDates> GetWeeks(DateTime fromDate, DateTime toDate, DayOfWeek lastDayOfWeek = DayOfWeek.Sunday)
        {
            var pair = new PairDates(fromDate, toDate);
            return GetWeeks(pair, lastDayOfWeek);
        }

        /// <summary>
        /// Returns list of dates segments, that groups given date range (from-to) into weeks (default monday-sunday).
        /// </summary>
        public static List<PairDates> GetWeeks(PairDates pair, DayOfWeek lastDayOfWeek = DayOfWeek.Sunday)
        {
            var result = new List<PairDates>();
            if (pair.ToDate < pair.FromDate) return result;
            var currentWeekStart = pair.FromDate;
            var currentWeekEnd = currentWeekStart.GetDateNextOrCurrent(lastDayOfWeek);
            while (currentWeekEnd < pair.ToDate)
            {
                result.Add(new PairDates(currentWeekStart, currentWeekEnd));
                currentWeekStart = currentWeekEnd.AddDays(1);
                currentWeekEnd = currentWeekEnd.AddDays(7);
            }
            result.Add(new PairDates(currentWeekStart, pair.ToDate));
            return result;
        }

        public IEnumerable<DateTime> GetDays()
        {
            return GetDays(this);
        }

        public static IEnumerable<DateTime> GetDays(DateTime fromDate, DateTime toDate)
        {
            return GetDays(new PairDates(fromDate, toDate));
        }

        public static IEnumerable<DateTime> GetDays(PairDates pair)
        {
            var currentDate = pair.FromDate;
            while (currentDate <= pair.ToDate)
            {
                yield return currentDate;
                currentDate = currentDate.AddDays(1);
            }
        }

        public static DateTime GetMaxDate(DateTime date1, DateTime date2)
        {
            date1 = date1.Date;
            date2 = date2.Date;
            return date1 > date2 ? date1 : date2;
        }

        public static DateTime GetMinDate(DateTime date1, DateTime date2)
        {
            date1 = date1.Date;
            date2 = date2.Date;
            return date1 < date2 ? date1 : date2;
        }

        public bool ContainsDate(DateTime value)
        {
            return FromDate <= value.Date && value.Date <= ToDate;
        }
    }
}