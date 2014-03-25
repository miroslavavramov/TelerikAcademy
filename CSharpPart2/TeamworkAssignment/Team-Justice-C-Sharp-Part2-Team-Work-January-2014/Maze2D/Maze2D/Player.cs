using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze2D
{
    public class Player
    {
        public struct visited
        {
            public int x;
            public int y;
        }

        private int positionX;
        private int positionY;
        private char playerSymbol;
        public int pathLength = 0;
        public List<visited> playerPath = new List<visited>();  

        public Player(int positionX, int positionY, char playerSymbol, MazeCell[,] matrix)
        {
            if (IsValidPosition(matrix, positionX, positionY))
            {
                this.positionX = positionX;
                this.positionY = positionY;
                this.playerSymbol = playerSymbol;
                this.pathLength = 0;
            }
        }

        public int PositionX
        {
            get
            {
                return this.positionX;
            }
        }

        public int PositionY
        {
            get
            {
                return this.positionY;
            }
        }


        public void Move(MazeCell[,] matrix, ConsoleKeyInfo key)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(positionY, positionX);

            if (key.Key == ConsoleKey.LeftArrow)
            {
                if (IsValidPosition(matrix, positionX, positionY - 1))
                {
                    visited visitedCell = new visited();
                    visitedCell.x = positionX;
                    visitedCell.y = positionY - 1;
                    playerPath.Add(visitedCell);
                    Console.SetCursorPosition(positionY + 1, positionX + 1);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(' ');
                    positionY--;
                    Console.SetCursorPosition(positionY + 1, positionX + 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(playerSymbol);
                    Console.ResetColor();
                    pathLength++;
                }
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                if (IsValidPosition(matrix, positionX, positionY + 1))
                {
                    visited visitedCell = new visited();
                    visitedCell.x = positionX;
                    visitedCell.y = positionY - 1;
                    playerPath.Add(visitedCell);
                    Console.SetCursorPosition(positionY + 1, positionX + 1);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(' ');
                    positionY++;
                    Console.SetCursorPosition(positionY + 1, positionX + 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(playerSymbol);
                    Console.ResetColor();
                    pathLength++;
                }
            }
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (IsValidPosition(matrix, positionX - 1, positionY))
                {
                    visited visitedCell = new visited();
                    visitedCell.x = positionX;
                    visitedCell.y = positionY - 1;
                    playerPath.Add(visitedCell);
                    Console.SetCursorPosition(positionY + 1, positionX + 1);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(' ');
                    positionX--;
                    Console.SetCursorPosition(positionY + 1, positionX + 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(playerSymbol);
                    Console.ResetColor();
                    pathLength++;
                }
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                if (IsValidPosition(matrix, positionX + 1, positionY))
                {
                    visited visitedCell = new visited();
                    visitedCell.x = positionX;
                    visitedCell.y = positionY - 1;
                    playerPath.Add(visitedCell);
                    Console.SetCursorPosition(positionY + 1, positionX + 1);
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(' ');
                    positionX++;
                    Console.SetCursorPosition(positionY + 1, positionX + 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(playerSymbol);
                    Console.ResetColor();
                    pathLength++;
                }
            }
        }

        private bool IsValidPosition(MazeCell[,] matrix, int row, int column)
        {
            bool result = false;
            if ((row >= 0) && (row < matrix.GetLength(0)) && (column >= 0) && (column < matrix.GetLength(1)))
            {
                if (matrix[row, column].Path == true)
                {
                    result = true;
                }
            }

            return result;
        }

    }
}
