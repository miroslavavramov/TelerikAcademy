using System;
/*Write a program that can solve these tasks:
Reverses the digits of a number
Calculates the average of a sequence of integers
Solves a linear equation a * x + b = 0
Create appropriate methods.	Provide a simple text-based menu for the user to choose which task to solve.
Validate the input data:
The decimal number should be non-negative; The sequence should not be empty; a should not be equal to 0 */
class Tasks
{
    static void Main()
    {
        while (true) 
        {
            Console.Clear();
            Console.WriteLine("Type a task number and press <ENTER>. Type \"exit\" to close the program.\n\n");
            Console.WriteLine(" Task 1 : Reverse digits of a number.");
            Console.WriteLine(" Task 2 : Calculate the average of a sequence of integers.");
            Console.WriteLine(" Task 3 : Solve the linear equation a*x + b = 0, where a > 0.");
            Console.Write("\n Input : ");

            switch (Console.ReadLine())
            {
                default: Console.WriteLine("Invalid Input! Press <ENTER> to try again.");
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    if(pressedKey.Key != ConsoleKey.Enter) { Environment.Exit(0); }
                    break;
                case "1": Console.Clear(); Reverse();
                    break;
                case "2": Console.Clear(); Average();
                    break;
                case "3": Console.Clear(); Equation();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
            }
        }

    }
    static void Reverse()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter a number: ");
                long n = long.Parse(Console.ReadLine());
                if (n <= 0) { Console.Clear(); continue; }
                long result = 0;
                while (n > 0)
                {
                    result = result * 10 + n % 10;
                    n /= 10;
                }
                Console.WriteLine("Reversed: {0}", result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Press <Enter> to try again or <ESC> to go to Main Menu.");
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.Enter) { Console.Clear(); continue; }
            else if (pressedKey.Key == ConsoleKey.Escape) { Console.Clear(); Tasks.Main(); }
            else { Environment.Exit(0); }
        }

    }
    static void Average()
    {
        while (true)
        {
            int[] arr = GenerateArray();
            double avrg = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                avrg += (double)arr[i];
            }

            avrg /= (double)arr.Length;
            Print(arr);
            Console.WriteLine("Average: {0:F3}", avrg);
            Console.WriteLine("\nPress <Enter> to try again or <ESC> to go to Main Menu.");
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.Enter) { Console.Clear(); continue; }
            else if (pressedKey.Key == ConsoleKey.Escape) { Console.Clear(); Tasks.Main(); }
            else { Environment.Exit(0); }
        }
    }
    static void Equation()
    {
        while(true)
        {
            try
            {
                Console.Write(" a = ");
                double a = double.Parse(Console.ReadLine());
                if (a < 1) { Console.Clear(); continue; }
                Console.Write(" b = ");
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine("\n Equation: {0}*x + {1} = 0", a,b);
                Console.WriteLine(" x = {0} \n", (-b) / a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Press <Enter> to try again or <ESC> to go to Main Menu.");
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.Enter) { Console.Clear(); continue; }
            else if (pressedKey.Key == ConsoleKey.Escape) { Console.Clear(); Tasks.Main(); }
            else { Environment.Exit(0); }
        }
    }
    static int[] GenerateArray()
    {
        int length = 0; int min = 0; int max = 0;
        while (true)
        {
            try
            {
                Console.Write("Array length = ");
                length = int.Parse(Console.ReadLine());
                if (length < 1) { Console.Clear(); continue; }
                Console.Write("Min value = ");
                min = int.Parse(Console.ReadLine());
                Console.Write("Max value = ");
                max = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception) 
            {
                Console.WriteLine("You did something wrong! Press <Enter> to try again\nor <ESC> to go to Main Menu.");
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.Enter) { Console.Clear(); continue; }
                else if (pressedKey.Key == ConsoleKey.Escape) { Console.Clear(); Tasks.Main(); }
            }
        }

        int[] arr = new int[length];
        Random rnd = new Random();

        for (int i = 0; i < length; i++)
        {
            arr[i] = rnd.Next(min, max);
        }
        Console.WriteLine("Array is generted!" + Environment.NewLine);
        return arr;
    }
    static void Print<T>(T[] arr)
    {
        Console.Write("Array : { ");
        foreach (var num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine(" }" + Environment.NewLine);
    }
}

