using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static int count = 0;
    static HashSet<string> words = new HashSet<string>();
    static void Main()
    {
        char[] letters = Console.ReadLine().ToCharArray();

        GeneratePermutations(letters, 0);

        Console.WriteLine(count);
    }
    static void GeneratePermutations(char[] arr, int k)
    {
        if (k >= arr.Length)
        {
            bool valid = true;
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    valid = false;
                    break;
                }
            }
            if (valid && !words.Contains(new string(arr)))
            {
                words.Add(new string(arr));
                count++;
            }
            
        }
        else
        {
            GeneratePermutations(arr, k + 1);
			
            for (int i = k + 1; i < arr.Length; i++)
            {
                Swap(ref arr[k], ref arr[i]);
                GeneratePermutations(arr, k + 1);
                Swap(ref arr[k], ref arr[i]);
            }
        }
    }
    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}

