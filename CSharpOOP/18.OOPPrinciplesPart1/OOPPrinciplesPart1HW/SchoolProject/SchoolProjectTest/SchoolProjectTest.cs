using SchoolProject.Common;
using System;
using System.Collections.Generic;

class SchoolProjectTest
{
    static void Main()
    {
        School mySchool = new School("Gymnasium of Mathematics and Natural Sciences");

        ClassOfStudents class10A = new ClassOfStudents("10 A");

        Discipline mathematics = new Discipline("Mathematics", 75, 50, "emphasis on");
        Discipline biology = new Discipline("Bilogy");
        Discipline chemistry = new Discipline("Chemistry", 30, 15);

        Teacher lubomirKolev = new Teacher("Lubomir", "Kolev");
        Teacher gerasimGerasimov = new Teacher("Gerassim", "Gerassimov", "nickname - Gero");
        
        Student petarGeorgiev = new Student("Petar", "Georgiev", 16, "troblemaker");
        Student aniPlamenova = new Student("Ani", "Plamenova", 1);
        Student mladenNikolov = new Student("Mladen", "Nikolov", 12, "Mathematics champion");

        lubomirKolev.AddDiscipline(chemistry, biology);
        gerasimGerasimov.AddDiscipline(mathematics);

        class10A.AddTeacher(lubomirKolev, gerasimGerasimov);
        class10A.AddStudent(petarGeorgiev, aniPlamenova, mladenNikolov, new Student("Kim", "Xo", "guest student"));

        mladenNikolov.AddComment("weakspot - Chemisty");
        //petarGeorgiev.Comments.Clear();

        mySchool.AddClass(class10A, new ClassOfStudents("9 B", "empty test class"));

        foreach (var classOfStudents in mySchool.Classes)
        {
            Console.WriteLine(classOfStudents);
        }
    }
}

