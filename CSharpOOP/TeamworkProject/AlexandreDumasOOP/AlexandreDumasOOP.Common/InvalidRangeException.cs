namespace AlexandreDumasOOP.Common
{
    using System;

    internal class InvalidRangeException
         : ApplicationException
    {
        private const string DefaultMessage = "Input is out of the specified range!";

        public int Min { get; private set; }
        public int Max { get; private set; }

        public InvalidRangeException(string message)
            :base(message)
        {
        }
        public InvalidRangeException(int min, int max)
            : this(DefaultMessage, min, max)
        {
        }

        public InvalidRangeException(string message, int min, int max, Exception innerException)
            : base(message, innerException)
        {
            this.Min = min;
            this.Max = max;
        }

        public InvalidRangeException(string message, int min, int max)
            : base(message)
        {
            this.Min = min;
            this.Max = max;
        }
    }
}
