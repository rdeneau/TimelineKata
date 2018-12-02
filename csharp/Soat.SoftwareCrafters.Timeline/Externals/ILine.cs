using System;
using System.Collections.Generic;

namespace Soat.SoftwareCrafters.Timeline.Externals
{
    /// <summary>
    /// Abstraction for a collection of sorted unique items that are at least two.
    ///
    /// Class invariants:
    /// - <see cref="Items"/> should be sorted
    /// - <see cref="Items"/> should contain unique items
    /// - <see cref="Items"/> should contain at least two items
    ///
    /// For performance issue, <see cref="Items"/> should not not perform any CPU intensive task.
    /// So, they should be stored internally already satisfying all class invariants.
    ///
    /// Use <see cref="LineExtensions.IsSorted{T}"/> to verify that a given items list is sorted,
    /// which is expected for the arguments of the constructor (see unit tests).
    /// </summary>
    public interface ILine<T> where T : class, IEquatable<T>, IComparable<T>
    {
        IList<T> Items { get; }

        /// <summary>
        /// Add the given item or ignore it if it's already in
        /// </summary>
        void Add(T item);

        /// <summary>
        /// Remove all items satisfying the given predicate except the possible two remaining items.
        /// </summary>
        void Remove(Func<T, bool> isItemToRemove);
    }
}
