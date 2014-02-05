using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretNumber = Console.ReadLine();
            
            int bulls = int.Parse(Console.ReadLine());
            int cows = int.Parse(Console.ReadLine());

            int bullsCounter = 0;
            int cowsCounter = 0;
            bool hasZero = false;
            bool noOutputs = true;

            char[] secretNumberDigits = secretNumber.ToCharArray();

            
            
            for (int number = 1111; number <= 9999; number++)
            {
                hasZero = false;
                secretNumberDigits = secretNumber.ToCharArray();
                char[] tempArr = number.ToString().ToCharArray();
                for (int i = 0; i < tempArr.Length; i++)
                {
                    if (tempArr[i] == '0')
                    {
                        hasZero = true;
                    }
                }
                if (hasZero == true)
                {
                    continue;
                }

                for (int j = 0; j < secretNumberDigits.Length; j++) //check for bulls
                {
                    for (int k = 0; k < tempArr.Length; k++) 
                    {
                        if (secretNumberDigits[j] == tempArr[k] && j == k)
                        {
                            bullsCounter++;
                            secretNumberDigits[j] = '0';
                            tempArr[k] = '0';
                        }
                    }
                }
                for (int j = 0; j < secretNumberDigits.Length; j++) // check for cows
                {
                     for (int k = 0; k < tempArr.Length; k++)    
                    {
                        if (secretNumberDigits[j] == tempArr[k] && j != k && tempArr[k] != '0' && secretNumberDigits[j] != '0')
                        {
                            cowsCounter++;
                            secretNumberDigits[j] = '0';
                            tempArr[k] = '0';
                        }
                    }
                }
                if (cowsCounter == cows && bullsCounter == bulls)
                {
                    noOutputs = false;
                    Console.Write(number + " ");
                }
                bullsCounter = 0;
                cowsCounter = 0;
            }
            if (noOutputs == true)
            {
                Console.WriteLine("No");
            }
        }
    }
}
