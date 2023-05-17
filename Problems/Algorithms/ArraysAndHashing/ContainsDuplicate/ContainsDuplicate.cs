using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.ArraysAndHashing.ContainsDuplicate;

/// <summary>
/// Problem:
/// Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
/// 
/// Constraint:
///  1 <= nums.length <= 105
///  -109 <= nums[i] <= 109
///  
/// Analysis:
/// f(t) = O(n)
/// f(s) = O(n)
/// 
/// Note: We could do this faster by iterating as we can return as soon as we 
/// find a duplicate key therefore short circuiting the algo, but I like the one liner as when solving these types of problems, speed is of huge benefit.
/// </summary>
public static class ContainsDuplicate
{
    public static bool Run(int[] nums) => 
        new HashSet<int>(nums).Count != nums.Length;
}
