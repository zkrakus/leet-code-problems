using Problems.Algorithms.ContainerWithTheMostWater;
using System;
using Xunit;

namespace Tests.Problems.Algorithms.ContainWithTheMostWaterTests;
public class RunOptimizedTests
{
    [Fact]
    public void Should_Init()
    {
        Assert.Equal(0, ContainerWithTheMostWater.RunOptimized(Array.Empty<int>()));
        Assert.Equal(0, ContainerWithTheMostWater.RunOptimized(new int[] { 12 }));
    }

    [Fact]
    public void Should_Find_Max_Area() =>
        //Assert.Equal(5, ContainerWithTheMostWater.RunOptimized(new int[] { 5, 5 }));
        Assert.Equal(5, ContainerWithTheMostWater.RunOptimized(new int[] { 1, 5, 5, 1 }));//Assert.Equal(25, ContainerWithTheMostWater.RunOptimized(new int[] { 5, 1, 1, 1, 1, 5 }));//Assert.Equal(20, ContainerWithTheMostWater.RunOptimized(new int[] { 4, 1, 1, 1, 1, 6 }));
}
