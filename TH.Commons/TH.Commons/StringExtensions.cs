using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TH.Commons
{
    public static class StringExtensions
    {
        public static string Trim(this string value, int maxLength)
        {
            if (!value.IsNullOrEmpty() && value.Length > maxLength)
            {
                return value.Trim().Substring(0, maxLength);
            }
            return value;
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string Hash(this string s, string salt = null)
        {
            var hash = new StringBuilder();
            using (var sha = new System.Security.Cryptography.SHA256CryptoServiceProvider())
            {
                var data = Encoding.UTF8.GetBytes(salt == null ? s : salt + s);
                var result = sha.ComputeHash(data);
                foreach (var b in result) hash.Append(b.ToString("x2"));
            }
            return hash.ToString();
        }

        public static string ToTitleCase(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public static string ToPlain(this string input)
        {
            // 2 - Strip diacritical marks using Michael Kaplan's function or equivalent
            return RemoveDiacritics(input);
        }

        public static string ToSlug(this string input)
        {
            input = RemoveDiacritics(input).ToLowerInvariant();
            input = ReplaceNonWordWithDashes(input);
            return input.Trim(' ', '-');
        }


        // http://blogs.msdn.com/michkap/archive/2007/05/14/2629747.aspx
        /// <summary>
        /// Strips the value from any non English character by replacing those with their English equivalent.
        /// </summary>
        /// <param name="value">The string to normalize.</param>
        /// <returns>A string where all characters are part of the basic English ANSI encoding.</returns>
        /// <seealso cref="http://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net"/>
        private static string RemoveDiacritics(string value)
        {
            var stFormD = value.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var t in stFormD.Where(t => CharUnicodeInfo.GetUnicodeCategory(t) != UnicodeCategory.NonSpacingMark))
            {
                sb.Append(NormalizeChar(t));
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private static char NormalizeChar(char c)
        {
            switch (c)
            {
                case 'ą':
                    return 'a';
                case 'ć':
                    return 'c';
                case 'ę':
                    return 'e';
                case 'ł':
                    return 'l';
                case 'ń':
                    return 'n';
                case 'ó':
                    return 'o';
                case 'ś':
                    return 's';
                case 'ż':
                case 'ź':
                    return 'z';
            }
            return c;
        }

        private static string ReplaceNonWordWithDashes(string title)
        {
            title = Regex.Replace(title, "[’'“”\"&]{1,}", "", RegexOptions.None);
            var builder = new StringBuilder();
            foreach (var t in title)
            {
                builder.Append(char.IsLetterOrDigit(t) ? t : ' ');
            }
            return Regex.Replace(builder.ToString(), "[ ]{1,}", "-", RegexOptions.None);
        }

        /// <summary>
        /// Checks if given string is proper currency value (only 2 decimals allowed), and within given min-max inclusive values.
        /// </summary>
        public static bool IsValidCurrencyNumber(string x, decimal minValueInclusive = decimal.MinValue, decimal maxValueInclusive = decimal.MaxValue)
        {
            decimal d;
            if (decimal.TryParse(x, out d))
                return d >= minValueInclusive && d <= maxValueInclusive && Math.Round(d, 2) == d;
            return false;
        }

        /// <summary>
        /// Trims string only if it's longer than maxLength. 
        /// Is so, it returns trimmed string with provided suffix at the end, which combined are no longer than maxLength.
        /// For value = "test56789" and maxLength = 8 and suffix = "...", returns: "test5...".
        /// </summary>
        /// <returns>String no longer than maxLength</returns>
        public static string Trim(this string value, int maxLength, string suffixIfTrimmed)
        {
            return value.Length > maxLength
                ? $"{value.Trim(maxLength - suffixIfTrimmed.Length)}{suffixIfTrimmed}"
                : value;
        }
    }
}