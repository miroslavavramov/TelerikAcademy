using System;

class Program
{
    static bool IsInGrid(byte[,] grid, int x, int y)
    {
        return x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1);
    }

    static int FindAllPossiblePaths(byte[,] grid, int x = 0, int y = 0)
    {
        if (!IsInGrid(grid, x, y) || grid[x, y] == 1)
        {
            return 0;
        }

        if (grid[x, y] == 2)
        {
            return 1;
        }

        grid[x, y] = 1;     //mark cell as visited

        int result = 0;

        result += FindAllPossiblePaths(grid, x - 1, y);
        result += FindAllPossiblePaths(grid, x, y - 1);
        result += FindAllPossiblePaths(grid, x + 1, y);
        result += FindAllPossiblePaths(grid, x, y + 1);

        grid[x, y] = 0;     // unvisit cell

        return result;
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
            {0, 0, 0, 0, 2},
        };

        var result = FindAllPossiblePaths(grid);

        Console.WriteLine(result);
    }
}