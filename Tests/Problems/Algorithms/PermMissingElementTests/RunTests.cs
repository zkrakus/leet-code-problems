using Problems.Algorithms.PermMissingElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.PermMissingElementTests;
public class RunTests
{

    [Theory]
    [InlineData(new int[] { 2 }, 1)]
    [InlineData(new int[] { }, 1)]
    [InlineData(new int[] { 5, 3, 1, 2 }, 4)]
    public void ShouldReturnSolution_ForInput(int[] input, int assertion)
    {
        Assert.Equal(assertion, PermMissingElement.Run(input));
    }
}
