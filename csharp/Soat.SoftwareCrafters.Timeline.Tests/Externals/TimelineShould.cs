using Soat.SoftwareCrafters.Timeline.Externals;

namespace Soat.SoftwareCrafters.Timeline.Tests.Externals
{
    public abstract partial class TimelineShould<TTimeline> : LineShould<Date, TTimeline> where TTimeline : ITimeline
    {
        protected override Date Item1 => new Date(2001, 1, 1);
        protected override Date Item2 => new Date(2002, 1, 1);
        protected override Date Item3 => new Date(2003, 1, 1);
        protected override Date Item4 => new Date(2004, 1, 1);
        protected override Date Item5 => new Date(2005, 1, 1);
        protected override Date Item6 => new Date(2006, 1, 1);
        protected override Date Item7 => new Date(2007, 1, 1);
        protected override Date Item8 => new Date(2008, 1, 1);
        protected override Date Item9 => new Date(2009, 1, 1);
    }

    public abstract partial class TimelineShould<TTimeline> where TTimeline : ITimeline { }
}
