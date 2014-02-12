using Students.Common;
using System;

class StudentsTest
{
    static void Main()
    {
        var firstStudent = new Student(
            "Rosen", "Ivanov", "Stojanov", 21,
            "94112001", "Bulgaria blvd. 19-A-12, Sofia 1000, Bulgaria",
            "0889311100", "rosen@abv.bg", 3,
            Major.Law, Faculty.Philosophy, University.UniversityOfMichigan);

        var secondStudent = new Student(
            "Polina", "Dimitrova", "Mladenova", 20,
            "88113991", "Ivan Vazov str. 5-A-9, Varna 9000, Bulgaria",
            "0899111222", "poly@mail.bg", 2,
            Major.Genetics, Faculty.Biology, University.UniversityOfZurich);

        Console.WriteLine("First student: \r\n" + firstStudent);
        Console.WriteLine("Second student: \r\n" + secondStudent);
        Console.WriteLine("First student comared to second student: " + firstStudent.CompareTo(secondStudent));
        Console.WriteLine("Second student comared to first student: " + secondStudent.CompareTo(firstStudent));

        var clone = (Student)firstStudent.Clone();
        //Console.WriteLine(clone);

        Console.WriteLine("First student compared to a copy of itself: " + firstStudent.Equals(clone));
        Console.WriteLine("Seconds student's hash code: "  + secondStudent.GetHashCode());

        //Task 4
        var agelessPerson = new Person("Ivan", "Ivanov", "Ivanov");
        Console.WriteLine("\r\n" + agelessPerson);
    }
}

