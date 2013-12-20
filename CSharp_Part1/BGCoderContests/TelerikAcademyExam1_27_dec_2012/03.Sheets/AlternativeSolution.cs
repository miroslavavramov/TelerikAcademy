

using System;

class Sheets
{
    static void Main()
    {
        ushort n = ushort.Parse(Console.ReadLine());
        byte counter = 0;
        byte[] bits = new byte[11];
        //проверка на битовете
        while (n != 0)
        {
            int bitCheck = n & 1;
            if (bitCheck == 1)
            {
                bits[counter]++;
            }
            n >>= 1;
            counter++;
        }

        for (int i = 0; i < 11; i++)
        {
            if (bits[i] != 1)
            {
                Console.WriteLine("A{0}", (10 - i));
            }
        }
    }
}

