/*Write a program that reads N integers from the console and reverses them using a stack. 
 * Use the Stack<int> class.*/

using System;
using System.Collections.Generic;

class ReverseOrder
{
    static void Main()
    {
        uint length = uint.Parse(Console.ReadLine());

        var stackOfIntegers = new Stack<int>();

        for (int i = 0; i < length; i++)
        {
            stackOfIntegers.Push(int.Parse(Console.ReadLine()));
        }

        int number;

        for (int i = 0; i < length; i++)
        {
            number = stackOfIntegers.Pop();
            Console.Write("{0} ", number);
        }
    }
}

