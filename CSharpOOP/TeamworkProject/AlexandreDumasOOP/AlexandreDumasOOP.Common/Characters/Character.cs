namespace AlexandreDumasOOP.Common.Characters
{
    using AlexandreDumasOOP.Common.Interfaces;

    public abstract class Character
        : INameable
    {
        protected Character(string name)
        {
            this.Name = name;
        }

        public string Name { get; protected set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
