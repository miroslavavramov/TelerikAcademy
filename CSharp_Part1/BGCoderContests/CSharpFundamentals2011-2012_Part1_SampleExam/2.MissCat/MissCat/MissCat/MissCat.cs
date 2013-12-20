using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int juryMembers = int.Parse(Console.ReadLine());
            int[] juryVotes = new int[juryMembers];
            int[] cats = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int mostVotes = 0;
            int tempVotes = 0;
            int winner = 0;
            
            for (int i = 0; i < juryMembers; i++)
            {
                juryVotes[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < cats.Length; i++)
            {
                for (int k = 0; k < juryVotes.Length; k++)
			    {
                    if (cats[i] == juryVotes[k])
                    {
                        tempVotes++;
                    }
			    }
                if (tempVotes == mostVotes)
                {
                    if (winner > cats[i])
                    {
                        cats[i] = winner;
                    }
                }
                if (tempVotes > mostVotes)
                {
                    mostVotes = tempVotes;
                    winner = cats[i];
                }
                tempVotes = 0;
            }

            Console.WriteLine(winner);
        }
    }
}
