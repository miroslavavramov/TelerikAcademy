using System;
// 03. Write a program that finds the biggest of three integers using nested if statements.

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

                if (a >= b)
                {
                    if (a >= c)
                    {
                        Console.WriteLine("{0} is the greatest number", a);
                    }
                    else
                    {
                        Console.WriteLine("{0} is the greatest number", c);
                    }
                }
                else if (b >= a)
                {
                    if (b >= c)
                    {
                        Console.WriteLine("{0} is the greatest number", b);
                    }
                    else
                    {
                        Console.WriteLine("{0} is the greatest number", c);
                    }
                }
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

