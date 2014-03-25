using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze2D
{
    public class GameControl
    {
        private static int playerPositionX = 1;
        private static int playerPositionY = 1;

        private static int exitPositionX = 1;
        private static int exitPositionY = 1;

        public static void InitGame(int x, int y)
        {
            Reset();
            MazeCell[,] maze = MazeCell.CreateMaze(x, y);
            GetPlayerPosition(maze); 
            RemoveScrollBars();
            PrintMaze(maze);
            PrintPlayer(playerPositionX, playerPositionY);
            PrintExit(exitPositionX, exitPositionY);
            Player player = new Player(playerPositionY - 1, playerPositionX - 1, '\u263B', maze);
            Stopwatch stopwatch = Stopwatch.StartNew();

            ConsoleKeyInfo key;
            bool paused = false;

            while (((player.PositionY + 1 != exitPositionX) || (player.PositionX + 1 != exitPositionY)))
            {
                key = Console.ReadKey(true);
                player.Move(maze, key);
                if ((key.Key == ConsoleKey.Escape) && !paused)
                {
                    Console.Clear();
                    paused = true;
                    Menu.Load(paused);
                    stopwatch.Stop();
                }
                if ((key.Key == ConsoleKey.Escape) && paused)
                {
                    paused = false;
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    PrintMaze(maze);
                    PrintPlayer(player.PositionY + 1, player.PositionX + 1);
                    PrintExit(exitPositionX, exitPositionY);
                    if (player.playerPath.Count > 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        for (int i = 0; i < player.playerPath.Count; i++)
                        {
                            Console.SetCursorPosition(player.playerPath[i].y + 2, player.playerPath[i].x + 1);
                            Console.Write(' ');
                        }
                        Console.ResetColor();
                    }
                    stopwatch.Start();
                }
            }
            Console.Beep();
            PrintSolution(maze);
            stopwatch.Stop();
            // When game is over, call method Score, to take players name and write name and score to file
            ScoreSystem.Score(stopwatch.Elapsed, player.pathLength, maze[0, 0].SolutionLenght);
        }

        private static void Reset()
        {
            playerPositionX = 1;
            playerPositionY = 1;
            exitPositionX = 1;
            exitPositionY = 1;
        }
          
        private static void GetPlayerPosition(MazeCell[,] maze)
        {
            int rows = maze.GetLength(0);
            int columns = maze.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (maze[i, j].Start == true)
                    {
                        playerPositionX += j;
                        playerPositionY += i;
                        //Console.WriteLine("{0} {1}", i, j);
                    }
                    
                    if (maze[i, j].End == true)
                    {
                        exitPositionX += j;
                        exitPositionY += i;
                        //Console.WriteLine("{0} {1}", i, j);
                    }
                }
            }
        }

        public static void PrintMaze(MazeCell[,] maze)
        {
            System.Console.OutputEncoding = System.Text.Encoding.Unicode;
            RemoveScrollBars();

            int rows = maze.GetLength(0);
            int columns = maze.GetLength(1);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(new String('\u2588', columns + 2));
            Console.ResetColor();

            for (int i = 0; i < rows; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write('\u2588');
                Console.ResetColor();
                
                for (int j = 0; j < columns; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}", maze[i, j].Path ? '\u0020' : '\u2588');
                }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine('\u2588');
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(new String('\u2588', columns + 2));
            Console.ResetColor();
        }

        private static void PrintSolution(MazeCell[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
			{
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if ((maze[i, j].PartOfSolution || maze[i, j].Start || maze[i, j].End) && maze[i, j].Path)
                    {
                         Console.SetCursorPosition(j + 1, i + 1);
                         Console.ForegroundColor = ConsoleColor.Cyan;
                         Console.Write('\u2588');
                    }
                }
			}
        }

        public static void RemoveScrollBars()
        {
            Console.BufferWidth = Console.WindowWidth = 70;
            Console.BufferHeight = Console.WindowHeight = 23;
        }

        private static void PrintPlayer(int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            PrintAtPosition(x, y, '\u263B');
            Console.ResetColor();
        }

        private static void PrintExit(int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintAtPosition(x, y, 'E');
            Console.ResetColor();
        }

        private static void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }
}
