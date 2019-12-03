using System;
using M04_Task1_and_Task2.Utils;

namespace M04_Task1_and_Task2.Shapes
{
    internal class Rectangle : Shape
    {
        public Point[] Coordinates { get; private set; }
        private readonly double leftRightSideLength;
        private readonly double upBottomSideLength;

        public Rectangle(Point leftUp, Point rightUp, Point rightBottom, Point leftBottom)
        {
            if (ShapeUtils.IsRectangle(leftUp, rightUp, rightBottom, leftBottom, 
                out var leftRightSide, out var upBottomSide))
            {
                this.Coordinates = new[] { leftUp, rightUp, rightBottom, leftBottom };
                this.leftRightSideLength = leftRightSide;
                this.upBottomSideLength = upBottomSide;
            }
            else
            {
                throw new ArgumentException("Invalid parameters. It's not a rectangle.");
            }
        }

        public override double GetArea() => leftRightSideLength * upBottomSideLength;

        public override double GetPerimeter() => 2 * (leftRightSideLength + upBottomSideLength);
    }
}
