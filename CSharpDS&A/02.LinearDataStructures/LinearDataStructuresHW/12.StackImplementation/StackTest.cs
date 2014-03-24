using System;

class StackTest
{
    static void Main()
    {
        var stack = new Stack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);

        stack.Pop();
        Console.WriteLine(stack.Peek());

        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
    }
}

