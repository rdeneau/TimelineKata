using System.Collections.Generic;
using FluentAssertions;
using Soat.SoftwareCrafters.Timeline.Externals;
using Xunit;

namespace Soat.SoftwareCrafters.Timeline.Tests.Externals
{
    // ReSharper disable once UnusedTypeParameter
    public partial class TimelineShould<TTimeline> where TTimeline : ITimeline
    {
        [Fact]
        public void Changes_on_an_input_item_should_not_impact_encapsulated_item()
        {
            // given
            var items = Items(1, 3, 5);
            var sut   = Sut(items);
            // when
            MakeFirstItemGreaterThanTheLastItem(items);
            // then
            sut.IsSorted().Should().BeTrue();
        }

        [Fact]
        public void Changes_on_an_output_item_should_not_impact_encapsulated_item()
        {
            // given
            var sut = Sut(1, 3, 5);
            // when
            MakeFirstItemGreaterThanTheLastItem(sut.Items);
            // then
            sut.IsSorted().Should().BeTrue();
        }

        private static void MakeFirstItemGreaterThanTheLastItem(IList<Date> items)
        {
            var last  = items[items.Count - 1];
            var first = items[0];
            first.AddYears(last.Year - first.Year + 1);
        }
    }
}
