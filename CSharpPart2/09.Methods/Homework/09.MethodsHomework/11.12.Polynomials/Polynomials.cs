using System;
using System.Collections.Generic;
//11.Write a method that adds two polynomials. Represent them as arrays of their coefficients 
//as in the example below:	x^2 + 5 = 1*x^2 + 0^x^1 + 5 
//12.Extend the program to support also subtraction and multiplication of polynomials.

class Polynomials
{
    static void Main()
    {
        PrintPolynomial(Add(new List<int> { 5, -1, 2, 3, 0 }, new List<int> { 0, -3, 1, 2, 3 })); 
        PrintPolynomial(Subtract(new List<int> {1, 5, 0, 2 }, new List<int> {6, 2, 0, 0 }));                    
        PrintPolynomial(Multiply(new List<int> { 2, 6, 2, 1, 0, 2, 2 }, new List<int> {5, 3, 0, 0, 1, 2, 7}));
    }

    static List<int> Add(List<int> p1, List<int> p2)
    {
        List<int> sum = new List<int>(Math.Max(p1.Count, p2.Count));

        for (int i = 0; i < sum.Capacity; i++)
        {
            sum.Add(p1[i] + p2[i]);
        }
        return sum;
    }

    static List<int> Subtract(List<int> p1, List<int> p2)
    {
        List<int> sum = new List<int>(Math.Max(p1.Count, p2.Count));

        for (int i = 0; i < sum.Capacity; i++)
        {
            sum.Add(p1[i] - p2[i]);
        }
        return sum;
    }

    static List<int> Multiply(List<int> p1, List<int> p2)
    {
        List<int> sum = new List<int>(Math.Max(p1.Count, p2.Count));

        for (int i = 0; i < sum.Capacity; i++)
        {
            sum.Add(p1[i] * p2[i]);
        }
        return sum;
    }

    static void PrintPolynomial(List<int> p)
    {
        for (int i = p.Count-1; i >= 0; i--)
        {
            Console.Write("{0}*x^{1}", p[p.Count - 1 - i],i);
            if(i > 0)
            {
                Console.Write(p[p.Count-i] >= 0 ? "+" : "");
            }
        }
        Console.WriteLine();
    }
}

