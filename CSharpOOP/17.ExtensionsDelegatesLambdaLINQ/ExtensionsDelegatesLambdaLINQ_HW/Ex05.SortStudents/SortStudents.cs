using System;
using System.Collections.Generic;
using System.Linq;
//Using the extension methods OrderBy() and ThenBy() with lambda expressions sort 
//the students by first name and last name in descending order. Rewrite the same with LINQ.

class SortStudents
{
    static void Main()
    {
        var students = new[] 
        {
            new {FirstName = "Martin", LastName = "Milenov"},
            new {FirstName = "Zlatko", LastName = "Zlatev"},
            new {FirstName = "Vesi", LastName = "Yaneva"},
            new {FirstName = "Iva", LastName = "Yaneva"},
            new {FirstName = "Georgi", LastName = "Stojanov"},
            new {FirstName = "Iva", LastName = "Atanasova"},
            new {FirstName = "Lubo", LastName = "Ivanov"},
            new {FirstName = "Lubo", LastName = "Zhelev"}
        };

        var sortedUsingLambdaEx = students
            .OrderByDescending(x => x.FirstName)
            .ThenByDescending(x => x.LastName);

        var sortedUsingLINQ =
            from student in students
            orderby student.FirstName descending, student.LastName descending
            select student;

        Console.WriteLine("Sorted using lambda expression: \n");

        foreach (var student in sortedUsingLambdaEx)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }

        Console.WriteLine("\nSorted using LINQ: \n");

        foreach (var student in sortedUsingLINQ)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }
    }
}

