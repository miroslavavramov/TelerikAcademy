using System;
//Write a program that finds in given array of integers a sequence of given sum S (if present). 
//Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}
    public class FindSumInArray
    {
        public static void Main()
        {
            try
            {
                Console.Write("Task 10:\n\n ");
                Console.Write(" Enter wanted sum: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                int s = int.Parse(Console.ReadLine());

                Console.ResetColor();
                Console.Write("\n  How many elements should the array contain? ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                int length = int.Parse(Console.ReadLine());
                Console.WriteLine();

                int[] array = new int[length];

                for (int index = 0; index < length; index++)    //assign values
                {
                    Console.Write("     array[{0}] = ", index);
                    array[index] = int.Parse(Console.ReadLine());
                }

                int tempSum = 0;
                int startIndex = 0;
                int endIndex = 0;
                bool isFound = false;

                for (int i = 0; i < length && isFound == false; i++)
                {
                    tempSum = 0;
                    for (int k = i; k < length; k++)
                    {
                        tempSum += array[k];
                        if (tempSum == s)
                        {
                            startIndex = i;
                            endIndex = k;
                            isFound = true;
                            break;
                        }
                    }
                }

                if (isFound)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n  Sequence which adds up to {0} : ( ", s);
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        Console.Write(array[i] + " ");
                    }
                    Console.Write(")\n\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  There's no such sequence!\n\n");
                }
                Console.ResetColor();
            }
            catch
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

