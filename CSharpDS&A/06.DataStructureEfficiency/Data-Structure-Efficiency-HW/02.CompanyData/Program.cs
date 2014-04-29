namespace CompanyData
{
    using System;

    class Program
    {
        static void Main()
        {
            var company = new Company("Planet Express");

            company.GenerateRandomProducts(1000000);

            var selected  = company.GetProductsInPriceRange(170, 170.5m);

            Console.WriteLine(string.Join(Environment.NewLine, selected));
        }
    }
}
