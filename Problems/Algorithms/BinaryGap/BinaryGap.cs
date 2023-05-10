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
            if (inGap == false && binaryValue[i] == '1')
                inGap = true;

            if (inGap == true)
            {
                if (binaryValue[i] == '0')
                    currentGapLength++;
                else
                {
                    largestGapLength = Math.Max(largestGapLength, currentGapLength);
                    currentGapLength = 0;
                }
            }
        }

        return largestGapLength;
    }
}
