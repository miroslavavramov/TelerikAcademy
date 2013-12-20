using System;

//13.Create a program that assigns null values to an integer and to double variables. 
//Try to print them on the console, try to add some values or the null literal to them and see the result.

    class Program
    {
        static void Main()
        {
            int? num1 = null;
            Console.WriteLine(" {0}, {1}", num1, num1 + 11);           //output: null, null
            double? num2 = null;
            Console.WriteLine(" {0}, {1}", num2, num2 + 11);           //output: null, null

            num1 = 42;
            num2 = 84;
            Console.WriteLine(num1 + ", " + num2);

            Console.ReadKey();
        }
    }

