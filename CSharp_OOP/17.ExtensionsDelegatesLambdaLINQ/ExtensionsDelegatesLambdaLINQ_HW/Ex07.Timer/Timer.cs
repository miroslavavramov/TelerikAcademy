using System;
using System.Diagnostics;
using System.Threading;

public class Timer
{
    private delegate void VoidMethodPointer();
    
    public Timer()
        : this(5,20)
    {
    }
    public Timer(int span, int executionSeconds)
    {
        this.Span = span;
        this.ExecutionSeconds = executionSeconds;
    }
    public int Span { get; private set; }
    public int ExecutionSeconds { get; private set; }

    public void Execute()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        VoidMethodPointer notify = new VoidMethodPointer( 
            delegate()
            {
                Console.WriteLine("{0} seconds remaining.", this.ExecutionSeconds - sw.Elapsed.Seconds);
            });

        VoidMethodPointer tick = new VoidMethodPointer(
            delegate()
            {
                Console.WriteLine("tick-tack");
            });

        
        while (sw.Elapsed.Seconds < this.ExecutionSeconds)
        {
            if (sw.Elapsed.Seconds % this.Span != 0)
            {
                tick();   
            }
            else
            {
                notify();
            }
            
            Thread.Sleep(1001);
        }
        Console.WriteLine("Too bad.\r\nBOOM!!");
    }
}

