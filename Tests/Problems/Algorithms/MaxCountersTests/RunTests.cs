using Problems.Algorithms.MaxCounters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.MaxCountersTests;
public class RunTests
{
    [Theory]
    [InlineData(5, new int[] { 3, 4, 4, 6, 1, 4, 4}, new int[] { 3, 2, 2, 4, 2 })]
    public void ShouldReturnSolution_ForInput(int n, int[] a, int[] assertion)
    {
        Assert.Equal(assertion, MaxCounters.Run(n, a));
    }
}
