using System;

class LinkedListTest
{
    static void Main()
    {
        var linkedList = new LinkedList<int>();

        linkedList.Add(1);
        linkedList.Add(2);
        linkedList.Add(3);
        linkedList.Add(4);
        linkedList.Add(5);
        linkedList.AddFirst(0);
        linkedList.AddFirst(-1);

        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }

        linkedList.RemoveFirst();
        linkedList.RemoveLast();
        linkedList.Remove(4);
        linkedList.Remove(0);
        linkedList.Remove(2);

        Console.WriteLine(linkedList);
    }
}

