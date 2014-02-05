namespace Animals.Common
{
    using System;

    public class Kitten 
        : Cat, ISound
    {
        public Kitten(string name, byte age)
            : base(name, age, false)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} the kitten said Meow-Meow", this.Name);
        }
    }
}
