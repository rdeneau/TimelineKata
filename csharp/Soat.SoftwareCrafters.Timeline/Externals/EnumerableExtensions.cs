using System;
using System.Collections.Generic;
using System.Linq;

namespace Soat.SoftwareCrafters.Timeline.Externals
{
    public static class EnumerableExtensions
    {
        public static bool IsSorted<T>(this IEnumerable<T> items) where T : IComparable<T> =>
            items.ToAdjacentPairs()
                 .All(x => x.Previous.CompareTo(x.Current) <= 0);

        public static IEnumerable<(T Previous, T Current)> ToAdjacentPairs<T>(this IEnumerable<T> items)
        {
            // ReSharper disable PossibleMultipleEnumeration
            var skipFirst = items.Skip(1);
            return skipFirst.Take(1).Any()
                       ? items.Zip(skipFirst, (x, y) => (x, y))
                       : Enumerable.Empty<(T, T)>();
            // ReSharper restore PossibleMultipleEnumeration
        }
    }
}
