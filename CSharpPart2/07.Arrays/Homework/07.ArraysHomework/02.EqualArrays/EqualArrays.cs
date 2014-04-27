using System;
//Write a program that reads two arrays from the console and compares them element by element.
public class EqualArrays
{
    public static void Main()
    {
        try
        {
            Console.Write("Task 2:\n\n ");
            Console.Write("Define the length of Array 1 and Array 2 : \n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n   Length of Array 1 = ");
            int firstArrayLength = int.Parse(Console.ReadLine());
            Console.Write("   Length of Array 2 = ");
            int secondArrayLength = int.Parse(Console.ReadLine());
            Console.ResetColor();

            bool areEqual = true;

            if (firstArrayLength != secondArrayLength)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nArrays are NOT equal!\n");
                Console.ResetColor();
            }
            else
            {
                int[] firstArray = new int[firstArrayLength];
                int[] secondArray = new int[secondArrayLength];

                Console.WriteLine("\nAssign values of Array 1 : ");     //read array 1

                for (int index = 0; index < firstArrayLength; index++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("   element[{0}] = ", index);
                    firstArray[index] = int.Parse(Console.ReadLine());
                }

                Console.ResetColor();
                Console.WriteLine("\nAssign values of Array 2 : ");     //read array 2 and compare

                for (int index = 0; index < secondArrayLength; index++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("   element[{0}] = ", index);
                    secondArray[index] = int.Parse(Console.ReadLine());

                    if (firstArray[index] != secondArray[index])
                    {
                        areEqual = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nArrays are NOT equal!");
                        break;
                    }
                }

                if (areEqual)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nArrays are equal!");
                }
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        catch (Exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\n You did something wrong!\n Type task number and press");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" <ENTER> ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("to try again.\n");
            Console.ResetColor();
        }

    }
}

