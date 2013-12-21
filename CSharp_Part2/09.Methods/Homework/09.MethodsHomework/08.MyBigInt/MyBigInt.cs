using System;
using System.Text;

//Write a method that adds two positive integer numbers represented as arrays of digits
//(each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
//Each of the numbers that will be added could have up to 10 000 digits.

class MyBigInt
{
    static void Main()
    {
        DateTime start = DateTime.Now;

        //string str1 = new string('9', (int)1E+4);         //Performance Test
        //string str2 = new string('9', (int)1E+4);

        string str1 = Console.ReadLine();
        string str2 = Console.ReadLine();

        if (str1.Length > str2.Length)
            str2 = new string('0', str1.Length - str2.Length) + str2;
        else
            str1 = new string('0', str2.Length - str1.Length) + str1;

        StringBuilder sb1 = new StringBuilder(); sb1.Append(Reverse(str1));
        StringBuilder sb2 = new StringBuilder(); sb2.Append(Reverse(str2));
        Console.WriteLine(Reverse(Add(sb1, sb2).ToString()));
        DateTime end = DateTime.Now;
        Console.WriteLine("Execution Time: " + (end - start));
    }
    static StringBuilder Add(StringBuilder s1, StringBuilder s2)
    {
        StringBuilder result = new StringBuilder();
        int temp = 0 ;

        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] >= 48 && s1[i] <= 57 && s2[i] >= 48 && s2[i] <= 57)   
            {
                temp += (int)(char.GetNumericValue(s1[i]) + char.GetNumericValue(s2[i]));
                if (temp > 9 && i == s1.Length - 1)
                {
                    result.Append( temp % 10);
                    result.Append( temp / 10);
                }
                else if (temp > 9)
                {
                    result.Append(temp - 10);
                    temp = 1;
                }
                else
                {
                    result.Append(temp);
                    temp = 0;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input!");
                return result.Clear();
            }   
        }
        return result;
    }
    static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();        
        Array.Reverse(arr);
        return new string (arr);
    }
   
}
