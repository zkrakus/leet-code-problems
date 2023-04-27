using Microsoft.Identity.Client;
using Problems.Algorithms.PermutationCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.PermutationCheckTests;
public class RunTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, 1)]
    [InlineData(new int[] { 1, 1, 1, 7 }, 0)]
    public void ShouldReturnSolution_ForInput(int[] input, int assertion)
    {
        Assert.Equal(assertion, PermutationCheck.Run(input));
    }
}
