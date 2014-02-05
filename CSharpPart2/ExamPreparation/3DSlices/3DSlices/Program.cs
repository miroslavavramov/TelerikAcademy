using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int[, ,] cuboid;
    static int equalCuts;
    static int w, h, d;
    static void Main()
    {
        ParseInput();

        for (int cutW = 1; cutW < w - 1; cutW++)
        {
            if (PartSumByWidth(0, cutW) == PartSumByWidth(cutW, w))
            {
                equalCuts += 1;
            }
        }
        for (int cutH = 1; cutH < h - 1; cutH++)
        {
            if (PartSumByWidth(0, cutH) == PartSumByWidth(cutH, h))
            {
                equalCuts += 1;
            }
        }
        for (int cutD = 1; cutD < d - 1; cutD++)
        {
            if (PartSumByWidth(0, cutD) == PartSumByWidth(cutD, d))
            {
                equalCuts += 1;
            }
        }
        Console.WriteLine(equalCuts);
    }
    static void ParseInput()
    {
        int[] whd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        cuboid = new int[whd[0], whd[1], whd[2]];

        w = whd[0];
        h = whd[1];
        d = whd[2];

        for (int height = 0; height < whd[1]; height++)
        {
            string[] layer = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            for (int depth = 0; depth < whd[2]; depth++)
            {
                string[] segment = layer[depth].Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

                for (int width = 0; width < whd[0]; width++)
                {
                    cuboid[width, height, depth] = int.Parse(segment[width].Trim());
                }
            }
        }
    }
    static int PartSumByWidth(int startW, int maxW)
    {
        int sum = 0;

        for (int width = startW; w < maxW; w++)
        {
            sum += cuboid[width, h, d];
        }

        return sum;
    }
    static int PartSumByHeight(int startH, int maxH)
    {
        int sum = 0;

        for (int height = startH; height < maxH; height++)
        {
            sum += cuboid[w, height, d];
        }

        return sum;
    }
    static int PartSumByDepth(int startD, int maxD)
    {
        int sum = 0;

        for (int depth = startD; depth < maxD; depth++)
        {
            sum += cuboid[w, h, depth];
        }
        return sum;
    }
}

