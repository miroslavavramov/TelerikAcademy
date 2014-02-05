using System;

// 04. Write a program that calculates N!/K! for given N and K (1<K<N).

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("N = ");
                double n = double.Parse(Console.ReadLine());
                Console.Write("K = ");
                double k = double.Parse(Console.ReadLine());

                if (n <= 1 || k <= 1)
                {
                    Console.WriteLine("N and K must be > 1");
                }
                else
                {
                    if (n > k)
                    {
                        Console.WriteLine("N!/K! = {0}", GetFactorial(n) / GetFactorial(k));
                    }
                    else if (n < k)
                    {
                        Console.WriteLine("K!/N! = {0}", GetFactorial(k) / GetFactorial(n));
                    }
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
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

