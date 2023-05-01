using Problems.Algorithms.MaxProfit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.MaxProfitTests;
public class RunTests
{
    [Theory]
    [InlineData(356, new int[] { 23171, 21011, 21123, 21013, 21367 })]
    public void ShouldReturnSolutionForInput(int assertion, int[] input)
    {
        Assert.Equal(assertion, MaxProfit.Run(input));
    }
}
