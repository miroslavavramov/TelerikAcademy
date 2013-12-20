using System;

// 09. We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. 
// Example: 3, -2, 1, 1, 8  1+1-2=0.

namespace Demo1
{
    class Program
    {
        static void Main()
        {
            int[] numbers = new int[5];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            decimal sum;
            for (int i = 1; i < Math.Pow(2, 5); i++)
            {
                sum = 0m;
                for (int j = 0; j < 5; j++)
                {
                    sum += numbers[j] * BinaryDigit(number: i, digit: j);
                }
                if (sum == 0)
                {
                    for (int j = 0; j < 5; j++)
                    {
                         if (BinaryDigit(number: i, digit: j) == 1)
                        {
                            Console.Write("{1}{0}{2} + ", numbers[j], numbers[j] < 0 ? "(" : "", numbers[j] < 0 ? ")" : "");
                        }
                    }
                    Console.WriteLine("\b\b= 0");
                }
            }
        }
        public static int BinaryDigit(int number, int digit)
        {
            return (number & (1 << digit)) >> digit;
        }
    }
}