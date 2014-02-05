using System;
//Write a program that finds all prime numbers in the range [1...10 000 000]. 
//Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
public class SieveOfErathosthenesAlgorithm
{
    public static void Main()
    {
        Console.BufferHeight = 500;
        try
        {
            Console.Write("Task 15: \n\n");
            Console.Write(" Max number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int n = int.Parse(Console.ReadLine());

            int totalPrimes = 0;

            bool[] isComposite = new bool[n + 1];
            //find primes
            for (int i = 2; i * i <= n; i++)
            {
                if (!isComposite[i])
                {
                    for (int k = i; i * k <= n; k++)
                    {
                        isComposite[i * k] = true;
                    }
                }
            }
            //print primes
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Prime numbers [1..{0}] : ", n);
            for (int i = 1; i < n; i++)
            {
                if (!isComposite[i])
                {
                    totalPrimes++;
                    Console.WriteLine(" " + i);
                }
            }
            Console.WriteLine("\n Total Primes: {0}", totalPrimes);
            Console.WriteLine();
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\n You did something wrong!\n Type task number and press");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" <ENTER> ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("to try again.\n");
            Console.ResetColor();
        }
    }

}

