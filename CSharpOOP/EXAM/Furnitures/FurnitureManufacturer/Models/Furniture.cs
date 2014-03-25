namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Text;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        protected Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get 
            { 
                return this.model; 
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Model cannot be empty, null or with less than 3 symbols!");
                }

                this.model = value;
            }
        }

        public string Material      //TODO: Caution!
        {
            get 
            { 
                return this.material; 
            }
            protected set
            {
                this.material = FirstCharToUpper(value);
            }
        }

        public decimal Price 
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0.0M)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be less or equal to $0.00!");
                }
                this.price = value;
            } 
        }

        public decimal Height
        {
            get 
            {
                return this.height;
            }
            protected set
            {
                if (value <= 0.0M)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be less or equal to 0.00 m!");
                }
                this.height = value;
            }
        }

        public override string ToString()   //TODO: Caution!
        {
            var output = new StringBuilder();

            output.AppendFormat("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, ",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height);

            return output.ToString();
        }

        private static string FirstCharToUpper(string input)
        {
            var output = new StringBuilder();

            output.Append(input[0].ToString().ToUpper());
            output.Append(input.Substring(1, input.Length - 1));

            return output.ToString();
        }
    }
}
