using System;
//You are given a sequence of positive integer values written into a string, separated by spaces. 
//Write a function that reads these values from given string and calculates their sum. 
//Example:	string = "43 68 9 23 318"  result = 461
class CalcSum
{
    static void Main()
    {
        string[] numsAsStrings = Console.ReadLine().Split(' ');
        int sum = 0;

        for (int i = 0; i < numsAsStrings.Length; i++)
        {
            sum += int.Parse(numsAsStrings[i]);
        }
        Console.WriteLine(sum);
    }
}