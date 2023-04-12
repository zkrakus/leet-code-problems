using System.Text;

namespace Problems.Algorithms.ZigZagConversion;

/// <summary>
/// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)
///
/// P   A   H   N 
/// A P L S I I G
/// Y   I   R
///
/// And then read line by line: "PAHNAPLSIIGYIR"
/// Write the code that will take a string and make this conversion given a number of rows.
/// </summary>
public static class ZigZagConversion
{
    /// <summary>
    /// Algorithm:
    /// Create a list of stringbuilders equal to the number of rows. Iterate through the characters in the input.
    /// Keep track of whether you are moving up or down the zigZag. Keep moving down the zigZag appending
    /// value to the associated string builder for that row.
    /// After appending to the bottom row, start moving back up the zigzag and continue appending characters.
    /// 
    /// Analysis:
    /// O(t) = O(n)
    /// O(s) = O(n + m) : m is the number of rows.
    /// </summary>
    public static string RunIterative(string s, int numRows)
    {
        if (numRows < 1)
            throw new ArgumentException("Argument: numRows must be greater than 0.");

        if (numRows is 1)
            return s;

        var rows = new List<StringBuilder>();
        for (var i = 0; i < Math.Min(numRows, s.Length); i++)
            rows.Add(new StringBuilder());

        var j = 0;
        var up = false;
        foreach (var c in s.ToCharArray())
        {
            _ = rows[j].Append(c);

            if (j + 1 == numRows)
                up = true;
            else if (j == 0)
                up = false;

            if (up)
                j--;
            else
                j++;
        }

        var zigzag = new StringBuilder();
        foreach (var sb in rows)
            _ = zigzag.Append(sb);

        return zigzag.ToString();
    }

    /// <summary>
    /// Algorithm:
    /// We can express the zigzag pattern as an expression of the index of the string and the number of rows.
    /// A    G    J  i + 2 * (numRows-1)
    /// B  F H  I L  i + 2 * (numRows-2), i + 2 * (numRows-3)       
    /// C E  I H  M  i + 2 * (numRows-3), i + 2 * (numRows-2) 
    /// D    J    N  i + 2 * (numRows-4)  
    /// 
    /// Iterate through the string and append the character to the appropriate row.
    /// 
    /// Analysis:
    /// O(t) = O(n)
    /// O(s) = O(n + m) : m is the number of rows.
    /// </summary>
    public static string RunMathemeticalExpression(string s, int numRows)
    {
        if (numRows < 1)
            throw new ArgumentException("Argument: numRows must be greater than 0.");

        if (numRows is 1)
            return s;

        var chars = s.ToCharArray();
        var zigZagString = new StringBuilder();
        (var i, var j) = (numRows - 1, 0);
        for (var row = 0; row < numRows; row++)
        {
            var index = row;
            while (index < chars.Length)
            {
                var offset1 = 2 * i;
                if (offset1 != 0 && index < chars.Length)
                    _ = zigZagString.Append(s[index]);
                index += offset1;

                var offset2 = 2 * j;
                if (offset2 != 0 && index < chars.Length)
                    _ = zigZagString.Append(s[index]);
                index += offset2;
            }

            j++;
            i--;
        }

        return zigZagString.ToString();
    }
}
