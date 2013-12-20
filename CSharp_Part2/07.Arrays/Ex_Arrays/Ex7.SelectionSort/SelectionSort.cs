using System;
//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. 
//Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, 
//move it at the second position, etc.

    class Program
    {
        static void Main()
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

            for (int i = 0; i < length; i++)        //sort the array
            {
                for (int k = i+1; k < length; k++)
                {
                    if (array[i] > array[k])
                    {
                        int temp = array[i];
                        array[i] = array[k];
                        array[k] = temp;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nSorted array: ");
            foreach (var element in array) //print sorted array
            {
                Console.Write(element + " ");
            }
            Console.ResetColor();
            Console.WriteLine("\n\n");
        }
    }
