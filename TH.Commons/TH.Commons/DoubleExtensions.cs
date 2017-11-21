using System;

namespace TH.Commons
{
    /// <summary>
    /// Decimal extension methods
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Returns double rounded "towards zero" to integer value, which means rounded down for positive numbers, and rounded up for negative numbers.
        /// </summary>
        public static double Truncate(this double d)
        {
            return d > 0 ? Math.Floor(d) : Math.Ceiling(d);
        }
    }
}