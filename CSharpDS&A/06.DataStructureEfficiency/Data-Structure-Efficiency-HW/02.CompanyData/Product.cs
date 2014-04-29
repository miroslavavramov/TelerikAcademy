namespace CompanyData
{
    using System;
    using System.Text;
    
    class Product : IComparable<Product>
    {
        static Random randGen = new Random();

        public Product()
        {
            this.Barcode = this.GetRandomString(12, '0', '9' + 1);
            this.Vendor = this.GetRandomString(randGen.Next(3,7), 'A', 'Z' + 1);
            this.Title = this.GetRandomString(randGen.Next(3, 7), 'A', 'Z' + 1);
            this.Price = this.GetRandomDecimal(0, 1000);
        }

        public Product(string barcode, string vendor, string title, decimal price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public string Barcode { get; private set; }

        public string Vendor { get; private set; }

        public string Title { get; private set; }

        public decimal Price { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} | {1} | {2} | {3}",
                this.Barcode, this.Vendor, this.Title, this.Price);
        }

        private string GetRandomString(int length, int min, int max)
        {
            var output = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                var c = (char)randGen.Next(min, max);

                output.Append(c);
            }

            return output.ToString();
        }

        private decimal GetRandomDecimal(decimal min, decimal max)
        {
            return Math.Round((min + ((decimal)randGen.NextDouble() * max - min)), 2);
        }

        public int CompareTo(Product other)
        {
            return this.Title.CompareTo(other.Title);
        }
    }
}
