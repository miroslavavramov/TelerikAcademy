using System;
using System.Collections.Generic;
using System.Linq;

class InfiniteConvergentSeries
{
    static double Fact(double n)
    {
        int result = 1;

        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        return (double)result;
    }

    static bool CheckPrecision(double num, int precision)
    {
        return ((num - (int)num).ToString().Length - 2) < precision;
    }

    static double Converge(Func<double, double> operate, Func<int, int> progress, int precision)
    {
        var result = 1d;
        int x = 1;

        while (CheckPrecision(result, precision))
        {
            x = progress(x);
            result += operate(x);
        }

        return result;
    }

    static void Main()
    {
        var resultA = Converge(
            x => 1 / x,
            x => x * 2, 
            precision: 10
            );

        var resultB = Converge(
            x => 1 / Fact(x),
            x => x + 1,
            precision: 10
            );

        var resultC = Converge(
            x => Math.Sqrt(x) % 2 == 0 ? -(1 / x) : 1 / x,
            x => x * 2,
            precision: 10
            );

        Console.WriteLine(resultA);
        Console.WriteLine(resultB);
        Console.WriteLine(resultC);
    }
}

