using System;
using System.Linq;
using Wintellect.PowerCollections;

class Program
{
    static Random rnd = new Random();

    static decimal GetRandomNumber(decimal min, decimal max)
    {
        return Math.Round((min + ((decimal)rnd.NextDouble() * max - min)), 2);
    }

    static void Main()
    {
        var products = new OrderedBag<Product>();

        for (int i = 0; i < 5e+5; i++)
        {
            products.Add(new Product(
                string.Format("product {0}", i), GetRandomNumber(1,1000)
                ));
        }

        decimal minPrice = 500m;
        decimal maxPrice = 500.5m;

        var selectedInRange = products
            .Range(new Product("", minPrice), true, new Product("", maxPrice), true)
            .Take(20);

        foreach (var prod in selectedInRange)
        {
            Console.WriteLine(prod);
        }
    }
}

