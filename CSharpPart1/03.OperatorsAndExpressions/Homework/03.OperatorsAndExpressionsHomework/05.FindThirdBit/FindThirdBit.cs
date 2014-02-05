using System;
//05. Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter a number: ");
                int num = int.Parse(Console.ReadLine());
                int p = 3;
                bool check = false;

                Console.Write("Bit [3] of {0} = 1 ? : ", num);

                num = num >> p;
                if ((num & 1) == 1)
                {
                    check = true;
                }
                Console.Write(check);
                Console.WriteLine();
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

