using System;

// 11.Write a program that prints all possible cards from a standard deck of 52 cards (without jokers).
// The cards should be printed with their English names. Use nested for loops and switch-case.

    class Program
    {
        static void Main()
        {
            string color = "";
            string card = "";

            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        color = "of Clubs";
                        Console.WriteLine("\n++ CLUBS ++\n");
                        break;
                    case 2:
                        color = "of Diamonds";
                        Console.WriteLine("\n++ DIAMONDS ++\n");
                        break;
                    case 3:
                        color = "of Hearts";
                        Console.WriteLine("\n++ HEARTS ++\n");
                        break;
                    case 4:
                        color = "of Spades";
                        Console.WriteLine("\n++ SPADES ++\n");
                        break;
                }
                for (int k = 1; k <= 13; k++)
                {
                    switch (k)
                    {
                        case 1:
                            card = "Ace";
                            Console.WriteLine(card + " " + color);
                            break;
                        case 2:
                            card = "Two";
                            Console.WriteLine(card + " " + color);
                            break;
                        case 3:
                            card = "Three";
                            Console.WriteLine(card + " " + color);
                            break;
                        case 4:
                            card = "Four";
                            Console.WriteLine(card + " " + color);
                            break;
                        case 5:
                            card = "Five";
                            Console.WriteLine(card + " " + color);
                            break;
                        case 6:
                            card = "Six";
                            Console.WriteLine(card + " " + color);
                            break;
                        case 7:
                            card = "Seven";
                            Console.WriteLine(card + " " + color);
                            break;
                        case 8:
                            card = "Eight";
                            Console.WriteLine(card + " " + color);
                            break;
                        case 9:
                            card = "Nine";
                            Console.WriteLine(card + " " + color);
                            break;
                        case 10:
                            card = "Ten";
                            Console.WriteLine(card + " " + color);
                            break;
                        case 11:
                            card = "Jack";
                            Console.WriteLine(card + " " + color);
                            break;
                        case 12:
                            card = "Queen";
                            Console.WriteLine(card + " " + color);
                            break;
                        case 13:
                            card = "Knight";
                            Console.WriteLine(card + " " + color);
                            break;
                    }

                }
            }
        }
    }

