using System;
class Poker
{
    static void Main()
    {
        int[] poker = new int[13];
        string consoleInput;
        for (int i = 0; i < 5; i++)
        {
            consoleInput = Console.ReadLine();
            if (consoleInput == "J") poker[9]++;
            else if (consoleInput == "Q") poker[10]++;
            else if (consoleInput == "K") poker[11]++;
            else if (consoleInput == "A") poker[12]++;
            else poker[int.Parse(consoleInput) - 2]++;
        }
        bool straight = ((poker[12] == 1) && Array.IndexOf(poker, 0, 0, 4) == -1);
        for (int i = 0; (i < 9) && (straight == false); i++)
        {
            if (Array.IndexOf(poker, 0 , i , 5) == -1) straight = true;
        }
        Array.Sort(poker);
        switch (poker[12])
        {
            case 5: Console.WriteLine("Impossible"); break;
            case 4: Console.WriteLine("Four of a Kind"); break;
            case 3: if (poker[11] == 2) Console.WriteLine("Full House");
                else Console.WriteLine("Three of a Kind"); break;
            case 2: if (poker[11] == 2) Console.WriteLine("Two Pairs");
                else Console.WriteLine("One Pair"); break;
            case 1: if (straight) Console.WriteLine("Straight");
                else Console.WriteLine("Nothing"); break;
        }
    }
}