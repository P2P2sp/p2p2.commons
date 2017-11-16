using System.Globalization;
using System.Linq;
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

        public static string ToString(this int x, string one, string twoFour, string zeroOrOther)
        {
            var lastCharInX = int.Parse(x.ToString(CultureInfo.InvariantCulture).Last().ToString(CultureInfo.InvariantCulture));
            if (x == 1)
            {
                return string.Format(one, x);
            }
            if (lastCharInX > 1 && lastCharInX < 5 && (x < 10 || x > 21))
            {
                return string.Format(twoFour, x);
            }
            return string.Format(zeroOrOther, x);
        }
    }
}
