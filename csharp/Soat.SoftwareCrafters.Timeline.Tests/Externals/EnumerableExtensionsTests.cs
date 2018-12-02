using System;
using System.Linq;
using FluentAssertions;
using Soat.SoftwareCrafters.Timeline.Externals;
using Xunit;

namespace Soat.SoftwareCrafters.Timeline.Tests.Externals
{
    public static class EnumerableExtensionsTests
    {
        public class IsSortedShould
        {
            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(100)]
            public void Be_true_given_any_range_of_numbers(int count)
            {
                Enumerable.Range(1, count)
                          .IsSorted()
                          .Should()
                          .Be(true);
            }

            [Theory]
            [InlineData("a,b")]
            [InlineData("a,b,b")]
            [InlineData("a,a,b")]
            public void Be_true_given_sorted_letters(string letters)
            {
                letters.Split(',')
                       .IsSorted()
                       .Should()
                       .Be(true);
            }

            [Theory]
            [InlineData("b,a")]
            [InlineData("b,b,a")]
            [InlineData("b,a,a")]
            public void Be_false_given_unsorted_letters(string letters)
            {
                letters.Split(',')
                       .IsSorted()
                       .Should()
                       .Be(false);
            }

            [Theory]
            [InlineData("2,1")]
            [InlineData("2,2,1")]
            public void Be_false_given_unsorted_numbers(string numbers)
            {
                numbers.Split(',')
                       .Select(int.Parse)
                       .IsSorted()
                       .Should()
                       .Be(false);
            }
        }

        public class ToAdjacentPairsShould
        {
            [Theory]
            [InlineData("", "")]
            [InlineData("a", "")]
            [InlineData("a,b", "a,b")]
            [InlineData("a,b,c", "a,b|b,c")]
            public void Return_expected_pairs(string values, string expectedPairs)
            {
                var expected = expectedPairs.Split('|', StringSplitOptions.RemoveEmptyEntries)
                                            .Select(pair =>
                                            {
                                                var items = pair.Split(',');
                                                return (items[0], items[1]);
                                            });
                values.Split(',', StringSplitOptions.RemoveEmptyEntries)
                      .ToAdjacentPairs()
                      .Should()
                      .Equal(expected);
            }
        }
    }
}
