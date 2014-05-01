using Animals.Common;
using System;
using System.Collections.Generic;
using System.Linq;

class AnimalsTest
{
    static void Main()
    {
        var animals = new HashSet<Animal>()
        {
            new Frog("Kermit", 11, true),
            new Dog("Druppy", 7, true),
            new Tomcat("Tom", 10),
            new Kitten("Lizzie", 4),
            new Cat("Mr Zazzles", 13, true),
            new Dog("Bonnie", 2, false),
            new Frog("Prince", 24, true),
            new Cat("Kemo", 7, true)
        };

        Console.WriteLine("Animals : ");
        Print(animals);
        Console.WriteLine("\r\nAnimals' average age: {0}\r\n", GetAverageAge(animals));

        Cat[] cats =
        {
            new Kitten("Lori", 5),
            new Tomcat("Joe Black", 2),
            new Cat("Silvester", 8, true),
            new Kitten("Sandy", 1),
            new Tomcat("Roy", 12),
            new Cat("Red dot chaser", 3, false)
        };

        Console.WriteLine("Cats : ");
        Print(cats);
        Console.WriteLine("\r\nCats' average age : {0}\r\n", GetAverageAge(cats));


        foreach (var animal in animals)
        {
            animal.ProduceSound();
        }
    }

    static double GetAverageAge(IEnumerable<Animal> animals)
    {
        return Math.Round(animals.Average(animal => animal.Age), 1);
    }

    static void Print<T>(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
}

