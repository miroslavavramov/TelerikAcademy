using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyGame
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = 20;
            Console.BufferWidth = Console.WindowWidth = 50;
            
            int speed = 700;

            int i = 0;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    if (pressedKey.Key == ConsoleKey.UpArrow)
                    {
                        if (speed > 1)
                        {
                            speed -= 50;    
                        }
                        else
                        {
                            speed = 1;
                        }
                        
                    }
                    else if (pressedKey.Key == ConsoleKey.DownArrow)
                    {
                        speed += 50;
                    }
                }
                if (i == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("       |  "  +   "            ".PadLeft(27, ' '));
                    Console.WriteLine("    __ |__"  +   "     __     ".PadLeft(29, ' '));
                    Console.WriteLine("   |  |   "  +   "|   |  | |  ".PadLeft(29, ' '));
                    Console.WriteLine("|  |__|   "  +   "|__ |__| |__".PadLeft(29, ' '));
                    Console.WriteLine("|__       "  +   "            ".PadLeft(27, ' '));

                }
                else if (i == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("            "    + "|           ".PadLeft(27, ' '));
                    Console.WriteLine("     __     "    + "|__  __     ".PadLeft(27, ' '));
                    Console.WriteLine("|   |  | |  "    + "    |  |    ".PadLeft(27, ' '));
                    Console.WriteLine("|__ |__| |__"    + "    |__||   ".PadLeft(27, ' '));
                    Console.WriteLine("            "    + "        |__ ".PadLeft(27, ' '));
                }

                else if (i == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("|           "    +   "       |   ".PadLeft(27, ' '));
                    Console.WriteLine("|__  __     "    +   "    __ |__ ".PadLeft(27, ' '));
                    Console.WriteLine("    |  |    "    +   "   |  |    ".PadLeft(27, ' '));
                    Console.WriteLine("    |__||   "    +   "|  |__|    ".PadLeft(27, ' '));
                    Console.WriteLine("        |__ "    +   "|__        ".PadLeft(27, ' '));
                }

                Console.WriteLine("\\\\____                ____|_|________".PadLeft(42, ' '));
                Console.WriteLine(" ===  \\             /  /   |      \\ \\  ".PadLeft(45, ' '));
                Console.WriteLine("    \\  \\___________/  /___ |_______\\ \\_".PadLeft(45, ' '));
                Console.WriteLine("       \\+++++++++++++        | -         |".PadLeft(46, ' '));
                Console.WriteLine("      \\=============\\      |           |".PadLeft(46, ' '));
                Console.WriteLine("           /          \\____|__________/".PadLeft(45, ' '));
                Console.WriteLine("          **                       **".PadLeft(43, ' '));
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Use arrows to regulate the speed.");
                i++;
                Thread.Sleep(speed);
                Console.Clear();
                if (i == 3)
                {
                    i = 0;
                }


            }





        }
    }
}
