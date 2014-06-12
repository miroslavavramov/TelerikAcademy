namespace Shapes
{
    using System;

    class Program
    {
        static void Main()
        {
            var rectangle = new Shape(width: 5, height: 10);
            Console.WriteLine("Rectangle(width= {0}, height= {1})", rectangle.Width, rectangle.Height);

            var rotatedShape = ShapeExtensions.GetRotatedShape(rectangle, 30);
            Console.WriteLine("After 30 degree rotation:\r\nwidth={0}, height={1}", rotatedShape.Width, rotatedShape.Height);
        }
    }
}
