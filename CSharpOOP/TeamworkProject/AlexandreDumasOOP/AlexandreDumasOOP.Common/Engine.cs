namespace AlexandreDumasOOP.Common
{
    using AlexandreDumasOOP.Common.Characters;
    using AlexandreDumasOOP.Common.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class Engine
    {
        private delegate void RevitalizeHeroesDelegate(params Hero[] heroes);
        private event RevitalizeHeroesDelegate OnBattleHasEnded;

        private Location battleLocation;
        private List<Hero> heroes;

        public Engine()
        {
            this.battleLocation = new Location("Battle Location");
            this.heroes = new List<Hero>();
        }

        private void AddHero(Hero hero)
        {
            if (!heroes.Exists(x => x.Name.ToLower() == hero.Name.ToLower()))
            {
                this.heroes.Add(hero);
                Hero.ColorizeHero(hero);
                Console.WriteLine("Created.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is already a hero with the same name!");
                Console.ResetColor();
            }
        }

        public void ProcessCommand(string command)
        {
            if (!string.IsNullOrWhiteSpace(command))
            {
                string[] commandWords = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (commandWords[0].ToLower())
                {
                    case "create":
                        ProcessCreateCommand(commandWords);
                        break;
                    case "set":
                        ProcessSetCommand(commandWords);
                        break;
                    case "equip":
                    case "dequip":
                        ProcessEquipDequipCommands(commandWords);
                        break;
                    case "battle":
                        ProcessBattleCommand(commandWords);
                        break;
                    case "show":
                        ProcessShowCommand(commandWords);
                        break;
                    case "revitalize":
                        ProcessRevitalizeCommand(commandWords);
                        break;
                    case "clear":
                        ProcessClearCommand();
                        break;
                    case "help":
                        ProcessHelpCommand();
                        break;
                    case "end":
                        ProcessEndCommand();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Command!");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Command!");
            }
            Console.ResetColor();
        }

        private void ProcessCreateCommand(string[] commandWords)
        {
            if (commandWords.Length == 3)
            {
                string heroName = commandWords[2];

                switch (commandWords[1].ToLower())
                {
                    case "human":
                        this.AddHero(new Human(heroName));
                        break;
                    case "orc":
                        this.AddHero(new Orc(heroName));
                        break;
                    case "elf":
                        this.AddHero(new Elf(heroName));
                        break;
                    case "undead":
                        this.AddHero(new Undead(heroName));
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Race Type!");
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Create Command!");
                Console.ResetColor();
            }
        }

        private void ProcessSetCommand(string[] commandWords)
        {
            if (commandWords.Length == 3)
            {
                if (commandWords[1] == "location")
                {
                    string locationType = commandWords[2].ToLower();

                    switch (locationType)
                    {
                        case "neutral":
                            battleLocation.Type = LocationType.Neutral;
                            Console.WriteLine("Battle Location Set: Neutral");
                            break;
                        case "town":
                            battleLocation.Type = LocationType.Town;
                            Console.WriteLine("Battle Location Set: Town");
                            break;
                        case "graveyard":
                            battleLocation.Type = LocationType.Graveyard;
                            Console.WriteLine("Battle Location Set: Graveyard");
                            break;
                        case "desert":
                            battleLocation.Type = LocationType.Desert;
                            Console.WriteLine("Battle Location Set: Desert");
                            break;
                        case "forest":
                            battleLocation.Type = LocationType.Forest;
                            Console.WriteLine("Battle Location Set: Forest");
                            break;
                        default: Console.WriteLine("Invalid Location Type!");
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Set Command contains invalid arguments!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Set Command!");
                Console.ResetColor();
            }
        }

        private void ProcessEquipDequipCommands(string[] commandWords)
        {
            if (commandWords.Length == 3)
            {
                string heroName = commandWords[1];
                string itemId = commandWords[2];
                bool heroFound = this.heroes.Exists(x => x.Name.ToLower() == heroName.ToLower());

                if (heroFound)
                {
                    if (commandWords[0].ToLower() == "equip")
                    {
                        this.heroes.Find(x => x.Name.ToLower() == heroName.ToLower()).Equip(itemId);
                    }
                    else if (commandWords[0].ToLower() == "dequip")
                    {
                        this.heroes.Find(x => x.Name.ToLower() == heroName.ToLower()).Dequip(itemId);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hero named {0} doesn't exist!", heroName);
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Equip/Dequip Command!");
                Console.ResetColor();
            }
        }

        private void ProcessBattleCommand(string[] commandWords)
        {
            if (commandWords.Length == 3)
            {
                string firstHeroName = commandWords[1];
                string secondHeroName = commandWords[2];

                var firstHero = this.heroes.Find(x => x.Name.ToLower() == firstHeroName.ToLower());
                var secondHero = this.heroes.Find(x => x.Name.ToLower() == secondHeroName.ToLower());

                if (firstHero != null && secondHero != null)
                {
                    CheckForLocationBonus(firstHero);
                    CheckForLocationBonus(secondHero);

                    while (true)
                    {
                        firstHero.Attack(secondHero);
                        Thread.Sleep(2000);

                        if (secondHero.HealthPoints == 0)
                        {
                            this.OnBattleHasEnded += this.RevitalizeHeroes;
                            break;
                        }

                        secondHero.Attack(firstHero);
                        Thread.Sleep(2000);

                        if (firstHero.HealthPoints == 0)
                        {
                            this.OnBattleHasEnded += this.RevitalizeHeroes;
                            break;
                        }

                    }

                    if (this.OnBattleHasEnded != null)
                    {
                        this.OnBattleHasEnded(firstHero, secondHero);
                        this.OnBattleHasEnded -= this.RevitalizeHeroes;
                    }

                    this.heroes.Find(x => x.Name.ToLower() == firstHeroName.ToLower()).HealthPoints = firstHero.HealthPoints;
                    this.heroes.Find(x => x.Name.ToLower() == secondHeroName.ToLower()).HealthPoints = secondHero.HealthPoints;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (firstHero == null) Console.Write("Hero named {0} not found! ", firstHeroName);
                    if (secondHero == null) Console.Write("Hero named {0} not found! ", secondHeroName);
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Battle Command!");
                Console.ResetColor();
            }
        }

        private void ProcessShowCommand(string[] commandWords)
        {
            if (commandWords.Length == 2 || commandWords.Length == 3)
            {
                string heroName = commandWords[1];
                var hero = this.heroes.Find(x => x.Name.ToLower() == heroName.ToLower());

                if (hero != null)
                {
                    if (commandWords.Length == 2)
                    {
                        Hero.ColorizeHero(hero);
                        Console.WriteLine(hero);
                    }
                    else if (commandWords.Length == 3 && commandWords[2].ToLower() == "inventory")
                    {
                        hero.DisplayInventory();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Show Command contains invalid arguments!");
                        Console.ResetColor();
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hero named {0} doesn't exist!", commandWords[1]);
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Show Command!");
                Console.ResetColor();
            }
        }

        private void ProcessRevitalizeCommand(string[] commandWords)
        {
            if (commandWords.Length == 2)
            {
                string heroName = commandWords[1];

                var hero = this.heroes.Find(x => x.Name.ToLower() == heroName.ToLower());

                if (hero != null)
                {
                    this.heroes.Find(x => x.Name.ToLower() == heroName.ToLower()).Revitalize();
                    Hero.ColorizeHero(hero);
                    Console.WriteLine("Revitalized!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hero named {0} doesn't exist!", heroName);
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Revitalize Command!");
                Console.ResetColor();
            }
        }

        private void ProcessClearCommand()
        {
            Console.Clear();
            ItemShop.GetItems.Display();
        }

        private void ProcessHelpCommand()
        {
            ProcessClearCommand();

            string decorationLine = new string('-', 65);
            var helpMessage = new StringBuilder();

            helpMessage.AppendFormat("GAME COMMANDS: \n{0}\n", decorationLine);
            helpMessage.AppendLine("create [human/orc/elf/undead] [hero name]");
            helpMessage.AppendLine("set [location] [neutral/town/graveyard/desert/forest]");
            helpMessage.AppendLine("equip/dequip [hero name] [item id]");
            helpMessage.AppendLine("battle [hero name] [hero name]");
            helpMessage.AppendLine("show [hero name] (+ [inventory])");
            helpMessage.AppendLine("revitalize [hero name]");
            helpMessage.AppendLine("clear");
            helpMessage.AppendLine("help");

            Console.WriteLine(helpMessage);
            Console.ReadKey();
            ProcessClearCommand();
        }

        private void ProcessEndCommand()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(60, 20);
            Console.WriteLine("Developed By Team Alexandre Dumas");
            Console.SetCursorPosition(60, 22);
            Console.WriteLine("Telerik Academy 2013/2014");
            Thread.Sleep(5000);
            Environment.Exit(0);
        }

        private void CheckForLocationBonus(Hero hero)
        {
            if (hero.NativeLocation == battleLocation.Type)
            {
                if (hero is Elf || hero is Undead)
                {

                    Console.WriteLine("{0} gained location bonus +10 AP!", hero.Name);
                    hero.Agility += 10;
                }
                else if (hero is Human || hero is Orc)
                {
                    Console.WriteLine("{0} gained location bonus +100 HP!", hero.Name);
                    hero.HealthPoints += 100;
                }
            }
        }

        private void RevitalizeHeroes(params Hero[] heroes)
        {
            Console.WriteLine("Revitalize Heroes? (Yes/No - Any Key/ESC)");
            ConsoleKeyInfo pressedKey = Console.ReadKey();

            if (pressedKey.Key != ConsoleKey.Escape)
            {
                foreach (var hero in heroes)
                {
                    hero.Revitalize();
                    Hero.ColorizeHero(hero);
                    Console.WriteLine("Revitalized!");
                }
            }
        }
    }
}
