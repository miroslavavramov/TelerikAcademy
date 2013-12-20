using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Secrets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            BigInteger number = BigInteger.Parse(input);
            if (number < 0)
            {
                number *= -1;
            }
            BigInteger specialSum = 0;
            BigInteger remainder = 0;

            string[] alphabet = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q",
                                "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

            for (int i = 1; i <= input.Length; i++)
            {
                remainder = number % 10;
                number /= 10;

                if(i % 2 != 0)
                {
                    specialSum += i * i * remainder; 
                }
                else
                {
                    specialSum += remainder * remainder * i; 
                }
            }

            Console.WriteLine(specialSum);

            BigInteger r = specialSum % 26;
            BigInteger letters = specialSum % 10;

            if (letters == 0)
            {
                Console.WriteLine("{0} has no secret alpha-sequence", input);
            }
            else
            {
                for (int i = 0; i < letters; i++)
                {
                    if (r >= alphabet.Length)
                    {
                        r = 0;
                        Console.Write(alphabet[(int)r]);
                        r++;
                    }
                    else
                    {
                        Console.Write(alphabet[(int)r]);
                        r++;
                    }
                    
                }
            }


            Console.WriteLine();

        }
    }
}
