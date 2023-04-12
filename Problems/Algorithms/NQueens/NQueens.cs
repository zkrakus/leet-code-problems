using Microsoft.IdentityModel.Tokens;

namespace Problems.Algorithms.NQueens;
public static class NQueens
{
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
    public static IList<char[,]> RunBruteForce(int boardSize)
    {
        // Explicit solutions.
        if (boardSize is <= 0 or 2 or 3)
            return Array.Empty<char[,]>();
        else if (boardSize is 1)
            return new List<char[,]> { new char[,] { { QUEEN } } };

        return FindSolutions(boardSize);
    }

    private static char[][,] FindSolutions(int boardSize)
    {
        var validBoardCollection = new List<char[,]>();

        // The maximum number of solutions is constrained by the boardsize because we can only have 1 queen per row and column.
        // If we can place a queen on each row and/or column we know we have a solution.
        // Let's see if we have a valid solution for any column start positions on the first row.
        for (var col = 0; col < boardSize; col++)
        {
            var chessboard = new char[boardSize, boardSize];
            var solution = FindSolution(chessboard, col, 0);
            if (solution != null)
                validBoardCollection.Add(solution);
        }

        return validBoardCollection.ToArray();
    }

    private static char[,]? FindSolution(char[,] board, int col, int row)
    {
        var validPosition = CheckValidPosition(board, col, row);

        if (validPosition)
            PlaceQueen(board, col, row);

        // Valid position on the final row. Final solution.
        var boardSize = board.GetLength(0) - 1;
        if (validPosition && row == boardSize)
            return board;

        // We could not find a valid solution after iterating through the entire board. No solution.
        if (row == boardSize && col == boardSize)
            return null;

        // Find solution on next row or on next column on current row.
        return col == boardSize
            ? FindSolution(board, 0, ++row)
            : FindSolution(board, ++col, row);
    }

    private static bool CheckValidPosition(char[,] board, int column, int row)
    {
        var n = board.GetLength(0);

        // Check current position.
        if (board[column, row] == QUEEN)
            return false;

        // Scan horizontally.
        // For a horizontal scan we want to iterate over the column.
        {
            var i = (column + 1) % n;
            while (i != column)
            {
                if (board[i, row] == QUEEN)
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
                if (board[column, j] == QUEEN)
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
            while (i < row && j >= 0)
            {
                if (board[j, i] == QUEEN)
                    return false;

                i = ++i % n;
                j = --j % n;
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

                i = --i % n;
                j = --j % n;
            }
        }

        return true;
    }

    private static void PlaceQueen(char[,] board, int col, int row)
        => board[col, row] = QUEEN;

    private static void PlaceEmpty(char[,] board, int col, int row)
        => board[col, row] = EMPTY_SPACE;
}
