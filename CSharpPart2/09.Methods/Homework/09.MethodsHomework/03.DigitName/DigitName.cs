using System;
//Write a method that returns the last digit of given integer as an English word.
// Examples: 512  "two", 1024  "four", 12309  "nine".
class DigitName
{
    static void Main()
    {
        long number;
        bool validNumber = long.TryParse(Console.ReadLine(), out number);

        if (validNumber) 
        { 
            PrintLastDigitName(number); 
        }
        else 
        { 
            Console.WriteLine("Invalid Input!"); 
        }
    }
    static void PrintLastDigitName(long n)
    {
        string[] digitNames = {"zero", "one", "two", "three", "four", "five",
                               "six", "seven", "eight", "nine"};

        Console.WriteLine(digitNames[Math.Abs(n) % 10]);
    }
}

