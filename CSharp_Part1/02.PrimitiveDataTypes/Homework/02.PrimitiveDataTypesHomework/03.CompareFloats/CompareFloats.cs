using System;

// 3. Write a program that safely compares floating-point numbers with precision of 0.000001. 
// Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003)  true

    class Program
    {
        static void Main()
        {
            Console.Write("Enter numer A: ");
            float a = float.Parse(Console.ReadLine());
            Console.Write("Enter number B: ");
            float b = float.Parse(Console.ReadLine());
            bool compareAB = false;
            
            if (a > b)
            {
                compareAB = true;
            }
            
            Console.Write("A > B ? : {0}", compareAB);
            Console.WriteLine();
            
            if (a == b)
            {
                Console.WriteLine("A is equal to B");
            }

            Console.ReadKey();
        }
    }

