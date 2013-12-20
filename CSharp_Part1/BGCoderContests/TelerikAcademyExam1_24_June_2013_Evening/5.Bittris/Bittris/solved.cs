	

    using System;
     
    class Bittris
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            N >>= 2; //delete N by 4;
     
            int score = 0;
            int[] gameField = new int[4];
     
            for (int i = 0; i < N; i++)
            {
                int currentInput = int.Parse(Console.ReadLine());
                int currentShape = currentInput & 255; // get the shape
     
                // count the number of bits in the input integer
                int numberOfBits = 0;
                while (currentInput != 0)
                {
                    if (currentInput % 2 == 1)
                    {
                        numberOfBits++;
                    }
                    currentInput >>= 1;
                }
     
                // read all commands
                string command = Console.ReadLine() + Console.ReadLine() + Console.ReadLine();
     
                int currentRow = 0;  // current row of the table                
                for (int j = 0; j < 3; j++)
                {
                    if ((command[j] == 'L') && (currentShape & 128) == 0)
                    {
                        currentShape <<= 1; // shift left
                    }
                    else if ((command[j] == 'R') && (currentShape & 1) == 0)
                    {
                        currentShape >>= 1; // shift right
                    }
     
                    if ((currentShape & gameField[currentRow + 1]) == 0) // next row is empty
                    {
                        currentRow++;
                        if (currentRow < 3)
                            continue;
                    }
     
                    // place shape on current row and calculate the score
                    gameField[currentRow] |= currentShape;
                    if (gameField[currentRow] < 255) // current row is not full
                    {
                        score += numberOfBits;
                    }
                    else // current row is full
                    {
                        score += 10 * (numberOfBits);
                        // remove current row and move upper rows down
                        for (int row = currentRow; row > 0; row--)
                        {
                            gameField[row] = gameField[row - 1];
                        }
                        gameField[0] = 0;
                    }
                    break; // ignore rest of the commands
                }            
            }
            Console.WriteLine(score);
        }
    }

