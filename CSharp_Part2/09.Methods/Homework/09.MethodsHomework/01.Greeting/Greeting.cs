using System;
//Write a method that asks the user for his name and prints “Hello, <name>” 
//(for example, “Hello, Peter!”). Write a program to test this method.

class Greeting
{
    static void Main()
    {
        Console.Write("Insert random name : ");
        Greet(Console.ReadLine());
    }
    static void Greet(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }
}

