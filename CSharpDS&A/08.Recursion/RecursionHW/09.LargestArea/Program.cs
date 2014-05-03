using System;

class Program
{
    static bool IsInGrid(byte[,] grid, int x, int y)
    {
        return x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1);
    }

    static int CalculateArea(byte[,] grid, int x, int y, int area = 0)
    {
        if (IsInGrid(grid,x,y) && grid[x,y] == 0)
        {
            area++;
            grid[x, y] = 1;

            area += CalculateArea(grid, x + 1, y);
            area += CalculateArea(grid, x, y + 1);
            area += CalculateArea(grid, x - 1, y);
            area += CalculateArea(grid, x, y - 1);
        }

        return area;
    }

    static int FindLargestEmptyArea(byte[,] grid)
    {
        int largestArea = 0;
        int area;
        
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                if (grid[x,y] == 0)
                {
                    area = CalculateArea(grid, x, y);

                    if (area > largestArea)
                    {
                        largestArea = area;
                    }
                }
            }
        }

        return largestArea;
    }

    static void Main()
    {
        // *empty non-visited cell == 0
        // *empty visited cell or non-passable cell == 1
        
        byte[,] grid = 
        {
            {0 ,0, 0, 1, 1},
            {1, 1, 1, 1, 0},
            {0, 1, 0, 0, 0},
            {0, 1, 0, 0, 1},
        };

        var result = FindLargestEmptyArea(grid);

        Console.WriteLine(result);
    }
}