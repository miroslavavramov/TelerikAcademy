namespace Shapes
{
    using System;

    public static class ShapeExtensions
    {
        public static Shape GetRotatedShape(Shape shape, double rotationAngle)
        {
            double width = (Math.Abs(Math.Cos(rotationAngle)) * shape.Width) +
                (Math.Abs(Math.Sin(rotationAngle)) * shape.Height);

            double height = (Math.Abs(Math.Sin(rotationAngle)) * shape.Width) +
                (Math.Abs(Math.Cos(rotationAngle)) * shape.Height);

            return new Shape(width, height);
        }
    }
}
