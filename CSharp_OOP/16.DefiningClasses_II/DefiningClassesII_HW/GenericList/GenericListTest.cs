using System;
using System.Collections.Generic;

class GenericListTest
{
    static void Main()
    {
        GenericList<int> myList = new GenericList<int>();

        myList.Add(1);
        myList.Add(2); 
        myList.Add(3); 
        myList.Add(4); 
        myList.Add(5);

        myList.RemoveAt(index: 0);
        myList.RemoveAt(index: 3);

        Console.WriteLine(myList.GetAt(index: 0));

        myList.Insert(2,999);
        
        Console.WriteLine(myList.GetAt(1));

        Console.WriteLine(myList.Find(10));
        Console.WriteLine(myList.Find(999));

        Console.WriteLine(myList.ToString());

        Console.WriteLine(myList.Max());

        Console.WriteLine(myList.Min());

        myList.Clear();

        Console.WriteLine(myList.ToString());
    }
}

