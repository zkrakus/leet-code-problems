using Problems.Algorithms.Triangle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.TriangleTests;
public class RunTests
{
    [Theory]
    [InlineData(1, new int[] { 10, 2, 5, 1, 8, 20 })]
    [InlineData(0, new int[] { 10, 50, 5, 1})]
    [InlineData(1, new int[] { int.MaxValue, int.MaxValue, int.MaxValue})]
    public void ShouldReturnSolution_ForInput(int assertion, int[] input)
    {
        Assert.Equal(assertion, Triangle.Run(input));
    }
}
