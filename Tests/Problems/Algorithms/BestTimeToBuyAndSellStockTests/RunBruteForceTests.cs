using Problems.Algorithms.BestTimeToBuyAndSellStock;
using System;
using Xunit;

namespace Tests.Problems.Algorithms.BestTimeToBuyAndSellStockTests;

public class RunBruteForceTests
{

    [Fact]
    public void Should_Init()
        => Assert.Equal(0, BestTimeToBuyAndSellStock.RunBruteForce(Array.Empty<int>()));

    [Fact]
    public void Should_Return_Zero_When_Profit_Impossible()
        => Assert.Equal(0, BestTimeToBuyAndSellStock.RunBruteForce(new int[] { 3, 2, 1 }));

    [Fact]
    public void Should_Return_Max_Profit() => Assert.Equal(2, BestTimeToBuyAndSellStock.RunBruteForce(new int[] { 1, 2, 3 }));
}
