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
        public void Adding_an_item_in_the_output_list_should_not_change_encapsulated_list()
        {
            // given
            var sut = Sut(1, 3, 5);
            // when
            sut.Items.Add(Item2);
            // then
            sut.IsSorted().Should().BeTrue();
        }

        [Fact]
        public void Changes_on_the_output_reference_list_should_not_impact_encapsulated_list()
        {
            // given
            var sut = Sut(1, 3, 5);
            // when
            sut.Items.Clear();
            // then
            sut.Items.Should().HaveCount(3);
        }
    }
}
