using Problems.Algorithms.BinaryGap;
using Problems.Algorithms.FrogJump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.FrogJumpTests;
public class RunTests
{
    [Theory]
    [InlineData(5, 5, 5, 0)] // No jump needed.
    [InlineData(15, 35, 6, 4)] // Jump.
    public void Run_ShouldReturnSolution_ForInput(int x, int y, int d, int assertion)
    {
        Assert.Equal(assertion, FrogJump.Run(x, y, d));
    }
}
