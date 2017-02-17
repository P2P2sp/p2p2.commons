namespace TH.Commons
{
    /// <summary>
    /// Integer extensions
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Returns full hours and remainder of minutes from given minutes value
        /// </summary>
        public static string ToStringHoursAndMinutes(this int minutes)
        {
            if (minutes < 60) return $"{minutes}";
            var hours = minutes / 60;
            var rest = minutes % 60;
            return $"{hours}g {rest}m";
        }
    }
}
