using System;

// 9.Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

    class Program
    {
        static void Main()
        {
            int num = 2;                         
            for (int i = 0; i < 10; i++)        //declare a "for" loop, which will repeat the given code in the body 10 times
            {
                if (num % 2 == 0)               //check if num is prime; (a % b = c, where c is the remainder of a / b)
                {
                    Console.Write(num + " ");   //print num 
                }
                else                            //if num isn't prime 
                {
                    Console.Write(-num + " ");  //print the negative amount 
                }
                num++;                          //increase num with 1 (num++ <=> num + 1)
            }
            Console.WriteLine();                
            Console.ReadKey();
        }
    }

