namespace Animals.Common
{
    using System;

    public class Frog
        : Animal, ISound
    {
        public Frog(string name, byte age, bool isMale)
            : base(name, age, isMale)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} the frog said Ribbit-Ribbit", this.Name);
        }
    }
}
