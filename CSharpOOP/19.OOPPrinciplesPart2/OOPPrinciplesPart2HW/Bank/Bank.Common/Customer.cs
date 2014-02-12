namespace Bank.Common
{
    using System;

    public abstract class Customer
    {
        public string Name { get; protected set; }
        
        protected Customer(string name)     
        {                                
            this.Name = name;
        }
    }
}
