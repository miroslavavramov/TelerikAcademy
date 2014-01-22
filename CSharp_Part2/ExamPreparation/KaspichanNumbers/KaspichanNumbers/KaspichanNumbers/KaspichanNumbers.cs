using System;
using System.Collections.Generic;
class KaspichanNumbers
{
    static List<string> kaspichanNumber = new List<string>();
    static List<ulong> GetRemainders(ulong n)
    {
        List<ulong> rem = new List<ulong>();
        if (n == 0) rem.Add(0);
        for (; n > 0; n /= 256) rem.Add(n % 256);
        return rem;
    }
    static List<string> ToBaseKaspichan(ulong n)
    {
        List<ulong> rem = GetRemainders(n);
        string temp = "";

        for (int i = rem.Count-1; i >= 0; i--)
        {
            temp = "";
            if (rem[i] < 26) 
            { kaspichanNumber.Add((((char)(rem[i] + 'A'))).ToString()); }
            else
            {
                temp = ((char)((rem[i] % 26) + 'A')).ToString();
                rem[i] /= 26;
                temp = (((char)((rem[i] % 26) + 'a'-1))).ToString() + temp;
                kaspichanNumber.Add(temp);
            }
        }
        return kaspichanNumber;
    }
    static void Main()
    {
        kaspichanNumber = ToBaseKaspichan(ulong.Parse(Console.ReadLine()));
        Console.WriteLine(String.Join("",kaspichanNumber));
    }
}

