using Problems.Algorithms.Dominator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.DominatorTests;
public class RunTests
{
    [Theory]
    [InlineData(new int[] { 0, 2, 4, 6, 7 }, new int[] { 3, 4, 3, 2, 3, -1, 3, 3 })]
    [InlineData(new int[] { 0 }, new int[]{ 1 })]
    [InlineData(new int[] { 0, 0 }, new int[] { 1 })]
    public void ShouldReturnSolution_ForInput(int[] assertion, int[] input)
    {
        Assert.Contains(Dominator.Run(input), assertion);
    }
}
