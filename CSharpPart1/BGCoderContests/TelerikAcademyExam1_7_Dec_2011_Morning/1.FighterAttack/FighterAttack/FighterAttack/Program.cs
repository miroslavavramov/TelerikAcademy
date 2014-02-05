using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalDamage = 0;

            int px1 = int.Parse(Console.ReadLine());
            int py1 = int.Parse(Console.ReadLine());
            int px2 = int.Parse(Console.ReadLine());
            int py2 = int.Parse(Console.ReadLine());
            int fx = int.Parse(Console.ReadLine());
            int fy = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            int minPx = Math.Min(px1, px2);
            int maxPx = Math.Max(px1, px2);
            int minPy = Math.Min(py1, py2);
            int maxPy = Math.Max(py1, py2);

            int middleMissleX = fx + d;
            int middleMissleY = fy;
            int frontMissleX = fx + d + 1;
            int frontMissleY = fy;
            int leftMissleX = fx + d;
            int leftMissleY = fy + 1;
            int rightMissleX = fx + d;
            int rightMissleY = fy - 1;

            
            if ((middleMissleX >= minPx && middleMissleX <= maxPx) && (middleMissleY >= minPy && middleMissleY <= maxPy))
            {
                totalDamage += 100;
            }
            if ((frontMissleX >= minPx && frontMissleX <= maxPx) && (frontMissleY >= minPy && frontMissleY <= maxPy))
            {
                totalDamage += 75;
            }
            if ((leftMissleX >= minPx && leftMissleX <= maxPx) && (leftMissleY >= minPy && leftMissleY <= maxPy))
            {
                totalDamage += 50;
            }
            if ((rightMissleX >= minPx && rightMissleX <= maxPx) && (rightMissleY >= minPy && rightMissleY <= maxPy))
            {
                totalDamage += 50;
            }

            Console.WriteLine(totalDamage + "%");
        }
    }
}
