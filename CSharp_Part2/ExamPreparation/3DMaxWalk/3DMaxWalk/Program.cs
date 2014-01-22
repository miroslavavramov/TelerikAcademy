using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace _3DMaxWalk
{
    class Program
    {
        static int[, ,] cuboid;
        static bool[, ,] visited;
        static int[][] direction = new int[6][];
        static int dir;
        static void ParseInput()
        {
            direction[0] = new int[] { -1, 0, 0 };  //Left
            direction[1] = new int[] {  1, 0, 0 };  //Right
            direction[2] = new int[] {  0,-1, 0 };  //Up
            direction[3] = new int[] {  0, 1, 0 };  //Down
            direction[4] = new int[] {  0, 0, 1 };  //Deeper
            direction[5] = new int[] {  0, 0, -1};  //Shallower

            int[] whd = Console.ReadLine().Split().Select(int.Parse).ToArray();

            cuboid = new int[whd[0], whd[1], whd[2]];
            visited = new bool[whd[0], whd[1], whd[2]];

          
            for (int h = 0; h < whd[1]; h++)
            {
                //AAAA AAAB BABA BBAA
                string[] layer = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                //[AAAA] [AAAB] [BABA] [BBAA]

                for (int d = 0; d < whd[2]; d++)
                {
                    string[] segment = layer[d].Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

                    for (int w = 0; w < whd[0]; w++)
                    {
                        cuboid[w, h, d] = int.Parse(segment[w]);
                    }
                }
            }
        }
        static void Walk()
        {
            int w = cuboid.GetLength(0) / 2;
            int h = cuboid.GetLength(1) / 2;
            int d = cuboid.GetLength(2) / 2;

            int max = cuboid[w,h,d];

            while (true)
            {
                int currMax = GetMax(w, h, d);

                if (visited[w, h, d] || currMax == int.MinValue)
                {
                    break;
                }
                else
                {
                    visited[w, h, d] = true;
                    w += direction[dir][0];
                    h += direction[dir][1];
                    d += direction[dir][2];

                    max += currMax;
                }
            }

            Console.WriteLine(max);
        }
        static int GetMax(int w, int h, int d)
        {
            int max = int.MinValue + 1;
            int temp = int.MinValue;

            for (int i = 0; i < direction.Length; i++)
            {
                int nextW = w + direction[i][0];
                int nextH = h + direction[i][1];
                int nextD = d + direction[i][2];

                if (    (nextW >= 0 && nextW < cuboid.GetLength(0))
                    &&  (nextH >= 0 && nextH < cuboid.GetLength(1))
                    &&  (nextD >= 0 && nextD < cuboid.GetLength(2))
                  )
                {
                    temp = cuboid[nextW, nextH, nextD];

                    if (temp > max)
                    {
                        max = temp;
                        dir = i;
                    }
                    else if (temp == max)
                    {
                        return int.MinValue;
                    }
                }
            }

            return max;
        }
        static void Main(string[] args)
        {
            ParseInput();

            Walk();
        }

    }
}
