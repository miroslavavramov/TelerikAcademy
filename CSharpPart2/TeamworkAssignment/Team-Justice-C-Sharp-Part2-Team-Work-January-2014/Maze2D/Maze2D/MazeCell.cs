using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze2D
{
    public class MazeCell
    {
        private bool path = false;//Path of the labrint if true
        private bool visited = false;
        private bool partOfSolution = true;
        private int row;
        private int col;
        private bool start = false;
        private bool end = false;
        private static Random rndGen = new Random();//random Generator
        private static int solutionLenght = 0;
        private static int startRow = 0;
        private static int startCol = 0;

        //constructor
        private MazeCell(int row, int col)
        {
            this.col = col;
            this.row = row;
        }

        //Getter for the starting point
        public int StartRow
        {
            get
            {
                return MazeCell.startRow;
            }
        }
        public int StartCol
        {
            get
            {
                return MazeCell.startCol;
            }
        }


        //Getter for the solution lenght
        public int SolutionLenght
        {
            get
            {
                return MazeCell.solutionLenght;
            }
        }

        //need it to peek
        public int Row
        {
            //no setter because i dont want any one to change those values
            get
            {
                return this.row;
            }
        }
        public int Col
        {
            //no setter because i dont want any one to change those values
            get
            {
                return this.col;
            }
        }

        //here we can read the solution path
        public bool PartOfSolution
        {
            get
            {
                return this.partOfSolution;
            }
        }

        //Reads the random begining and end
        public bool Start
        {
            get
            {
                return this.start;
            }
        }
        public bool End
        {
            get
            {
                return this.end;
            }
        }

        //if true then player can step on it
        public bool Path
        {
            get
            {
                return this.path;
            }
        }

        //Gets and sets visited(here we can save player's path)
        public bool Visited
        {
            set
            {
                this.visited = value;
            }
            get
            {
                return this.visited;
            }
        }

        //using DFS algorithm again for solution
        private static void Solve(MazeCell[,] maze, MazeCell start, MazeCell end)
        {
            Stack<MazeCell> backTrack = new Stack<MazeCell>();
            MazeCell current = start;

            while (current.Row != end.Row || current.Col != end.Col)
            {
                maze[current.Row, current.Col].partOfSolution = false;
                //left
                if (current.Col - 1 >= 0 && maze[current.Row, current.Col - 1].partOfSolution == true
                    && maze[current.Row, current.Col - 1].path == true)
                {
                    backTrack.Push(current);
                    current = maze[current.Row, current.Col - 1];
                }
                //right
                else if (current.Col + 1 < maze.GetLength(1) && maze[current.Row, current.Col + 1].partOfSolution == true
                    && maze[current.Row, current.Col + 1].path == true)
                {
                    backTrack.Push(current);
                    current = maze[current.Row, current.Col + 1];
                }
                //up
                else if (current.Row - 1 >= 0 && maze[current.Row - 1, current.Col].partOfSolution == true
                    && maze[current.Row - 1, current.Col].path == true)
                {
                    backTrack.Push(current);
                    current = maze[current.Row - 1, current.Col];
                }

                //down
                else if (current.Row + 1 < maze.GetLength(0) && maze[current.Row + 1, current.Col].partOfSolution == true
                    && maze[current.Row + 1, current.Col].path == true)
                {
                    backTrack.Push(current);
                    current = maze[current.Row + 1, current.Col];
                }
                else
                {
                    current = backTrack.Pop();
                }
            }

            MazeCell.solutionLenght = backTrack.Count;

            ResetSolution(maze);
            while (backTrack.Count > 0)
            {
                //when printing solution check both if it is a path and if it is a solution!!
                maze[backTrack.Peek().Row, backTrack.Peek().Col].partOfSolution = true;
                backTrack.Pop();
            }
        }

        //It is a nice idea to store begining and ending cell, not to get in to
        //searching them in loops all the time
        //generates a random begining
        private static MazeCell GenerateStart(MazeCell[,] maze)
        {
            MazeCell start;

            do
            {
                start = maze[rndGen.Next(0, maze.GetLength(0) - 1), 0];
            } while (!start.path);

            maze[start.Row, start.Col].start = true;
            MazeCell.startRow = start.Row;
            MazeCell.startCol = start.Col;

            return start;
        }

        //generates a random end
        private static MazeCell GenerateEnd(MazeCell[,] maze)
        {
            MazeCell end;

            do
            {
                end = maze[rndGen.Next(0, maze.GetLength(0) - 1), maze.GetLength(1) - 1];
            } while (!end.path);

            maze[end.Row, end.Col].end = true;
            return end;
        }

        //gets a list of unvisited elements by the labrint creation algorithm
        private static List<MazeCell> FindAvailable(MazeCell[,] maze, MazeCell current)
        {
            List<MazeCell> available = new List<MazeCell>();

            //down
            if (current.Row + 1 < maze.GetLength(0) &&
                maze[current.Row + 1, current.Col].visited == false)
            {
                available.Add(maze[current.Row + 1, current.Col]);
            }
            //up
            if (current.Row - 1 >= 0 &&
                maze[current.Row - 1, current.Col].visited == false)
            {
                available.Add(maze[current.Row - 1, current.Col]);
            }
            //right
            if (current.Col + 1 < maze.GetLength(1) &&
                maze[current.Row, current.Col + 1].visited == false)
            {
                available.Add(maze[current.Row, current.Col + 1]);
            }
            //left
            if (current.Col - 1 >= 0 &&
                maze[current.Row, current.Col - 1].visited == false)
            {
                available.Add(maze[current.Row, current.Col - 1]);
            }
            return available;
        }

        //We can use that variable to store player path later
        private static void Reset(MazeCell[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i, j].visited = false;
                }
            }
        }

        //Resets solution path
        private static void ResetSolution(MazeCell[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i, j].partOfSolution = false;
                }
            }
        }

        //checks where there we can move in that way and moves
        private static bool Move(MazeCell next, MazeCell[,] maze)
        {
            int notWays = 0;
            //left
            if (next.Col - 1 >= 0 && maze[next.Row, next.Col - 1].path == true)
            {
                notWays++;
            }
            //right
            if (next.Col + 1 < maze.GetLength(1) && maze[next.Row, next.Col + 1].path == true)
            {
                notWays++;
            }
            //up
            if (next.Row - 1 >= 0 && maze[next.Row - 1, next.Col].path == true)
            {
                notWays++;
            }
            //down
            if (next.Row + 1 < maze.GetLength(0) && maze[next.Row + 1, next.Col].path == true)
            {
                notWays++;
            }
            if (notWays > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static MazeCell[,] CreateMaze(int height, int weight)
        {
            //I need that loop because i keep rows and cols private
            //and it is going to be realy hard if i dont store it in every element
            MazeCell[,] maze = new MazeCell[height, weight];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < weight; j++)
                {
                    maze[i, j] = new MazeCell(i, j);
                }
            }

            //DFS algorithm
            Stack<MazeCell> backTrack = new Stack<MazeCell>();
            MazeCell current = maze[rndGen.Next(0, height - 1), rndGen.Next(0, weight - 1)];

            do
            {
                maze[current.Row, current.Col].visited = true;
                maze[current.Row, current.Col].path = true;
                List<MazeCell> available = FindAvailable(maze, current);

                if (available.Count > 0)
                {
                    MazeCell next = available[rndGen.Next(0, available.Count)];
                    if (Move(next, maze))
                    {
                        backTrack.Push(current);
                        current = next;
                    }
                    else
                    {
                        maze[next.Row, next.Col].Visited = true;
                    }
                }
                else
                {
                    current = backTrack.Pop();
                }
            } while (backTrack.Count > 0);

            //Creating start and end and solving the puzzle
            MazeCell start = GenerateStart(maze);
            MazeCell end = GenerateEnd(maze);
            Solve(maze,start,end);

            //making cells unvisited for further use
            MazeCell.Reset(maze);
            return maze;
        }        
    }
}