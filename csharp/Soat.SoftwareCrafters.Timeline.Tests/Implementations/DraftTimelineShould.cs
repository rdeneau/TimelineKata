using System.Collections.Generic;
using Soat.SoftwareCrafters.Timeline.Externals;
using Soat.SoftwareCrafters.Timeline.Implementations;
using Soat.SoftwareCrafters.Timeline.Tests.Externals;

namespace Soat.SoftwareCrafters.Timeline.Tests.Implementations
{
    public class DraftTimelineShould : TimelineShould<DraftTimeline>
    {
        protected override DraftTimeline Sut(IList<Date> items) => new DraftTimeline(items);
    }
}
