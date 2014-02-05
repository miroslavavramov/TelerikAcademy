using System;

//10.Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. 
//Example: v=5; p=1  false.

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
                bool check = false;
                if (p < 31)
                {
                    if (((number >> p) & 1) == 1)       //moves the bits "p" positions rightwards  
                    {                                   //and collates it with 1
                        check = true;
                    }
                    Console.WriteLine("Bit number [{0}] of {1} equals 1 ? : {2} ", p, number, check);
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
            Console.ReadKey();
        }
    }
