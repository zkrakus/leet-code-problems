using Problems.Algorithms.CountFactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.CountFactorsTests;
public class RunTests
{
    [Theory]
    [InlineData(8, 24)]
    [InlineData(8, -24)]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(2, 3)]
    public void ShouldReturnSolutionForInput(int assertion, int input)
    {
        Assert.Equal(assertion, CountFactors.Run(input));
    }
}
