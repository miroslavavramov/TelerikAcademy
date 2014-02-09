using System;
using System.Collections.Generic;

class InfiniteConvergentSeries
{
    static void Main()
    {
        Console.WriteLine(Math.Pow(-2,2));
    }
    private static double GetEulerPartialSum()
    {
        double sum = 0.0;

        for (int i = 1; ; i++)
        {
            sum += 1.0 / Math.Pow(i, 2);
        }

        return sum;
    }
}

