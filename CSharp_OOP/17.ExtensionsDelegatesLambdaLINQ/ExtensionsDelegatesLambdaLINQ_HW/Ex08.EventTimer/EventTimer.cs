using System;
using System.Collections.Generic;
using System.Diagnostics;
public class EventTimer
{
    private event EventHandler notify = new EventHandler(Notify);
    public EventTimer()
        : this(5,20)
    {
    }
    public EventTimer(int span, int executionSeconds)
    {
        this.Span = span;
        this.ExecutionSeconds = executionSeconds;
    }
    public int Span { get; private set; }
    public int ExecutionSeconds { get; private set; }

    public void Execute()
    {
        Stopwatch sw = new Stopwatch();


               
    }

    private  void Notify(object sender, EventArgs e)
    {
        Console.WriteLine("seconds remaining");
    }
}

