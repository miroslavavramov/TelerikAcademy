using System;
//Write a program that finds the maximal sequence of equal elements in an array.
//		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.
    public class MaxSeqOfConsElements
    {
        public static void Main()
        {
            try
            {
                Console.Write("Task 4:\n\n ");
                Console.Write(" How many elements should the array contain? ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                int length = int.Parse(Console.ReadLine());
                Console.WriteLine();
                int[] array = new int[length];
                for (int index = 0; index < length; index++)    //assign values
                {
                    Console.Write("     array[{0}] = ", index);
                    array[index] = int.Parse(Console.ReadLine());
                }

                int counter = 0;
                int biggestSequence = 0;
                int value = 0;

                for (int index = 0; index < length; index++)
                {
                    counter = 0;
                    for (int startIndex = index; startIndex < length; startIndex++)
                    {
                        if (array[index] == array[startIndex])
                        {
                            counter++;
                            if (counter > biggestSequence)
                            {
                                biggestSequence = counter;
                                value = array[index];
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n The longest streak has {0} equal elements of value {1}\n", biggestSequence, value);
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

