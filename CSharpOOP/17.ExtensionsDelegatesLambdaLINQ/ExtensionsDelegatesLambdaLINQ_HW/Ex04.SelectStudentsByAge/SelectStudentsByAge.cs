using System;
using System.Linq;
//Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

class SelectStudentsByAge
{
    static void Main()
    {
        var students = new[] 
        {
            new {FirstName = "Marin", LastName = "Milenov", Age = 24},
            new {FirstName = "Zlatko", LastName = "Zlatev", Age = 17},
            new {FirstName = "Vesi", LastName = "Yaneva", Age = 22},
            new {FirstName = "Georgi", LastName = "Stojanov", Age = 29},
            new {FirstName = "Iva", LastName = "Atanasova", Age = 20},
            new {FirstName = "Lubo", LastName = "Ivanov", Age = 15}
        };

        var selectedStudents =
            from student in students
            where (student.Age >= 18 && student.Age <= 24)
            select student;

        foreach (var student in selectedStudents)
        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Age);
        }
    }
}

