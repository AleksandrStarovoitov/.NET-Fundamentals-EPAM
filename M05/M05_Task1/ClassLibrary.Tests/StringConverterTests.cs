using ClassLibrary;
using NLog;
using NUnit.Framework;
using System;

namespace ClassLibrary.Tests
{
    [TestFixture]
    public class StringConverterTests
    {
        private static Logger logger;
        private static StringConverter converter;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            logger = LogManager.GetCurrentClassLogger();
            converter = new StringConverter(logger);
        }

        [Test]
        public void ToInt32_EmptyString_ThrowsArgumentException()
        {
            var empty = String.Empty;

            Assert.That(() => converter.ToInt32(empty),
                    Throws.ArgumentException.
                    With.Message.
                    EqualTo("Input string is null or empty.\r\nParameter name: str"));
        }

        [Test]
        public void ToInt32_NullString_ThrowsArgumentException()
        {
            string nullString = null;

            Assert.That(() => converter.ToInt32(nullString),
                    Throws.ArgumentException.
                    With.Message.
                    EqualTo("Input string is null or empty.\r\nParameter name: str"));
        }

        [Test]
        public void ToInt32_NumberBiggerThanInt32_ThrowsOverflowException()
        {
            string number = "10000000000000";

            Assert.That(() => converter.ToInt32(number),
                    Throws.Exception.
                    TypeOf<OverflowException>());
        }

        [Test]
        public void ToInt32_StringWithNonDigit_ThrowsArgumentException()
        {
            string number = "123b";

            Assert.That(() => converter.ToInt32(number),
                    Throws.ArgumentException.
                    With.Message.
                    EqualTo("Invalid string. 'b' is not a digit."));
        }

        [Test]
        public void ToInt32_String123_ReturnsInt123()
        {
            string number = "123";

            var result = converter.ToInt32(number);

            Assert.That(result, Is.EqualTo(123));
        }

        [Test]
        public void ToInt32_StringNegative123_ReturnsNegativeInt123()
        {
            string number = "-123";

            var result = converter.ToInt32(number);

            Assert.That(result, Is.EqualTo(-123));
        }

        [Test]
        public void ToInt32_String0_ReturnsInt0()
        {
            string number = "0";

            var result = converter.ToInt32(number);

            Assert.That(result, Is.EqualTo(0));
        }
    }
}