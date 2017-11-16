namespace TH.Commons
{
    /// <summary>
    /// Decimal extension methods
    /// </summary>
    public static class DecimalExtensions
    {
        /// <summary>
        /// Returns decimal rounded down (or "towards zero") to given decimals count. 
        /// For 1,279 and 2 decimals, returns 1,27. For -2,7654 and 1 decimals returns -2,7. And so on.
        /// </summary>
        public static decimal Truncate(this decimal d, byte decimals)
        {
            var r = decimal.Round(d, decimals);

            if (d > 0 && r > d)
            {
                return r - new decimal(1, 0, 0, false, decimals);
            }
            if (d < 0 && r < d)
            {
                return r + new decimal(1, 0, 0, false, decimals);
            }

            return r;
        }
    }
}
