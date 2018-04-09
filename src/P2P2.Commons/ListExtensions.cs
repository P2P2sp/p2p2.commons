using System.Collections.Generic;

namespace P2P2.Commons
{
    public static class ListExtensions
    {
        public static IList<T> AddRange<T>(this IList<T> list, IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// Returns true if list is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count == 0;
        }

        /// <summary>
        /// Returns true only if list is NOT null and is empty.
        /// </summary>
        public static bool IsEmpty<T>(this IList<T> list)
        {
            return list != null && list.Count == 0;
        }
    }
}