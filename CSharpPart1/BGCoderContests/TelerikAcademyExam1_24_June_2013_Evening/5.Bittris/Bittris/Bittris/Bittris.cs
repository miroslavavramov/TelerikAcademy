using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine(~8);
        int score = 0;
        int[] grid = { 0, 0, 0, 0 };
        int row = grid.Length - 1;    //3
        int inputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputs; i += 4)
        {
            int inputNumber = int.Parse(Console.ReadLine()) & 255;  //get first 8 bits
            string command = Console.ReadLine() + Console.ReadLine() + Console.ReadLine();
            int bits = CountBits(inputNumber);
            row = grid.Length - 1;

            for (int j = 0; j < command.Length; j++)
            {
                if (command[j] == 'L' && ((inputNumber & 128) == 0))
                {
                    inputNumber <<= 1;
                }
                else if (command[j] == 'R' && ((inputNumber & 1) == 0))
                {
                    inputNumber >>= 1;
                }

                if ((grid[row] & grid[row - 1]) != 0)
                {
                    score += bits;
                    break;
                }
                else
                {
                    grid[row - 1] |= grid[row];
                    grid[row] ^= grid[row];
                    if (grid[row - 1] == 255)
                    {
                        grid[row] = 0;
                        score += bits * 10;
                        break;
                    }
                    if (row - 1 == 0)
                    {
                        score += bits;
                        break;
                    }
                    else
                    {
                        row--;
                    }
                }
            }
        }
        Console.WriteLine(score);
        }
        
    
        static int CountBits(int b)
        {
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                if (((b >> i) & 1) == 1)
                {
                    count++;
                }
            }
            return count;
        }
    }    




