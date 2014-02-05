using System;
// 02.Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. 
//Use a sequence of if statements.

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
                Console.Write("c = ");
                int c = int.Parse(Console.ReadLine());
                char productSign = '+';

                if (a < 0 ^ b < 0 ^ c < 0)
                {
                    productSign = '-';
                }
                Console.WriteLine("The sign of the product is '{0}'", productSign);
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

