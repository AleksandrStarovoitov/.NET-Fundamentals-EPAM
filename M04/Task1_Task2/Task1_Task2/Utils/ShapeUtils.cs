using System;
using M04_Task1_and_Task2.Shapes;

namespace M04_Task1_and_Task2.Utils
{
    internal static class ShapeUtils
    {
        public const double Tolerance = 0.00000001;

        public static double GetDistance(Point first, Point second)
        {
            var xDiff = second.X - first.X;
            var yDiff = second.Y - first.Y;
            var xPow = Math.Pow(xDiff, 2);
            var yPow = Math.Pow(yDiff, 2);

            return Math.Sqrt(xPow + yPow);
        }

        public static bool IsRectangle(Point leftUp, Point rightUp, Point rightBottom, Point leftBottom,
            out double leftRightSide, out double upBottomSide)
        {
            var leftSide = GetDistance(leftUp, leftBottom);
            var rightSide = GetDistance(rightUp, rightBottom);
            var upSide = GetDistance(leftUp, rightUp);
            var bottomSide = GetDistance(leftBottom, rightBottom);
            var diag1 = GetDistance(leftUp, rightBottom);
            var diag2 = GetDistance(rightUp, leftBottom);

            var leftLegsPow = Math.Pow(leftSide, 2) + Math.Pow(bottomSide, 2);
            var leftHypoPow = Math.Pow(diag1, 2);
            var rightLegsPow = Math.Pow(rightSide, 2) + Math.Pow(upSide, 2);
            var rightHypoPow = Math.Pow(diag1, 2);

            var leftLegsHypoDiff = Math.Abs(leftHypoPow - leftLegsPow);
            var rightLegsHypoDiff = Math.Abs(rightHypoPow - rightLegsPow);
            var leftRightDiff = Math.Abs(leftSide - rightSide);
            var bottomUpDiff = Math.Abs(upSide - bottomSide);
            var diagsDiff = Math.Abs(diag1 - diag2);

            if (leftRightDiff < Tolerance && bottomUpDiff < Tolerance &&
                diagsDiff < Tolerance && leftLegsHypoDiff < Tolerance &&
                rightLegsHypoDiff < Tolerance)
            {
                leftRightSide = leftSide;
                upBottomSide = upSide;
                return true;
            }

            leftRightSide = -1;
            upBottomSide = -1;
            return false;
        }
    }
}
