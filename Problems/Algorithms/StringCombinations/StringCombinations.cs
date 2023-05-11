using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.StringCombinations;
public static class StringCombinations
{
    public static void Combine(string s)
    {

    }

    public static void CombineRec(string s, string data, int start, int end, int index, int r)
    {
        if (index == r)
        {
            for (var j = 0; j < r; j++)
                Console.Write(data[j] + " ");
            Console.WriteLine("");
            return;
        }
    }
}
