using System;
class HelpDoge
{
    static string[,] field;
    static int N, M, fx, fy;


    static void ParseInput()
    {
        string[] rowsAndCols = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        N = int.Parse(rowsAndCols[0]);
        M = int.Parse(rowsAndCols[1]);

        field = new string[N, M];

        string[] foodCoordinates = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        fx = int.Parse(foodCoordinates[0]);
        fy = int.Parse(foodCoordinates[1]);

        field[fx, fy] = "food";

        int numberOfEnemies = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfEnemies; i++)
        {
            string[] enemyCoordinates = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int enemyX = int.Parse(enemyCoordinates[0]);
            int enemyY = int.Parse(enemyCoordinates[1]);

            field[enemyX, enemyY] = "enemy";
        }
    }
    static int AllPossiblePaths(int x, int y)
    {
        if (x == N || y == M)
        {
            return 0;
        }
        if (x > fx || y > fy)
        {
            return 0;
        }
        if (field[x, y] == "enemy")
        {
            return 0;
        }
        else
        {
            if (x == fx && y == fy)
            {
                return 1;
            }
            else
            {
                return AllPossiblePaths(x + 1, y) + AllPossiblePaths(x, y + 1);
            }
        }
    }
    static void Main()
    {
        ParseInput();

        Console.WriteLine(AllPossiblePaths(0, 0));
    }
}