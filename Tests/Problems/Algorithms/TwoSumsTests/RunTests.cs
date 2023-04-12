using Problems.Algorithms.TwoSums;
using System;
using System.Linq;
using Xunit;

namespace Tests.Problems.Algorithms.TwoSumsTests;
public class RunTests
{
    [Fact]
    public static void Should_Init()
    {
        _ = Assert.Throws<ArgumentException>(() => TwoSums.Run(Array.Empty<int>(), 0));
        _ = Assert.Throws<ArgumentException>(() => TwoSums.Run(new int[] { 0, 1 }, 0));
    }

    [Fact]
    public static void Should_Find_Sum()
    {
        Assert.True(
            TwoSums.Run(new int[] { 0, 1 }, 1).SequenceEqual(
new int[] { 0, 1 }));

        Assert.True(
            TwoSums.Run(new int[] { 1, 1 }, 2).SequenceEqual(
new int[] { 0, 1 }));

        Assert.True(
            TwoSums.Run(new int[] { 1, 2, 3, 4, 5 }, 6).SequenceEqual(
new int[] { 1, 3 }));
    }
}
