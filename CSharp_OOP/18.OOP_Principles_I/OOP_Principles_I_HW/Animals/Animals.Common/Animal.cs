namespace Animals.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Animal
    {
        private string name;
        private byte age;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Name can't be an empty string!");
                }
                this.name = value;
            }
        }

        public byte Age
        {
            get { return this.age; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Age can't be negative !");
                }
                this.age = value;
            }
        }
        public bool IsMale { get; private set; }

        public Animal(string name, byte age, bool isMale)
        {
            this.Name = name;
            this.Age = age;
            this.IsMale = isMale;
        }

        public override string ToString()
        {
            return String.Format("Name : {0}, Age : {1}, Sex : {2}"
                , this.Name, this.Age, IsMale ? "male" : "female");
        }

        public abstract void ProduceSound();    //abstract methods don't possess bodies
    }
}
