using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;

class Program
{
    static SortedDictionary<string, SortedList<string, string>> students
        = new SortedDictionary<string, SortedList<string, string>>();

    static void ParseInput(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            var inputLine = "";

            while ((inputLine = reader.ReadLine()) != null)
            {
                var studentInfo = inputLine.Split('|')
                    .Select(x => x.Trim())
                    .ToArray();

                var firstName = studentInfo[0];
                var lastName = studentInfo[1];
                var course = studentInfo[2];

                if (!students.ContainsKey(course))
                {
                    students.Add(course, new SortedList<string, string>());
                }

                students[course].Add(lastName, firstName);
            }
        }
    }

    static void PrintResult()
    {
        foreach (var stud in students)
        {
            Console.Write(stud.Key + ": ");

            foreach (var pair in stud.Value)
            {
                Console.Write(pair.Value + " " + pair.Key + ", ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        ParseInput(@"..\..\input.txt");

        PrintResult();    
    }
}

