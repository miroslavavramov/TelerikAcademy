using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleRotationDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            char digit = '\0';

            for (int i = 1; i <= 3; i++)
            {
                digit = number[number.Length - i];
                if (digit == '0')
                {
                    continue;
                }
                number = digit + number;
            }

            for (int i = 0; i < number.Length-3; i++)
            {
                Console.Write(number[i]);
            }
            Console.WriteLine();
        }
    }
}
