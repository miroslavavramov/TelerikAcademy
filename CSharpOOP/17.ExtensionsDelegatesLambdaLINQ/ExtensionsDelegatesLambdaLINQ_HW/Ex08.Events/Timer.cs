using System;
using System.Diagnostics;
using System.Threading;

public class Timer
{
    private delegate void TimerEventHandler(object sender, EventArgs e);
    private event TimerEventHandler PrintMessage;
    
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

        PrintMessage += Message;

        while (sw.Elapsed.Seconds < this.ElapsedRuntimeSeconds)
        {
            if (sw.Elapsed.Seconds % this.Span == 0)
            {
                PrintMessage(this, new EventArgs());
            }
            Thread.Sleep(1001);
        }
    }

    void Message(object o, EventArgs e)
    {
        Console.WriteLine("You've probably got better things to do.");
    }
}

