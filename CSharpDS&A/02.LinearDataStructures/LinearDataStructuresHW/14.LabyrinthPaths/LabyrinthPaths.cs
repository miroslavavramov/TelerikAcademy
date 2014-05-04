/*
 * We are given a labyrinth of size N x N. Some of its cells are empty (0) and some are full (x). 
 * We can move from an empty cell to another empty cell if they share common wall. 
 * Given a starting position (*) calculate and fill in the array the minimal distance from this 
 * position to any other cell in the array. Use "u" for all unreachable cells.
*/
using System;

class LabyrithPaths
{
    static string[,] grid = new string[,]
    {
     { "0", "0", "0", "x", "0", "x" },
     { "0", "x", "0", "x", "0", "x" },
     { "0", "*", "x", "0", "x", "0" },
     { "0", "x", "0", "0", "0", "0" },
     { "0", "0", "0", "x", "x", "0" },
     { "0", "0", "0", "x", "0", "x" },
    };

    static void TraverseAndMark(int row, int col, int distance = 0)
    {
        if (row >= 0 && row < grid.GetLength(0) && 
            col >= 0 && col < grid.GetLength(1) &&
            grid[row,col] != "x")
        {
            if (grid[row,col] == "0" || grid[row,col] == "*" || int.Parse(grid[row,col]) > distance)
            {
                if (grid[row,col] != "*")
                {
                    grid[row, col] = distance.ToString();   
                }

                TraverseAndMark(row + 1, col, distance + 1);
                TraverseAndMark(row - 1, col, distance + 1);
                TraverseAndMark(row, col + 1, distance + 1);
                TraverseAndMark(row, col - 1, distance + 1);
            }
        }
    }

    static void PrintGrid()
    {
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(0); col++)
            {
                if (grid[row,col] == "0")
                {
                    grid[row, col] = "u";
                }
                Console.Write("{0,3}",grid[row,col]);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int startRow = 2;
        int startCol = 1;

        TraverseAndMark(startRow,startCol);

        PrintGrid();
    }
}


