using System;
//Write a program that creates an array containing all letters from the alphabet (A-Z). 
//Read a word from the console and print the index of each of its letters in the array.
public class ArrayOfLetters
{
    public static void Main()
    {
        Console.BufferHeight = 250;
        Console.Write("Task 12: \n");
        Console.Write("\n Type a random word: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string inputString = Console.ReadLine();
        inputString = inputString.ToUpper();    // turns all letters to uppercase

        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        Console.WriteLine();

        //Find indices of the word's letters
        for (int i = 0; i < inputString.Length; i++)
        {
            for (int k = 0; k < alphabet.Length; k++)
            {
                if (inputString[i] == alphabet[k])
                {
                    Console.Write(" {0}", inputString[i]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" has an index of : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" {0}\n", k);
                    break;
                }
            }
        }
        Console.WriteLine();
        Console.ResetColor();
        Console.ReadKey();
    }
}

