namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StudentTest
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Kaloyan", "Petrov", "551206", "02777111", "kaloyan@abv.bg", 1, "Mathematics", 6, 3, 5),
                new Student("Jeni", "Stoyanova", "123405", "12094123","jeni@gmail.com", 2, "Medical", 2, 3, 4, 2, 4),
                new Student("Reni", "Todorova", "774306", "12455521", "reni@yahoo.com", 3, "Social", 5, 4, 5, 2),
                new Student("Georgi", "Marinov", "999403", "02112233", "joro@mail.bg", 2, "Mathematics", 5, 2, 2),
                new Student("Martin", "Andonov", "123409", "22555432", "martin@hotmail.com", 2, "Judicial", 6, 6),
                new Student("Simeon", "Kolev", "555505", "19012453", "simeon@hotmail.com", 3, "Social", 5, 4, 4, 5),
                new Student("Kalina", "Ivanova", "999907", "03524943", "kalina@abv.bg", 1, "Medical", 3, 3, 4),
                new Student("Boris", "Atanasov", "123506", "02999999", "boris@aol.co.uk", 1, "Mathematics", 5, 6, 6),
                new Student("Gergana", "Todorova", "663308", "84721200", "geri@gmail.com", 3, "Judicial", 4, 2, 4)
            };

            #region Task9
            var secondGroup =
                from student in students
                where student.Group.GroupNumber == 2
                select student;

            Console.WriteLine("|Task 9|\nStudents from group 2 (extracted with LINQ): \n");
            Print(secondGroup);
            #endregion

            #region Task10
            secondGroup = students
                .FindAll(s => s.Group.GroupNumber == 2);

            Console.WriteLine("\n|Task 10|\nStudents from group 2 (extracted with extension method): \n");
            Print(secondGroup);
            #endregion

            #region Task11
            var stAtAbv =
                from student in students
                where student.EMailAddress.Contains("abv.bg")
                select student;

            Console.WriteLine("\n|Task 11|\nStudents whose email provider is abv.bg : \n");
            Print(stAtAbv);
            #endregion

            #region Task12
            var stFromSofia =
                from student in students
                where student.PhoneNumber.StartsWith("02")
                select student;

            Console.WriteLine("\n|Task 12|\nStudents from Sofia: \n");
            Print(stFromSofia);
            #endregion

            #region Task13
            var stWithExcellentMark =
                from student in students
                where student.Marks.Contains(6)
                select new
                {
                    FullName = student.FirstName + " " + student.LastName,
                    Marks = student.Marks
                };

            Console.WriteLine("\n|Task 13|\nStudents that have at least one excellent mark (stored as anonymous types) : \n");

            foreach (var student in stWithExcellentMark)
                Console.WriteLine("{0}, Marks : {1}", student.FullName, string.Join(", ", student.Marks));

            #endregion

            #region Task14
            var stWithTwoTwoMarks = students
                .Where(s => s.Marks.Count(m => m == 2) == 2);

            Console.WriteLine("\n|Task 14|\nStudents with exactly two \"2\" marks : \n");
            Print(stWithTwoTwoMarks);
            #endregion

            #region Task15

            var stEnrolledIn06 =
                from student in students
                where student.FacultyNumber[4] == '0' && student.FacultyNumber[5] == '6'
                select new
                {
                    FullName = student.FirstName + " " + student.LastName,
                    Marks = student.Marks
                };

            Console.WriteLine("\n|Task 15|\nMarks of students enrolled in 2006 : (stored as anonymous types)\n");

            foreach (var student in stEnrolledIn06)
                Console.WriteLine("{0}, Marks : {1}", student.FullName, string.Join(", ", student.Marks));

            #endregion

            #region Task16

            Group[] mathDept = { new Group(1, "Mathematics") };

            var stFromMathDept =
                from student in students
                join groups in mathDept
                on student.Group.DepartmentName equals groups.DepartmentName
                select new
                {
                    FullName = student.FirstName + " " + student.LastName,
                };

            Console.WriteLine("\n|Task 16|\nStudents from the Department of Mathematics : (stored as anonymous types)\n");

            foreach (var student in stFromMathDept)
                Console.WriteLine("{0} {1}", student.FullName);

            #endregion

            #region Task18

            var sortedByDeptName =
                from student in students
                group student by student.Group.DepartmentName
                    into newGroup
                    orderby newGroup.Key
                    select newGroup;

            Console.WriteLine("\n|Task 18|\nStudents ordered by department name (with LINQ) :\n");

            foreach (var department in sortedByDeptName)
            {
                Console.WriteLine("#" + department.Key);

                foreach (var student in department)
                    Console.WriteLine(student.FirstName + " " + student.LastName);
            }
            
            #endregion

            #region Task 19

            sortedByDeptName = students
                .GroupBy(s => s.Group.DepartmentName)
                .OrderBy(s => s.Key);

            Console.WriteLine("\n|Task 19|\nStudents ordered by department name (with Lambda expression) :\n");

            foreach (var department in sortedByDeptName)
            {
                Console.WriteLine("#" + department.Key);

                foreach (var student in department)
                    Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            #endregion
        }
        static void Print<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
