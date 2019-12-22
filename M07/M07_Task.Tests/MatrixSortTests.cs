using System.Linq;
using NUnit.Framework;

namespace M07_Task.Tests
{
    [TestFixture]
    public class MatrixSortTests
    {
        private int[][] array;
        private System.Func<int[], int[], bool> descRowSumCompare = 
            (first, second) => first.Sum() < second.Sum();

        [SetUp]
        public void SetUp()
        {
            array = new int[4][]
            {
                new int[3] { 9, 0, 1 }, //Min 0, Max 9, Sum 11
                new int[3] { 10, 2, 1 }, //Min 1, Max 10, Sum 13
                new int[3] { 8, 5, 6 }, //Min 5, Max 8, Sum 19
                new int[3] { 7, 3, 4 } //Min 3, Max 7, Sum 14
            };
        }

        [Test]
        public void Sort_MatrixIsNull_ThrowsArgumentNullException()
        {
            Assert.That(() => MatrixSort.Sort(null, descRowSumCompare),
                Throws.ArgumentNullException.
                With.Message.EqualTo("Value cannot be null.\r\nParameter name: matrix"));
        }

        [Test]
        public void Sort_MatrixRowIsNull_ThrowsArgumentNullException()
        {
            var nullRowArray = new int[4][];

            Assert.That(() => MatrixSort.Sort(nullRowArray, descRowSumCompare),
                Throws.ArgumentNullException.
                With.Message.EqualTo("Value cannot be null.\r\nParameter name: matrix[0]"));
        }

        [Test]
        public void Sort_FuncIsNull_ThrowsArgumentNullException()
        {
            Assert.That(() => MatrixSort.Sort(array, null),
                Throws.ArgumentNullException.
                With.Message.EqualTo("Value cannot be null.\r\nParameter name: compare"));
        }

        [Test]
        public void Sort_DescRowSum_SortsCorrectly()
        {            
            MatrixSort.Sort(array, descRowSumCompare);

            var expected = new int[4][]
            {
                new int[3] { 8, 5, 6 }, //Min 5, Max 8, Sum 19
                new int[3] { 7, 3, 4 }, //Min 3, Max 7, Sum 14
                new int[3] { 10, 2, 1 }, //Min 1, Max 10, Sum 13
                new int[3] { 9, 0, 1 } //Min 0, Max 9, Sum 11
            };

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test]
        public void Sort_AscRowSum_SortsCorrectly()
        {
            MatrixSort.Sort(array, (first, second) => first.Sum() > second.Sum());

            var expected = new int[4][]
            {
                new int[3] { 9, 0, 1 }, //Min 0, Max 9, Sum 11
                new int[3] { 10, 2, 1 }, //Min 1, Max 10, Sum 13
                new int[3] { 7, 3, 4 }, //Min 3, Max 7, Sum 14
                new int[3] { 8, 5, 6 } //Min 5, Max 8, Sum 19
            };

            Assert.That(array, Is.EqualTo(expected));
        }
        
        [Test]
        public void Sort_DescRowMax_SortsCorrectly()
        {
            MatrixSort.Sort(array, (first, second) => first.Max() < second.Max());

            var expected = new int[4][]
            {
                new int[3] { 10, 2, 1 }, //Min 1, Max 10, Sum 13
                new int[3] { 9, 0, 1 }, //Min 0, Max 9, Sum 11
                new int[3] { 8, 5, 6 }, //Min 5, Max 8, Sum 19
                new int[3] { 7, 3, 4 } //Min 3, Max 7, Sum 14
            };

            Assert.That(array, Is.EqualTo(expected));
        }
        
        [Test]
        public void Sort_AscRowMax_SortsCorrectly()
        {
            MatrixSort.Sort(array, (first, second) => first.Max() > second.Max());

            var expected = new int[4][]
            {
                new int[3] { 7, 3, 4 }, //Min 3, Max 7, Sum 14
                new int[3] { 8, 5, 6 }, //Min 5, Max 8, Sum 19
                new int[3] { 9, 0, 1 }, //Min 0, Max 9, Sum 11
                new int[3] { 10, 2, 1 } //Min 1, Max 10, Sum 13
            };

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test]
        public void Sort_DescRowMin_SortsCorrectly()
        {
            MatrixSort.Sort(array, (first, second) => first.Min() < second.Min());

            var expected = new int[4][]
            {
                new int[3] { 8, 5, 6 }, //Min 5, Max 8, Sum 19
                new int[3] { 7, 3, 4 }, //Min 3, Max 7, Sum 14
                new int[3] { 10, 2, 1 }, //Min 1, Max 10, Sum 13
                new int[3] { 9, 0, 1 } //Min 0, Max 9, Sum 11
            };

            Assert.That(array, Is.EqualTo(expected));
        }

        [Test]
        public void Sort_AscRowMin_SortsCorrectly()
        {
            MatrixSort.Sort(array, (first, second) => first.Min() > second.Min());

            var expected = new int[4][]
            {
                new int[3] { 9, 0, 1 }, //Min 0, Max 9, Sum 11
                new int[3] { 10, 2, 1 }, //Min 1, Max 10, Sum 13
                new int[3] { 7, 3, 4 }, //Min 3, Max 7, Sum 14
                new int[3] { 8, 5, 6 } //Min 5, Max 8, Sum 19
            };

            Assert.That(array, Is.EqualTo(expected));
        }
    }
}