using System;

    //12. We are given integer number n, value v (v=0 or 1) and a position p. 
    //Write a sequence of operators that modifies
    //n to hold the value v at the position p from the binary representation of n.
	//Example: n = 5 (00000101), p=3, v=1  13 (00001101)
	//n = 5 (00000101), p=2, v=0  1 (00000001)

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Number = ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Position = ");
                int position = int.Parse(Console.ReadLine());
                Console.Write("Value (0 or 1) = ");
                int value = int.Parse(Console.ReadLine());

                if (((position < 32) || (position >= 0))  && ((value == 0 || value == 1))) 
                {
                    int mask = 1 << position;
                    int bit = value << position;

                    number = (number & (~mask)) | bit;  //gets the value at given position and collates it with the new value

                    Console.WriteLine(number);
                }
                else
                {
                    Console.WriteLine("The number {0} is of type Int32 and contains only 32 bits[0..31]", number);
                    Console.WriteLine("You've either entered an unappropriate position or your value != 0 or 1" );
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }

        }
    }
