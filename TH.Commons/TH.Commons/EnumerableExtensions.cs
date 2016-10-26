using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEqual<T>(this IEnumerable<T> enumerable, IEnumerable<T> value)
        {
            return enumerable.All(value.Contains);
        }
    }
}