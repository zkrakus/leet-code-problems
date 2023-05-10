using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.StringPermutations;
public static class StringPermutations
{
    public static IList<string> Permute(string s)
    {
        List<string> permutations = new List<string>();
        PermuteRec(s, "", permutations);

        return permutations;
    }

    public static void PermuteRec(string s, string permutation, IList<string> permutations)
    {
        if (s.Length == 0)
        {
            permutations.Add(permutation);
            return;
        }

        for (int i = 0; i < s.Length; i++)
        {
            var left = s.Substring(0, i);
            char ch = s[i];
            var right = s.Substring(i + 1);
            var rest = left + right;
            PermuteRec(rest, permutation + ch, permutations);
        }
    }
}
