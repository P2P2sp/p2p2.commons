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
    }
}