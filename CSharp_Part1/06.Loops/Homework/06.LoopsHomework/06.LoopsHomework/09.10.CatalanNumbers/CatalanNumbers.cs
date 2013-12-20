using System;

// 10.Write a program to calculate the Nth Catalan number by given N.

    class Program
    {
        static void Main()
        {
            double n = double.Parse(Console.ReadLine());
            double catalanNumber = GetFactorial(2 * n) / (GetFactorial(n + 1) * GetFactorial(n));

            Console.WriteLine("If n = {0} => the Catalan number equals {1}", n, catalanNumber);
        }
        static double GetFactorial(double num)    // a method that gets a number and returns its factorial product
        {
            double factorial = 1;

            for (double i = num; i > 1; i--)
            {
                factorial *= (double)i;
            }

            return factorial;
        }
    }

