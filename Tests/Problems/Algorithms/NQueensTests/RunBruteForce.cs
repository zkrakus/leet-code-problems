using Problems.Algorithms.NQueens;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.Problems.Algorithms.NQueensTests;
public class RunBruteForce
{
    [Fact]
    public static void RunBruteForce_ShouldReturnEmpty_WhenNegativeOrZero()
    {
        var nQueens = new NQueens();

        Assert.Equal(Array.Empty<char[,]>(), nQueens.RunBruteForce(-1));
        Assert.Equal(Array.Empty<char[,]>(), nQueens.RunBruteForce(int.MinValue));
        Assert.Equal(Array.Empty<char[,]>(), nQueens.RunBruteForce(0));
    }

    [Fact]
    public static void RunBruteForce_ShouldReturnResult_WhenOne()
    {
        var nQueens = new NQueens();

        var chessboard = new List<char[,]> { new char[,] { { 'Q' } } };
        Assert.Equal(chessboard, nQueens.RunBruteForce(1));
    }

    [Fact]
    public static void RunBruteForce_ShouldReturnEmptyResult_WhenTwoOrThree()
    {
        var nQueens = new NQueens();

        var chessboard = Array.Empty<char[,]>();
        Assert.Equal(chessboard, nQueens.RunBruteForce(2));
        Assert.Equal(chessboard, nQueens.RunBruteForce(3));
    }

    [Fact]
    public static void RunBruteForce_ShouldReturnResult_WhenFour()
    {
        var queens = new NQueens();

        var result = queens.RunBruteForce(4);

        foreach (var chessboard in result)
        {
            for(var m = 0;  m < chessboard.Rank; m++)
            {
                for(var n = 0;  n < chessboard.GetLength(m); n++)
                {
                    if (chessboard[m, n] == 'Q')
                    {
                        Assert.True(NQueens.CheckValidPosition(chessboard, n, m));
                    }
                }
            }
        }

    }

    [Fact]
    public static void RunBruteForce_ShouldReturnResult_WhenN()
    {
        var queens = new NQueens();
        var random = new Random();
        var result = queens.RunBruteForce(random.Next(0, 8));

        foreach (var chessboard in result)
        {
            for (var m = 0; m < chessboard.Rank; m++)
            {
                for (var n = 0; n < chessboard.GetLength(m); n++)
                {
                    if (chessboard[m, n] == 'Q')
                        Assert.True(NQueens.CheckValidPosition(chessboard, n, m));
                }
            }
        }
    }
}
