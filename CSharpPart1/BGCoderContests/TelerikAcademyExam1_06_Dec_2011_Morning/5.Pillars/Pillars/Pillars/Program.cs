using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillars
{
    class Program
    {
        static void Main(string[] args)
        {
            int pillar = 0;
            int totalPoints = int.MinValue;
            int leftPoints = int.MinValue;
            int rightPoints = int.MinValue;
            bool win = false;
            int[,] grid = new int[8, 8];
            for (int row = 0; row < 8; row++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                if (inputNumber < 0)
                {
                    inputNumber *= -1;
                }
                string inputString = Convert.ToString(inputNumber, 2).PadLeft(8, '0');

                for (int col = 0; col < 8; col++)
                {
                    if (inputString[col] == '1')
                    {
                        grid[row, col] = 1;
                    }    
                }
            }

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(grid[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            for (int i = 0; i < 8; i++)
            {
                leftPoints = 0;
                //left side
                for (int row = 0; row < 8; row++)
                {
                    for (int col = 0; col < i; col++)
                    {
                        if (grid[row, col] == 1)
                        {
                            leftPoints++;
                        }
                    }
                }
                rightPoints = 0;
                //right side
                for (int row = 0; row < 8; row++)
                {
                    for (int col = i+1; col < 8; col++)
                    {
                        if (grid[row, col] == 1)
                        {
                            rightPoints++;
                        }
                    }
                }
                if (leftPoints == rightPoints) //&& rightPoints != 0 && leftPoints != 0)
                {
                    pillar = 7 - i;
                    totalPoints = rightPoints;
                    win = true;
                    break;
                }
            }
            if (win)
            {
                Console.WriteLine(pillar);
                Console.WriteLine(totalPoints);    
            }
            else
            {
                Console.WriteLine("No");
            }
            
        }
    }
}
