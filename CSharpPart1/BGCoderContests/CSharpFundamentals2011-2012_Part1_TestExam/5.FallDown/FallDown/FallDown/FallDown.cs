using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallDown
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[8];
            int col = 0;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int pos = 0; pos < numbers.Length; pos++)
            {
                row = 0;
                for (int index = numbers.Length - 1; index >= 0; index--)
                {
                    if (CheckBitAtPosition(numbers[index], pos) == 0)
                    {
                        continue;
                    }
                    else if (CheckBitAtPosition(numbers[index], pos) == 1)
                    {
                        numbers[index] = ReplaceBitAtPosition(numbers[index], pos, 0);
                        numbers[numbers.Length - 1 - row] = ReplaceBitAtPosition(numbers[numbers.Length - 1 - col], pos, 1);
                        row++;
                    }
                }
            }

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        static int CheckBitAtPosition(int number, int position)
        {
            int bit = (number & (1 << position)) >> position;
            return bit;

        }
        static int ReplaceBitAtPosition(int number, int position, int value)
        {
            if (value == 1)
            {
                number = number | (1 << position);
            }
            else if (value == 0)
            {
                number = number & (~(1 << position));
            }
            return number;
        }
    }
}
