using System;
//Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
    public class MaxIncreasingSeq
    {
        public static void Main()
        {
            try 
            {
                Console.Write("Task 5:\n\n ");
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
                int maxCount = 0;
                int lastIndex = 0;

                for (int index = 0; index < length; index++)            //find the longest sequence
                {
                    counter = 0;
                    for (int tempIndex = 0; tempIndex < length-1; tempIndex++)
                    {
                        if (array[tempIndex] < array[tempIndex+1])
                        {
                            counter++;
                            if (counter > maxCount)
                            {
                                maxCount = counter;
                                lastIndex = tempIndex + 1;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n Maximal increasing sequence:   (");
                for (int i = lastIndex-maxCount; i <= lastIndex; i++)       //print sequence
                {
                    Console.Write(" {0} ", array[i]);
                }
                Console.Write(")\n\n");
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

