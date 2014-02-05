namespace Animals.Common
{
    using System;

    public class Tomcat
        : Cat, ISound
    {
        public Tomcat(string name, byte age)
            : base(name, age, true)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} the tomcat said Meow-Meow", this.Name);
        }
    }
}