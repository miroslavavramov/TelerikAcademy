using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _02.TheHorror
{
    class TheHorror
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = 0;
            int sum = 0;
            int digits = -1;
            int evenDigits = 0;

            for (int i = 0; i < text.Length; i++)
            {
                bool isDigit = int.TryParse(text[i].ToString(), out n);
                if (isDigit == true)
                {
                    digits++;
                    if (digits % 2 == 0)
                    {
                        sum += n;
                        evenDigits++;
                    }
                }
            }

            Console.WriteLine(evenDigits + " " + sum);    

        }
        
    }
}
