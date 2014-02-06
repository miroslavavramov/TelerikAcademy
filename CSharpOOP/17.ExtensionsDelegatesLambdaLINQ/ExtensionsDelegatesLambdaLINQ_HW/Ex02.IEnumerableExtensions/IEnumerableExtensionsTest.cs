using System;
using System.Collections.Generic;
//Implement a set of extension methods for IEnumerable<T> that implement the following group functions:
//sum, product, min, max, average.

class IEnumerableExtensions
{
    static void Main()
    {
        Console.WriteLine(new int[]{1, 2, 3, 4}.Sum());
        Console.WriteLine(new double[] { 11.11, 5, 0.4, 2 }.Product());
        Console.WriteLine(new List<double>(){0.1, 0.11, 0.09, 0.091}.Min());
        Console.WriteLine(new HashSet<byte>() {1, 91, 100, 127, 255, 0, 2, 67 }.Max());
        Console.WriteLine(new SortedSet<short>() {99, 11, -54, 7, 1, 109 }.Average());
    }
}