namespace AlexandreDumasOOP.UI
{
    using AlexandreDumasOOP.Common;
    using AlexandreDumasOOP.Common.Items;
    using System;
    using System.IO;
    
    
    class GameUI
    {
        static void SetWindowDimensions()
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 150;
        }

        static void PrintIntroLogo()
        {
            string line = string.Empty;

            Console.CursorTop = 15;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            using (StreamReader reader = new StreamReader(@"..\..\..\AlexandreDumasOOP.Common\IntroLogo.txt"))
            {
                line = reader.ReadToEnd();
            }

            Console.WriteLine(line);

            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = true;
        }

        static void Main()
        {
            SetWindowDimensions();
            PrintIntroLogo();
            ItemShop.GetItems.Display();
            
            Engine engine = new Engine();

            string command = Console.ReadLine();

            while (true)
            {
                engine.ProcessCommand(command);
                command = Console.ReadLine();
            }
        }
        
    }
}

