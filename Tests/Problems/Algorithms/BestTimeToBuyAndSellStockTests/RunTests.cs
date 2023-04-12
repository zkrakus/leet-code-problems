using Problems.Algorithms.BestTimeToBuyAndSellStock;
using System;
using Xunit;

namespace Tests.Problems.Algorithms.BestTimeToBuyAndSellStockTests;
public class RunTests
{
    [Fact]
    public void Should_Init()
    => Assert.Equal(0, BestTimeToBuyAndSellStock.RunBruteForce(Array.Empty<int>()));

    [Fact]
    public void Should_Return_Zero_When_Profit_Impossible()
    {
        Assert.Equal(0, BestTimeToBuyAndSellStock.RunBruteForce(new int[] { 0 }));
        Assert.Equal(0, BestTimeToBuyAndSellStock.RunBruteForce(new int[] { 0, 0 }));
        Assert.Equal(0, BestTimeToBuyAndSellStock.RunBruteForce(new int[] { 2, 1 }));
    }

    [Fact]
    public void Should_Return_Max_Profit()
    {
        Assert.Equal(2, BestTimeToBuyAndSellStock.RunBruteForce(new int[] { 1, 2, 3 }));
        Assert.Equal(5, BestTimeToBuyAndSellStock.RunBruteForce(new int[] { 2, 1, 4, 0, 5 }));
        Assert.Equal(5, BestTimeToBuyAndSellStock.RunBruteForce(new int[] { 0, 1, 2, 3, 4, 5 }));
        Assert.Equal(5, BestTimeToBuyAndSellStock.RunBruteForce(new int[] { 1, 5, 0, 5, 1 }));
    }
}
