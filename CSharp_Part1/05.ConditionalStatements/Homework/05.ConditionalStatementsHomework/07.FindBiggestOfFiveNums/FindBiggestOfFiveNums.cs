using System;
// 07. Write a program that finds the greatest of given 5 variables.

    class Program
    {
        static void Main()
        {
            try
            {
                int[] arr = new int[6];     //declare an array of type "int", which takes 6 values
                int biggestNum = int.MinValue;

                for (int i = 0; i < 5; i++)
                {
                    Console.Write("num[{0}] = ", i + 1);
                    arr[i + 1] = int.Parse(Console.ReadLine()); //assign a value to the [i+1]'th element in the array

                    if (arr[i + 1] > arr[i])    //checks if the assigned value is greater than the one of the previous element
                    {
                        biggestNum = arr[i + 1]; //if so - assigns it to the biggestNum variable
                    }
                }
                Console.WriteLine("The biggest number is {0}", biggestNum);
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
        }
    }

