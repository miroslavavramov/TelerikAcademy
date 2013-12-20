using System;
//Write a program, that reads from the console an array of N integers and an integer K,
//sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

class BinSearch
{
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Write("N = ");
                int n = int.Parse(Console.ReadLine());
                Console.Write("K = ");
                int k = int.Parse(Console.ReadLine());

                int[] numbers = new int[n];

                for (int i = 0; i < n; i++)
                    numbers[i] = int.Parse(Console.ReadLine());


                Array.Sort(numbers);
                Console.Write("Sorted array: ");
                Print(numbers);

                int output = Array.BinarySearch(numbers, k);
                //Console.WriteLine(output);
                if (output > 0) { Console.WriteLine("Largest number <= K : {0}", numbers[output]); }
                else if ((~output) - 1 >= 0) { Console.WriteLine("Largest num <= K : {0}", numbers[(~output) - 1]); }
                else { Console.WriteLine("No such number"); }
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
                break;  //exit
            }
        }
        
    }
    static void Print<T>(T[] arr)   //generic method; works with various data types
    {
        foreach (var item in arr)
	    {
		    Console.Write(item + " ");
	    }
        Console.WriteLine();
    }
}

