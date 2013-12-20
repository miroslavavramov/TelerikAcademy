using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SomeGame
{
    struct Car 
    {
        public int x;
        public int y;
        public char c;
        
    }
    class Program
    {
        static void PrintOnPosition(int x = 20, int y = 0, char c = '@', ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }
        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth = 30;

            Car userCar = new Car();
            userCar.x = Console.WindowWidth / 2;
            userCar.y = Console.WindowHeight-1;
            userCar.c = 'O';

            List<Car> cars = new List<Car>();
            Random randomGenerator = new Random();
            
            while (true)
            {
                Car randomCar = new Car();
                randomCar.x = randomGenerator.Next(0, Console.WindowWidth-1);
                randomCar.y = 0;
                randomCar.c = '#';
                cars.Add(randomCar);
                
                if (Console.KeyAvailable)
                {
                    
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (userCar.x < Console.WindowWidth-1)
                        {
                            userCar.x += 1;    
                        }
                        else
                        {
                            userCar.x = Console.WindowWidth - 1;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (userCar.x > 1)
                        {
                            userCar.x -= 1;    
                        }
                        else
                        {
                            userCar.x = 0;
                        }    
                    }

                    for (int i = 0; i < cars.Count; i++)
                    {
                        Car car = cars[i];
                        car.y += 1;     
                    }
                }
                Console.Clear();
                PrintOnPosition(userCar.x, userCar.y);
                Thread.Sleep(100);
              
            }
        }
    }
}
