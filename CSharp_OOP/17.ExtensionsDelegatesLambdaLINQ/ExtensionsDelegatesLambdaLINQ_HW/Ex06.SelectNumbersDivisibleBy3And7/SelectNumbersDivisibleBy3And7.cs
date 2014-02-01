using System;
using System.Linq;
//Write a program that prints from given array of integers all numbers that are 
//divisible by 7 and 3. Use the built-in extension methods and lambda expressions. 
//Rewrite the same with LINQ.

class SelectNumbersDivisibleBy3And7
{
    static void Main()
    {
        int[] numbers = new int[100];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
        }

        var selectedUsingLambda =
            numbers.Where(x => (x % 21 == 0));

        var selectedUsingLinq =
            from n in numbers
            where (n % 21 == 0)
            select n;

        foreach (var n in selectedUsingLambda)
        {
            Console.WriteLine(n);
        }

        foreach (var n in selectedUsingLinq)
        {
            Console.WriteLine(n);
        }
    }
}

