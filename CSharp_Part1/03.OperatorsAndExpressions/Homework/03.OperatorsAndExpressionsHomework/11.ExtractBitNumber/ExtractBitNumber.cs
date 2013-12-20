using System;

//11.Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2  value=1.

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("number = ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("[bit] = ");
                int p = int.Parse(Console.ReadLine());
                if ((p < 32) && (p >= 0)) //variable of type "int" contains 32 bits
                {
                    int value = (number >> p) & 1;

                    Console.WriteLine("Bit number [{0}] of {1} equals {2} ", p, number, value);
                }
                else
                {
                    Console.WriteLine("The number {0} is of type Int32 and contains only 32 bits[0..31]", number);
                }
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

