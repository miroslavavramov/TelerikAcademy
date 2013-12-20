using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne
{
    class AllInOne
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1": IntArray.Main();
                    break;
                case "2": EqualArrays.Main();
                    break;
                case "3": CompareCharArrays.Main();
                    break;
                case "4": MaxConsSequence.Main();
                    break;
                default: Console.WriteLine("FAK U DOLAN!");
                    break;
            }
            
        }
    }
}
