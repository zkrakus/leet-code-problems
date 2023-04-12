using Problems.Algorithms.ZigZagConversion;
using System;
using Xunit;

namespace Tests.Problems.Algorithms.ZigZagConversionTests;
public class RunMathemeticalExpressionTests
{
    [Fact]
    public static void Should_Init()
    {
        Assert.Equal("A", ZigZagConversion.RunMathemeticalExpression("A", 1));
        _ = Assert.Throws<ArgumentException>(() => ZigZagConversion.RunMathemeticalExpression("A", 0));
    }

    [Fact]
    public static void Should_Create_ZigZag()
    {
        Assert.Equal("AB", ZigZagConversion.RunMathemeticalExpression("AB", 1));
        Assert.Equal("AB", ZigZagConversion.RunMathemeticalExpression("AB", 2));
        Assert.Equal("ACB", ZigZagConversion.RunMathemeticalExpression("ABC", 2));
        Assert.Equal("ACBD", ZigZagConversion.RunMathemeticalExpression("ABCD", 2));
        Assert.Equal("AEBDFC", ZigZagConversion.RunMathemeticalExpression("ABCDEF", 3));
        Assert.Equal("AGMBFHLNCEIKODJP", ZigZagConversion.RunMathemeticalExpression("ABCDEFGHIJKLMNOP", 4));
        Assert.Equal("AKUBJLTVCIMSWDHNRXEGOQYFPZ", ZigZagConversion.RunMathemeticalExpression("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 6));
    }
}
