using System;
using System.Threading;
//* Modify your last program and try to make it work for any number type, 
//not just integer (e.g. decimal, float, byte, etc.). Use generic method (read in Internet about generic methods in C#).

class ParametersGeneric
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        Console.WriteLine("Min : " + MinCalc(1, 89, 3, 54, 712, 1002, 0.151, 18, 29, 10));
        Console.WriteLine("Max : " + MaxCalc(-21, 800, 31, 5.4, 712, 122, 171, 18, 23.3, 10));
        Console.WriteLine("Average : " + AvrgCalc(1, 23, 29, 11, 83, -111));
        Console.WriteLine("Sum : " + SumCalc(1, 89, -102, 99.99, 11, 3, -54, 712, 1.002, 151, 18, 2.79, 10));
        Console.WriteLine("Product : " + ProductCalc(931, -0.89, -3, 10));
    }
    static T MinCalc<T>(params T[] arr)
    {
        Array.Sort(arr);
        return arr[0];
    }
    static T MaxCalc<T>(params T[] arr)
    {
        Array.Sort(arr);
        return arr[arr.Length - 1];
    }
    static double AvrgCalc<T>(params T[] arr) 
    {
        return Convert.ToDouble(SumCalc(arr)) / arr.Length;
    }
    static T SumCalc<T>(params T[] arr)
    {
        dynamic sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }
    static T ProductCalc<T>(params T[] arr)
    {
        dynamic prod = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            prod *= arr[i];
        }
        return prod;
    }
}

