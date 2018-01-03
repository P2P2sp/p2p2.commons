using System;
using System.Collections.Generic;
using System.Linq;

namespace TH.Commons
{
    /// <summary>
    /// Class providing a set of helper methods concerning System.DayOfWeek enum
    /// </summary>
    public static class DayOfWeekHelpers
    {
        /// <summary>
        /// Returns a 7 elements list, sorted from monday do sunday.
        /// </summary>
        /// <returns></returns>
        public static List<DayOfWeek> GetDaysOfWeekStartingWithMonday()
        {
            return new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday }
                .ToList();
        }
    }
}
