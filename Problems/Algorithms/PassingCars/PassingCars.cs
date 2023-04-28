using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Algorithms.PassingCars;
public static class PassingCars
{
    /// <summary>
    /// Problem:
    /// 
    /// A non-empty array A consisting of N integers is given. The consecutive elements of array A represent consecutive cars on a road.
    /// Array A contains only 0s and/or 1s:
    /// 0 represents a car traveling east,
    /// 1 represents a car traveling west.
    /// The goal is to count passing cars.We say that a pair of cars (P, Q), where 0 ≤ P<Q<N, is passing when P is traveling to the east and Q is traveling to the west.
    /// 
    /// Analysis:
    /// t(n) = O(n)
    /// s(n) = O(1)
    /// </summary>
    public static int Run(int[] cars)
    {
        if (!cars.Any() || cars.Length < 2)
            return 0;

        int numCarsHeadingEast = 0;
        int passingCarPairs = 0;
        for (var i = 0; i < cars.Length; i++)
        {
            var direction = (Direction)cars[i];
            if (direction == Direction.East)
            {
                numCarsHeadingEast++;
            }
            else if (direction == Direction.West)
            {
                passingCarPairs += numCarsHeadingEast;
                if (passingCarPairs > 1000000000)
                    return -1;
            }
        }

        return passingCarPairs;
    }

    private enum Direction
    {
        East = 0,
        West = 1,
    }
}
