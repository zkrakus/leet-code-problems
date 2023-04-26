using Problems.Algorithms.TapeEquilibrium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.TapeEquilibriumTests;
public class RunTests
{
    [Fact]
    public void ShouldReturnSolution_ForInput()
    {
        var input = new int[] { 3, 1, 2, 4, 3 };
        Assert.Equal(1, TapeEquilibrium.Run(input));
    }
}
