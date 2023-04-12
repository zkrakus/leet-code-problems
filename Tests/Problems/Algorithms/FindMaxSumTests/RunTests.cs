using Problems.Algorithms.FindMaxSum;
using System;
using Xunit;

namespace Tests.Problems.Algorithms.FindMaxSumTests;

public class RunTests
{

    [Fact]
    public static void Should_Init()
    {
        _ = Assert.Throws<ArgumentException>(() => FindMaxSum.Run(Array.Empty<int>()));
        _ = Assert.Throws<ArgumentException>(() => FindMaxSum.Run(new int[] { 0 }));
    }

    [Fact]
    public static void Should_Find_Max_Sum()
    {
        Assert.Equal(2, FindMaxSum.Run(new int[] { 1, 1 }));
        Assert.Equal(5, FindMaxSum.Run(new int[] { 3, 2, 1 }));
        Assert.Equal(5, FindMaxSum.Run(new int[] { 1, 2, 3 }));
        Assert.Equal(6, FindMaxSum.Run(new int[] { 3, 3 }));
        Assert.Equal(8, FindMaxSum.Run(new int[] { 4, 3, 4, 3 }));
        Assert.Equal(8, FindMaxSum.Run(new int[] { 3, 4, 3, 4 }));
    }
}
