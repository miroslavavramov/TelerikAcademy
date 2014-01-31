using System;
using System.Linq;
//Write a method that from a given array of students finds all students whose 
//first name is before its last name alphabetically. Use LINQ query operators.
class SelectStudentsByName
{
    static void Main()
    {
        var students = new[] 
        {
            new {FirstName = "Martin", LastName = "Milenov"},
            new {FirstName = "Zlatko", LastName = "Zlatev"},
            new {FirstName = "Vesi", LastName = "Yaneva"},
            new {FirstName = "Georgi", LastName = "Stojanov"},
            new {FirstName = "Iva", LastName = "Atanasova"},
            new {FirstName = "Lubo", LastName = "Ivanov"}
        };

        var sortedStudents =
            from student in students
            where student.FirstName.CompareTo(student.LastName) < 0
            select student;

        foreach (var student in sortedStudents)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }
    }
}

