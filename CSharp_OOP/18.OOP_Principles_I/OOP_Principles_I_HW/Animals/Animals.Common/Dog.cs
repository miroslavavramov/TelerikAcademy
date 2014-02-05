namespace Animals.Common
{
    using System;

    public class Dog 
        : Animal, ISound
    {
        public Dog(string name, byte age, bool isMale)
            : base(name, age, isMale)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} the dog said Woof-Woof!", this.Name);
        }
    }
}
