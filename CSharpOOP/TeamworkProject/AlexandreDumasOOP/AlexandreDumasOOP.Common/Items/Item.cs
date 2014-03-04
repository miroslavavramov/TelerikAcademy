namespace AlexandreDumasOOP.Common.Items
{
    using AlexandreDumasOOP.Common.Interfaces;
    using System;

    public abstract class Item
        : INameable, IPriceable
    {
        private int price;
        private const int MinPrice = 0;
        private const int MaxPrice = 1000;
        private readonly InvalidRangeException invalidPriceException =
            new InvalidRangeException(string.Format("Price must be in range [{0}, {1}]", MinPrice, MaxPrice), 0, 1000);

        protected Item(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }
        
        public string Name { get; protected set; }

        public int Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                if (value < MinPrice || value > MaxPrice)
                {
                    throw this.invalidPriceException;
                }
                this.price = value;   
            }
        }

        public override string ToString()
        {
            return string.Format("#{0}: \"{1}\" {2} gold \n[ID: {3}] ", 
                this.GetType().Name.ToString().ToUpper(), this.Name, this.Price, this.GetHashCode());
        }
    }
}