using System;

namespace M04_Task1_and_Task2.Shapes
{
    internal class Circle : Shape
    {
        public Point Center { get; private set; }
        public double Radius { get; private set; }
        
        public Circle(Point center, double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Radius is less than 0", nameof(radius));
            }

            this.Center = center;
            this.Radius = radius;
        }

        public override double GetArea() => Math.PI * Math.Pow(Radius, 2);

        public override double GetPerimeter() => 2 * Math.PI * Radius;
    }
}
