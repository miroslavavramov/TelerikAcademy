using System;
using System.Threading;
//Using delegates write a class Timer that can execute certain method at each t seconds.

class TimerTest
{
    static void Main()
    {
        Timer t = new Timer();
        t.Execute();
    }
}