namespace Problems.Algorithms.Strings.LongestSubstringWithoutRepeatingCharacters;
public static class LongestSubstringWIthoutRepeatingCharacters
{
    /// <summary>
    /// Problem: Given a string s, find the length of the longest substring without repeating characters.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string Run(string input)
    {
        if (input.Length is 0 or 1)
            return input;

        var slidingWindowCharacterIndexDictionary = new Dictionary<char, int>();
        var longestSubstringStartIndex = 0;
        var longestSubstringLength = 0;
        var currentSlidingWindowStartIndex = 0;
        var currentSubstringLength = 0;
        for (var slidingWindowEnd = 0; slidingWindowEnd < input.Length; slidingWindowEnd++)
        {
            var currentCharacter = input[slidingWindowEnd];
            if (slidingWindowCharacterIndexDictionary.TryGetValue(currentCharacter, out var curCharIndex))
            {
                if (currentSubstringLength > longestSubstringLength)
                {
                    longestSubstringLength = currentSubstringLength;
                    longestSubstringStartIndex = slidingWindowEnd - currentSubstringLength;
                }

                currentSlidingWindowStartIndex = curCharIndex + 1;
                slidingWindowCharacterIndexDictionary[currentCharacter] = slidingWindowEnd;
                currentSubstringLength = slidingWindowEnd - curCharIndex;
                slidingWindowCharacterIndexDictionary = input.Substring(currentSlidingWindowStartIndex, currentSubstringLength)
                    .ToDictionary((character) => character, (element) => slidingWindowCharacterIndexDictionary[element]);
            }
            else
            {
                slidingWindowCharacterIndexDictionary.Add(currentCharacter, slidingWindowEnd);
                currentSubstringLength++;
            }
        }

        if (currentSubstringLength > longestSubstringLength)
        {
            longestSubstringLength = currentSubstringLength;
            longestSubstringStartIndex = input.Length - currentSubstringLength;
        }

        var longestSubstring = input.Substring(longestSubstringStartIndex, longestSubstringLength);
        return longestSubstring;
    }

    /// <summary>
    /// Problem: Given a string s, find the length of the longest substring without repeating characters.
    /// 
    /// Algorithm: We use a sliding window algorithm where the left window index is exclusive and the right window index is inclusive.
    /// We iterate through the input and see if the character is a duplicate by checking our dictionary.
    /// If it is a duplicate we return the index. The left window will either be the current left window
    /// if it's ahead on the last instance of the repeated character or the index of the repeated characer it's ahead of the current left window + 1.
    /// 1 is added to the left index to move it right so the window doesn't include the repeated character.
    /// This because we move the window to the right every iteration so it already includes the duplicate character.
    /// 
    /// Once the left window is moved, we save the character to the dictionary along with the current right window index. 
    /// If the characer already exists, we update the index. Lastly, we calculate the window length and save if it the current 
    /// window length is greater than previous length
    /// 
    /// Space: s(n) = O(n) At most we will have every character in the input in the dictionary.
    /// Time: t(n) = O(n) At most the sliding window iterates through the input once. The left window update is O(1),
    /// but in the worse case when every character is a duplicate, we move the left window n times. O(2n) = O(n)
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static int RunOptimized(string input)
    {
        if (input.Length is 0 or 1)
            return input.Length;

        var characters = new Dictionary<char, int>();
        int left = 0, right, result = 0;
        for (right = 0; right < input.Length; right++)
        {
            var currentCharacter = input[right];
            if (characters.TryGetValue(currentCharacter, out var index))
                // Note: Math.Max is a great way of doing swap logic in one line. 
                left = Math.Max(left, index + 1);

            // Dictionary access indexing is a great way of doing replace and add on the same line. 
            // Jives well with contains key.
            characters[currentCharacter] = right;

            // right - left to find the distance.
            // + 1 since the left window isn't inclusive in our algorithm. 
            result = Math.Max(result, right - left + 1);
        }

        return result;
    }
}
