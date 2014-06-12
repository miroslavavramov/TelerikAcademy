namespace School.UI
{
    using System;
    using System.Collections.Generic;
    using School.Common;

    public class SchoolDemo
    {
        private static void Main()
        {
            var students = new List<Student>() 
            { 
                new Student("Ron Paul", 93321),
                new Student("Ayn Rand", 11061),
                new Student("Thomas Sowell", 55503),
                new Student("Adam Smith", 33976),
                new Student("Steven Dubner", 91200)
            };

            var courses = new List<Course>()
            {
                new Course("Mathematics"),
                new Course("Physics"),
                new Course("Chemistry")
            };

            courses[0].AddStudent(students[0]);
            courses[0].AddStudent(students[1]);
            courses[0].AddStudent(students[2]);
            courses[1].AddStudent(students[2]);
            courses[1].AddStudent(students[4]);
            courses[2].AddStudent(students[3]);
            courses[2].AddStudent(students[1]);

            var school = new School("High School of Natural Sciences", courses);

            Console.WriteLine(school.Name);
            foreach (var course in school.Courses)
            {
                Console.WriteLine(course.Name);
                foreach (var student in course.Students)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
