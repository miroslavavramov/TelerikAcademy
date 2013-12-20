using System;
//14.* Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Number = ");
                uint number = uint.Parse(Console.ReadLine());
                Console.Write("p = ");
                byte p = byte.Parse(Console.ReadLine());
                Console.Write("q = ");
                byte q = byte.Parse(Console.ReadLine());
                Console.Write("k = ");
                byte k = byte.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("Before the swap \n{0} = {1}", number, GetIntBinaryString(number));

                uint mask = 0;
                for (uint i = 0; i < k; i++)
                {
                    mask = (mask * 2) + 1;    //if k=1 mask=1(bits=1); k=2 mask=3(11); k=3 mask=7(111); k=4 mask=15(1111) ...
                }

                uint bitChangerP = number & (mask << p);
                uint bitChangerQ = number & (mask << q);

                number = (~(mask << p) & number) | (bitChangerQ >> (q - p));
                number = (~(mask << q) & number) | (bitChangerP << (q - p));

                Console.WriteLine();
                Console.WriteLine("After the swap \n{0} = {1} ", number, GetIntBinaryString(number));
                Console.ReadKey();
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

        static string GetIntBinaryString(uint n)        //for given int returns its binary representation
        {                                              
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

