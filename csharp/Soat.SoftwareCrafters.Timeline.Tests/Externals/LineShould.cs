using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Soat.SoftwareCrafters.Timeline.Externals;
using Xunit;

namespace Soat.SoftwareCrafters.Timeline.Tests.Externals
{
    [Trait("Category", "UnitTests")]
    [Trait("Feature",  "Line")]
    public abstract partial class LineShould<TItem, TLine>
        where TItem : class, IComparable<TItem>, IEquatable<TItem>
        where TLine : ILine<TItem>
    {
        [Fact]
        public void Have_items_in_ascending_order()
        {
            var items = new[] { Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9 };
            items.Should().BeInAscendingOrder(Comparer<TItem>.Default);
        }

        [Fact]
        public void Prevent_construction_by_throwing_ArgumentNullException_given_items_null()
        {
            this.Invoking(_ => _.Sut((IList<TItem>) null))
                .Should().Throw<ArgumentNullException>();
        }

        // TODO: @Dorian => nouveau test
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Prevent_construction_by_throwing_ArgumentException_given_less_than_two_items(int count)
        {
            var itemNumbersFrom1To9 = Enumerable.Range(1, count).ToArray();
            this.Invoking(_ => _.Sut(itemNumbersFrom1To9))
                .Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Prevent_construction_by_throwing_ArgumentException_given_not_sorted_items()
        {
            this.Invoking(_ => _.Sut(2, 3, 1))
                .Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Prevent_add_by_throwing_ArgumentNullException_when_the_given_item_is_null()
        {
            var sut = Sut(1, 2);
            this.Invoking(_ => sut.Add(null))
                .Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Add_the_given_new_item_preserving_the_order()
        {
            // given
            var sut      = Sut(1, 5, 9);
            var item     = Item(4);
            var expected = Items(1, 4, 5, 9);

            // when
            sut.Add(item);

            // then
            sut.Items.Should().Equal(expected);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(9)]
        public void Not_add_the_item_given_it_is_already_in(int itemAlreadyIn)
        {
            // given
            var sut      = Sut(1, 5, 9);
            var item     = Item(itemAlreadyIn);
            var expected = Items(1, 5, 9);

            // when
            sut.Add(item);

            // then
            sut.Items.Should().Equal(expected);
        }

        [Fact]
        public void Prevent_removing_by_throwing_ArgumentNullException_when_provided_predicate_is_null()
        {
            var sut = Sut(1, 2);
            this.Invoking(_ => sut.Remove(null))
                .Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Remove_the_element_satisfying_the_predicate_given_a_three_item_line()
        {
            // given
            var sut          = Sut(1, 5, 9);
            var itemToRemove = sut.Items.First();
            var expected     = Items(5, 9);

            // when
            // TODO @Dorian: pas new Date(5) mais date(5)
            sut.Remove(item => item.Equals(itemToRemove));

            // then
            sut.Items.Should().Equal(expected);
        }

        // TODO: @Dorian => nouveau test
        [Fact]
        public void Remove_nothing_given_no_item_satisfies_the_predicate()
        {
            // given
            var sut          = Sut(1, 5, 9);
            var itemToRemove = Item(4);
            var expected     = Items(1, 5, 9);

            // when
            sut.Remove(item => item.Equals(itemToRemove));

            // then
            sut.Items.Should().Equal(expected);
        }

        [Fact]
        public void Remove_all_should_keep_at_least_two_elements()
        {
            // given
            var sut = Sut(1, 3, 5, 7, 9);
            // when
            sut.Remove(_ => true);
            // then
            sut.Items.Should().HaveCount(2);
        }

        protected TLine Sut(params int[] itemNumbersFrom1To9) =>
            Sut(Items(itemNumbersFrom1To9));

        // TODO: @Dorian => suppression du champ timeline pour privilégier l'emploi explicit de CreateSut() dans chaque test et ainsi savoir les éléments contenus dans la (time)line
        /// <remarks>Use <see cref="Items"/> to map from numbers to items</remarks>
        protected abstract TLine Sut(IList<TItem> items);

        protected IList<TItem> Items(params int[] itemNumbersFrom1To9) =>
            itemNumbersFrom1To9.Select(Item).ToList();

        private TItem Item(int numberFrom1To9)
        {
            switch (numberFrom1To9)
            {
                case 1: return Item1;
                case 2: return Item2;
                case 3: return Item3;
                case 4: return Item4;
                case 5: return Item5;
                case 6: return Item6;
                case 7: return Item7;
                case 8: return Item8;
                case 9: return Item9;

                default:
                    throw new ArgumentOutOfRangeException(nameof(numberFrom1To9), numberFrom1To9, null);
            }
        }

        protected abstract TItem Item1 { get; }
        protected abstract TItem Item2 { get; }
        protected abstract TItem Item3 { get; }
        protected abstract TItem Item4 { get; }
        protected abstract TItem Item5 { get; }
        protected abstract TItem Item6 { get; }
        protected abstract TItem Item7 { get; }
        protected abstract TItem Item8 { get; }
        protected abstract TItem Item9 { get; }
    }

    public abstract partial class LineShould<TItem, TLine> { }
}
