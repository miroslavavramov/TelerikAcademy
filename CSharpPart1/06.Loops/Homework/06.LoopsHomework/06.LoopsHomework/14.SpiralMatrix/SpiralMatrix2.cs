	

    using System;
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a positive, integer number: ");
            int number = int.Parse(Console.ReadLine());
            int[,] arr = new int[number, number];
            int x = 0; int y=0;
            arr[x, y] = 1;
            for (int i = 2; i <= number*number; i++)
            {
                if ((y + 1 < number) && (arr[x, y + 1] == 0)&&(x==0||arr[x-1,y]!=0)) y += 1;
                else if ((x + 1 < number) && (arr[x + 1, y]) == 0) x += 1;
                else if ((y - 1 >= 0) && (arr[x, y - 1] == 0)) y -= 1;
                else if ((x - 1 >= 0) && (arr[x - 1, y]) == 0) x -= 1;
                arr[x,y] = i;
            }
            for (int i = 0; i < number; i++)
            {
                for (int g = 0; g < number; g++)
                {
                    Console.Write("{0,3} ",arr[i,g]);
                }
                Console.WriteLine();
            }
        }
    }

