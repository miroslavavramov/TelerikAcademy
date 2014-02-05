using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AstrologicalDigits
{
    class AstrologicalDigits
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            input = input.Replace(".", "");
            BigInteger n = BigInteger.Parse(input);
            
            if (n < 0)
            {
                n *= -1;
            }
            string str = "";
           
            while (n > 9)
            {
                str = n.ToString();
                n = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    n += (BigInteger)char.GetNumericValue(str[i]); 
                }
            }
            Console.WriteLine(n);
        }
    }
}
