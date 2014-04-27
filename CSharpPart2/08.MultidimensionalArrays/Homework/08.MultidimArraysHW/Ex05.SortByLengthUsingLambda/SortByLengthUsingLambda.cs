using System;
//You are given an array of strings. Write a method that sorts the array by the length 
//of its elements (the number of characters composing them).
    class SortByLengthUsingLambda
    {
        static void Main()
        {
            /*
            int n = int.Parse(Console.ReadLine());
            string[] words = new string[n];

            for (int i = 0; i < n; i++)
                words[i] = Console.ReadLine(); */

            string[] words = { "Luxemburg", "Canada", "China", "UAE", "Netherlands", "Brazil" };

            Array.Sort(
                words, (word1, word2) => word1.Length.CompareTo(word2.Length)
                );
            
            Print(words);
        }
        static void Print<T>(T[] collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine("{0} ", item);
            }
            Console.WriteLine();
        }
    }

