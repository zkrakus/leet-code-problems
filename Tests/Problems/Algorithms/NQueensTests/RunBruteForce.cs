using Problems.Algorithms.NQueens;
using System;
using Xunit;

namespace Tests.Problems.Algorithms.NQueensTests;
public class RunBruteForce
{
    [Fact]
    public static void RunBruteForce_ShouldReturnEmpty_WhenNegativeOrZero()
    {
        //Assert.Equal(Array.Empty<char[]>(), NQueens.RunBruteForce(-1));
        //Assert.Equal(Array.Empty<char[]>(), NQueens.RunBruteForce(int.MinValue));
        //Assert.Equal(Array.Empty<char[]>(), NQueens.RunBruteForce(0));
    }

    [Fact]
    public static void RunBruteForce_ShouldReturnResult_WhenOne()
    {
        var chessboard = new char[][] { new char[] { 'Q' } };
        //Assert.Equal(chessboard, NQueens.RunBruteForce(1));
    }

    [Fact]
    public static void RunBruteForce_ShouldReturnEmptyResult_WhenTwoOrThree()
    {
        //Assert.Equal(Array.Empty<char[]>(), NQueens.RunBruteForce(2));
        //Assert.Equal(Array.Empty<char[]>(), NQueens.RunBruteForce(3));
    }

    [Fact]
    public static void RunBruteForce_ShouldReturnResult_WhenFour()
    {
        var result = NQueens.RunBruteForce(4);

        foreach(var chessboard in result)
        {
            Console.WriteLine(  );
        }
    }

    private static bool CompareChessboards(char[][] chessboard1, char[][] chessboard2)
    {
        for (var i = 0; i < chessboard1.Length; i++)
        {
            for (var j = 0; j < chessboard1[i].Length; j++)
            {

            }
        }

        return true;
    }

    private static bool CompareChessboardCells(char[][] chessboard1, char[][] chessboard2, int i, int j)
    {
        try
        {
            if (chessboard1[i][j] != chessboard2[i][j])
                return false;

        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }

        return true;
    }
}
