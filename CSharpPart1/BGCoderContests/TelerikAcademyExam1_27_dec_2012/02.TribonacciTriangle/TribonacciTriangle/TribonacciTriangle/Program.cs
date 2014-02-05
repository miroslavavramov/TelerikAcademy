using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TribonacciTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 member1 = long.Parse(Console.ReadLine());
            Int64 member2 = long.Parse(Console.ReadLine());
            Int64 member3 = long.Parse(Console.ReadLine());
            
            int lines = int.Parse(Console.ReadLine());

            long nextMember;

            for (int i = 0; i < lines; i++)
            {
                for (int k = 0; k <= i ; k++)
                {
                    nextMember = member1 + member2 + member3;
                    Console.Write(member1 + " ");
                    member1 = member2;
                    member2 = member3;
                    member3 = nextMember;
                }
                Console.WriteLine();
            }
        }
    }
}
