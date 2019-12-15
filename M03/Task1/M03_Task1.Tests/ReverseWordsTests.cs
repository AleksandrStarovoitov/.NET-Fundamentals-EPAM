using NUnit.Framework;
using System;

namespace M03_Task1.Tests
{
    [TestFixture]
    public class ReverseWordsTests
    {
        [Test]
        public void Reverse_EmptyStrings_ThrowsArgumentException()
        {
            var empty = String.Empty;

            Assert.That(() => ReverseWords.Reverse(empty),
                    Throws.ArgumentException.
                    With.Message.
                    EqualTo(Resources.Resources.NullOrEmptyExMessage + "\r\nParameter name: input"));
        }

        [Test]
        public void Reverse_NullStrings_ThrowsArgumentException()
        {
            string nullString = null;

            Assert.That(() => ReverseWords.Reverse(nullString),
                    Throws.ArgumentException.
                    With.Message.
                    EqualTo(Resources.Resources.NullOrEmptyExMessage + "\r\nParameter name: input"));
        }

        [Test]
        public void Reverse_ValidString_ReturnsReversedString()
        {
            var str = "The greatest victory is that which requires no battle";

            var result = ReverseWords.Reverse(str);

            Assert.That(result, Is.EqualTo("battle no requires which that is victory greatest The"));
        }

        [Test]
        public void Reverse_OnveWord_ReturnsSameWord()
        {
            var str = "The";

            var result = ReverseWords.Reverse(str);

            Assert.That(result, Is.EqualTo(str));
        }
    }
}
