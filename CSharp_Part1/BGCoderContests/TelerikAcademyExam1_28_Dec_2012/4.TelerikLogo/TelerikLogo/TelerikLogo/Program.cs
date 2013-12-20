using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikLogo
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int z = x/2 + 1;
            int height = 3 * x - 2;
            int row = 0;
            int col = 0;
            char[,] grid = new char[3 * x - 2, 3 * x - 2];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = '.';
                }
            }

            row = z-1;
            col = 0;
            while (true)
            {
                grid[row, col] = '*';
                row--;
                col++;
                if (row<0)
                {
                    row++;
                    col--;
                    break;
                }
            }
            while (true)
            {
                grid[row, col] = '*';
                row++;
                col++;
                if (row == 2*x-1)
                {
                    row--;
                    col--;
                    break;
                }
            }
            while (true)
            {
                grid[row, col] = '*';
                row++;
                col--;
                if (row == height)
                {
                    row--;
                    col++;
                    break;
                }
            }
            while (true)
            {
                grid[row, col] = '*';
                row--;
                col--;
                if (row == height-x-1)
                {
                    row++;
                    col++;
                    break;
                }
            }
            while (true)
            {
                grid[row, col] = '*';
                row--;
                col++;
                if (row == 0)
                {
                    break;
                }
            }
            while (true)
            {
                grid[row, col] = '*';
                row++;
                col++;
                if (row == z)
                {
                    break;
                }
            }

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                      Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
