using System;

// 2.Which of the following values can be assigned to a variable of type float and which to a variable of type double: 
// 34.567839023, 12.345, 8923.1234857, 3456.091?

    class Assign_Float_Double
    {
        static void Main()
        {
            double num1 = 34.56789023d;
            float num2 = 12.345f;
            double num3 = 8923.1234857d;
            float num4 = 3456.091f;

            Console.WriteLine(num1 + "\n" + num2 + "\n" + num3 + "\n" + num4);
            Console.ReadKey();
        }
    }

