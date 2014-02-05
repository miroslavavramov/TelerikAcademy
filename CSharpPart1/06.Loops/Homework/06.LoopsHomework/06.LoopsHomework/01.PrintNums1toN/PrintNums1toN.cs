using System;
// 01. Write a program that prints all the numbers from 1 to N.

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("N = ");
                int n = int.Parse(Console.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine(i);
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
    }

