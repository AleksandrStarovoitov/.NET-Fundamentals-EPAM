using System;
using M04_Task1_and_Task2.Utils;

namespace M04_Task1_and_Task2.Shapes
{
    internal class Square : Shape
    {
        public Point[] Coordinates { get; private set; }
        private readonly double sidesLength;

        public Square(Point leftUp, Point rightUp, Point rightBottom, Point leftBottom)
        {
            if (IsSquare(leftUp, rightUp, rightBottom, leftBottom, out var sidesLength))
            {
                this.Coordinates = new[] { leftUp, rightUp, rightBottom, leftBottom };
                this.sidesLength = sidesLength;
            }
            else
            {
                throw new ArgumentException("Invalid parameters. It's not a square");
            }
        }

        private static bool IsSquare(Point leftUp, Point rightUp, Point rightBottom,
                                     Point leftBottom, out double sideLength)
        {
            var isRectangle = ShapeUtils.IsRectangle(leftUp, rightUp, rightBottom, leftBottom,
                out var leftRightSide, out var upBottomSide);
            
            if (isRectangle && Math.Abs(leftRightSide - upBottomSide) < ShapeUtils.Tolerance)
            {
                sideLength = leftRightSide;
                return true;
            }
            
            sideLength = -1;
            return false;
        }

        public override double GetArea() => sidesLength * sidesLength;

        public override double GetPerimeter() => 4 * sidesLength;
    }
}
