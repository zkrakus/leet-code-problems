using Core;
using Problems.Algorithms.BestTimeToBuyAndSellStock;
using Problems.Algorithms.BinaryGap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.BinaryGapTests;
public class RunTests
{

    [Theory]
    [InlineData(1041, 5)]
    [InlineData(74901729, 4)]
    [InlineData(1376796946, 5)]
    [InlineData(1610612737, 28)]
    public void Run_ShouldReturnSolution_ForInput(int value, int assertion)
    {
        Assert.Equal(assertion, BinaryGap.Run(value));
    }
}
