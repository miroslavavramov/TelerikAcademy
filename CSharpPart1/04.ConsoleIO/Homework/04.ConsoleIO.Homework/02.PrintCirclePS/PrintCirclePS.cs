using System;
// 02.Write a program that reads the radius r of a circle and prints its perimeter and area.
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("r = ");
                double r = double.Parse(Console.ReadLine());

                Console.WriteLine("P = {0}", 2 * Math.PI * r);
                Console.WriteLine("S = {0}", Math.PI * Math.Pow(r, 2));
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }
    }

