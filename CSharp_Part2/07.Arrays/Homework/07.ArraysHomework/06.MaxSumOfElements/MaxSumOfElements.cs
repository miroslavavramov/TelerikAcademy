using System;
//Write a program that reads two integer numbers N and K and an array of N elements from the console.
// Find in the array those K elements that have maximal sum.
    public class MaxSumOfElements
    {
        public static void Main()
        {
            try
            {
                Console.Write("Task 6:\n\n");
                Console.Write(" N = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                int N = int.Parse(Console.ReadLine());

                int length = N;
                Console.ResetColor();

                Console.Write(" K = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                int K = int.Parse(Console.ReadLine());
                Console.WriteLine();

                int[] array = new int[N];
                for (int index = 0; index < N; index++)    //assign values
                {
                    Console.Write(" array[{0}] = ", index);
                    array[index] = int.Parse(Console.ReadLine());
                }

                //sort elements of the array in increasing order
                for (int i = 0; i < length; i++)
                {
                    for (int k = i + 1; k < length; k++)
                    {
                        if (array[i] > array[k])
                        {
                            int temp = array[i];
                            array[i] = array[k];
                            array[k] = temp;
                        }
                    }
                }

                //print K elements with biggest sum
                Console.Write("\n K elements with biggest sum: ");
                for (int i = length - 1; i > length - K - 1; i--)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0} ", array[i]);
                }
                Console.ResetColor();
                Console.WriteLine("\n\n");
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
    }

