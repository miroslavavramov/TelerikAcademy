using System;
using System.Text;
//Write a program to calculate n! for each n in the range [1..100]. Hint: 
//Implement first a method that multiplies a number represented as array of digits by given integer number. 

class CalcFactorial
{
    static void Main()
    {
        //string str1 = Console.ReadLine();         //Test
        //string str2 = Console.ReadLine();
        //Console.WriteLine(Add(str1,str2));
        //Console.WriteLine(Multiply(str1,str2));

        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine("{0}! = {1}", i, Fact(i));
        }
        
    }
    static string Fact(int n)
    {
        string prod = "1";
        for (int i = n; i >= 1; i--)
        {
            prod = Multiply(prod, i.ToString());
        }
        return prod;
    }
    static string Multiply(string s1, string s2)
    {
        s1 = Reverse(s1);
        s2 = Reverse(s2);

        string product = "";
        StringBuilder tempProduct = new StringBuilder();
        int temp = 1;
        int buffer = 0;
        for (int i = 0; i < s2.Length; i++)
        {
            tempProduct.Clear();
            for (int k = 0; k < s1.Length; k++)
            {
                if (s1[k] >= 48 && s1[k] <= 57 && s2[i] >= 48 && s2[i] <= 57)
                {
                    temp = (int)(char.GetNumericValue(s1[k]) * char.GetNumericValue(s2[i])) + buffer;
                    buffer = 0;
                    if (temp > 9 && k == s1.Length - 1)
                    {
                        tempProduct.Append(temp % 10);
                        tempProduct.Append(temp / 10);
                    }
                    else if (temp > 9)
                    {
                        tempProduct.Append(temp % 10);
                        buffer = temp / 10;
                    }
                    else
                    {
                        tempProduct.Append(temp);
                    }
                }
                else { Console.WriteLine("Invalid Input"); return null; }
            }
            product = Add(product, Reverse(tempProduct.Insert(0, new string('0', i)).ToString()));
        }
        return product;
    }
    static string Add(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            s2 = s2.Insert(0, new string('0', s1.Length - s2.Length));
        else if (s1.Length < s2.Length)
            s1 = s1.Insert(0, new string('0', s2.Length - s1.Length));

        s1 = Reverse(s1);
        s2 = Reverse(s2);

        StringBuilder sum = new StringBuilder();
        int temp = 0;

        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] >= 48 && s1[i] <= 57 && s2[i] >= 48 && s2[i] <= 57)
            {
                temp += (int)(char.GetNumericValue(s1[i]) + char.GetNumericValue(s2[i]));
                if (temp > 9 && i == s1.Length - 1)
                {
                    sum.Append(temp % 10);
                    sum.Append(temp / 10);
                }
                else if (temp > 9)
                {
                    sum.Append(temp - 10);
                    temp = 1;
                }
                else
                {
                    sum.Append(temp);
                    temp = 0;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input!");
                return null;
            }
        }
        return Reverse(sum.ToString());
    }
    static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}

