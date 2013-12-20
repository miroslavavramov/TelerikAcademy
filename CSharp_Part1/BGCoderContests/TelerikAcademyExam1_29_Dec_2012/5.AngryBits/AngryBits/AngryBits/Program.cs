using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int flightLength = 0;
            int destroyedPigs = 0;
            bool pigHit = false;
            bool fallOut = false;
            int score = 0;
            
            int[,] matrix = new int[8, 16];
            for (int i = 0; i < 8; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                string inputString = Convert.ToString(inputNumber, 2).PadLeft(16, '0');

                for (int j = 0; j < 16; j++)
                {
                    if (inputString[j] == '1')
                    {
                        matrix[i, j] = 1;
                    }
                 //   Console.Write(matrix[i,j] + " ");
                }
               // Console.WriteLine();
            }

            //fire some birds
            for (int col = 7; col >= 0; col--)
            {
                for (int row = 0; row < 8; row++)
                {
                    pigHit = false;
                    fallOut = false;
                    destroyedPigs = 0;
                    flightLength = 0;
                    //find a bird
                    if (matrix[row, col] == 1)
                    {
                        while (pigHit == false && fallOut == false)      
                        {
                            if (row == 0)
                            {
                                while (pigHit == false && fallOut == false) // go down
                                {
                                    if (matrix[row + 1, col + 1] != 1)
                                    {
                                        flightLength++;
                                        row++;
                                        col++;
                                        if (col == 15 || row == 7)
                                        {
                                            fallOut = true;
                                            score += flightLength;
                                            break;
                                        }
                                    }
                                    else // pig is hit
                                    {
                                        pigHit = true;
                                        flightLength++;
                                        destroyedPigs++;
                                        row++;
                                        col++;
                                        matrix[row, col] = 0;
                                        if (row == 7)    //check for surrounding bits
                                        {
                                            if (matrix[row, col + 1] == 1)
                                                destroyedPigs++;
                                            matrix[row, col + 1] = 0;
                                            if (matrix[row - 1, col + 1] == 1)
                                                destroyedPigs++;
                                            matrix[row - 1, col + 1] = 0;
                                            if (matrix[row - 1, col] == 1)
                                                destroyedPigs++;
                                            matrix[row - 1, col] = 0;
                                            if (matrix[row - 1, col - 1] == 1)
                                                destroyedPigs++;
                                            matrix[row - 1, col - 1] = 0;
                                            if (matrix[row, col - 1] == 1)
                                                destroyedPigs++;
                                            matrix[row, col - 1] = 0;
                                        }
                                        else if (col == 15)
                                        {
                                            if (matrix[row + 1, col] == 1)
                                                destroyedPigs++;
                                            matrix[row + 1, col] = 0;
                                            if (matrix[row - 1, col] == 1)
                                                destroyedPigs++;
                                            matrix[row - 1, col] = 0;
                                            if (matrix[row + 1, col - 1] == 1)
                                                destroyedPigs++;
                                            matrix[row + 1, col - 1] = 0;
                                            if (matrix[row, col - 1] == 1)
                                                destroyedPigs++;
                                            matrix[row, col - 1] = 0;
                                            if (matrix[row - 1, col - 1] == 1)
                                                destroyedPigs++;
                                            matrix[row - 1, col - 1] = 0;
                                        }
                                        else
                                        {
                                            if (matrix[row, col + 1] == 1)
                                                destroyedPigs++;
                                            matrix[row, col + 1] = 0;
                                            if (matrix[row + 1, col + 1] == 1)
                                                destroyedPigs++;
                                            matrix[row + 1, col + 1] = 0;
                                            if (matrix[row + 1, col] == 1)
                                                destroyedPigs++;
                                            matrix[row + 1, col] = 0;
                                            if (matrix[row + 1, col - 1] == 1)
                                                destroyedPigs++;
                                            matrix[row + 1, col - 1] = 0;
                                            if (matrix[row, col - 1] == 1)
                                                destroyedPigs++;
                                            matrix[row, col - 1] = 0;
                                            if (matrix[row - 1, col] == 1)
                                                destroyedPigs++;
                                            matrix[row - 1, col] = 0;
                                            if (matrix[row - 1, col - 1] == 1)
                                                destroyedPigs++;
                                            matrix[row - 1, col - 1] = 0;
                                            if (matrix[row - 1, col + 1] == 1)
                                                destroyedPigs++;
                                            matrix[row - 1, col + 1] = 0;
                                        }
                                        score += destroyedPigs * flightLength;
                                        destroyedPigs = 0;
                                        flightLength = 0;
                                        break;
                                    }
                                }
                            }
                            //shoot bird upwards
                            if (matrix[row-1, col+1] != 1)  //if next cell is empty
                            {
                                flightLength++;
                                row--;
                                col++;
                            }
                            else if (matrix[row-1, col+1] == 1)     //pig is hit
                            {
                                pigHit = true;
                                destroyedPigs++;
                                flightLength++;
                                row--;
                                col++;
                                matrix[row, col] = 0;
                                if(row == 0)    // check for surrounding pigs
                                {
                                    if(matrix[row, col + 1] == 1)
                                        destroyedPigs++;
                                        matrix[row, col + 1] = 0;
                                    if(matrix[row+1, col+1] == 1)
                                        destroyedPigs++;
                                        matrix[row+1, col+1] = 0;
                                    if(matrix[row+1, col] == 1)
                                        destroyedPigs++;
                                        matrix[row+1, col] = 0;
                                    if(matrix[row+1, col-1] == 1)
                                        destroyedPigs++;
                                        matrix[row+1, col-1] = 0;
                                    if(matrix[row, col-1] == 1)
                                        destroyedPigs++;
                                        matrix[row, col-1] = 0;
                                }
                                else if (col == 15)
	                            {
		                            if(matrix[row+1, col] == 1)
                                        destroyedPigs++;
                                        matrix[row+1, col] = 0;
                                    if(matrix[row-1, col] == 1)
                                        destroyedPigs++;
                                        matrix[row-1, col] = 0;
                                    if(matrix[row+1, col-1] == 1)
                                        destroyedPigs++;
                                        matrix[row+1, col-1] = 0;
                                    if(matrix[row, col-1] == 1)
                                        destroyedPigs++;
                                        matrix[row, col-1] = 0;
                                    if(matrix[row-1, col-1] == 1)
                                        destroyedPigs++;
                                        matrix[row-1, col-1] = 0;
	                            }
                                else
	                            {
                                    if(matrix[row, col + 1] == 1)
                                        destroyedPigs++;
                                        matrix[row, col + 1] = 0;
                                    if(matrix[row+1, col+1] == 1)
                                        destroyedPigs++;
                                        matrix[row+1, col+1] = 0;
                                    if(matrix[row+1, col] == 1)
                                        destroyedPigs++;
                                        matrix[row+1, col] = 0;
                                    if(matrix[row+1, col-1] == 1)
                                        destroyedPigs++;
                                        matrix[row+1, col-1] = 0;
                                    if(matrix[row, col-1] == 1)
                                        destroyedPigs++;
                                        matrix[row, col-1] = 0;
                                    if(matrix[row-1, col] == 1)
                                        destroyedPigs++;
                                        matrix[row-1, col] = 0;
                                    if(matrix[row-1, col-1] == 1)
                                        destroyedPigs++;
                                        matrix[row-1, col-1] = 0;
                                    if(matrix[row-1, col+1] == 1)
                                        destroyedPigs++;
                                        matrix[row-1, col+1] = 0;
	                            }
                                score += destroyedPigs * flightLength;
                                destroyedPigs = 0;
                                flightLength = 0;
                                break;
                            }
                        }
                    }
                    }
                }
            Console.WriteLine(score);
            }
            
        
        }
    }

