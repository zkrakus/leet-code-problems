using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.BinaryGap;

public static class BinaryGap
{
    /// <summary>
    /// Problem:
    /// A binary gap within a positive integer N is any maximal sequence of consecutive zeros that is
    /// surrounded by ones at both ends in the binary representation of N.
    ///
    /// Analysis:
    /// t(n) => O(1)
    /// s(n) => O(1)
    /// </summary>
    public static int Run (int n)
    {
        var binaryValue = Convert.ToString(n, 2).ToString();
        var largestGapLength = 0;
        var currentGapLength = 0;

        var inGap = false;
        for(var i = 0; i < binaryValue.Length; i++)
        {
            if (binaryValue[i] == '1' && inGap == false)
                inGap = true;
            else if (inGap == true && binaryValue[i] == '0')
                currentGapLength++;
            else if (binaryValue[i] == '1' && inGap == true)
            {
                largestGapLength = Math.Max(largestGapLength, currentGapLength);
                currentGapLength = 0;
            } 
        }

        return largestGapLength;
    }
}
