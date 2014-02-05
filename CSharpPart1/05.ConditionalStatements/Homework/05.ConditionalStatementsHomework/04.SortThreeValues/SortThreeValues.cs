using System;
// 04. Sort 3 real values in descending order using nested if statements.
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
                    if (b >= c)
                    {
                        Console.WriteLine(a + ", " + b + ", " + c);
                    }
                    if (c >= b && a >= c)
                    {
                        Console.WriteLine(a + ", " + c + ", " + b);
                    }
                }

                if (b >= a)
                {
                    if (a >= c)
                    {
                        Console.WriteLine(b + ", " + a + ", " + c);
                    }
                    if (b >= c && c >= a)
                    {
                        Console.WriteLine(b + ", " + c + ", " + a);
                    }
                }

                if (c >= b)
                {
                    if (b >= a)
                    {
                        Console.WriteLine(c + ", " + b + ", " + a);
                    }
                    if (c >= a && a >= b)
                    {
                        Console.WriteLine(c + ", " + a + ", " + b);
                    }
                }
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

