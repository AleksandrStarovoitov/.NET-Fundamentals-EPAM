using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;

namespace ClassLibrary.Tests
{
    [TestFixture]
    public class AlgorithmsTests
    {
        [Test]
        public void BinarySearch_NullArguments_ThrowsArgumentNullException()
        {
            var array = new [] { "1", "2", "3" };
            string[] nullArr = null;
            var item = "1";

            Assert.Multiple(() =>
            {
                Assert.That(() => Algorithms.BinarySearch(array, null),
                    Throws.ArgumentNullException);
                Assert.That(() => Algorithms.BinarySearch(nullArr, item),
                    Throws.ArgumentNullException);
                Assert.That(() => Algorithms.BinarySearch(nullArr, null),
                    Throws.ArgumentNullException);
            });
        }

        [Test]
        public void BinarySearch_ItemDoesNotImplementIComparable_ThrowsArgumentNullException()
        {
            var item = new {a = "anonymous", b = "type"};
            var array = new [] { item, item, item };

            var exceptionFormatString = "{0} does not implement IComparable interface";
            Assert.That(() => Algorithms.BinarySearch(array, item),
                Throws.ArgumentException.
                    With.Message.
                    EqualTo(String.Format(exceptionFormatString, nameof(item))));
        }

        [Test]
        public void BinarySearch_ItemAt1_ArrSize3_Returns1()
        {
            var array = new [] { 1, 2, 3 };

            var result = Algorithms.BinarySearch(array, 2);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void BinarySearch_ItemAt1_ArrSize4_Returns1()
        {
            var array = new [] { 1, 2, 3, 4 };

            var result = Algorithms.BinarySearch(array, 2);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void BinarySearch_ItemAtStart_Returns0()
        {
            var array = new [] { 1, 2, 3 };

            var result = Algorithms.BinarySearch(array, 1);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void BinarySearch_ItemAtEnd_ReturnsArrCountMinusOne()
        {
            var array = new [] { 1, 2, 3 };

            var result = Algorithms.BinarySearch(array, 3);

            Assert.That(result, Is.EqualTo(array.Length - 1));
        }

        [Test]
        public void BinarySearch_ItemAt0_ArrSize1_Returns0()
        {
            var array = new [] { 2 };

            var result = Algorithms.BinarySearch(array, 2);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void BinarySearch_EmptyArray_ReturnsMinus1()
        {
            var array = new int[] { };

            var result = Algorithms.BinarySearch(array, 2);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void BinarySearch_NoItem_ReturnsMinus1()
        {
            var array = new [] { 1, 2, 3 };

            var result = Algorithms.BinarySearch(array, 5);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void GetFibonacciNumbers_Count0_ReturnsEmptyIEnumerable()
        {
            var result = Algorithms.GetFibonacciNumbers(-1);

            Assert.That(result.Any(), Is.EqualTo(false));
        }

        [Test]
        public void GetFibonacciNumbers_Count5_Returns011235()
        {
            var result = Algorithms.GetFibonacciNumbers(5).ToArray();

            var expected = new[] { 0, 1, 1, 2, 3 };

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
