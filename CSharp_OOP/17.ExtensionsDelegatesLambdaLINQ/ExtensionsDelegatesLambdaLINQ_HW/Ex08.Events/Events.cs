using System;
//* Read in MSDN about the keyword event in C# and how to publish events. 
//Re-implement the above using .NET events and following the best practices.

class Events
{
    static void Main()
    {
        Timer t = new Timer(4, 17);
        t.Execute();
    }
}

