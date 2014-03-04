namespace AlexandreDumasOOP.Common.Characters
{
    using AlexandreDumasOOP.Common;

    public class Elf : Hero
    {
        private const int ElfBasicHealthPoints = 700;
        private const int ElfBasicAgilityPoints = 10;

        public Elf(string name)
            : base(name)
        {
            this.HealthPoints = ElfBasicHealthPoints;
            this.Agility = ElfBasicAgilityPoints;
            this.NativeLocation = LocationType.Forest;
        }

        public override void Revitalize()
        {
            this.HealthPoints = ElfBasicHealthPoints;
        }

        public override string ToString()
        {
            string result = string.Format("[Elf] {0}", base.ToString());

            return result;
        }
    }
}
