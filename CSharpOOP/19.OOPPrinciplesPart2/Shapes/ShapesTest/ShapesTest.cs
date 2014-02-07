using Shapes.Common;
using System;
using System.Collections.Generic;
using System.Linq;

class ShapesTest
{
    static void Main()
    {
        var shapes = new List<Shape>()
        {
            new Rectangle(5.0, 3.5),
            new Triangle(8.0, 6.0),
            new Circle(3.0),
            new Rectangle(9.1, 4.008),
            new Circle(3.00124),
            new Triangle(66, 41.092)
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine("Type : {0} Area = {1}", shape.GetType().Name, shape.CalculateSurface());           
        }
    }
}

