namespace Shapes
{
    using System;

    public static class ShapeExtensions
    {
        public static void PrintShapeInfoOnConsole(Shape shape)
        {
            Console.WriteLine(
                "I am a {0}. My perimeter is {1:f2}. My surface is {2:f2}.",
                shape.GetType().Name, 
                shape.CalculatePerimeter(), 
                shape.CalculateSurface());
        }
    }
}