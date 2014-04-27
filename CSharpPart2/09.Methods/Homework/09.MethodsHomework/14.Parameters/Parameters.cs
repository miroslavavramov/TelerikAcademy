using System;
//Write methods to calculate minimum, maximum, average, sum and product of
//given set of integer numbers. Use variable number of arguments.

class Parameters
{
    static void Main()
    {
        Console.WriteLine("Min : " + MinCalc(1, 89, 3, 54, 712, 1002, 151, 18, 29, 10));
        Console.WriteLine("Max : " + MaxCalc(21, 800, 31, 54, 712, 122, 171, 18, 233, 10));
        Console.WriteLine("Average : " + AvrgCalc(1, 23, 29, 11, 83, 111));
        Console.WriteLine("Sum : " + SumCalc(1, 89, 102, 9999, 11, 3, 54, 712, 1002, 151, 18, 29, 10));
        Console.WriteLine("Product : " + ProductCalc(931, 89, 3, 10));
    }

    static long MinCalc(params long[] arr)
    {
        Array.Sort(arr);
        return arr[0];
    }

    static long MaxCalc(params long[] arr)
    {
        Array.Sort(arr);
        return arr[arr.Length-1];
    }

    static double AvrgCalc(params long[] arr)
    {
        double avrg = (double)SumCalc(arr)/ (double)arr.Length;
        return avrg;
    }

    static long SumCalc(params long[] arr)
    {
        long sum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    static long ProductCalc(params long[] arr)
    {
        long prod = 1;

        for (int i = 0; i < arr.Length; i++)
        {
            prod *= arr[i];
        }

        return prod;
    }
}

