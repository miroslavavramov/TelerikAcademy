using System;
//08.Write an expression that calculates trapezoid's area by given sides a and b and height h.

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
                Console.Write("h = ");
                double h = double.Parse(Console.ReadLine());

                Console.WriteLine("The trapezoid's area equals: {0}", ((a + b) * h) / 2);
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

