using NUnit.Framework;
using System;

namespace M03_Task1.Tests
{
    [TestFixture]
    public class BigNumbersSumTests
    {
        [Test]
        public void Sum_EmptyStrings_ThrowsArgumentException()
        {
            var empty = String.Empty;
            var nonEmpty = "a";

            Assert.Multiple(() => 
            {
                Assert.That(() => BigNumbersSum.Sum(empty, empty),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage));
                Assert.That(() => BigNumbersSum.Sum(empty, nonEmpty),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage));
                Assert.That(() => BigNumbersSum.Sum(nonEmpty, empty),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage));
            });
        }

        [Test]
        public void Sum_NullStrings_ThrowsArgumentException()
        {
            string nullString = null;
            var nonNullString = "a";

            Assert.Multiple(() =>
            {
                Assert.That(() => BigNumbersSum.Sum(nullString, nullString),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage));
                Assert.That(() => BigNumbersSum.Sum(nonNullString, nullString),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage));
                Assert.That(() => BigNumbersSum.Sum(nullString, nonNullString),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage));
            });
        }

        [Test]
        public void Sum_IncorrectNumbers_ThrowsArgumentException()
        {
            var correctNumber = "100";
            var incorrectNumber = "1a00";

            Assert.Multiple(() =>
            {
                Assert.That(() => BigNumbersSum.Sum(correctNumber, incorrectNumber),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo("Input string is not a correct number"));
                Assert.That(() => BigNumbersSum.Sum(incorrectNumber, correctNumber),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo("Input string is not a correct number"));
                Assert.That(() => BigNumbersSum.Sum(incorrectNumber, incorrectNumber),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo("Input string is not a correct number"));
            });
        }

        [Test]
        public void Sum_SmallNumbers1and1_Returns2()
        {
            var first = "1";
            var second = "1";

            var result = BigNumbersSum.Sum(first, second);

            Assert.That(result, Is.EqualTo("2"));
        }

        [Test]
        public void Sum_BigNumbers_ReturnsCorrectResult()
        {
            var first = "12250165209153784685228690083746175751559134784";
            var second = "1225016520915378468522869008374617575155";

            var result = BigNumbersSum.Sum(first, second);

            Assert.That(result, Is.EqualTo("12250166434170305600607158606615184126176709939"));
        }
    }
}
