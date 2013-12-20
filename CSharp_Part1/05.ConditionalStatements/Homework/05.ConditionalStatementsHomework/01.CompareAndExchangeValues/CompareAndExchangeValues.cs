using System;
//1. Write an if statement that examines two integer variables and exchanges their values if 
//the first one is greater than the second one.

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("a = ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("b = ");
                int b = int.Parse(Console.ReadLine());
                int c;
                bool aGreaterThanB = false;

                if (a > b)
                {
                    aGreaterThanB = true;
                    c = a;
                    a = b;
                    b = c;
                }
                Console.Write("a > b ? {0} \na = {1} b = {2}\n", aGreaterThanB, a, b);
                Console.ReadKey();
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }

        }
    }


