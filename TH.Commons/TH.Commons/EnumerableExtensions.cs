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

        public static bool AreSame<T>(this IEnumerable<T> enumerable, IEnumerable<T> value)
        {
            return enumerable.All(value.Contains);
        }
    }
}