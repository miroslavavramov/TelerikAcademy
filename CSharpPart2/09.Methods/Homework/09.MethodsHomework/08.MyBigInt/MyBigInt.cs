using System;
using System.Text;

//Write a method that adds two positive integer numbers represented as arrays of digits
//(each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
//Each of the numbers that will be added could have up to 10 000 digits.

class MyBigInt
{
    static void Main()
    {
        //DateTime start = DateTime.Now;

        //string str1 = new string('9', (int)1E+6);         //Performance Test
        //string str2 = new string('9', (int)1E+6);

        string str1 = Console.ReadLine();
        string str2 = Console.ReadLine();

        Console.WriteLine(Add(str1, str2));

        //DateTime end = DateTime.Now;
        //Console.WriteLine("Execution Time: " + (end - start));
    }

    static string Add(string s1, string s2)
    {
        if (s1.Length > s2.Length)
        {
            s2 = s2.Insert(0, new string('0', s1.Length - s2.Length));
        }
        else if (s1.Length < s2.Length)
        { 
            s1 = s1.Insert(0, new string('0', s2.Length - s1.Length)); 
        }

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
                Console.WriteLine("Invalid Input!"); return null; 
            }
        }
        return Reverse(sum.ToString());
    }

    static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();        
        Array.Reverse(arr);
        return new string (arr);
    }
}
