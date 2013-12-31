using System;
//Write a program that generates and prints to the console 10 random values in the range [100, 200].
class RandomValues
{
    static readonly Random globalRandomGenerator = new Random();
    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(globalRandomGenerator.Next(100, 201));
        }
    }
}

