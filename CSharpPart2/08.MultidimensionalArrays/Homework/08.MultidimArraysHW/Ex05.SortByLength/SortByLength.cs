using System;
//You are given an array of strings. Write a method that sorts the array by the length 
//of its elements (the number of characters composing them).

class SortByLength
{
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Write("How many words you want to type ? : ");
                int n = int.Parse(Console.ReadLine());
                string[] arr = new string[n];

                for (int i = 0; i < n; i++)
                {
                    arr[i] = Console.ReadLine();
                }

                arr = Sort(arr);
                Console.Write("\nSorted by length: \n");

                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }
                    
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\nPress <ENTER> to try again.");
            ConsoleKeyInfo pressedKey = Console.ReadKey();

            if (pressedKey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                continue;   //restart
            }
            else
            {
                break;  //Exit
            }
        }
    }

    static string[] Sort(string[] array)    //selection sort algorithm
    {
        string temp = "";

        for (int i = 0; i < array.Length; i++)
        {
            for (int k = i; k < array.Length; k++)
            {
                if (array[i].Length > array[k].Length)
                {
                    temp = array[i];
                    array[i] = array[k];
                    array[k] = temp;
                }
            }
        }

        return array;
    }
}

