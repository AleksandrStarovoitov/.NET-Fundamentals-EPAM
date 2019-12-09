using System;
using M04_Task1_and_Task2.Utils;

namespace M04_Task1_and_Task2.Shapes
{
    internal class Triangle : Shape
    {
        public Point[] Coordinates { get; private set; }
        private readonly double[] sides;

        public Triangle(Point a, Point b, Point c)
        {
            this.Coordinates = new[] { a, b, c };

            sides = new[]
            {
                ShapeUtils.GetDistance(a, b),
                ShapeUtils.GetDistance(b, c),
                ShapeUtils.GetDistance(c, a)
            };
        }

        public override double GetArea()
        {
            var a = Coordinates[0];
            var b = Coordinates[1];
            var c = Coordinates[2];

            var first = a.X*(b.Y-c.Y);
            var second = b.X*(c.Y-a.Y);
            var third = c.X*(a.Y-b.Y);

            return Math.Abs((first + second + third)/2);
        }

        public override double GetPerimeter() => sides[0] + sides[1] + sides[2];
    }
}
