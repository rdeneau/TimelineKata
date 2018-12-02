using System;

namespace Soat.SoftwareCrafters.Timeline.Externals
{
    public static class LineExtensions
    {
        public static bool IsSorted<T>(this ILine<T> @this) where T : class, IEquatable<T>, IComparable<T> =>
            @this.Items.IsSorted();
    }
}
