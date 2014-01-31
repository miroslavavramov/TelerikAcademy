using System;
using System.Diagnostics;
using System.Threading;
//* Read in MSDN about the keyword event in C# and how to publish events. 
//Re-implement the above using .NET events and following the best practices.

class Program
{
    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        sw.Stop();
        Console.WriteLine(sw.Elapsed.Seconds);
    }
}

