using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBit1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = { 2, 38, 20, 48, 111, 15, 3, 43 };
            int[] numbers = new int[8];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            char[,] grid = new char[8, 8];

            for (int rows = 0; rows < numbers.Length; rows++)   // build the grid
            {
                for (int cols = 0; cols < numbers.Length; cols++)
                {
                    string binaryRepresentation = Convert.ToString(numbers[rows], 2).PadLeft(8, '0');
                    grid[rows, cols] = binaryRepresentation[cols];
                }
            }

            //for (int rows = 0; rows < grid.GetLength(0); rows++)        // print the  grid
            //{
            //    for (int cols = 0; cols < grid.GetLength(1); cols++)
            //    {
            //        Console.Write(grid[rows, cols] + " ");
            //    }
            //    Console.WriteLine();
            //}

            bool west = false;
            bool north = false;
            bool south = false;
            bool turnNorth = true;
            bool finish = true;
            int distance = 0;
            int turns = 0;
            int row = 0;
            int col = 7;

            if (row < 7 && grid[row + 1, col] == '0')
            {
                distance++;
                south = true;
            }
            else
            {
                Console.WriteLine("No {0}", distance);
                return;
            }

            while (!(row == 7 && col == 0))
            {
                if (south == true)
                {
                    if (row < 7 && grid[row + 1, col] == '0')
                    {
                        distance++;
                        row++;
                    }
                    else
                    {
                        south = false;
                        if (col > 0 && grid[row, col-1] == '0')
                        {
                            west = true;
                            turns++;
                        }
                        else
                        {
                            Console.WriteLine("No {0}", distance);
                            finish = false;
                            break;
                        }
                    }    
                }
                if (west == true)
                {
                    if (col > 0 && grid[row, col-1] == '0')
                    {
                        distance++;
                        col--;
                    }
                    else
                    {
                        west = false;
                        if (turnNorth == true)
                        {
                            if (row > 0 && grid[row-1, col] == '0')
                            {
                                turns++;
                                north = true;
                                turnNorth = false;
                            }
                            else
                            {
                                Console.WriteLine("No {0}", distance);
                                finish = false;
                                break;
                            }
                        }
                        else
                        {
                            west = false;
                            if (row < 7 && grid[row+1, col] == '0')
                            {
                                turns++;
                                south = true;
                                turnNorth = true;
                            }
                            else
                            {
                                Console.WriteLine("No {0}", distance);
                                finish = false;
                                break;
                            }
                        }
                    }
                }
                if (north == true)
                {
                    if (row > 0 && grid[row-1, col] == '0')
                    {
                        distance++;
                        row--;
                    }
                    else
                    {
                        north = false;
                        if (col > 0 && grid[row, col-1] == '0')
                        {
                            west = true;
                            turns++;
                        }
                        else
                        {
                            Console.WriteLine("No {0}", distance);
                            finish = false;
                            break;
                        }
                    }
                }
                
            }
            if (finish == true)
            {
                Console.WriteLine("{0} {1}", distance, turns);    
            }
            

            

        }
        
    }
}
