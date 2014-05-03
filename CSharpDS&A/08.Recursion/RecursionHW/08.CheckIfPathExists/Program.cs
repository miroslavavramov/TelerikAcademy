using System;
using System.Collections;

class Program
{
    static bool IsInGrid(byte[,] grid, int x, int y)
    {
        return x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1);
    }

    static bool CheckIfPathExists(byte[,] grid, int x = 0, int y = 0, bool found = false)
    {
        if (!found)
        {
            if (!IsInGrid(grid,x,y) || grid[x,y] == 1)
            {
                return false;
            }

            if (grid[x,y] == 2)
            {
                return true;
            }

            grid[x,y] = 1;  //mark as visited

            found = CheckIfPathExists(grid, x + 1, y, found);
            found = CheckIfPathExists(grid, x, y + 1, found);
            found = CheckIfPathExists(grid, x - 1, y, found);
            found = CheckIfPathExists(grid, x, y - 1, found);

            grid[x, y] = 0;     //unvisit
        }

        return found;
    }

    static void Main()
    {
        // *empty non-visited cell == 0
        // *empty visited cell or non-passable cell == 1
        // *target cell == 2

        byte[,] grid = 
        {
            {0 ,0, 0, 0, 1},
            {1, 0, 0, 1, 0},
            {0, 0, 1, 0, 0},
            {0, 1, 0, 0, 2},
        };

        var result = CheckIfPathExists(grid);

        Console.WriteLine(result);
    }
}
