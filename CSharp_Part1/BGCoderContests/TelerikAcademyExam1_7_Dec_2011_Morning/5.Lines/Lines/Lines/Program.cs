using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[8, 8];
            int longestLine = 0;
            int currentLine = 0;
            int linesCount = 0;

            for (int i = 0; i < 8; i++)
            {
                int inputNumber = Math.Abs(int.Parse(Console.ReadLine()));
                string inputString = Convert.ToString(inputNumber, 2).PadLeft(8, '0');
                for (int j = 0; j < 8; j++)
                {
                    if (inputString[j] == '1')
                    {
                        grid[i, j] = 1;
                    }
                }
            }

            int length = 8;
            // check vertical lines
            for (int row = 0; row < length; row++)
            {
                currentLine = 0;
                for (int col = 0; col < length; col++)
                {
                    if (grid[row,col] == 1)
                    {
                        currentLine++;
                    }
                    if (grid[row, col] != 1 || col == 7)
                    {
                        if (currentLine == longestLine)
                        {
                            linesCount++;
                        }
                        if (currentLine > longestLine)
                        {
                            longestLine = currentLine;
                            linesCount = 1;
                        }
                        currentLine = 0;
                    }
                }
            }
            //check horizontal lines
            for (int col = 0; col < length; col++)
            {
                currentLine = 0;
                for (int row = 0; row < length; row++)
                {
                    if (grid[row, col] == 1)
                    {
                        currentLine++;
                    }
                    if (grid[row, col] != 1 || row == 7)
                    {
                        if (currentLine == longestLine && currentLine > 1)  // makes sure if longest line = 1 not to be counted twice
                        {
                            linesCount++;
                        }
                        if (currentLine > longestLine)
                        {
                            longestLine = currentLine;
                            linesCount = 1;
                        }
                        currentLine = 0;
                    }
                }
            }
            Console.WriteLine(longestLine);
            Console.WriteLine(linesCount);

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
