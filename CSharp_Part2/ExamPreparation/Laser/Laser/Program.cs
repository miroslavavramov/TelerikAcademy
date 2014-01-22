using System;

class Program
{
    static bool[, ,] cube;
    static int width, height, depth;
    static int w, h, d;
    static int dirW, dirH, dirD;

    static void ParseInput()
    {
        string[] cubeDimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        width = int.Parse(cubeDimensions[0]);
        height = int.Parse(cubeDimensions[1]);
        depth = int.Parse(cubeDimensions[2]);

        cube = new bool[width, height, depth];

        string[] laserStartCoordinates = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        w = int.Parse(laserStartCoordinates[0]) - 1;
        h = int.Parse(laserStartCoordinates[1]) - 1;
        d = int.Parse(laserStartCoordinates[2]) - 1;

        string[] startDirections = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        dirW = int.Parse(startDirections[0]);
        dirH = int.Parse(startDirections[1]);
        dirD = int.Parse(startDirections[2]);
    }
    static void BurnEdges()
    {
        for (int w = 0; w < width; w++)
        {
            if (h == 0 && d == 0) cube[w, h, d] = true;
            if (h == 0 && d == depth - 1) cube[w, h, d] = true;
            if (h == height - 1 && d == 0) cube[w, h, d] = true;
            if (h == height - 1 && d == depth - 1) cube[w, h, d] = true;
        }
        for (int h = 0; h < height; h++)
        {
            if (w == 0 && d == 0) cube[w, h, d] = true;
            if (w == 0 && d == depth - 1) cube[w, h, d] = true;
            if (w == width - 1 && d == 0) cube[w, h, d] = true;
            if (w == width - 1 && d == depth - 1) cube[w, h, d] = true;
        }
        for (int d = 0; d < depth; d++)
        {
            if (w == 0 && h == 0) cube[w, h, d] = true;
            if (w == 0 && h == height - 1) cube[w, h, d] = true;
            if (w == width - 1 && h == 0) cube[w, h, d] = true;
            if (w == width - 1 && h == height - 1) cube[w, h, d] = true;
        }
    }
    static bool InsideCube(int currW, int currH, int currD)
    {
        return currW >= 0 && currW < width &&
                currH >= 0 && currH < height &&
                currD >= 0 && currD < depth;
    }
    static void Fire()
    {
        BurnEdges();

        int nextW, nextH, nextD;

        while (true)
        {
            nextW = w + dirW;
            nextH = h + dirH;
            nextD = d + dirD;

            if (InsideCube(nextW, nextH, nextD))
            {
                if (cube[nextW, nextH, nextD] == true)
                {
                    break;
                }
                else
                {
                    cube[nextW, nextH, nextD] = true;
                    w = nextW;
                    h = nextH;
                    d = nextD;
                }
            }
            else
            {
                if (!(nextW >= 0 && nextW < width)) dirW *= -1;
                if (!(nextH >= 0 && nextH < height)) dirH *= -1;
                if (!(nextD >= 0 && nextD < depth)) dirD *= -1;
            }
        }

        Console.WriteLine("{0} {1} {2}", w + 1, h + 1, d + 1);
    }
    static void Main()
    {
        ParseInput();
        Fire();
    }
}