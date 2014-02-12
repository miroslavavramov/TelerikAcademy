namespace Shapes.Common
{
    using System;

    public class Circle
        : Shape
    {
        public Circle(double width)
            : base(width, width)
        {
        }

        public override double CalculateSurface()
        {
            return this.Width * this.Width * Math.PI;
        }
    }
}
