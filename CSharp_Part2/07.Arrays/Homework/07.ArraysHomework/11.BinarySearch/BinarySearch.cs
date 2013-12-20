using System;
//Write a program that finds the index of given element in a sorted array of integers 
//by using the binary search algorithm (find it in Wikipedia).

    public class BinarySearch
    {
        public static void Main()
        {
            try
            {

                Console.WriteLine("Task 11: \n");
                Console.WriteLine(" Initialize the array.\n Define the length and the scope of its elements:");
                //Console.ReadKey();
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

                Console.WriteLine("\n Your array is successfully generated!");
                Console.Write("\n Now type a number, to check if it's in the array: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                int number = int.Parse(Console.ReadLine());

                Array.Sort(array);  //sorts elements in ascending order

                //apply Binary Search algorithm
                int index = BinSearch(array, 0, array.Length - 1, number);

                if (index >= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n There IS such number in the array! Index: {0}", index);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n There's no such number!");
                }

                Console.Write("\n Array: { ");
                foreach (int element in array)
                {
                    Console.Write("{0} ", element);
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
        static int BinSearch(int[] arr, int start, int end, int x)
        {
            int mid;  //middle index
            while (start <= end)
            {
                mid = (start + end) / 2;
                if (arr[mid] == x) return mid;  
                else if (arr[mid] > x) { end = mid - 1; }
                else if (arr[mid] < x) { start = mid + 1;}
            }
            return -1;  //if not found
        }
    }

