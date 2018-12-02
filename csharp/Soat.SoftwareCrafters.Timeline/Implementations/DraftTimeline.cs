using System;
using System.Collections.Generic;
using System.Linq;
using Soat.SoftwareCrafters.Timeline.Externals;

namespace Soat.SoftwareCrafters.Timeline.Implementations
{
    public class DraftTimeline : ITimeline
    {
        public IList<Date> Items { get; }

        public DraftTimeline(IList<Date> items)
        {
            Items = items;
        }

        public void Add(Date item)
        {
            Items.Add(item);
        }

        public void Remove(Func<Date, bool> isItemToRemove)
        {
            var itemsToRemove = Items.Where(isItemToRemove).ToList();
            itemsToRemove.ForEach(item => Items.Remove(item));
        }
    }
}
