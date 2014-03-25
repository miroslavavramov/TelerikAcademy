using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace Maze2D
{
    internal static class ScoreSystem
    {
        private static string scoreTablePath = @"..\..\ScoreTable.txt";
        private static List<string> scoreTable = new List<string>();

        /// <summary>
        /// Read the file where scores are stored. File is small enough to read it at once.
        /// </summary>
        private static void ReadWholeFile()
        {
            string line;

            if (!scoreTable.Any())
            {
                StreamReader reader = new StreamReader(scoreTablePath, Encoding.GetEncoding("windows-1251"));
                using (reader)
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Add each line in the List
                        scoreTable.Add(line);
                    }
                }
            }
        }

        /// <summary>
        /// Print top 10
        /// </summary>
        public static void PrintTopScores()
        {
            Console.Clear();
            // Check if list is empty
            if (!scoreTable.Any())
            {
                ReadWholeFile();
            }

            Console.ResetColor();
            Menu.PrintLogo();

            for (int i = 0; i < scoreTable.Count; i++)
            {
                if (i % 2 == 0) { Console.ForegroundColor = ConsoleColor.Green; }
                else Console.ForegroundColor = ConsoleColor.Yellow;

                Console.SetCursorPosition(49, i + 5);
                Console.Write(scoreTable[i].Substring(0, scoreTable[i].IndexOf(' ')).PadLeft(4));
                Console.Write(" - ");
                Console.WriteLine("{0}", scoreTable[i].Substring(scoreTable[i].IndexOf(' ') + 1).PadRight(15));
            }

            Console.ResetColor();
            Console.ReadKey();      //go back to Main Menu
            Console.Clear();
        }

        /// <summary>
        /// Write current score and player name, into the file
        /// </summary>
        /// 
        /// <param name="time">Time for solving the maze</param>
        /// <param name="playerMoves">Player moves</param>
        /// <param name="optimalMoves">Min coun of moves to solve the maze</param>
        public static void Score(TimeSpan time, int playerMoves, int optimalMoves)
        {
            double score;
            string playerName;

            // Check if list is empty
            if (!scoreTable.Any())
            {
                ReadWholeFile();
            }

            score = CalcCurrentScore(time, playerMoves, optimalMoves);
            playerName = ReadPlayerName();
            SaveScoreToFile(score, playerName);
        }

        /// <summary>
        /// Reads player name, from the console
        /// </summary>
        /// <returns>Player name</returns>
        static private string ReadPlayerName()
        {
            StringBuilder playerName = new StringBuilder();

            Console.SetCursorPosition(53, 5);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("YOU'VE WON !");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(53, 6);
            Console.Write("Enter your name");
            Console.SetCursorPosition(53, 7);
            Console.Write(": ");

            // Track name length. Allowed length is 14 chars
            // Track cursor position, so player can'n delete some of the visualization
            while (Console.CursorLeft < 69)
            {
                ConsoleKeyInfo cki = Console.ReadKey();

                if (cki.Key.Equals(ConsoleKey.Enter))
                {
                    return playerName.ToString();
                }

                if (cki.Key.Equals(ConsoleKey.Backspace))
                {
                    if (Console.CursorLeft < 55)
                    {
                        Console.CursorLeft = 55;
                    }
                    else
                    {
                        playerName.Remove(playerName.Length - 1, 1);

                        Console.Write(' ');
                        int currentCursorPosition = Console.CursorLeft - 1;
                        Console.SetCursorPosition(currentCursorPosition, 7);
                    }
                }
                else
                {
                    playerName.Append(cki.KeyChar);
                }
            }

            return playerName.ToString();
        }

        /// <summary>
        /// Get highest score
        /// </summary>
        /// <returns>Highest score</returns>
        private static double GetHighScore()
        {
            double score;
            string scoreText = string.Empty;

            // Check if list is empty
            if (!scoreTable.Any())
            {
                ReadWholeFile();
            }

            if (scoreTable.Any())
            {
                scoreText = scoreTable[0].Substring(0, scoreTable[0].IndexOf(' '));
                score = double.Parse(scoreText);
            }
            // Initially, when file is empty, 0 will be returned
            else
            {
                score = 0;
            }

            return score;
        }

        /// <summary>
        /// Calculate current game score
        /// </summary>
        /// <param name="time">Time for solving the maze</param>
        /// <param name="playerMoves">Player moves</param>
        /// <param name="optimalMoves">Min coun of moves to solve the maze</param>
        /// <returns>Current game score</returns>
        public static double CalcCurrentScore(TimeSpan time, int playerMoves, int optimalMoves)
        {
            // For each move, -5 points
            // For each second, - 5 point
            double seconds;
            double movesScore;
            double totalScore;

            seconds = time.TotalSeconds - optimalMoves;
            movesScore = ((playerMoves * 1.0) / optimalMoves) * (optimalMoves * 3);
            totalScore = movesScore - seconds * 3;
            totalScore = Math.Round(totalScore);

            if (totalScore > GetHighScore())
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(53, 1);
                Console.WriteLine("New high score");
                Console.SetCursorPosition(53, 2);
                Console.Write(": {0}", totalScore);
                Console.SetCursorPosition(53, 3);
                Console.WriteLine("Congratulations!");
            }

            if (totalScore < 0)
            {
                return 0;
            }

            return totalScore;
        }

        /// <summary>
        /// Write List with scores and names to file
        /// </summary>
        private static void WriteToFile()
        {
            StreamWriter writer = new StreamWriter(scoreTablePath, false, Encoding.GetEncoding("windows-1251"));

            using (writer)
            {
                for (int i = 0; i < scoreTable.Count; i++)
                {
                    writer.WriteLine(scoreTable[i]);
                }
            }
        }

        /// <summary>
        /// Insert score and name to the wright place in the table, and write it to the file
        /// </summary>
        /// <param name="currentScore">Current game score</param>
        /// <param name="playerName">Player name</param>
        private static void SaveScoreToFile(double currentScore, string playerName)
        {
            string scoreAndName = String.Concat(currentScore, ' ', playerName);
            string score;
            int scoreInTable;

            for (int i = 0; i < scoreTable.Count; i++)
            {
                if (i == 10)
                {
                    return;
                }

                score = scoreTable[i].Substring(0, scoreTable[i].IndexOf(' ')); //Throw an exception if space(' ') is at the start of the string
                scoreInTable = int.Parse(score);

                // Find the correct place of the current score
                if (currentScore > scoreInTable)
                {
                    if (scoreTable.Count == 10)
                    {
                        scoreTable.RemoveAt(9);
                    }

                    // Insert the current score at the correct place in the file
                    scoreTable.Insert(i, scoreAndName);
                    WriteToFile();
                    return;
                }
            }

            scoreTable.Add(scoreAndName);
            WriteToFile();
        }
    }
}
