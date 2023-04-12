using Problems.Algorithms.CountAnalogousArrays;
using Xunit;

namespace Tests.Problems.Algorithms.CountAnalagousArraysTests;

public class RunTests
{
    [Fact]
    public static void Should_Find_AnalogousArrays()
    {
        Assert.Equal(1, CountAnalagousArrays.Run(new int[] { 0 }, 0, 0));
        Assert.Equal(2, CountAnalagousArrays.Run(new int[] { 0, 0 }, 0, 1));
        Assert.Equal(0, CountAnalagousArrays.Run(new int[] { 2 }, 1, -1));
        Assert.Equal(3, CountAnalagousArrays.Run(new int[] { 10 }, -1, 1));
        Assert.Equal(0, CountAnalagousArrays.Run(new int[] { -2, -1, 0, 1, 2 }, -1, 1));
        Assert.Equal(3, CountAnalagousArrays.Run(new int[] { -2, -1, 0, 1, 2 }, -2, 4));
    }
}
