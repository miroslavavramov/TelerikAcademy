using System;

//13. Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter Number: ");
                uint number = uint.Parse(Console.ReadLine());
                Console.WriteLine("Before the swap: ");
                Console.WriteLine("{0} = {1} ", number, GetIntBinaryString(number));

                uint mask = 7;  // binary representation of 7 is 111
                uint getBits345 = number & (mask << 3);
                uint getBits242526 = number & (mask << 21);

                number = (number & (~(mask << 3) | (getBits242526 >> 21)));
                number = (number & (~(mask << 21)) | (getBits345 << 21));

                Console.WriteLine();
                Console.WriteLine("After the swap: ");
                Console.WriteLine("{0} = {1} ", GetIntBinaryString(number), number);
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

        static string GetIntBinaryString(uint n)        //method that for given uint returns its 
        {                                               //binary representation
            char[] b = new char[32];
            int pos = 31;
            int i = 0;

            while (i < 32)
            {
                if ((n & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            }
            return new string(b);
        }
    }

