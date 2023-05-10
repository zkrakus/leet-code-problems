using Problems.Algorithms.StringPermutations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.StringPermutationsTests;
public class RunTests
{
    [Theory]
    [InlineData("ABC")]
    public void ShouldReturnSolution_ForInput(string input)
    {
        var permutations = StringPermutations.Permute(input);

        foreach (var permutation in permutations)
        {
            Console.WriteLine(permutation);
        }
    }

}
