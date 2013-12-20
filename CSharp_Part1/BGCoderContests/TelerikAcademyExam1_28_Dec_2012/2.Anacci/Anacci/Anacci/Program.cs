using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anacci
{
    class Program
    {
        static int GetLetterValue(string s)
        {
            int value = 0;
            switch (s)
            {
                case "A": value = 1;
                    break;
                case "B": value = 2;
                    break;
                case "C": value = 3;
                    break;
                case "D": value = 4;
                    break;
                case "E": value = 5;
                    break;
                case "F": value = 6;
                    break;
                case "G": value = 7;
                    break;
                case "H": value = 8;
                    break;
                case "I": value = 9;
                    break;
                case "J": value = 10;
                    break;
                case "K": value = 11;
                    break;
                case "L": value = 12;
                    break;
                case "M": value = 13;
                    break;
                case "N": value = 14;
                    break;
                case "O": value = 15;
                    break;
                case "P": value = 16;
                    break;
                case "Q": value = 17;
                    break;
                case "R": value = 18;
                    break;
                case "S": value = 19;
                    break;
                case "T": value = 20;
                    break;
                case "U": value = 21;
                    break;
                case "V": value = 22;
                    break;
                case "W": value = 23;
                    break;
                case "X": value = 24;
                    break;
                case "Y": value = 25;
                    break;
                case "Z": value = 26;
                    break;
            }
            return value;
        }
        static string PrintLetter(int n)
        {
            if (n > 26)
            {
                n %= 26;
            }
            string letter = "";
            switch (n)
            {
                case 1: letter = "A";
                    break;
                case 2: letter = "B";
                    break;
                case 3: letter = "C";
                    break;
                case 4: letter = "D";
                    break;
                case 5: letter = "E";
                    break;
                case 6: letter = "F";
                    break;
                case 7: letter = "G";
                    break;
                case 8: letter = "H";
                    break;
                case 9: letter = "I";
                    break;
                case 10: letter = "J";
                    break;
                case 11: letter = "K";
                    break;
                case 12: letter = "L";
                    break;
                case 13: letter = "M";
                    break;
                case 14: letter = "N";
                    break;
                case 15: letter = "O";
                    break;
                case 16: letter = "P";
                    break;
                case 17: letter = "Q";
                    break;
                case 18: letter = "R";
                    break;
                case 19: letter = "S";
                    break;
                case 20: letter = "T";
                    break;
                case 21: letter = "U";
                    break;
                case 22: letter = "V";
                    break;
                case 23: letter = "W";
                    break;
                case 24: letter = "X";
                    break;
                case 25: letter = "Y";
                    break;
                case 26: letter = "Z";
                    break;
            }
            return letter;
        }
        static void Main(string[] args)
        {
            string previousMember = Console.ReadLine();
            string currentMember = Console.ReadLine();
            string nextMember = PrintLetter(GetLetterValue(previousMember) + GetLetterValue(currentMember));
            int lines = int.Parse(Console.ReadLine());
            int spacesCount = 0;

            if (lines > 0)
            {
                Console.WriteLine(previousMember);
                for (int i = 1; i < lines; i++)
                {
                    Console.Write(currentMember + new string(' ', spacesCount) + nextMember);

                    spacesCount++;
                    previousMember = nextMember;
                    currentMember = PrintLetter(GetLetterValue(currentMember) + GetLetterValue(nextMember));
                    nextMember = PrintLetter(GetLetterValue(currentMember) + GetLetterValue(nextMember));
                    Console.WriteLine();
                }    
            }
            
        }
    }
}
