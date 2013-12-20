using System;
// 05.Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("a = ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("b = ");
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine("{0} is the greater number", Math.Max(a, b));
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }
        
    }

