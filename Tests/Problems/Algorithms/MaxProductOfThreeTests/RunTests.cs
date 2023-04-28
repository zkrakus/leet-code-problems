using Problems.Algorithms.MaxProuctOfThree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.MaxProductOfThreeTests;
public class RunTests
{
    [Theory]
    [InlineData(-120, new int[] {-5, -6, -4, -7, -10})]
    [InlineData(105, new int[] { 4, 7, 3, 2, 1, -3, -5 })]
    public void ShouldReturnSolution_ForInput(int assertion, int[] input)
    {
        Assert.Equal(assertion, MaxProductOfThree.Run(input));
    }
}
