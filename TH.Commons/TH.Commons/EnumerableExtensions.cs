using System.Collections.Generic;

namespace TH.Commons
{
    public static class EnumerableExtensions
    {
        public static IList<T> AddRange<T>(this IList<T> en, IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                en.Add(item);
            }
            return en;
        }

        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count == 0;
        }

        /// <summary>
        /// Returns true only if list is NOT null, and is empty
        /// </summary>
        public static bool IsEmptyList<T>(this IList<T> list)
        {
            return list != null && list.Count == 0;
        }
    }
}