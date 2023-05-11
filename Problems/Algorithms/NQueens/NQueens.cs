using Microsoft.CodeAnalysis;
using Microsoft.IdentityModel.Tokens;
using System.Collections;

namespace Problems.Algorithms.NQueens;
public class NQueens
{
    private readonly List<char[,]> _validBoardCollection = new();

    private static readonly char EMPTY_SPACE = '.';
    private static readonly char QUEEN = 'Q';

    /// <summary>
    /// Algorithm:
    /// If n == 0, 2, 3 We know we cannot place n queens on the board.
    /// If n == 1 we know there is only 1 solution.
    /// 
    /// If n > 3 we try to find all possible solutions via brute force.
    /// We iterate through the first row and place a queen in each position as we know every solution will require a queen in the first row.
    /// 
    /// 
    /// Analysis:
    /// </summary>
    public IList<char[,]> RunBruteForce(int boardSize)
    {
        // Explicit solutions.
        if (boardSize is <= 0 or 2 or 3)
            return Array.Empty<char[,]>();
        else if (boardSize is 1)
            return new List<char[,]> { new char[,] { { QUEEN } } };

        return FindSolutions(boardSize);
    }

    private char[][,] FindSolutions(int boardSize)
    {
        var validBoardCollection = new List<char[,]>();

        // The maximum number of solutions is constrained by the boardsize because we can only have 1 queen per row and column.
        // If we can place a queen on each row and/or column we know we have a solution.
        // Let's see if we have a valid solution for any column start positions on the first row.
        var chessboard = new char[boardSize, boardSize];
        var solution = FindSolution(chessboard, 0, 0);

        return _validBoardCollection.ToArray();
    }

    private char[,]? FindSolution(char[,] board, int col, int row)
    {
        var validPosition = CheckValidPosition(board, col, row);

        if (validPosition)
            PlaceQueen(board, col, row);

        // Valid position on the final row. Save chessboard and find next solution.
        var boardSize = board.GetLength(0) - 1;
        if (validPosition && row == boardSize)
        {
            _validBoardCollection.Add(board);

            // Find Queen on first row.
            var queenFirstRowCol = 0;
            while (queenFirstRowCol <= boardSize)
            {
                if (board[0, queenFirstRowCol] == QUEEN)
                    break;

                queenFirstRowCol++;
            }

            // If queen is not in last column. Try to find valid solution with queen in next column.
            if (queenFirstRowCol != boardSize)
            {
                var tmp = FindSolution(new char[boardSize + 1, boardSize + 1], queenFirstRowCol + 1, 0);
                if (tmp != null)
                    board = tmp;
            }

            return board;
        }

        // We could not find a valid solution after iterating through the entire board. No solution.
        if (!validPosition && row == boardSize && col == boardSize)
            return null;

        // Could not place queen on this row. No solution.
        if (!validPosition && col == boardSize)
            return null;

        // If we found a valid position try to find a full solution on the next row.
        char[,]? solution = null;
        if (validPosition)
            solution = FindSolution(board, 0, row + 1);

        // If no solution exists for the above position. Unset the current position and try to find a solution in 
        // a subsequent column ensuring all combinations of valid placements are tried.
        if (solution == null)
        {
            PlaceEmpty(board, col, row);

            // Don't continue to next row. If we reached the end of the row when there was no solution, we're done.
            if (col != boardSize)
                solution = FindSolution(board, col + 1, row);
        }

        return solution;
    }

    public static bool CheckValidPosition(char[,] board, int column, int row)
    {
        var n = board.GetLength(0);

        // Scan horizontally.
        // For a horizontal scan we want to iterate over the column.
        {
            var i = (column + 1) % n;
            while (i != column)
            {
                if (board[row, i] == QUEEN)
                    return false;

                i = ++i % n;
            }
        }


        // Scan vertically.
        // For a vertical scan we want to iterate over the row
        {
            var j = (row + 1) % n;
            while (j != row)
            {
                if (board[j, column] == QUEEN)
                    return false;

                j = ++j % n;
            }
        }

        // Scan the rightward descending diagonol.
        // For scanning a descending diagonol we want to increment the column and increment the row.
        {
            int i = column + 1, j = row + 1;
            while (i < n && j < n)
            {
                if (board[j, i] == QUEEN)
                    return false;

                i = ++i;
                j = ++j;
            }
        }

        // Scan the rightward ascending diagonol.
        // For scanning a ascending diagonol we want to increment the column and decrement the row.
        {
            int i = column + 1, j = row - 1;
            while (i < n && j >= 0)
            {
                if (board[j, i] == QUEEN)
                    return false;

                i = ++i;
                j = --j;
            }
        }

        // Scan the leftward descending diagonol.
        // For scanning a leftward descending diagonol we want to decrement the column and increment the row.
        {
            int i = column - 1, j = row + 1;
            while (i >= 0 && j < n)
            {
                if (board[j, i] == QUEEN)
                    return false;

                i = --i;
                j = ++j;
            }
        }

        // Scan the leftward ascending diagonol.
        // For scanning a leftward ascending diagonol we want to decrement the column and decrement the row.
        {
            int i = column - 1, j = row - 1;
            while (i >= 0 && j >= 0)
            {
                if (board[j, i] == QUEEN)
                    return false;

                i = --i;
                j = --j;
            }
        }

        return true;
    }

    private static void PlaceQueen(char[,] board, int col, int row)
        => board[row, col] = QUEEN;

    private static void PlaceEmpty(char[,] board, int col, int row)
        => board[row, col] = EMPTY_SPACE;
}