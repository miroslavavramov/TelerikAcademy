using System;

//Write a program that compares two char arrays lexicographically (letter by letter).

    public class CompareCharArrays
    {
        public static void Main()
        {
            Console.Write("Define the length of both arrays! ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int length = int.Parse(Console.ReadLine());
            Console.ResetColor();

            char[] arr1 = new char[length];
            char[] arr2 = new char[length];
            //assign values and compare
            Console.WriteLine("\nAssign values: ");
            for (int index = 0; index < length; index++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n   arr1[{0}] = ", index);
                arr1[index] = char.Parse(Console.ReadLine());
                Console.Write("   arr2[{0}] = ", index);
                arr2[index] = char.Parse(Console.ReadLine());
                if (arr1[index] < arr2[index])
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Between [{0}]({2}) and [{1}]({3}), [{0}] comes first",
                        arr1[index], arr2[index], (int)arr1[index], (int)arr2[index]);
                }
                else if (arr1[index] > arr2[index])
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Between [{0}]({2}) and [{1}]({3}), [{1}] comes first",
                        arr1[index], arr2[index], (int)arr1[index], (int)arr2[index]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("You've typed same characters! [{0}]({1})", arr1[index], (int)arr1[index]);
                }
            }
            Console.ResetColor();
            Console.ReadKey();
        }
    }

