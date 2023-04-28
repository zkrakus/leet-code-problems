using Problems.Algorithms.Brackets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.BracketsTests;
public class RunTests
{
    [Theory]
    [InlineData(1, "{[()()]}")]
    [InlineData(0, "([)()]")]
    [InlineData(1, "")]
    [InlineData(1, null)]
    [InlineData(0, "{")]

    public void ShouldReturnSolution_ForInput(int assertion, string input)
    {
        Assert.Equal(assertion, Brackets.Run(input));
    }
}
