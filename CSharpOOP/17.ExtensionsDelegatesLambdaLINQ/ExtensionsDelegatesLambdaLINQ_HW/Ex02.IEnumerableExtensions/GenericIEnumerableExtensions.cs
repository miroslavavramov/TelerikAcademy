using System;
using System.Collections.Generic;
using System.Linq;

public static class GenericIEnumerableExtensions
{
    public static T Sum<T>(this IEnumerable<T> collection)
        where T : struct
    {
        dynamic sum = default(T);

        foreach (var item in collection)
        {
            sum += item;
        }

        return sum;
    }

    public static T Product<T>(this IEnumerable<T> collection)
    {
        dynamic prod = 1;

        foreach (var item in collection)
        {
            prod *= item;
        }

        return prod;
    }

    public static decimal Average<T>(this IEnumerable<T> collection)
    {
        dynamic avrg = default(T);
        int count = 0;

        foreach (var item in collection)
        {
            avrg += item;
            count++;
        }

        return Math.Round(avrg/(decimal)count,3);
    }

    public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
    {
        dynamic min = collection.First();

        foreach (var item in collection)
        {
            min = min > item ? item : min;
        }

        return min;
    }

    public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
    {
        dynamic max = collection.First();

        foreach (var item in collection)
        {
            max = max < item ? item : max;
        }

        return max;
    }
}