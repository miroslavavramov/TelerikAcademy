using System;

//04.Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the 
//reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("a = ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("b = ");
                int b = int.Parse(Console.ReadLine());
                int numbers = 0;
                if (a > b)
                {
                    for (int i = b; i <= a; i++)
                    {
                        if (i % 5 == 0)
                        {
                            numbers++;
                        }
                    }
                    Console.WriteLine("From {0} to {1} there are {2} numbers divisible by 5 without remainder."
                        , a, b, numbers);
                }
                else
                {
                    for (int i = a; i <= b; i++)
                    {
                        if (i % 5 == 0)
                        {
                            numbers++;
                        }
                    }
                    Console.WriteLine("From {0} to {1} there are {2} numbers divisible by 5 without remainder."
                        , a, b, numbers);
                }
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
        }
    }
