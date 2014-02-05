using System;
// 07. Write a program that reads a number N and calculates the sum of the first N members  
//     of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

    class Program
    {
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            decimal member = 0;
            decimal nextMember = 1;
            decimal tempSum = 0;
            decimal sum = member + nextMember;

            for (int i = 2; i < n; i++)
            {
                tempSum = member + nextMember;
                member = nextMember;
                nextMember = tempSum;
                sum += tempSum;
            }
            Console.WriteLine("Sum [1..n] members of the Fibonacci sequence = {0}", sum);
        }
    }

