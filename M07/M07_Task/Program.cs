using System.Linq;

namespace M07_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new int[4][]
            {
                new int[4] { 1, 1, 1, 1 },
                new int[4] { 2, 2, 2, 2 },
                new int[4] { 4, 4, 1, 4 },
                new int[4] { 3, 3, 3, 3 }
            };

            //in descending order of sums of matrix row elements
            MatrixSort.Sort(array, (first, second) => first.Sum() < second.Sum());

            //in ascending order of sums of matrix row elements
            MatrixSort.Sort(array, (first, second) => first.Sum() > second.Sum());

            //in descending order of maximum element in a matrix row;
            MatrixSort.Sort(array, (first, second) => first.Max() < second.Max());

            //in ascending order of maximum element in a matrix row;
            MatrixSort.Sort(array, (first, second) => first.Max() > second.Max());

            //in descending order of minimum element in a matrix row;
            MatrixSort.Sort(array, (first, second) => first.Min() < second.Min());

            //in ascending order of minimum element in a matrix row;
            MatrixSort.Sort(array, (first, second) => first.Min() > second.Min());
        }
    }
}