using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.BinarySearch;
public class BinarySearch : IBinarySearch
{
    public int Run(int[] nums, int target) 
    {
        if (nums == null || nums.Length == 0)
            return -1;

        int left = 0, right = nums.Length - 1;
        while (left <= right)
        {
            int middle = (left + right) / 2 , cur = nums[middle];
            if (cur == target)
                return middle;
            else if (target < cur)
                right = middle - 1;
            else if (target > cur)
                left = middle + 1;
        }

        return -1;
    }
}
