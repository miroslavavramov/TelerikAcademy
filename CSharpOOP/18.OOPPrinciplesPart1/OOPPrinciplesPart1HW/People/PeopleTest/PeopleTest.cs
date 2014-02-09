using People.Common;
using System;
using System.Collections.Generic;
using System.Linq;

class PeopleTest
{
    static void Main()
    {
        var students = new List<Student>()
        {
            new Student("Miroslava", "Todorova", 6),
            new Student("Ivan", "Georgiev", 3.33),
            new Student("Mihail", "Mihajlov", 2.99),
            new Student("Svetlana", "Stojanova", 4.25),
            new Student("Krasimira", "Nedelcheva", 5.75),
            new Student("Radoslav", "Penev", 4),
            new Student("Georgi", "Georgiev", 3),
            new Student("Cvetan", "Trifonov", 6),
            new Student("Svetlana", "Marinova", 4.25),
            new Student("Petia", "Zlateva", 5.5)
        };

        var sortedStudents = students
            .OrderBy(x => x.Grade);

        Console.WriteLine("Sorted Students : \r\n");

        foreach (var student in sortedStudents)
            Console.WriteLine(student);

        var workers = new List<Worker>()
        {
            new Worker("Mihail", "Nikolov", 300m, 12),
            new Worker("Petar", "Petrov", 350m, 8),
            new Worker("Gergana", "Todorova", 150m, 4),
            new Worker("Svilen", "Najdenov", 1000m, 10),
            new Worker("Anton", "Todorov", 270m, 8),
            new Worker("Georgi", "Slavchev", 500.5m, 8),
            new Worker("Rumen", "Radev", 420m, 9),
            new Worker("Genoveva", "Andreeva", 390.5m, 10),
            new Worker("Viktoria", "Nikolova", 700m, 9),
            new Worker("Lubomir", "Nikolov", 100m, 4),
        };

        var sortedWorkers = 
            from worker in workers
            orderby worker.CalcHourlySalary() descending
            select worker;
        
        Console.WriteLine("\r\nSorted Workers : \r\n");

        foreach (var worker in sortedWorkers)
            Console.WriteLine(worker);

        var mergedList = workers.Concat<Human>(students);

        mergedList = mergedList
            .OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName);

        Console.WriteLine("\r\nSorted People : \r\n");

        foreach (var human in mergedList)
            Console.WriteLine(human.FirstName + " " + human.LastName);

        Human a = new Human("ASD", "asd");
    }
}
