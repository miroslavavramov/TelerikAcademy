namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Text;

    public class Chair : Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, string material, decimal price, decimal height,
            int numberOfLegs) 
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Chair legs can't be negative or zero!");
                }
                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());

            output.AppendFormat("Legs: {0}", this.NumberOfLegs);

            return output.ToString();
        }
    }
}
