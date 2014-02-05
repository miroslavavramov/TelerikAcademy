using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadronacciRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long member1 = long.Parse(Console.ReadLine());
            long member2 = long.Parse(Console.ReadLine());
            long member3 = long.Parse(Console.ReadLine());
            long member4 = long.Parse(Console.ReadLine());
            long nextmember = member1 + member2 + member3 + member4;
           
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            //print first row
            Console.Write(member1 + " " + member2 + " " + member3 + " " + member4 + " ");
            for (int i = 4; i < cols; i++)
            {
                Console.Write(nextmember + " ");
                member1 = member2;
                member2 = member3;
                member3 = member4;
                member4 = nextmember;
                nextmember = member1 + member2 + member3 + member4;
            }
            Console.WriteLine();
            //print the rest
            for (int row = 1; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(nextmember + " ");
                    member1 = member2;
                    member2 = member3;
                    member3 = member4;
                    member4 = nextmember;
                    nextmember = member1 + member2 + member3 + member4;
                }
                Console.WriteLine();
            }
        }
    }
}
