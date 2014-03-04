namespace AlexandreDumasOOP.Common.Interfaces
{
    using AlexandreDumasOOP.Common.Characters;

    public interface IBattler
    {
        int HealthPoints { get; }

        int Agility { get; }

        void Attack(Hero hero);
    }
}