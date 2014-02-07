namespace Shapes.Common
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;

        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width can't be zero or negative!");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height can't be zero or negative!");
                }
                this.height = value;
            }
        }

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public abstract double CalculateSurface();

    }
}
