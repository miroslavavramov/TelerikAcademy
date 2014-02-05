using System;
// 08. Write a program that reads an integer number n from the console and 
//prints all the numbers in the interval [1..n], each on a single line.

 class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("n = ");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("numbers [1 ... {0}]", n);
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine(i);
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
        }
    }

