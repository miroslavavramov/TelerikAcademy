using System;
using System.Threading;
//* Write a program that reads three integer numbers N, K and S and an array of N elements from the console. 
//Find in the array a subset of K elements that have sum S or indicate about its absence.
public class CheckSpecificSubsetSum
{
    public static void Main()
    {
        try
        {
            Console.Write("Task 17: \n\n");
            Console.WriteLine(" Initialize the array.\n Define the length and the scope of its elements:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n Smallest possible member: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("\n Greatest possible member: ");
            int max = int.Parse(Console.ReadLine());
            Console.Write("\n Length = ");
            int length = int.Parse(Console.ReadLine());
            Console.ResetColor();

            if (min > max)  //swap values using bitwise XoR; more info here: http://www.blackwasp.co.uk/XORSwap.aspx
            {
                min = min ^ max;
                max = max ^ min;
                min = min ^ max;
            }

            Random rnd = new Random();  // Random class, which is used to generate random numbers
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = rnd.Next(min, max);  //assign random values(in [min,max] interval) to the elements
            }

            Console.WriteLine("\n Your array is successfully generated!\n");
            Console.Write(" Now type a number to check if there's given\n subset in array, that adds up to this number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int sum = int.Parse(Console.ReadLine());
            Console.ResetColor();
            Console.Write(" \n How many elements should the subset exactly contain? : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int count = int.Parse(Console.ReadLine());
            Console.ResetColor();

            int tempSum = 0;
            int tempCount = 0;
            bool subsetFound = false;
            int totalSubsets = 0;
            Console.ResetColor();

            for (int i = 1; i < 1 << array.Length; i++)     // find subsets
            {
                tempSum = 0;
                tempCount = 0;
                for (int k = 0; k < array.Length; k++)
                {
                    tempSum += array[k] * CheckBitAtPosition(i, k);
                    tempCount += CheckBitAtPosition(i, k);
                }
                if (tempSum == sum && tempCount == count) // print subset
                {
                    totalSubsets++;
                    subsetFound = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\n Subset Found! : { ");
                    for (int k = 0; k < array.Length; k++)
                    {
                        if (CheckBitAtPosition(i, k) == 1)
                        {
                            Console.Write("{0} ", array[k]);
                        }
                    }
                    Console.Write("}");
                }
            }
            if (subsetFound == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n No subset of {0} elements adds up to {1}!", count, sum);
            }
            else
            {
                Console.WriteLine("\n Total Subsets: {0}", totalSubsets);
            }
            Console.Write("\n\n Array: { ");
            foreach (int number in array)
            {
                Console.Write("{0} ", number);
            }
            Console.Write(" }\n\n\t\t\t");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
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
}

