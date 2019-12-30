using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary
{
    public static class Algorithms
    {
        private static string IComparableImplException = "{0} does not implement IComparable interface";

        public static int BinarySearch(ArrayList collection, object item)
        {
            if (collection == null || item == null)
            {
                throw new ArgumentNullException(collection == null ? nameof(collection) : nameof(item));
            }

            var itemType = item.GetType();
            var itemComp = item as IComparable ??
                           throw new ArgumentException(String.Format(IComparableImplException, nameof(item)));

            int leftIndex = 0, rightIndex = collection.Count - 1;

            while (leftIndex <= rightIndex)
            {
                var halfIndex = (rightIndex + leftIndex) / 2;

                if (collection[halfIndex].GetType() != itemType)
                {
                    throw new ArgumentException("Arguments must have same type.");
                }

                var currentItemComp = collection[halfIndex] as IComparable;

                var compareResult = itemComp.CompareTo(currentItemComp);

                if (compareResult == 0)
                {
                    return halfIndex;
                }

                if (compareResult > 0)
                {
                    leftIndex = halfIndex + 1;
                }
                else if (compareResult < 0)
                {
                    rightIndex = halfIndex - 1;
                }
            }

            return -1;
        }

        public static IEnumerable<long> GetFibonacciNumbers(int count)
        {
            long prev = -1, current = 1;

            for (var i = 0; i < count; i++)
            {
                var sum = prev + current;
                prev = current;
                current = sum;
                yield return sum;
            }
        }
    }
}