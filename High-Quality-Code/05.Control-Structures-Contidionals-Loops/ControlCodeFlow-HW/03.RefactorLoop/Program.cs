using System;

class Program
{
    static void Main()
    {
        int[] arrayOfNumbers = new int[100];
        int expectedValue = 49;

        for (int index = 0; index < arrayOfNumbers.Length; index++)
        {
            if (index % 10 == 0)
            {
                Console.WriteLine(arrayOfNumbers[index]);

                if (arrayOfNumbers[index] == expectedValue)
                {
                    Console.WriteLine("Value Found");
                    break;
                }
            }
        }
    }
}

