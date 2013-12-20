using System;
using System.Threading;
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int[][] triangle = new int[height+1][];

            //define capacity of each array in the jagged array
            for (int row = 0; row < height; row++)
			{
			    triangle[row] = new int[row+1];
			}

            //calculate Pascal's triangle
            triangle[0][0] = 1;
            for (int row = 0; row < height-1; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    triangle[row + 1][col] += triangle[row][col];
                    triangle[row + 1][col + 1] += triangle[row][col];
                }
            }

            //print Pascal's triangle
            for (int row = 0; row < height; row++)
            {
                Console.Write("".PadLeft((height-row)*2));
                for (int col = 0; col <= row; col++)
                {
                    Console.Write("{0,3} ", triangle[row][col]);
                    Thread.Sleep(300);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
