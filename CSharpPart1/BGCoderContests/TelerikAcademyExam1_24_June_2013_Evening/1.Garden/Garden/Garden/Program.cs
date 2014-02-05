using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal tomatoeSeeds = decimal.Parse(Console.ReadLine());
            decimal tomatoeArea = decimal.Parse(Console.ReadLine());
            decimal cuccumberSeeds = decimal.Parse(Console.ReadLine());
            decimal cuccumberArea = decimal.Parse(Console.ReadLine());
            decimal potatoeSeeds = decimal.Parse(Console.ReadLine());
            decimal potatoeArea = decimal.Parse(Console.ReadLine());
            decimal carrotSeeds = decimal.Parse(Console.ReadLine());
            decimal carrotArea = decimal.Parse(Console.ReadLine());
            decimal cabbageSeeds = decimal.Parse(Console.ReadLine());
            decimal cabbageArea = decimal.Parse(Console.ReadLine());
            decimal beanSeeds = decimal.Parse(Console.ReadLine());
            decimal beanArea;
            
            const decimal totalArea = 250m;
            string areaMessage;

            const decimal tomatoePrice = 0.5m;
            const decimal cuccumberPrice = 0.4m;
            const decimal potatoePrice = 0.25m;
            const decimal carrotPrice = 0.6m;
            const decimal cabbagePrice = 0.3m;
            const decimal beansPrice = 0.4m;

            decimal totalPrice = tomatoeSeeds * tomatoePrice + cuccumberSeeds * cuccumberPrice + potatoeSeeds * potatoePrice +
                carrotSeeds * carrotPrice + cabbageSeeds * cabbagePrice + beanSeeds * beansPrice;

            beanArea = totalArea - (tomatoeArea + cuccumberArea + potatoeArea + carrotArea + cabbageArea);

            if (beanArea > 0)
            {
                areaMessage = "Beans area: " + beanArea;
            }
            else if (beanArea == 0)
            {
                areaMessage = "No area for beans";
            }
            else if (true)
	        {
                areaMessage = "Insufficient area";
	        }

            Console.WriteLine("Total costs: {0:F2}", totalPrice);
            Console.WriteLine(areaMessage);
        }
    }
}
