using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MathExpression
{
    class MathExpression
    {
        static void Main(string[] args)
        {
            
            double n = double.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());

            const double firstConst = 1337;
            const double secondConst = 128.523123123;
            

            double nominator;
            double denominator;
            double sum;

            nominator = (n * n) + 1 / (m * p) + firstConst;
            denominator = n - (secondConst * p);
                      

            sum = nominator / denominator + Math.Sin((int)m % 180);
            Console.WriteLine("{0:F6}", sum);
            
        }
    }
}
