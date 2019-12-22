using System;

namespace M07_Task
{
    internal static class MatrixSort
    {
        public static void Sort(int[][] matrix, Func<int[], int[], bool> compare)
        {
            if (compare == null)
            {
                throw new ArgumentNullException(nameof(compare));
            }

            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = 0; j < matrix.Length - 1; j++)
                {
                    if (matrix[j] == null)
                    {
                        throw new ArgumentNullException($"{nameof(matrix)}[{j}]");
                    }

                    if (compare(matrix[j], matrix[j + 1]))
                    {
                        int[] t = matrix[j + 1];
                        matrix[j + 1] = matrix[j];
                        matrix[j] = t;
                    }
                }
            }
        }
    }
}