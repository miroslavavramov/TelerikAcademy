using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipDamage
{
    class Program
    {
        static void Main(string[] args)
        {
            int Sx1 = int.Parse(Console.ReadLine());
            int Sy1 = int.Parse(Console.ReadLine());
            int Sx2 = int.Parse(Console.ReadLine());
            int Sy2 = int.Parse(Console.ReadLine());
            int H = int.Parse(Console.ReadLine());
            int Cx1 = int.Parse(Console.ReadLine());
            int Cy1 = int.Parse(Console.ReadLine());
            int Cx2 = int.Parse(Console.ReadLine());
            int Cy2 = int.Parse(Console.ReadLine());
            int Cx3 = int.Parse(Console.ReadLine());
            int Cy3 = int.Parse(Console.ReadLine());

            int damage = 0;

            int projectedCx1 = Cx1;
            int projectedCx2 = Cx2;
            int projectedCx3 = Cx3;
            int projectedCy1 = 2 * H - Cy1;
            int projectedCy2 = 2 * H - Cy2;
            int projectedCy3 = 2 * H - Cy3;

            int minX = Math.Min(Sx1, Sx2);
            int maxX = Math.Max(Sx1, Sx2);
            int minY = Math.Min(Sy1, Sy2);
            int maxY = Math.Max(Sy1, Sy2);
            
            // hit inside
            if ((projectedCx1 > minX) && (projectedCx1 < maxX) && (projectedCy1 > minY) && (projectedCy1 < maxY))
            {
                damage += 100;
            }
            if ((projectedCx2 > minX) && (projectedCx2 < maxX) && (projectedCy2 > minY) && (projectedCy2 < maxY))
            {
                damage += 100;
            }
            if ((projectedCx3 > minX) && (projectedCx3 < maxX) && (projectedCy3 > minY) && (projectedCy3 < maxY))
            {
                damage += 100;
            }

            // hit border
            if (((projectedCx1 == minX || projectedCx1 == maxX) && (projectedCy1 > minY && projectedCy1 < maxY)) || 
                ((projectedCx1 > minX && projectedCx1 < maxX) && (projectedCy1 == minY || projectedCy1 == maxY)))
            {
                damage += 50;
            }
            if (((projectedCx2 == minX || projectedCx2 == maxX) && (projectedCy2 > minY && projectedCy2 < maxY)) ||
                ((projectedCx2 > minX && projectedCx2 < maxX) && (projectedCy2 == minY || projectedCy2 == maxY)))
            {
                damage += 50;
            }
            if (((projectedCx3 == minX || projectedCx3 == maxX) && (projectedCy3 > minY && projectedCy3 < maxY)) ||
                ((projectedCx3 > minX && projectedCx3 < maxX) && (projectedCy3 == minY || projectedCy3 == maxY)))
            {
                damage += 50;
            }

            //hit corner
            if ((projectedCx1 == minX || projectedCx1 == maxX) && (projectedCy1 == minY || projectedCy1 == maxY))
            {
                damage += 25;
            }
            if ((projectedCx2 == minX || projectedCx2 == maxX) && (projectedCy2 == minY || projectedCy2 == maxY))
            {
                damage += 25;
            }
            if ((projectedCx3 == minX || projectedCx3 == maxX) && (projectedCy3 == minY || projectedCy3 == maxY))
            {
                damage += 25;
            }

            Console.WriteLine(damage+"%");
        }
    }
}
