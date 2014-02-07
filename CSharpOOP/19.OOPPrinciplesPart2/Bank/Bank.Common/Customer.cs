namespace Bank.Common
{
    using System;

    public class Customer
    {
        public string Name { get; private set; }
        
        protected Customer(string name)     //can be accessed only by it's descendands
        {                                   //i.o. to avoid creating customers of non-specific type
            this.Name = name;
        }
    }
}
