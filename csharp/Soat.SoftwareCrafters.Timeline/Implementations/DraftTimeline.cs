using System;
using System.Collections.Generic;
using System.Linq;
using Soat.SoftwareCrafters.Timeline.Externals;

namespace Soat.SoftwareCrafters.Timeline.Implementations
{
    public class DraftTimeline : ITimeline
    {
        private readonly SortedSet<Date> _items;

        public IList<Date> Items => _items.Select(Date.Clone).ToList();

        public DraftTimeline(IList<Date> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (items.Count < 2) throw new ArgumentException("At least 2 items expected", nameof(items));
            if (!items.IsSorted()) throw new ArgumentException("Sorted items expected", nameof(items));
            _items = new SortedSet<Date>(items.Select(Date.Clone));
        }

        public void Add(Date item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }

        public void Remove(Func<Date, bool> isItemToRemove)
        {
            var itemsToRemove = _items.Where(isItemToRemove).Take(_items.Count - 2).ToList();
            itemsToRemove.ForEach(item => _items.Remove(item));
        }
    }
}
