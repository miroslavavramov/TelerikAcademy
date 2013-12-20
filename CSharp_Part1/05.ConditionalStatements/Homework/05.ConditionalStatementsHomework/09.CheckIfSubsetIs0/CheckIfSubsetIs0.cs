using System;
using System.Diagnostics;

// 09. We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. 
// Example: 3, -2, 1, 1, 8  1+1-2=0.

class Program
{
    static void Main()
    {
        try
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.Write("How many numbers do you want to enter ? ");
            int count = int.Parse(Console.ReadLine());
            int[] numbers = new int[count];     //declare an array that'll keep a given number of values

            for (int i = 0; i < count; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());     //assign value to the element with index i
            }

            int sum;    //declare a variable that'll temporarily keep the sum of a single subset

            for (int i = 1; i < Math.Pow(2, count); i++)    // every k amount of elements have 2^(k-1) combinations among each other
            {                                               // without repetition
                sum = 0;
                for (int k = 0; k < count; k++) //a loop that goes through each element in the array "numbers"
                {
                    sum += numbers[k] * GetBinaryNum(number: i, bit: k);    //e.g. i==30 => 30==11110(binary) i.e. for each k, except the 
                }                                                           //last one(k==5), the method will return 1 => sum = numbers[k=1]*1+
                                                                            //[k=2]*1 + [k=3]*1 + [k=4]*1 + [k=5]*0 ;               
                if (sum == 0)
                {
                    for (int k = 0; k < count; k++) //goes through the numbers
                    {
                        if (GetBinaryNum(i, k) != 0)
                        {
                            Console.Write("{0}  ", numbers[k]); //prints each number, whose place in the array corresponds to 
                        }                                       //the bit with value of 1 in "i"
                    }
                    Console.WriteLine();
                }
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
        catch (OverflowException ofe)
        {
            Console.WriteLine(ofe.Message);
        }
    }
    static int GetBinaryNum(int number, int bit)      // a method that takes 2 int arguments (number and bit) and checks
    {                                               // if the bit in "number" on place "digit" has value of 0 or 1
        return (number & (1 << bit)) >> bit;
    }
}