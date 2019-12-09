using System;
using M04_Task1_and_Task2.Shapes;

namespace M04_Task1_and_Task2
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var shapes = new Shape[] { 
                new Square(new Point(0, 1), new Point(1, 1), new Point(1, 0), new Point(0, 0)),
                new Rectangle(new Point(0, 1), new Point(2, 1), new Point(2, 0),new Point(0, 0)),
                new Circle(new Point(0,0), 5),
                new Triangle(new Point(0,0), new Point(0, 3), new Point(3,0))
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }
        }
    }
}
