using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static int N;
    static List<string> words;
    static List<string[]> validCrosswords;
    static string[] crossword;
    
    static void Main()
    {
        ReadInput();

        CrosswordGenerator(0);

        if (validCrosswords.Count == 0) 
            { Console.WriteLine("NO SOLUTION!"); }
        else if (validCrosswords.Count == 1)
        {
            foreach (var word in validCrosswords[0])
                Console.WriteLine(word);
        }
        else
        {
            string s = GetLowest(validCrosswords);

            for (int i = 0; i < s.Length; i++)
            {
                if (i > 0 && (i % N) == 0) { Console.WriteLine(); }
                Console.Write(s[i]);
            }
        }
    }
    static void ReadInput()
    {
        N = int.Parse(Console.ReadLine());

        crossword = new string[N];
        validCrosswords = new List<string[]>();

        words = new List<string>();
        for (int i = 0; i < 2 * N; i++) words.Add(Console.ReadLine());
    }
    static void CrosswordGenerator(int index)
    {
        if (index == crossword.Length)
        {
            if(Validate(crossword))
            {   
                validCrosswords.Add((string[])crossword.Clone());
            }
        }
        else
        {
            for (int i = 0; i < words.Count; i++)
            {
                crossword[index] = words[i];
                CrosswordGenerator(index + 1);
            }
        }
    }
    static bool Validate(string[] crossword)
    {
        var temp = new StringBuilder();

        for (int i = 0; i < N; i++)
        {
            for (int k = 0; k < N; k++)
            {
                temp.Append(crossword[k][i]);
            }
            if (!words.Contains(temp.ToString())) { return false; }
            temp.Clear();
        }
        return true;
    }
    static string GetLowest(List<string[]> l)
    {
        var temp = new StringBuilder();

        List<string> list = new List<string>();

        for (int i = 0; i < l.Count; i++)
		{
            for (int k = 0; k < l[i].Length; k++)
            {
                temp.Append(l[i][k]);
            }
            list.Add(temp.ToString());
            temp.Clear();
		}
        list.Sort();
        return list[0];
    }   
}