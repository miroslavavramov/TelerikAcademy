namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Text;

    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, string material, decimal price, decimal height,
            decimal length, decimal width) 
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get 
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Table length can't be negative or zero!");
                }
                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Table width can't be negative or zero!");
                }
                this.width = value;
            }
        }

        public decimal Area
        {
            get 
            {
                return this.Width * this.Length;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());

            output.AppendFormat("Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);

            return output.ToString();
        }
    }
}
