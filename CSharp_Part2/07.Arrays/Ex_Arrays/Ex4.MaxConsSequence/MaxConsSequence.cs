using System;
//Write a program that finds the maximal sequence of equal elements in an array.
//		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.

    public class MaxConsSequence
    {
        public static void Main()
        {
            Console.Write("How many elements should the array contain? ");
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
            Console.WriteLine("\nThe longest streak has {0} equal elements of value {1}\n", biggestSequence, value);
            Console.ResetColor();
        }
    }

