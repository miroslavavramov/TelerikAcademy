using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBall
{
    class Program
    {
        static void Main(string[] args)
        {
            int topTeamScore = 0;
            int bottomTeamScore = 0;
            
            //get topTeam on the pitch
            int[,] topTeam = new int[8, 8];
            for (int i = 0; i < topTeam.GetLength(0); i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                string inputString = Convert.ToString(inputNumber, 2).PadLeft(8, '0');
                for (int j = 0; j < topTeam.GetLength(0); j++)
                {
                    if (inputString[j] == '1')
                    {
                        topTeam[i, j] = 1;
                    }
                }
            }
            //get bottomTeam on the pitch
            int[,] bottomTeam = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                string inputString = Convert.ToString(inputNumber, 2).PadLeft(8, '0');
                for (int j = 0; j < 8; j++)
                {
                    if (inputString[j] == '1')
                    {
                        bottomTeam[i, j] = 2;
                    }
                }
            }
            //print player positions
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(topTeam[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
            //Console.WriteLine();
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write(bottomTeam[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
            //Console.WriteLine();

            //set playfield
            int[,] playfield = new int[8, 8];
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (topTeam[row, col] == 1 && bottomTeam[row, col] == 2)
                    {
                        playfield[row, col] = 0;
                    }
                    else if (topTeam[row, col] == 1)
                    {
                        playfield[row, col] = 1;
                    }
                    else if (bottomTeam[row, col] == 2)
                    {
                        playfield[row, col] = 2;
                    }
                    else
                    {
                        playfield[row, col] = 0; 
                    }
                    //Console.Write(playfield[row, col] + " ");         //print playfield
                }
                //Console.WriteLine(); 
            }
            
            //Console.WriteLine();
            //Console.WriteLine();
           
            //Battle Phase
            bool topTeamAttacks = false;
            bool bottomTeamAttacks = false;
            // topTeam attacks
            for (int col = 0; col < 8; col++)
            {
                topTeamAttacks = false;
                for (int row = 0; row < 8; row++)
                {
                    if (playfield[row,col] == 1)
                    {
                        topTeamAttacks = true;
                    }
                    if (playfield[row, col] == 2)
                    {
                        topTeamAttacks = false;
                    }
                }
                if (topTeamAttacks == true)
                {
                    topTeamScore++;
                }
            }
            //bottomTeamAttacks
            for (int col = 0; col < 8; col++)
            {
                bottomTeamAttacks = false;
                for (int row = 7; row >= 0; row--)
                {
                    if (playfield[row, col] == 2)
                    {
                        bottomTeamAttacks = true;
                    }
                    if (playfield[row, col] == 1)
                    {
                        bottomTeamAttacks = false;
                    }
                }
                if (bottomTeamAttacks == true)
                {
                    bottomTeamScore++;
                }
            }
            Console.WriteLine("{0}:{1}", topTeamScore, bottomTeamScore);
        }
    }
}
