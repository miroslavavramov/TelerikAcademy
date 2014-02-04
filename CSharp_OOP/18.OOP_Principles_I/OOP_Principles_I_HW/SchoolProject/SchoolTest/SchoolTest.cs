using SchoolHierarchy.Common;
using System;
using System.Collections.Generic;

class SchoolTest
{
    static void Main()
    {
        School mySchool = new School("Gymnasium of Mathematics and Natural Sciences");

        ClassOfStudents class10A = new ClassOfStudents("10 A");

        Discipline mathematics = new Discipline("Mathematics", 7, 7, "emphasis on");
        Discipline biology = new Discipline("Bilogy");
        Discipline chemistry = new Discipline("Chemistry", 4, 4);

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
        petarGeorgiev.ClearComments();

        mySchool.AddClass(class10A, new ClassOfStudents("9 B", "empty test class"));

        foreach (var classOfStudents in mySchool.Classes)
            Console.WriteLine(classOfStudents);
    }
}

