using System;
using System.Text.RegularExpressions;
//Write a program to check if in a given expression the brackets are put correctly.
class CheckBrackets
{
    static void Main()
    {
        Console.WriteLine(Check("(x+y^2)*x-19/((3+x*(7^y))-y)"));
        Console.WriteLine(Check("(9-x*y)*((7-3)*((1-y)"));
        Console.WriteLine(Check(")x+(5+5)/y("));
    }
    static bool Check(string e)
    {
        int leftBracketsCount = e.Length - e.Replace("(", "").Length;
        int rightBracketsCount = e.Length - e.Replace(")", "").Length;

        if (     e.IndexOf('(') > e.IndexOf(')')     ||
             e.LastIndexOf('(') > e.LastIndexOf(')') ||
            leftBracketsCount != rightBracketsCount  )
        {
            return false;
        }
        return true;
    }
}

