namespace CompanyData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    class Company
    {
        public Company(string name)
        {
            this.Name = name;
            this.Products = new OrderedMultiDictionary<decimal, Product>(false);
        }

        public string Name { get; private set; }

        public OrderedMultiDictionary<decimal, Product> Products { get; private set; }

        public void AddProduct(Product product)
        {
            this.Products.Add(product.Price, product);
        }

        public void GenerateRandomProducts(int itemsCount)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                this.AddProduct(new Product());
            }
        }

        public IEnumerable<Product> GetProductsInPriceRange(decimal min, decimal max)
        {
            var result = this.Products
                .Range(min, true, max, true)
                .Select(x => x.Value);

            var output = new List<Product>();

            output.AddRange(result.SelectMany(x => x));

            return output;
        }
    }
}
