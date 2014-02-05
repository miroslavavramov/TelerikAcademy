using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveBits
{
    class Program
    {
        static int ReverseBits(int number)
        {

            //int number = int.Parse(Console.ReadLine());
            char[] bits = Convert.ToString(number, 2).ToCharArray();

            //foreach (char symbol in bits)
            //{
            //    Console.Write(symbol);
            //}
            //Console.WriteLine();

            Array.Reverse(bits);

            //foreach (char symbol in bits)
            //{
            //    Console.Write(symbol);
            //}
            //Console.WriteLine();

            int reversedNumber = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                reversedNumber += (int)char.GetNumericValue(bits[bits.Length - 1 - i]) * (int)Math.Pow(2, i);
            }
            return reversedNumber;
        }
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<int> collection = new List<int>();

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                collection.Add(ReverseBits(number));
            }
            foreach (int number in collection)
            {
                Console.WriteLine(number);
            }
        }
    }
}
