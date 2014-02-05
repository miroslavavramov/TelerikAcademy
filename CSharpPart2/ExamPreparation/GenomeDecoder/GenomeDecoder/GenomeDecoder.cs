using System;
using System.Text;
using System.Collections.Generic;

class GenomeDecoder
{
    static int nl, sp;
    static string enc;
    static StringBuilder dec, output;
    static void Main()
    {
        ReadAndDecode();
        Print();
    }
    static void Print()
    {
        output = new StringBuilder();
        int lines = dec.Length / nl; lines += dec.Length % nl == 0 ? 0 : 1;
        int pad = lines.ToString().Length;
        int line = 0;

        for (int i = 0; i < dec.Length; i += nl)
        {
            line++;
            output.Append(line.ToString().PadLeft(pad) + " ");

            for (int k = 0; k < nl && i + k < dec.Length; k++)
            {
                output.Append(dec[i + k]);
                if ((k + 1) % sp == 0 && (k != nl - 1)) output.Append(" ");
            }
            Console.WriteLine(output.ToString());
            output.Clear();
        }
    }
    static void ReadAndDecode()
    {
        string[] input = Console.ReadLine().Split(' ');
        nl = int.Parse(input[0]);
        sp = int.Parse(input[1]);
        enc = Console.ReadLine();

        dec = new StringBuilder();
        string temp = String.Empty;

        for (int i = 0; i < enc.Length; i++)
        {
            if (IsDigit(enc[i]))
            {
                temp += enc[i];
            }
            else if (!IsDigit(enc[i]) && temp.Length != 0)
            {
                dec.Append(new string(enc[i], int.Parse(temp)));
                temp = "";
            }
            else
            {
                dec.Append(enc[i]);
            }
        }
    }
    static bool IsDigit(char c)
    {
        return (c >= '0') && (c <= '9');
    }
}