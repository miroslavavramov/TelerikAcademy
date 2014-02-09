//Define a class BitArray64 to hold 64 bit values inside an ulong value. 
//Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

using System;
using System.Collections.Generic;

class BitArrayTest
{
    static void Main()
    {
        BitArray64 b1 = new BitArray64(127);

        Console.WriteLine(b1);
        b1[3] = 0;
        Console.WriteLine(b1);

        foreach (var item in b1)
        {
            Console.WriteLine(item);
        }

        BitArray64 b2 = new BitArray64(127);
        
        Console.WriteLine(b1 == b2);
        b1[3] = 1;
        Console.WriteLine(b1 != b2);
        Console.WriteLine(b1.GetHashCode());
    }
}

