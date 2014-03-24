/*Write a method that finds the longest subsequence of equal numbers in given 
 * List<int> and returns the result as new List<int>. Write a program to 
 * test whether the method works correctly.
*/
using System;
using System.Collections.Generic;
using System.Linq;

class LongestSubsequence
{
    static void Main()
    {
        var sequence = new List<int>() { 1, 1, 5, 3, 7, 7, 7, 5, 8, 3, 3, 3, 3, 1, 3 };
        
        int startIndex = 0;
        int maxCount = 1;
        int count = 1;
        
        for (int i = 0; i < sequence.Count - 1; i++)
        {
            if (sequence[i] == sequence[i+1])
            {
                count++;
            }
            else
            {
                if (count > maxCount)
                {
                    maxCount = count; 
                    startIndex = i - count + 1;
                }
                count = 1;
            }
        }

        var longestSubsequence = sequence.Skip(startIndex).Take(maxCount);

        foreach (var num in longestSubsequence)
        {
            Console.WriteLine(num);
        }
    }
}

