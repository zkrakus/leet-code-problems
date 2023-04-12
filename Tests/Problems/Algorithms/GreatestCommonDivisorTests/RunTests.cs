using Problems.Algorithms.GreatestCommonDivisor;
using System;
using Xunit;

namespace Tests.Problems.Algorithms.GreatestCommonDivisorTests;

public class RunTests
{
    [Fact]
    public void Should_Init()
    {
        _ = Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.RunOptimized(Array.Empty<int>()));
        _ = Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.RunOptimized(new int[] { 0 }));
    }

    [Fact]
    public void Should_Return_One_When_No_GCD() => Assert.Equal(1, GreatestCommonDivisor.RunOptimized(new int[] { 3, 1 }));

    [Fact]
    public void Should_Find_GCD()
    {
        Assert.Equal(1, GreatestCommonDivisor.RunOptimized(new int[] { 1, 1 }));
        Assert.Equal(3, GreatestCommonDivisor.RunOptimized(new int[] { 3, 3 }));
        Assert.Equal(3, GreatestCommonDivisor.RunOptimized(new int[] { 6, 9 }));
        Assert.Equal(7, GreatestCommonDivisor.RunOptimized(new int[] { 28, 21, 14, 7 }));
    }
}
