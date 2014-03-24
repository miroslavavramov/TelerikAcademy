/* We are given the following sequence:
S1 = N;
S2 = S1 + 1;
S3 = 2*S1 + 1;
S4 = S1 + 2;
S5 = S2 + 1;
S6 = 2*S2 + 1;
S7 = S2 + 2;
...
Using the Queue<T> class write a program to print its first 50 members for given N.
Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...*/
using System;
using System.Collections.Generic;
using System.Linq;

class QueueSequence
{
    static void Main()
    {
        const int MembersCount = 50;

        int n = int.Parse(Console.ReadLine());

        var sums = new Queue<int>();
        var sequence = new List<int>();

        sums.Enqueue(n);
        
        int sum;
        
        for (int i = 0; i < MembersCount; i++)
        {
            sum = sums.Dequeue();
            sequence.Add(sum);

            sums.Enqueue(sum + 1);
            sums.Enqueue(2 * sum + 1);
            sums.Enqueue(sum + 2);
        }

        Console.WriteLine(string.Join(", ", sequence));
    }
}
