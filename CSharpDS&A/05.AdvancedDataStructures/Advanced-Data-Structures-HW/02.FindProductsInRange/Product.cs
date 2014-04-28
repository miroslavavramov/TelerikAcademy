using System;

class Product : IComparable<Product>
{
    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public override string ToString()
    {
        return string.Format("{0} {1}", this.Name, this.Price);
    }

    public int CompareTo(Product other)
    {
        return this.Price.CompareTo(other.Price);
    }
}