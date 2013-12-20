using System;
using System.Collections.Generic;
//* Write a program that reads an array of integers and removes from it a minimal number of elements 
//in such way that the remaining array is sorted in increasing order. Print the remaining sorted array. 
//Example: 	{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}
    public class SortByRemoving
    {
        public static void Main()
        {
            try
            {
                Console.Write("Task 18:\n\n ");
                Console.Write(" How many elements should the array contain? ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                int length = int.Parse(Console.ReadLine());
                Console.WriteLine();
                int[] sequence = new int[length];

                for (int index = 0; index < length; index++)    //assign values
                {
                    Console.Write("     array[{0}] = ", index);
                    sequence[index] = int.Parse(Console.ReadLine());
                }

                List<int> maxIncreasingSubset = new List<int>();
                List<int> bufferSubset = new List<int>();

                for (int i = 1; i < 1 << sequence.Length; i++)  //generate every possible subset
                {
                    for (int k = 0; k < sequence.Length; k++)
                    {
                        if (sequence[k] * CheckBitAtPosition(i, k) != 0)
                        { bufferSubset.Add(sequence[k]); } 
                    }
                    if (CheckIfIncreasing(bufferSubset) == true && bufferSubset.Count > maxIncreasingSubset.Count) 
                    { maxIncreasingSubset = AssignValues(bufferSubset, maxIncreasingSubset); }
                    bufferSubset.Clear();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n Maximal increasing subset : { ");
                foreach (var item in maxIncreasingSubset)
                {
                    Console.Write(item + " ");
                }
                Console.Write("}\n\n");
                Console.ResetColor();
                Console.ReadKey();
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
        static int CheckBitAtPosition(int number, int position)
        {
            int bit = (number & ((int)1 << position)) >> position;
            return bit;
        }
        static bool CheckIfIncreasing(List<int> collection)
        {
            bool isIncreasing = true;
            for (int i = 0; i < collection.Count-1; i++)
            {
                if (collection[i] > collection[i+1])
                {
                    isIncreasing = false;
                    break;
                }
            }
            return isIncreasing;
        }
        static List<int> AssignValues(List<int> buffer, List<int> collection)
        {
            collection.Clear();
            for (int i = 0; i < buffer.Count; i++)
            {
                collection.Add(buffer[i]);
            }
            return collection;
        }
    }

