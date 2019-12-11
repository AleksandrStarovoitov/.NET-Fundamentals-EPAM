using NUnit.Framework;
using System;

namespace M03_Task1.Tests
{
    [TestFixture]
    public class DoubleCharsTests
    {
        [Test]
        public void GetDoubleCharString_EmptyStrings_ThrowsArgumentException()
        {
            var empty = String.Empty;
            var nonEmpty = "a";

            Assert.Multiple(() =>
            {
                Assert.That(() => DoubleChars.GetDoubleCharString(empty, empty),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage));
                Assert.That(() => DoubleChars.GetDoubleCharString(empty, nonEmpty),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage));
                Assert.That(() => DoubleChars.GetDoubleCharString(nonEmpty, empty),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage));
            });
        }

        [Test]
        public void GetDoubleCharString_NullStrings_ThrowsArgumentException()
        {
            string nullString = null;
            var nonNullString = "a";

            Assert.Multiple(() =>
            {
                Assert.That(() => DoubleChars.GetDoubleCharString(nullString, nullString),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage));
                Assert.That(() => DoubleChars.GetDoubleCharString(nonNullString, nullString),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage));
                Assert.That(() => DoubleChars.GetDoubleCharString(nullString, nonNullString),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage));
            });
        }

        [Test]
        public void GetDoubleCharString_ValidStrings_ReturnsCorrectResult()
        {
            var first = "omg i love shrek";
            var second = "o kek";

            var result = DoubleChars.GetDoubleCharString(first, second);

            Assert.That(result, Is.EqualTo("oomg i loovee shreekk"));
        }

        [Test]
        public void GetDoubleCharString_NoOccurencies_ReturnsFirstString()
        {
            var first = "Test";
            var second = "abcd";

            var result = DoubleChars.GetDoubleCharString(first, second);

            Assert.That(result, Is.EqualTo(first));
        }
    }    
}
