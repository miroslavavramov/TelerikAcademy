namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private const int PlayfieldRowsCount = 5;
        private const int PlayfieldColumnsCount = 10;
        private const int MinelessBoxesCount = 35;
        private const int HighScoresRankingCapacity = 6;

        private static readonly char[] Separators = new char[] { ' ', ',', '.' };
        private static readonly Random GlobalRandomGenerator = new Random();

        public void ReadAndExecuteCommands()
        {
            char[,] playfield = InitializePlayfield();
            char[,] minefield = PlaceMines();
            List<PlayerScore> highScoreRanking = new List<PlayerScore>(HighScoresRankingCapacity);

            string command = string.Empty;
            int minelessBoxesFound = 0;
            bool steppedOnMine = false;
            
            int currentRow = 0;
            int currentColumn = 0;

            bool gameHasJustLaunched = true;
            bool allMinelessBoxesFound = false;

            do
            {
                if (gameHasJustLaunched)
                {
                    Console.WriteLine("Welcome to Console Minesweeper! Your task is to find all \"mineless\" boxes.");
                    Console.WriteLine("Type \"top\" to see the high score ranking.");
                    Console.WriteLine("Type \"restart\" to start a new game.");
                    Console.WriteLine("Type \"exit\" to quit.");

                    PrintPlayfieldOnConsole(playfield);
                    gameHasJustLaunched = false;
                }

                Console.Write("Enter row and column : ");
                var commandWords = Console.ReadLine().Split(Separators, StringSplitOptions.RemoveEmptyEntries);

                if (commandWords.Length == 2)
                {
                    if (int.TryParse(commandWords[0], out currentRow) && 
                        int.TryParse(commandWords[1], out currentColumn) &&
                        currentRow >= 0 && currentRow < PlayfieldRowsCount && 
                        currentColumn >= 0 && currentColumn < PlayfieldColumnsCount)
                    {
                        command = "turn";
                    }
                }
                else if (commandWords.Length == 1)
                {
                    command = commandWords[0];
                }

                switch (command)
                {
                    case "top":
                        PrintHighScores(highScoreRanking);
                        break;
                    case "restart":
                        playfield = InitializePlayfield();
                        minefield = PlaceMines();
                        PrintPlayfieldOnConsole(playfield);
                        steppedOnMine = false;
                        gameHasJustLaunched = false;
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        Console.Read();
                        break;
                    case "turn":
                        if (minefield[currentRow, currentColumn] != '*')
                        {
                            if (minefield[currentRow, currentColumn] == '-')
                            {
                                UpdateFields(playfield, minefield, currentRow, currentColumn);
                                minelessBoxesFound++;
                            }

                            if (MinelessBoxesCount == minelessBoxesFound)
                            {
                                allMinelessBoxesFound = true;
                            }
                            else
                            {
                                PrintPlayfieldOnConsole(playfield);
                            }
                        }
                        else
                        {
                            steppedOnMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("Ivalid Command!\r\n");
                        break;
                }

                if (steppedOnMine)
                {
                    PrintPlayfieldOnConsole(minefield);
                    Console.WriteLine("You've just stepped on a mine. Your points: {0}", minelessBoxesFound);

                    string name = Console.ReadLine();
                    PlayerScore playerScore = new PlayerScore(name, minelessBoxesFound);

                    if (highScoreRanking.Count < HighScoresRankingCapacity - 1)
                    {
                        highScoreRanking.Add(playerScore);
                    }
                    else
                    {
                        for (int i = 0; i < highScoreRanking.Count; i++)
                        {
                            if (highScoreRanking[i].Points < playerScore.Points)
                            {
                                highScoreRanking.Insert(i, playerScore);
                                highScoreRanking.RemoveAt(highScoreRanking.Count - 1);
                                break;
                            }
                        }
                    }

                    highScoreRanking
                        .OrderBy(p1 => p1.Points)
                        .ThenBy(p1 => p1.Name);

                    PrintHighScores(highScoreRanking);

                    playfield = InitializePlayfield();
                    minefield = PlaceMines();
                    minelessBoxesFound = 0;
                    steppedOnMine = false;
                    gameHasJustLaunched = true;
                }

                if (allMinelessBoxesFound)
                {
                    Console.WriteLine("\r\nCongratulations! You've won!.");
                    PrintPlayfieldOnConsole(minefield);

                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();
                    PlayerScore playerScore = new PlayerScore(name, minelessBoxesFound);
                    highScoreRanking.Add(playerScore);
                    PrintHighScores(highScoreRanking);

                    playfield = InitializePlayfield();
                    minefield = PlaceMines();
                    minelessBoxesFound = 0;
                    allMinelessBoxesFound = false;
                    gameHasJustLaunched = true;
                }
            }
            while (command != "exit");
        }

        private static void PrintHighScores(List<PlayerScore> highScores)
        {
            Console.WriteLine("\nRanking:");

            if (highScores.Count > 0)
            {
                for (int i = 0; i < highScores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, highScores[i].Name, highScores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Scoreboard is empty\n");
            }
        }

        private static void UpdateFields(char[,] playfield, char[,] minefield, int row, int column)
        {
            char countAdjacentMinesCount = CountAdjacentMines(minefield, row, column);
            minefield[row, column] = countAdjacentMinesCount;
            playfield[row, column] = countAdjacentMinesCount;
        }

        private static void PrintPlayfieldOnConsole(char[,] board)
        {
            Console.WriteLine("\r\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < PlayfieldRowsCount; row++)
            {
                Console.Write("{0} | ", row);

                for (int column = 0; column < PlayfieldColumnsCount; column++)
                {
                    Console.Write(string.Format("{0} ", board[row, column]));
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   ---------------------\r\n");
        }

        private static char[,] InitializePlayfield()
        {
            char[,] playfield = new char[PlayfieldRowsCount, PlayfieldColumnsCount];

            for (int i = 0; i < PlayfieldRowsCount; i++)
            {
                for (int j = 0; j < PlayfieldColumnsCount; j++)
                {
                    playfield[i, j] = '?';
                }
            }

            return playfield;
        }

        private static char[,] PlaceMines()
        {
            char[,] minefield = new char[PlayfieldRowsCount, PlayfieldColumnsCount];

            for (int row = 0; row < PlayfieldRowsCount; row++)
            {
                for (int column = 0; column < PlayfieldColumnsCount; column++)
                {
                    minefield[row, column] = '-';
                }
            }

            List<int> randomIntegers = new List<int>();

            while (randomIntegers.Count < 15)
            {
                int asfd = GlobalRandomGenerator.Next(50);

                if (!randomIntegers.Contains(asfd))
                {
                    randomIntegers.Add(asfd);
                }
            }

            foreach (int number in randomIntegers)
            {
                int row = number / PlayfieldColumnsCount;
                int column = number % PlayfieldColumnsCount;

                if (column == 0 && number != 0)
                {
                    row--;
                    column = PlayfieldColumnsCount;
                }
                else
                {
                    column++;
                }

                minefield[row, column - 1] = '*';
            }

            return minefield;
        }

        private static char CountAdjacentMines(char[,] minefield, int row, int column)
        {
            int count = 0;
            int rowsCount = minefield.GetLength(0);
            int columnsCount = minefield.GetLength(1);

            if (row - 1 >= 0)
            {
                if (minefield[row - 1, column] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rowsCount)
            {
                if (minefield[row + 1, column] == '*')
                {
                    count++;
                }
            }

            if (column - 1 >= 0)
            {
                if (minefield[row, column - 1] == '*')
                {
                    count++;
                }
            }

            if (column + 1 < columnsCount)
            {
                if (minefield[row, column + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (minefield[row - 1, column - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columnsCount))
            {
                if (minefield[row - 1, column + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rowsCount) && (column - 1 >= 0))
            {
                if (minefield[row + 1, column - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rowsCount) && (column + 1 < columnsCount))
            {
                if (minefield[row + 1, column + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
