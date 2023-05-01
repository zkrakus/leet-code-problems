using Problems.Algorithms.CountNonDivisible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.CountNonDivisibleTests;
public class RunTests
{
    [Theory]
    [InlineData(new int[] { 2, 4, 3, 2, 0 }, new int[] { 3, 1, 2, 3, 6})]
    public void ShouldReturnSolution_ForInput(int[] assertion, int[] input)
    {
        Assert.Equal(assertion, CountNonDivisible.Run(input));
    }
}
