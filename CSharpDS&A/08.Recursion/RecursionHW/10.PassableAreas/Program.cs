using System;
using System.Collections.Generic;

class Program
{
    static void PrintAreas(List<List<Tuple<int, int>>> passableAreas)
    {
        Console.WriteLine("All passable areas: " + passableAreas.Count);

        foreach (var area in passableAreas)
        {
            Console.Write("Area: ");

            foreach (var cell in area)
            {
                Console.Write("({0},{1}) ", cell.Item1, cell.Item2);
            }

            Console.WriteLine();
        }
    }

    static bool IsInGrid(byte[,] grid, int x, int y)
    {
        return x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1);
    }

    static void GetArea(byte[,] grid, List<Tuple<int,int>> area, int x, int y )
    {
        if (IsInGrid(grid, x, y) && grid[x, y] == 0)
        {
            area.Add(new Tuple<int, int>(x, y));
            grid[x, y] = 1;

            GetArea(grid, area, x + 1, y);
            GetArea(grid, area, x, y + 1);
            GetArea(grid, area, x - 1, y);
            GetArea(grid, area, x, y - 1);
        }   
    }

    static List<List<Tuple<int,int>>> FindAllPassableAreas(byte[,] grid)
    {
        var allPassableAreas = new List<List<Tuple<int, int>>>();

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                if (grid[x, y] == 0)
                {
                    var area = new List<Tuple<int, int>>();
                    GetArea(grid, area, x, y);
                    allPassableAreas.Add(area);
                }
            }
        }

        return allPassableAreas;
    }

    static void Main()
    {
        // *empty non-visited cell == 0
        // *empty visited cell or non-passable cell == 1

        byte[,] grid = 
        {
            {1 ,0, 0, 1, 1},
            {0, 1, 1, 1, 0},
            {0, 1, 0, 1, 0},
            {0, 1, 0, 0, 1},
        };

        var result = FindAllPassableAreas(grid);

        PrintAreas(result);
    }
}

