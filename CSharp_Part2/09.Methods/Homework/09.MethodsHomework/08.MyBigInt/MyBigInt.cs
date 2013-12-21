using System;
//Write a method that adds two positive integer numbers represented as arrays of digits
//(each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
//Each of the numbers that will be added could have up to 10 000 digits.

class MyBigInt
{
    static void Main()
    {
        PrintTrangle(5);
    }
    static void PrintTrangle(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int k = 1; k <= i; k++)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();
        }
    }
}
