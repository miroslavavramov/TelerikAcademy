namespace AlexandreDumasOOP.Common.Characters
{
    using AlexandreDumasOOP.Common;
    using AlexandreDumasOOP.Common.Interfaces;
    using AlexandreDumasOOP.Common.Items;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public abstract class Hero
        : Character, IEquipper, IBattler
    {
        private static readonly Random rnd = new Random();
        private const int StartingGold = 1000;
        private const int InitialDamage = 10;
        private const int InitialDefence = 5;

        protected Hero(string name)
            : base(name)
        {
            this.Gold = StartingGold;
            this.Inventory = new List<Item>();
        }

        public int HealthPoints { get; set; }

        public int Agility { get; set; }

        public int Gold { get; set; }

        public LocationType NativeLocation { get; protected set; } 

        public List<Item> Inventory { get; protected set; }
        
        public void Equip(string code)
        {
            int id;
            Console.ForegroundColor = ConsoleColor.Red;

            if (int.TryParse(code, out id))
            {
                var item = ItemShop.GetItems.Find(x => x.GetHashCode() == id);

                if (item != null)
                {
                    /* Make sure hero doesn't possess duplicates items. */
                    if (!(item is Weapon) && this.Inventory.Exists(x => x.GetType() == item.GetType()))
                    {
                        Console.WriteLine("Your character already has {0}!", item.GetType().Name);  //Armor, or Charm
                    }
                    else if ((item is Weapon) && this.Inventory.Exists(x => x.GetType().BaseType.BaseType == item.GetType().BaseType.BaseType))
                    {
                        Console.WriteLine("Your character already has a weapon!");
                    }
                    else
                    {
                        if (this.Gold >= item.Price)
                        {
                            this.Inventory.Add(item);
                            this.Gold -= item.Price;

                            Console.ResetColor();
                            ColorizeHero(this);
                            Console.WriteLine("\"{0}\" added to the inventory!", item.Name);

                            if (item is Charm) 
                            { 
                                this.HealthPoints += (item as Charm).HealthPoints; 
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not enough gold!");
                        }
                    }
                }
                else Console.WriteLine("Item with ID of {0} not found!", id);
            }
            else Console.WriteLine("Invalid ID!");
        }

        public void Dequip(string code)
        {
            int id;
            Console.ForegroundColor = ConsoleColor.Red;

            if (int.TryParse(code, out id))
            {
                var item = this.Inventory.Find(x => x.GetHashCode() == id);

                if (item != null)
                {
                    this.Inventory.Remove(item);
                    this.Gold += item.Price;

                    Console.ResetColor();
                    ColorizeHero(this);
                    Console.WriteLine("\"{0}\" removed from the inventory!", item.Name);

                    if (item is Charm) 
                    { 
                        this.HealthPoints -= (item as Charm).HealthPoints; 
                    }
                }
                else Console.WriteLine("Item with ID of {0} not found!", id);
            }
            else Console.WriteLine("Invalid ID!");
        }

        public virtual void Attack(Hero enemy)
        {
            var attackerWeapon = (Weapon)this.Inventory.Find(x => x is Weapon);
            var defenderArmour = (Armour)enemy.Inventory.Find(x => x is Armour);

            int attackerDamage = InitialDamage;
            int defenderDefence = InitialDefence;
            int causedDamage = 0;

            bool doubleDamageAchieved = false;
            bool criticalStrikeAchieved = false;
            
            if (enemy.Evade())
            {
                ColorizeHero(enemy);
                Console.WriteLine("has evaded the attack.");
            }
            else
            {
                if (defenderArmour != null)
                {
                    defenderDefence += defenderArmour.Defence;
                }
                if (attackerWeapon != null)
                {
                    attackerDamage += attackerWeapon.Damage * attackerWeapon.AttackSpeed;

                    if (attackerWeapon is MeleeWeapon)
                    {
                        if (rnd.Next(1, 100) <= (attackerWeapon as MeleeWeapon).DoubleDamageRatio)
                        {
                            doubleDamageAchieved = true;
                            ColorizeHero(this);
                            Console.Write("Double damage! ");
                        }
                    }
                    else if (attackerWeapon is RangedWeapon)
                    {
                        if (rnd.Next(1, 100) <= (attackerWeapon as RangedWeapon).CriticalStrikeRatio)
                        {
                            criticalStrikeAchieved = true;
                            ColorizeHero(this);
                            Console.Write("Critical strike! ");
                        }
                    }
                    else if (attackerWeapon is MagicalWeapon)
                    {
                        if (rnd.Next(1, 100) <= (attackerWeapon as MagicalWeapon).DirectDamageRatio)
                        {
                            defenderDefence = 0;
                            ColorizeHero(this);
                            Console.Write("Direct damage! ");
                        }
                    }
                }

                if(attackerDamage - defenderDefence > 1)    // avoids exception in case of disbalanced items
                    causedDamage = rnd.Next(1, attackerDamage - defenderDefence);

                if (doubleDamageAchieved)       causedDamage *= 2;
                if (criticalStrikeAchieved)     causedDamage *= 3;     //ranged weapons have less initial damage than melee weapons
                ColorizeHero(this);
                Console.WriteLine("Attacks! (Damage caused: {0})", causedDamage);

                if (enemy.HealthPoints - causedDamage <= 0)
                {
                    ColorizeHero(this);
                    Console.WriteLine(" won the battle [HP: {0}]!", this.HealthPoints);
                    enemy.HealthPoints = 0;
                }
                else
                {   
                    enemy.HealthPoints -= causedDamage;
                }
            }
        }

        public void DisplayInventory()
        {
            ColorizeHero(this);
            Console.Write("'s Inventory:\n{0}\n",  
                this.Inventory.Count == 0 ? "Empty" : string.Join("\n", this.Inventory));
        }
        
        private bool Evade()
        {
            int evasionRatio = this.Agility;

            foreach (var item in this.Inventory)
            {
                if (item is IEvader) evasionRatio += (item as IEvader).EvasionRatio;
            }

            return rnd.Next(1, 100) <= evasionRatio;
        }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendFormat("[HP: {0}] [Ag: {1}] [NT: {2}] [Gold: {3}]",
                this.HealthPoints, this.Agility, this.NativeLocation, this.Gold)
                .ToString();
        }

        public abstract void Revitalize();

        public static void ColorizeHero(Hero hero)
        {
            if (hero is Elf)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (hero is Human)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (hero is Orc)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (hero is Undead)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.Write("[{0}] ", hero.Name);
            Console.ResetColor();
        }
       
    }
}
