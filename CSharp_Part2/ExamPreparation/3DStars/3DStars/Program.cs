using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static char[, ,] cuboid;
    static int maxW, maxH, maxD;
    static void ParseInput()
    {
        int[] whd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        cuboid = new char[whd[0], whd[1], whd[2]];
        maxW = whd[0];
        maxH = whd[1];
        maxD = whd[2];

        for (int h = 0; h < whd[1]; h++)
        {
            //AAAA AAAB BABA BBAA
            string[] layer = Console.ReadLine().Split();
            //[AAAA] [AAAB] [BABA] [BBAA]

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
    static bool IsStar(int w, int h, int d)
    {
        char color = cuboid[w, h, d];

        return  cuboid[w+1 ,h, d] == color &&
                cuboid[w-1 ,h, d] == color &&
                cuboid[w, h+1, d] == color && 
                cuboid[w, h-1, d] == color &&
                cuboid[w, h, d+1] == color &&
                cuboid[w, h, d-1] == color;
    }
    static void Main()
    {
        ParseInput();

        Dictionary<char, int> stars = new Dictionary<char, int>();
        int totalStars = 0;

        for (int w = 1; w < maxW-1; w++)
        {
            for (int h = 1; h < maxH-1; h++)
            {
                for (int d = 1; d < maxD-1; d++)
                {
                    if (IsStar(w, h, d))
                    {
                        totalStars += 1;

                        if(stars.ContainsKey(cuboid[w,h,d]))
                        {
                            stars[cuboid[w, h, d]] += 1;
                        }
                        else
                        {
                            stars.Add(cuboid[w, h, d], 1);
                        }
                    }
                }
            }
        }

        var list = stars.Keys.ToList();
        list.Sort();


        Console.WriteLine(totalStars);

        foreach (var key in list)
        {
            Console.WriteLine("{0} {1}", key, stars[key]);
        }
    }
}

