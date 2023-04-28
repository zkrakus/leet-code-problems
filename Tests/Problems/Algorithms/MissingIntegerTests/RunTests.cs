using Problems.Algorithms.MissingInteger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.MissingIntegerTests;
public class RunTests
{

    [Fact]
    public void ShouldReturnSolution_ForInput()
    {
        Assert.Equal(4, MissingInteger.RunOptimized(new int[] { 1, 2, 3 }));
    }
}
