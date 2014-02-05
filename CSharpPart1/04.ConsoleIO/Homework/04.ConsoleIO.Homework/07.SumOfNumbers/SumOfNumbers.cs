using System;
// 07. Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("How many numbers you want to enter ? ");
                int numbers = int.Parse(Console.ReadLine());
                int sum = 0;
                for (int i = 1; i <= numbers; i++)
                {
                    Console.Write("number[{0}] = ", i);
                    int number = int.Parse(Console.ReadLine());
                    sum += number;
                }
                Console.WriteLine("sum = {0}", sum);
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

