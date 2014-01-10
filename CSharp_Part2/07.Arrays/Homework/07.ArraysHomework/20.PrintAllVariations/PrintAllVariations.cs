using System;
//Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. 
//Example:	N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
public class PrintAllVariations
{
    static int n;                          //global variables, that can be accessed by every method in the class
    static int k;
    public static void Main()
    {
        try
        {
            Console.BufferHeight = 300;
            Console.Write("Task 20: \n\n");
            Console.Write(" N = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            n = int.Parse(Console.ReadLine());
            Console.ResetColor();
            Console.Write(" K = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            k = int.Parse(Console.ReadLine());
            Console.ResetColor();

            int[] numbers = new int[k];         // k represents the number of loops, while n - number of iterations

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n Variations of {0} elements in [1..{1}] : ", k, n);
            PrintVariations(0, numbers);
            Console.Write("\n\n");
            Console.WriteLine(" Total Variations : {0}", Math.Pow(n, k));
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\n You did something wrong!\n Type task number and press");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" <ENTER> ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("to try again.\n");
            Console.ResetColor();
        }
    }
    static void PrintVariations(int index, int[] numbers)
    {
        if (index == numbers.Length)
        {
            Console.Write("\n {");
            foreach (var item in numbers)
            {
                Console.Write(" " + item);
            }
            Console.Write(" }");
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                numbers[index] = i;
                PrintVariations(index + 1, numbers); //recursive call 
            }
        }
    }
}

