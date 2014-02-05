using System;

class Ball
{
    public int BallHeight {get; set; }
    public int BallWidth {get; set; }
    public int BallDepth { get; set; }

    public Ball(int width, int height, int depth)
    {
        this.BallWidth = width;
        this.BallHeight = height;
        this.BallDepth = depth;
    }
}
class Program
{
    static string[, ,] cube;
    static int width, height, depth, ballW, ballD;
    static Ball ball;

    static void Main()
    {
        ReadInput();

        ProcessBall();       
    }

    static void ProcessBall()
    {
        ball = new Ball(ballW, 0, ballD);

        while (true)
        {
            string[] command = cube[ball.BallWidth, ball.BallHeight, ball.BallDepth]
                .Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

            if (command[0] == "S")
            {
                switch (command[1])
                {
                    case "L": ball.BallWidth--; ball.BallHeight++; break;
                    case "R": ball.BallWidth++; ball.BallHeight++; break;
                    case "F": ball.BallDepth--; ball.BallHeight++; break;
                    case "B": ball.BallDepth++; ball.BallHeight++; break;
                    case "FL": ball.BallDepth--; ball.BallWidth--; ball.BallHeight++; break;
                    case "FR": ball.BallDepth--; ball.BallWidth++; ball.BallHeight++; break;
                    case "BL": ball.BallDepth++; ball.BallWidth--; ball.BallHeight++; break;
                    case "BR": ball.BallDepth++; ball.BallWidth++; ball.BallHeight++; break;
                }
            }
            else if (command[0] == "T")
            {
                ball.BallWidth = int.Parse(command[1]);
                ball.BallDepth = int.Parse(command[2]);
            }
            else if (command[0] == "E")
            {
                ball.BallHeight++;
            }
            else if (command[0] == "B")
            {
                Console.WriteLine("No\n{0} {1} {2}", ball.BallWidth, ball.BallHeight, ball.BallDepth);
                Environment.Exit(0);
            }
            else throw new ArgumentException("Invalid Command");

            if (CheckState() == 2) 
            {
                continue; 
            }
            else
            {
                if (CheckState() == 1)
                {
                    Console.WriteLine("No\n{0} {1} {2}", ball.BallWidth, ball.BallHeight, ball.BallDepth);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Yes\n{0} {1} {2}", ball.BallWidth, ball.BallHeight, ball.BallDepth);
                    Environment.Exit(0);
                }
            }
        }
    }
    static void ReadInput()
    {
        string[] whd = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        width = int.Parse(whd[0]);
        height = int.Parse(whd[1]);
        depth = int.Parse(whd[2]);

        cube = new string[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string[] line = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

            for (int d = 0; d < depth; d++)
            {
                string[] fragment = line[d].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

                for (int w = 0; w < width; w++)
                {
                    cube[w, h, d] = fragment[w];
                }
            }
        }
        string[] bWbD = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        ballW = int.Parse(bWbD[0]);
        ballD = int.Parse(bWbD[1]);

    }
    static int CheckState()
    {
        //bottom
        if (ball.BallHeight == height - 1)
        {
            return 0;   //ball got out
        }
        //wall
        else if (   ball.BallWidth < 0 
            || ball.BallWidth > width - 1
            || ball.BallDepth < 0
            || ball.BallDepth > depth - 1)
        {
            return 1; // hit wall
        }
        return 2; // can proceed
    }
}

