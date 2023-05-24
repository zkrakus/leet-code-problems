using Problems.Algorithms.BinarySearch;
using Problems.Algorithms.TwoPointers.ValidPalindrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Problems.Algorithms.BinarySearchTests;
public class RunTests
{
    [Theory]
    [MemberData(nameof(BinarySearchTestData.BinarySearchInstances), MemberType = typeof(BinarySearchTestData))]
    public void ShouldReturnSolution_ForInput(IBinarySearch @class)
    {
        int[] nums = { -1, 0, 3, 5, 9, 12 };
        Assert.Equal(4, @class.Run(nums, 9));
    }

    private static class BinarySearchTestData
    {
        private static IEnumerable<IBinarySearch> BinarySearchCollection =>
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type =>
                    typeof(IBinarySearch).IsAssignableFrom(type)
                    && !type.IsAbstract
                    && !type.IsGenericType
                    && type.GetConstructor(Array.Empty<Type>()) != null)
                .Select(type => (IBinarySearch)Activator.CreateInstance(type)!)
            .ToArray();

        public static IEnumerable<object[]> BinarySearchInstances =>
            BinarySearchCollection.Select(@class => new object[] { @class });
    }
}
