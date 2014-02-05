using System;
//11. Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.

    class Program
    {
        static void Main()
        {
            int a = 5;
            int b = 10;
            int c = 0; 

            Console.WriteLine("a = {0} b = {1}", a, b);

            c = a;
            a = b;
            b = c;

            Console.WriteLine("a = {0} b = {1}", a, b);
            Console.ReadKey();
        }
    }

