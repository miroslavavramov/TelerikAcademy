using System;
using System.Numerics;

// 06. Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N

    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine(new string('-', 15) + "S = 1 + 1!/X + 2!/X^2 + … + N!/X^N" + new string('-', 15));
                Console.Write("X = ");
                double x = double.Parse(Console.ReadLine());
                Console.Write("N = ");
                double n = double.Parse(Console.ReadLine());
                double sum = 1;

                if (x != 0)
                {
                    for (double i = n; i > 0; i--)
                    {
                        sum += GetFactorial(i) / Math.Pow(x, i);
                    }
                    Console.WriteLine("S = {0}", sum);    
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                    Console.WriteLine("X shouldn't equal zero!");
                }
                
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            

        }

        static double GetFactorial(double num)    // a method that gets a number and returns its factorial product
        {
            double factorial = 1;

            for (double i = num; i > 1; i--)
            {
                factorial *= i;
            }

            return factorial;
        }
    }

