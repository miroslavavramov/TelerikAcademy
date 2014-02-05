using System;
//07.Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter a number: ");
                int n = int.Parse(Console.ReadLine());
                bool isPrime = true;

                for (int i = 2; i < Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        break;                  // stops the loop's execution and leaves its body 
                    }
                }
                Console.WriteLine("{0} is prime? : {1}", n, isPrime);
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
    }

