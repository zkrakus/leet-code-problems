namespace Problems.Algorithms.FindIntervalsOfDuplicateElements;

public static class FindIntervalsOfDuplicateElements
{
    /// <summary>
    /// Problem: 
    /// Given an array of characters return an array of lengths that partions the given array such that each of the returned lengths are of minimum size and contain all the characters of its type.
    /// Optimize for fewest possible arrays using this criteria.
    /// The intermediary subarrays are for demonstrations only and are not mandatory
    /// e.g. [a,b,c] => [a],[b],[c] => [1],[1],[1]
    /// abc => [a,b,c,a] => [4]
    /// abcdaefge => [a,b,c,d,a],[e,f,g,e] => [5],[4]
    /// abcdadefgeg => [a,b,c,d,a],[e,f,g,e,g] => [5],[5]
    /// abcdefeggsfppkfpplogs => [abcde], [gsfpkfplogk]  => [5],[11]
    /// 
    /// Algorithm: 
    /// Create a dictionary of intervals for each character that maps a character to it's interval.
    /// Do this by iterating through the array, if a character is not in the dictionary add it with an intercal from and to it's current index.
    /// If they character exists replace the end of the interval with the current index.
    /// 
    /// Create a return list (since we don't know how many intervals we will have once merged) the intersecting sub intervals.
    /// Iterate through the input array one more time and for each element get it's interval from the dictionary. Iterate through the interval
    /// and as you iterate continue to get the interval for each element being iterated over. If the interval for the element has a greated end bound
    /// than the interval you are currently iterating over increase end interval index. When you iterate past the bounds of your interval, add the length 
    /// of the interval to your return list.
    /// 
    /// Once you finish iterating over the return array convert the list to an array.
    /// 
    /// Analysis:
    /// Time: O(3n) = O(n) 
    /// Iterate once to create the interval array. 
    /// Iterate again to merge intervals. 
    /// Convert the list to an array, which in the worst case scenario, would be the size of the input array.
    /// 
    /// Space: O(2n) = O(n)
    /// In the worse case the intervals list and dictionary would be n when the input array is composed of unique elements.
    /// 
    /// </summary>
    public static int[] Run(char[] arr)
    {
        if (arr.Length == 0)
            return Array.Empty<int>();

        if (arr.Length == 1)
            return new int[] { 1 };

        var dict = new Dictionary<char, (int, int)>();
        for (var i = 0; i < arr.Length; i++)
        {
            var item = arr[i];
            if (!dict.ContainsKey(item))
            {
                dict.Add(item, (i, i));
            }
            else
            {
                var cur = dict[item];
                dict[item] = (cur.Item1, i);
            }
        }

        int minInterval = 0, maxInterval = 0;
        var intervalLengths = new List<int>();
        for (var arrayIndex = 0; arrayIndex < arr.Length; arrayIndex++)
        {
            var interval = dict[arr[arrayIndex]];
            maxInterval = Math.Max(interval.Item2, maxInterval);

            if (arrayIndex == maxInterval)
            {
                intervalLengths.Add(maxInterval - minInterval + 1);
                if (arr.Length > maxInterval + 1)
                {
                    minInterval = dict[arr[arrayIndex + 1]].Item1;
                    maxInterval = dict[arr[arrayIndex + 1]].Item2;
                }
            }
        }

        return intervalLengths.ToArray();
    }
}