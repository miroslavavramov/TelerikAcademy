using System;
using System.Numerics;

// 05.Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("K = ");
                BigInteger k = BigInteger.Parse(Console.ReadLine());
                Console.Write("N = ");
                BigInteger n = BigInteger.Parse(Console.ReadLine());

                if (n <= 1 || k <= 1 || k < n )
                {
                    Console.WriteLine("N && K must be > 1 && K > N ");
                }
                else
                {
                    BigInteger result = (GetFactorial(n) * GetFactorial(k)) / GetFactorial(k - n);
                    Console.WriteLine("N!*K! / (K-N)! = {0}", result);
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

        static BigInteger GetFactorial(BigInteger num)    // a method that gets a number and returns its factorial product
        {
            BigInteger factorial = 1;

            for (BigInteger i = num; i > 1; i--)
            {
                factorial *= i;
            }

            return factorial;
        }   
    }
