using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Warhead
{
    class Warhead
    {
        static void Main(string[] args)
        {
            //set up the board
            char[,] circuitBoard = new char[16, 16];
            int length = 16;

            for (int row = 0; row < length; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < length; col++)
                {
                    circuitBoard[row, col] = input[col];
                }
            }

            //print colored circuitBoard
            //Console.Clear();
            //for (int i = 0; i < length; i++)
            //{
            //    for (int j = 0; j < length; j++)
            //    {
            //        if (j < 8)
            //        {
            //            Console.BackgroundColor = ConsoleColor.Red;
            //            Console.Write(circuitBoard[i, j]);
            //        }
            //        else
            //        {
            //            Console.BackgroundColor = ConsoleColor.Blue;
            //            Console.Write(circuitBoard[i, j]);
            //        }

            //    }
            //    Console.WriteLine();
            //}


            //sum shapes
            int redShapes = 0;
            int blueShapes = 0;
            
            //check red shapes(left) and blue shapes
            for (int row = 1; row < 15; row++)
            {
                for (int col = 1; col < 15; col++)
                {
                    if (circuitBoard[row,col] == '0' && circuitBoard[row, col+1] == '1' && circuitBoard[row+1, col+1] == '1'
                        && circuitBoard[row + 1, col] == '1' && circuitBoard[row+1, col - 1] == '1' && circuitBoard[row, col - 1] == '1'
                        && circuitBoard[row-1, col - 1] == '1' && circuitBoard[row-1, col] == '1' && circuitBoard[row-1, col + 1] == '1')
                    {
                        if (col < 7)
                        {
                            redShapes++;    
                        }
                        else if (col > 7)
                        {
                            blueShapes++;
                        }
                        
                    }
                }   
            }
            ////check blue shapes(right)
            //for (int row = 1; row < 15; row++)
            //{
            //    for (int col = 8; col < 15; col++)
            //    {
            //        if (circuitBoard[row, col] == '0' && circuitBoard[row, col + 1] == '1' && circuitBoard[row + 1, col + 1] == '1'
            //            && circuitBoard[row + 1, col] == '1' && circuitBoard[row + 1, col - 1] == '1' && circuitBoard[row, col - 1] == '1'
            //            && circuitBoard[row - 1, col - 1] == '1' && circuitBoard[row - 1, col] == '1' && circuitBoard[row - 1, col + 1] == '1')
            //        {
            //            blueShapes++;
            //        }
            //    }
            //}

            //read commands

            string command;
            int x, y;
            List<char> outputs = new List<char>();

            while (true)
            {
                command = Console.ReadLine();
                //hover
                if (command == "hover")
                {
                    x = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());
                    if (circuitBoard[x, y] == '1')
                    {
                        //Console.WriteLine("*");
                        outputs.Add('*');
                    }
                    else
                    {
                        outputs.Add('-');
                        //Console.WriteLine("-");
                    }
                }
                //operate
                else if (command == "operate")
                {
                    x = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());
                    if (x == 0 || x == 15 || y == 0 || y == 15)
                    {
                        continue;
                    }
                    else if (circuitBoard[x, y] == '0' && circuitBoard[x, y + 1] == '1' && circuitBoard[x + 1, y + 1] == '1'
                        && circuitBoard[x + 1, y] == '1' && circuitBoard[x + 1, y - 1] == '1' && circuitBoard[x, y - 1] == '1'
                        && circuitBoard[x - 1, y - 1] == '1' && circuitBoard[x - 1, y] == '1' && circuitBoard[x - 1, y + 1] == '1')
                    {
                        circuitBoard[x, y + 1] = '0';
                        circuitBoard[x + 1, y + 1] = '0';
                        circuitBoard[x + 1, y] = '0';
                        circuitBoard[x + 1, y - 1] = '0';
                        circuitBoard[x, y - 1] = '0';
                        circuitBoard[x - 1, y - 1] = '0';  
                        circuitBoard[x - 1, y] = '0';
                        circuitBoard[x - 1, y + 1] = '0';
                        if (y < 7)
                        {
                            redShapes--;
                        }
                        else
                        {
                            blueShapes--;
                        }
                    }
                    else if (circuitBoard[x,y] == '1')
                    {
                        foreach (char output in outputs)
                        {
                            Console.WriteLine(output);
                        }
                        Console.WriteLine("missed");
                        Console.WriteLine(redShapes+blueShapes);
                        Console.WriteLine("BOOM");
                        break;
                    }
                }
                else if (command == "cut")
                {
                    string redOrBlue = Console.ReadLine();
                    if (redOrBlue == "red")
                    {
                        if (redShapes == 0)
                        {
                            foreach (char output in outputs)
                            {
                                Console.WriteLine(output);
                            }
                            Console.WriteLine(blueShapes);
                            Console.WriteLine("disarmed");
                            break;
                        }
                        else
                        {
                            foreach (char output in outputs)
                            {
                                Console.WriteLine(output);
                            }
                            Console.WriteLine(redShapes);
                            Console.WriteLine("BOOM");
                            break;
                        }
                    }
                    else if (redOrBlue == "blue")
                    {
                        if (blueShapes == 0)
                        {
                            foreach (char output in outputs)
                            {
                                Console.WriteLine(output);
                            }
                            Console.WriteLine(redShapes);
                            Console.WriteLine("disarmed");
                            break;
                        }
                        else
                        {
                            foreach (char output in outputs)
                            {
                                Console.WriteLine(output);
                            }
                            Console.WriteLine(blueShapes);
                            Console.WriteLine("BOOM");
                            break;
                        }
                    }
                    
                }
            }

        }
    }
}
