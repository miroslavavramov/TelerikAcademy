namespace Animals.Common
{
    using System;

    public class Cat
        : Animal, ISound
    {
        public Cat(string name, byte age, bool isMale)
            : base(name, age, isMale)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} the cat said Meow-Meow", this.Name);
        }
    }
}
