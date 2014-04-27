using System;
using System.Threading;
//Write a program that reads a rectangular matrix of size N x M and finds 
//in it the square 3 x 3 that has maximal sum of its elements.

class MaxPlatform
{
    static int CheckPlatform(int[,] matrix, int row, int col)
    {
        int sum = 0;

        for (int rows = row; rows < row+3; rows++)
        {
            for (int cols = col; cols < col+3; cols++)
            {
                sum += matrix[rows, cols];
            }
        }
        return sum;
    }
    static void Main()
    {
        int height = 0;
        int width = 0;
        while (true)
        {
            try
            {
                Console.Write("Height = ");
                height = int.Parse(Console.ReadLine());
                Console.Write("Width = ");
                width = int.Parse(Console.ReadLine());

                if (height < 3 || width < 3)
                {
                    Console.WriteLine("Height and Width should be BOTH >= 3");
                }
                else
                {
                    int[,] matrix = new int[height, width];
                    int bestRow = 0;
                    int bestCol = 0;
                    int bestSum = 0;

                    Random rnd = new Random();
                    //generate and assign random values

                    for (int row = 0; row < height; row++)
                    {
                        for (int col = 0; col < width; col++)
                        {
                            matrix[row, col] = rnd.Next(0, 99); //assign random value from 0 to 99
                        }
                    }
                    //find max 3x3 platform 

                    for (int row = 0; row < height-2; row++)
                    {
                        for (int col = 0; col < width-2; col++)
                        {
                            if (CheckPlatform(matrix, row, col) > bestSum) 
                            { 
                                bestSum = CheckPlatform(matrix, row, col);
                                bestRow = row;
                                bestCol = col;
                            }
                        }
                    }
                    //print matrix and highlight the platform
                    Console.WriteLine();

                    for (int row = 0; row < height; row++)
			        {
			            for (int col = 0; col < width; col++)
			            {
                            if ((row >= bestRow && row < bestRow+3) && (col >= bestCol && col < bestCol+3))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            Console.Write(" {0,2}", matrix[row,col]);
                            Console.ResetColor();
			            }
                        Console.WriteLine();
			        }
                    Console.WriteLine("\nBest platform sum = {0}", bestSum);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\nPress <ENTER> to try again.");
            ConsoleKeyInfo pressedKey = Console.ReadKey();

            if (pressedKey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                continue;
            }
            else
            {
                //Environment.Exit(0);
                break;
            }
        }
    }
}