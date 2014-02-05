using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurons
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            int rightBorder;
            int leftBorder;
            int count = 0;

            uint[] number = new uint[32];

            for (int i = 0; i < number.Length; i++)     //assign values
            {
                uint num = 0;
                bool validInput = uint.TryParse(Console.ReadLine(), out num);
                if (validInput)
                {
                    number[i] = num;
                }
                else
                {
                    count = i;
                    break;
                }
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(PrintNeurons(number[i]));
            }

            for (int i = 0; i < count; i++)
            {
                rightBorder = -1;
                leftBorder = -1;

                for (int j = 0; j < 32; j++)    //find the right border
                {
                    if (CheckBitAtPosition(number[i], j) == 1 && CheckBitAtPosition(number[i], j + 1) != 1)
                    {
                        rightBorder = j;
                        break;
                    }
                }

                for (int j = 31; j >= 0; j--)     //find the left border
                {
                    if (CheckBitAtPosition(number[i], j) == 1 && CheckBitAtPosition(number[i], j - 1) != 1)
                    {
                        leftBorder = j;
                        break;
                    }
                }
                if (rightBorder < leftBorder)
                {
                    for (int j = 0; j < 32; j++)     //assign new values
                    {
                        if (j > rightBorder && j < leftBorder)
                        {
                            for (int k = j; k < leftBorder; k++)
                            {
                                number[i] = ReplaceBitAtPosition(number[i], k, 1);
                            }
                        }
                        else
                        {
                            number[i] = ReplaceBitAtPosition(number[i], j, 0);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < 32; j++)
                    {
                        number[i] = ReplaceBitAtPosition(number[i], j, 0);
                    }
                }
                
                Console.WriteLine(number[i]);
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(PrintNeurons(number[i]));
            }
            Console.ReadKey();
        }

        
        static uint CheckBitAtPosition(uint number, int position)
        {
           uint bit = (number & ((uint)1 << position)) >> position;
           return bit;

        }
        static uint ReplaceBitAtPosition(uint number, int position, uint value)
        {
            if (value == 1)
            {
                number = number | ((uint)1 << position);
            }
            else if (value == 0)
            {
                number = number & (~((uint)1 << position));
            }
            return number;
        }

        
    }
}
