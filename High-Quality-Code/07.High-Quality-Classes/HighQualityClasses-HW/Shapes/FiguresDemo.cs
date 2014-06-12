namespace Shapes
{
    using System;

    public class FiguresDemo
    {
        private static void Main()
        {
            var circle = new Circle(5);
            var rect = new Rectangle(2, 3);

            ShapeExtensions.PrintShapeInfoOnConsole(circle);
            ShapeExtensions.PrintShapeInfoOnConsole(rect);
        }
    }
}
