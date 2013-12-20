using System;
//09. Write a program to print the first 100 members of the sequence of Fibonacci: 
//0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

    class Program
    {
        static void Main()
        {
            decimal a = 0;
            decimal b = 1;
            decimal sum = 0;

            Console.WriteLine("member[0] = {0}", a);
            Console.WriteLine("member[1] = {0}", b);
            for (int i = 2; i < 100; i++)
            {
                sum = a + b;
                a = b;
                b = sum;
                Console.WriteLine("member[{0}] = {1}", i, sum);
            }
        }
    }

