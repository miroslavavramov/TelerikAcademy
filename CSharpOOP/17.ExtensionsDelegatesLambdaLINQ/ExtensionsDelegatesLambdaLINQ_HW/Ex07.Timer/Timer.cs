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
    public Timer(int span, int elapsedRuntimeSeconds)
    {
        this.Span = span;
        this.ElapsedRuntimeSeconds = elapsedRuntimeSeconds;
    }
    public int Span { get; private set; }
    public int ElapsedRuntimeSeconds { get; private set; }

    public void Execute()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        VoidMethodPointer notify = new VoidMethodPointer( 
            delegate()
            {
                Console.WriteLine("{0} seconds remaining.", this.ElapsedRuntimeSeconds - sw.Elapsed.Seconds);
            });

        VoidMethodPointer tick = new VoidMethodPointer(
            delegate()
            {
                Console.Write("tick-");
                Console.WriteLine("tack");
            });

        
        while (sw.Elapsed.Seconds < this.ElapsedRuntimeSeconds)
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

