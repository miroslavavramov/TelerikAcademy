namespace PriorityQueueImplementatiton
{
    using System;

    class Program
    {
        static void Main()
        {
            var pq = new PriorityQueue<string>("Saturn", "Pluto", "Earth", "Jupiter", "Venus", "Mars");

            Console.WriteLine(pq);

            pq.Enqueue("Alpha Centauri");

            Console.WriteLine(pq);

            Console.WriteLine(pq.Peek());

            pq.Dequeue();

            Console.WriteLine(pq.Peek());
        }
    }
}
