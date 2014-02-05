using System;
using System.Numerics;

// 13*. * Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
//	N = 10  N! = 3628800  2
//  N = 20  N! = 2432902008176640000  4

    class Program
    {
        static void Main()
        {
            BigInteger n = int.Parse(Console.ReadLine());
            BigInteger number = GetFactorial(n);
            BigInteger zeros = 0;

            Console.Write("N = {0} | !N = {1} \n", n, number);

            while (number % 5 == 0)         //The trailing zeros in N! are equal to the number 
            {                               //of its prime divisors of value 5
                zeros++;
                number /= 5;
            }

            Console.WriteLine("Trailing Zeros: {0}", zeros);
            Console.ReadKey();
        }

        static BigInteger GetFactorial(BigInteger num)    // a method that gets a number and returns its factorial product
        {
            BigInteger factorial = 1;

            for (BigInteger i = num; i > 1; i--)
            {
                factorial *= (BigInteger)i;
            }

            return factorial;
        }
    }

