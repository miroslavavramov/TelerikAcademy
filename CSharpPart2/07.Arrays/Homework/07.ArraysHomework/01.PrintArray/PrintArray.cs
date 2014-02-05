using System;
using System.Threading;
//Write a program that allocates array of 20 integers and initializes each 
//element by its index multiplied by 5. Print the obtained array on the console.
public class PrintArray
{
    public static void Main()
    {
        Console.WriteLine("Task 1: ");
        int[] array = new int[20];
        Console.WriteLine();
        //assign values
        for (int index = 0; index < array.Length; index++)
        {
            array[index] = index * 5;
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" element[{0}] = ", index);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0} \n", array[index]);
        }
        Console.ReadKey();
    }
}

