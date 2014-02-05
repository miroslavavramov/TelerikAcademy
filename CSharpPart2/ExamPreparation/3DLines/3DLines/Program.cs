using System;
using System.Linq;
class Program
{
    static int[] dirWidth = { 1, 0, 1, -1, 0, 0, 0, 1, -1, 1, 1, 1, 1 };
    static int[] dirHeight = { 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, -1, 1, -1 };
    static int[] dirDepth = { 0, 0, 1, 1, 1, 1, -1, 0, 0, 1, 1, -1, -1 };

    static char[, ,] cuboid;
    static int maxW, maxH, maxD;
    static int currSeq = 1, maxSeq = 1, maxSeqCount = 1;

    static void ParseInput()
    {
        int[] whd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        cuboid = new char[whd[0], whd[1], whd[2]];

        maxW = whd[0];
        maxH = whd[1];
        maxD = whd[2];

        for (int h = 0; h < whd[1]; h++)
        {
            string[] layer = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int d = 0; d < whd[2]; d++)
            {
                string segment = layer[d];

                for (int w = 0; w < whd[0]; w++)
                {
                    cuboid[w, h, d] = segment[w];
                }
            }
        }
    }
    static bool IsInCube(int w, int h, int d)
    {
        return (w >= 0 && w < maxW && h >= 0 && h < maxH && d >= 0 && d < maxD);
    }
    static void CheckSequence(int w, int h, int d)
    {
        char ch = cuboid[w, h, d];

        for (int i = 0; i < dirDepth.Length; i++)
        {
            currSeq = 1;
            int width = w;
            int height = h;
            int depth = d;

            while (true)
            {
                width += dirWidth[i];
                height += dirHeight[i];
                depth += dirDepth[i];

                if (!IsInCube(width,height,depth))
                {
                    break;
                }
                if (cuboid[width, height, depth] == ch)
                {
                    currSeq++;
                }
                else break;
            }

            if (currSeq > maxSeq)
            {
                maxSeq = currSeq;
                maxSeqCount = 1;
            }
            else if (currSeq == maxSeq)
            {
                maxSeqCount++;
            }
        }
    }
    static void Main()
    {
        ParseInput();

        for (int w = 0; w < maxW; w++)
        {
            for (int h = 0; h < maxH; h++)
            {
                for (int d = 0; d < maxD; d++)
                {
                    CheckSequence(w, h, d);
                }
            }
        }


        Console.WriteLine("{0} {1}",maxSeq,maxSeqCount);
    }
}

