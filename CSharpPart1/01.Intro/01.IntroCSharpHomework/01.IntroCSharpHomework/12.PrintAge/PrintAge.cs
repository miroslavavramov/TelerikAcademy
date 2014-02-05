using System;

// 12. *Write a program to read your age from the console and print how old you will be after 10 years.

    class Program
    {
        static void Main()
        {
            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());    //method that converts the string representation 
                                                        //of a number to its 32-bit signed integer equivalent.
            
            Console.WriteLine("After 10 years you'll be {0} years old.", age + 10);
            Console.ReadKey();
        }
    }

