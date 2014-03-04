namespace AlexandreDumasOOP.Common.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public sealed class ItemShop : List<Item>   //as Singleton
    {
        private static readonly ItemShop items = new ItemShop() 
        {
            new Sword("Eagle's Sword Of Hope", 325, 65, 5, 20),
            new Axe("Bloodthirsty Axe Of Despair", 450, 100, 3, 30),
            new Crossbow("Golden Ballista", 475, 50, 7, 10),
            new Bow("Vorpal Bow Of Sorrows", 350, 40, 10, 15),
            new Orb("Gleaming Sphere Of Nevermore", 450, 35, 7, 25),
            new Staff("Eternal Staff Of Elders", 300, 30, 6, 20),
            new Armour("Leviathan's Shell", 600, 250, 15),
            new Armour("Serpent's Skin", 400, 50, 35),
            new Armour("Arcane Armour of the Underworld", 475, 160, 20),
            new Armour("Demonic Vest", 525, 100, 40),
            new Charm("Moonstone", 75, 35, 5),
            new Charm("Fluke's Stone", 100, 5, 15),
            new Charm("Charm Of Life", 100, 100, 1),
        };

        private ItemShop() { }      

        public static ItemShop GetItems
        {
            get { return items; }
        }

        public void Display()
        {
            string decorationLine = new string('-', 65);

            var output = new StringBuilder(string.Format("ITEM SHOP: \n{0}", decorationLine));
            
            foreach (var item in items)
            {
                output.AppendFormat("{0}\n{1}", item, decorationLine);
            }

            string[] shopInfoByLine = output.ToString().Split(new char[] { '\n', '#' }, StringSplitOptions.RemoveEmptyEntries);

            int left = 80;
            int top = -1;
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var line in shopInfoByLine) 
            {
                Console.SetCursorPosition(left, ++top);
                Console.WriteLine(line);
            }

            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
        }
    }
}
