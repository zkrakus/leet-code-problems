using Problems.Algorithms.ArraysAndHashing.CyclicRotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.ArraysAndHashing.CyclicRotationTests;
public class RunTests
{
    [Theory]
    [InlineData(new int[] { }, 0, new int[] { })] // Empty Array
    [InlineData(new int[] { 1 }, 1, new int[] { 1 })] // One element
    [InlineData(new int[] { 1, 2, 3, 4 }, 2, new int[] { 3, 4, 1, 2 })] // K < N
    [InlineData(new int[] { 1, 2, 3, 4 }, 4, new int[] { 1, 2, 3, 4 })] // K == N
    [InlineData(new int[] { 1, 2, 3, 4 }, 5, new int[] { 4, 1, 2, 3 })] // K > N
    public void Run_ShouldReturnRotatedArray(int[] a, int k, int[] rotatedArray)
    {
        Assert.Equal(rotatedArray, CyclicRotation.Run(a, k));
    }
}
