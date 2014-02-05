using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CardWars
{
    class Program
    {
        static void Main()
        {
            int rounds = int.Parse(Console.ReadLine());
            int cardsDrawn = 3;
            BigInteger firstPlayerOverallScore = 0;
            BigInteger secondPlayerOverallScore = 0;
            bool firstPlayerXcard = false;
            bool secondPlayerXcard = false;
            int firstPlayerRoundsWon = 0;
            int secondPlayerRoundsWon = 0;

            for (int i = 0; i < rounds; i++)
            {
                int firstPlayerHandScore = 0;
                int secondPlayerHandScore = 0;
                //calculate player 1 hand strength
                for (int k = 0; k < cardsDrawn; k++)
                {
                    string firstPlayerDraw = Console.ReadLine();
                    switch (firstPlayerDraw)
                    {
                        case "A": firstPlayerHandScore += 1;
                            break;
                        case "K": firstPlayerHandScore += 13;
                            break;
                        case "Q": firstPlayerHandScore += 12;
                            break;
                        case "J": firstPlayerHandScore += 11;
                            break;
                        case "X": firstPlayerXcard = true;
                            break;
                        case "Y": firstPlayerOverallScore -= 200;
                            break;
                        case "Z": firstPlayerOverallScore *= 2;
                            break;
                        default: firstPlayerHandScore += 12 - int.Parse(firstPlayerDraw);
                            break;
                    }
                }
                //calculate player 2 hand strength
                for (int k = 0; k < cardsDrawn; k++)
                {
                    string secondPlayerDraw = Console.ReadLine();
                    switch (secondPlayerDraw)
                    {
                        case "A": secondPlayerHandScore += 1;
                            break;
                        case "K": secondPlayerHandScore += 13;
                            break;
                        case "Q": secondPlayerHandScore += 12;
                            break;
                        case "J": secondPlayerHandScore += 11;
                            break;
                        case "X": secondPlayerXcard = true;
                            break;
                        case "Y":
                            secondPlayerOverallScore -= 200;
                            break;
                        case "Z":
                            secondPlayerOverallScore *= 2;
                            break;
                        default: secondPlayerHandScore += 12 - int.Parse(secondPlayerDraw);
                            break;
                    }
                }
                if (firstPlayerXcard == true && secondPlayerXcard == true)
                {
                    firstPlayerOverallScore += 50;
                    secondPlayerOverallScore += 50;
                }
                else if (firstPlayerXcard == true && secondPlayerXcard == false)
                {
                    break;
                }
                else if (secondPlayerXcard == true && firstPlayerXcard == false)
                {
                    break;
                }

                if (firstPlayerHandScore > secondPlayerHandScore)
                {
                    firstPlayerOverallScore += firstPlayerHandScore;
                    firstPlayerRoundsWon++;
                }
                else if (firstPlayerHandScore < secondPlayerHandScore)
                {
                    secondPlayerOverallScore += secondPlayerHandScore;
                    secondPlayerRoundsWon++;
                }
                //reset counters for the next round
                firstPlayerHandScore = 0;
                secondPlayerHandScore = 0;
                firstPlayerXcard = false;
                secondPlayerXcard = false;
            }

            // print results
            if (firstPlayerXcard == true && secondPlayerXcard == false)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
            }
            else if (firstPlayerXcard == false && secondPlayerXcard == true)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
            }
            else if (firstPlayerOverallScore > secondPlayerOverallScore)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}", firstPlayerOverallScore);
                Console.WriteLine("Games won: {0}", firstPlayerRoundsWon);
            }
            else if (secondPlayerOverallScore > firstPlayerOverallScore)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", secondPlayerOverallScore);
                Console.WriteLine("Games won: {0}", secondPlayerRoundsWon);
            }
            else 
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: {0}", firstPlayerOverallScore);
            }

        }
    }
}
