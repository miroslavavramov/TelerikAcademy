using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancingBits
{
    class DancingBits
    {
        static void Main(string[] args)
        {
            int dancingBits = Math.Abs(int.Parse(Console.ReadLine()));
            int numbers = Math.Abs(int.Parse(Console.ReadLine()));
            string sequence = "";
            int sum = 0;

            for (int i = 0; i < numbers; i++)
            {
                int input = int.Parse(Console.ReadLine());
                sequence += Convert.ToString(input, 2);
            }
            if (sequence[sequence.Length-1] == '0')
            {
                sequence += "1";
            }
            string stringMask = "";
            for (int i = 0; i < dancingBits; i++)
            {
                stringMask += "1";    
            }

            int num = BinaryStringToInt(sequence);
            int mask = BinaryStringToInt(stringMask);

            for (int i = 0; i <= sequence.Length-stringMask.Length; i++)
            {
                if ( (((num & (mask << i)) ) == 0) ||  (((num & (mask << i)) >> i) == mask) )
                {
                    if (CheckBitAtPosition(num, i) != CheckBitAtPosition(num, i-1) && 
                        (CheckBitAtPosition(num, i + stringMask.Length-1) != CheckBitAtPosition(num, i + stringMask.Length)))
                    {
                        sum++;
                    }
                }
            }
            Console.WriteLine(sum);
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
