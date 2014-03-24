using System;

class QueueTest
{
    static void Main()
    {
        var queue = new Queue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);

        queue.Dequeue();

        foreach (var item in queue)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine(queue.Peek());
        Console.WriteLine(queue.Contains(2));
    }
}

