using NUnit.Framework;

namespace ClassLibrary.Tests
{
    [TestFixture]
    class SetTests
    {
        [Test]
        public void Constructor_NegativeCapacity_ThrowsArgumentOutOfRangeEx()
        {
            Assert.That(() => new Set<string>(-1),
                Throws.Exception.
                With.Message.
                EqualTo("Specified argument was out of the range of valid values.\r\nParameter name: capacity"));
        }

        [Test]
        public void Add_TwoDifferentElements_Count2()
        {
            var set = new Set<string>();

            set.Add("1");
            set.Add("2");

            Assert.That(set.Count, Is.EqualTo(2));
        }

        [Test]
        public void Add_TwoEqualElements_Count2()
        {
            var set = new Set<string>();
            var str = "1";

            set.Add(str);
            set.Add(str);

            Assert.That(set.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_NoElement_ReturnsFalse()
        {
            var set = new Set<string>();

            var res = set.Remove("Test1");

            Assert.That(res, Is.EqualTo(false));
        }

        [Test]
        public void Remove_HasElement_ReturnsTrue()
        {
            var set = new Set<string>();

            set.Add("Test1");
            var res = set.Remove("Test1");

            Assert.That(res, Is.EqualTo(true));
        }

        [Test]
        public void Contains_NoElement_ReturnsFalse()
        {
            var set = new Set<string>();

            var res = set.Contains("Test1");

            Assert.That(res, Is.EqualTo(false));
        }

        [Test]
        public void Contains_HasElement_ReturnsTrue()
        {
            var set = new Set<string>();

            set.Add("Test1");
            var res = set.Contains("Test1");

            Assert.That(res, Is.EqualTo(true));
        }
        
        [Test]
        public void Clear_TwoElements_Count0()
        {
            var set = new Set<string>(2);

            set.Add("1");
            set.Add("2");
            set.Clear();

            Assert.That(set.Count, Is.EqualTo(0));
        }
    }
}
