using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int dancingBits = int.Parse(Console.ReadLine());
            string sequence = Console.ReadLine()+"@";
            int sum = 0;
            bool bitsDance = true;

            
        }
        static int BinaryStringToInt(string s)
        {
            int n = 0;

            for (int i = 0; i < s.Length; i++)
            {
                n += (int)char.GetNumericValue(s[i]) * (int)Math.Pow(2, s.Length - i - 1);
            }

            return n;
        }
        static int CheckBitAtPosition(int number, int position)
        {
            int bit = (number & ((int)1 << position)) >> position;
            return bit;

        }
    }
}
