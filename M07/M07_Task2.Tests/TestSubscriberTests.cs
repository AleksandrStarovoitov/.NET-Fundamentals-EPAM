using NUnit.Framework;

namespace M07_Task2.Tests
{
    [TestFixture]
    public class TestSubscriberTests
    {
        private static string nullExceptionMessage = "Value cannot be null.\r\nParameter name: cd";

        [Test]
        public void Subscribe_CountdownNull_ThrowsArgumentNullException()
        {
            var sub1 = new TestSubscriber1();
            
            Assert.That(() => sub1.Subscribe(null, 4), 
                Throws.ArgumentNullException.
                With.Message.EqualTo(nullExceptionMessage));
        }

        [Test]
        public void Unsubscribe_CountdownNull_ThrowsArgumentNullException()
        {
            var sub1 = new TestSubscriber1();

            Assert.That(() => sub1.Unsubscribe(null),
                Throws.ArgumentNullException.
                With.Message.EqualTo(nullExceptionMessage));
        }
    }
}
