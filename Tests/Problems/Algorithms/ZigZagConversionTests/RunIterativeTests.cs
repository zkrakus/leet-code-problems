using Problems.Algorithms.ZigZagConversion;
using System;
using Xunit;

namespace Tests.Problems.Algorithms.ZigZagConversionTests;
public class RunIterativeTests
{
    [Fact]
    public static void Should_Init()
    {
        Assert.Equal("A", ZigZagConversion.RunIterative("A", 1));
        _ = Assert.Throws<ArgumentException>(() => ZigZagConversion.RunIterative("A", 0));
    }

    [Fact]
    public static void Should_Create_ZigZag()
    {
        Assert.Equal("AB", ZigZagConversion.RunIterative("AB", 1));
        Assert.Equal("AB", ZigZagConversion.RunIterative("AB", 2));
        Assert.Equal("ACB", ZigZagConversion.RunIterative("ABC", 2));
        Assert.Equal("ACBD", ZigZagConversion.RunIterative("ABCD", 2));
        Assert.Equal("AEBDFC", ZigZagConversion.RunIterative("ABCDEF", 3));
        Assert.Equal("AKUBJLTVCIMSWDHNRXEGOQYFPZ", ZigZagConversion.RunIterative("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 6));
    }
}
