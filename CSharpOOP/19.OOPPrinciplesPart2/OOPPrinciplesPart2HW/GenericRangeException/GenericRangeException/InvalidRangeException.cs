using System;
using System.Collections.Generic;

public class InvalidRangeException<T>
    : Exception
{
    private const string DefaultMessage = "Input is out of the specified range!";
	
    public T Min { get; private set; }
    public T Max { get; private set; }

    public InvalidRangeException(T min, T max)
        : this(DefaultMessage, min, max)
    {
    }

    public InvalidRangeException(string message, T min, T max)
        : base(message)
    {
        this.Min = min;
        this.Max = max;
    }
}

