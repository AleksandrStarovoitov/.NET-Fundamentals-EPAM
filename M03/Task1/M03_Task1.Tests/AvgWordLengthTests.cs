using NUnit.Framework;
using System;

namespace M03_Task1.Tests
{
    [TestFixture]
    public class AvgWordLengthTests
    {
        [Test]
        public void GetAvgWordLength_EmptyString_ThrowsArgumentException()
        {
            var avgLengthInput = String.Empty;
            
            Assert.That(() => AvgWordLength.GetAvgWordLength(avgLengthInput), 
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage + "\r\nParameter name: input"));
        }

        [Test]
        public void GetAvgWordLength_NullString_ThrowsArgumentException()
        {
            string avgLengthInput = null;

            Assert.That(() => AvgWordLength.GetAvgWordLength(avgLengthInput),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo(Resources.Resources.NullOrEmptyExMessage + "\r\nParameter name: input"));
        }

        [Test]
        public void GetAvgWordLength_OneWordWithLength4_Returns4()
        {
            var avgLengthInput = "Test";

            var avgLength = AvgWordLength.GetAvgWordLength(avgLengthInput);

            Assert.That(avgLength, Is.EqualTo(4));
        }

        [Test]
        public void GetAvgWordLength_OnlyPunctuationChars_Returns0()
        {
            var avgLengthInput = ",/.;";
                        
            Assert.That(() => AvgWordLength.GetAvgWordLength(avgLengthInput),
                        Throws.ArgumentException.
                        With.Message.
                        EqualTo("No words in input string\r\nParameter name: input"));
        }

        [Test]
        public void GetAvgWordLength_EqualWordsWithLength4_4()
        {
            var avgLengthInput = "Test test test";

            var avgLength = AvgWordLength.GetAvgWordLength(avgLengthInput);

            Assert.That(avgLength, Is.EqualTo(4));
        }

        [Test]
        public void GetAvgWordLength_StringsWithLength1_2_3_Returns2()
        {
            var avgLengthInput = "a bc def";

            var avgLength = AvgWordLength.GetAvgWordLength(avgLengthInput);

            Assert.That(avgLength, Is.EqualTo(2));
        }

        [Test]
        public void GetAvgWordLength_StringsWithPunctuationsAndLength1_2_3_Returns2()
        {
            var avgLengthInput = "a, bc: def/;";

            var avgLength = AvgWordLength.GetAvgWordLength(avgLengthInput);

            Assert.That(avgLength, Is.EqualTo(2));
        }
    }
}
