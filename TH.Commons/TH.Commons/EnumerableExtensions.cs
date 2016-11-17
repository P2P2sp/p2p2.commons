using System;
using System.Collections.Generic;

namespace TH.Commons
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var i in enumerable)
            {
                action(i);
            }
        }

        /// <summary>
        /// Compares two enumerables.
        /// </summary>
        public static bool IsEqual<T>(this IEnumerable<T> enumerable, IEnumerable<T> value, IEqualityComparer<T> comparer = null)
        {
            var cnt = new Dictionary<T, int>(comparer);
            foreach (var s in enumerable)
            {
                if (cnt.ContainsKey(s))
                {
                    cnt[s]++;
                }
                else
                {
                    cnt.Add(s, 1);
                }
            }
            foreach (var s in value)
            {
                if (cnt.ContainsKey(s))
                {
                    cnt[s]--;
                }
                else
                {
                    return false;
                }
            }
            foreach (var c in cnt.Values)
            {
                if (c != 0) return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if enumerable consists of distinct elements.
        /// </summary>
        public static bool HasDistinctElementsBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var knownKeys = new HashSet<TKey>();
            foreach (var sourceItem in source)
            {
                if (!knownKeys.Add(keySelector(sourceItem)))
                    return false;
            }
            return true;
        }
    }
}