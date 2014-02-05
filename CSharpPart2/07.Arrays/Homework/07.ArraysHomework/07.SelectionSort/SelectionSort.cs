using System;
//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. 
//Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, 
//move it at the second position, etc.
public class SelectionSort
{
    public static void Main()
    {
        try
        {
            Console.Write("Task 7:\n\n ");
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

            for (int i = 0; i < length; i++)        //sort the array
            {
                for (int k = i + 1; k < length; k++)
                {
                    if (array[i] > array[k])    //swap values using bitwise XoR; 
                    {                           //more info here: http://www.blackwasp.co.uk/XORSwap.aspx
                        array[i] ^= array[k];
                        array[k] ^= array[i];
                        array[i] ^= array[k];
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n  Sorted array: ");
            foreach (var element in array) //print sorted array
            {
                Console.Write(element + " ");
            }
            Console.ResetColor();
            Console.WriteLine("\n\n");
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

