using FluentAssertions;
using Soat.SoftwareCrafters.Timeline.Externals;
using Xunit;

namespace Soat.SoftwareCrafters.Timeline.Tests.Externals
{
    // ReSharper disable UnusedTypeParameter
    public partial class LineShould<TItem, TLine>
    // ReSharper restore UnusedTypeParameter
    {
        [Fact]
        public void Adding_an_item_in_the_input_list_should_not_change_encapsulated_list()
        {
            // given
            var items = Items(1, 3, 5);
            var sut   = Sut(items);
            // when
            items.Add(Item2); // => [1, 3, 5, 2]
            // then
            sut.IsSorted().Should().BeTrue();
        }

        [Fact]
        public void Changes_on_the_input_reference_list_should_not_impact_encapsulated_list()
        {
            // given
            var items = Items(1, 3, 5);
            var sut   = Sut(items);
            // when
            items.Clear();
            // then
            sut.Items.Should().HaveCount(3);
        }
    }
}
