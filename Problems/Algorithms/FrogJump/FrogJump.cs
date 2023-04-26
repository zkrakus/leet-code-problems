using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.FrogJump;
public static class FrogJump
{
    /// <summary>
    /// Problem: 
    /// A small frog wants to get to the other side of the road. 
    /// The frog is currently located at position X and wants to 
    /// get to a position greater than or equal to Y.
    /// The small frog always jumps a fixed distance, D. Count the minimal number of 
    /// jumps that the small frog must perform to reach its target.
    /// 
    /// Analysis:
    /// t(n) = O(1)
    /// s(n) = O(1)
    /// </summary>
    public static int Run(int x, int y, int d)
    {
        y -= x;
        return (int)Math.Ceiling(y / (double)d);
    }
}
