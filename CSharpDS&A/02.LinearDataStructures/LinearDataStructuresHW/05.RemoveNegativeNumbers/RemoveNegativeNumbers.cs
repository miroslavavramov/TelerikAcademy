//Write a program that removes from given sequence all negative numbers.

using System;
using System.Collections.Generic;
using System.Linq;

class RemoveNegativeNumbers
{
    static void Main()
    {
        var numbers = new List<int>() { 1, 4, -3, 4, 5, -1, -1, 2 };

        var positiveNumbers = numbers.Where(x => x > 0);

        Console.WriteLine(string.Join(", ", positiveNumbers));
    }
}

