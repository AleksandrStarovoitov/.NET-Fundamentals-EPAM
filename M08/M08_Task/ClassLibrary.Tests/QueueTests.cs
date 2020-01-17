using NUnit.Framework;

namespace ClassLibrary.Tests
{
    [TestFixture]
    class QueueTests
    {
        [Test]
        public void Constructor_NegativeCapacity_ThrowsArgumentOutOfRangeEx()
        {
            Assert.That(() => new Queue<int>(-1),
                Throws.Exception.
                With.Message.
                EqualTo("Non-negative number required\r\nParameter name: capacity\r\nActual value was -1."));
        }

        [Test]
        public void Dequeue_EmptyQueue_ThrowsInvalidOperationEx()
        {
            var queue = new Queue<int>();

            Assert.That(() => queue.Dequeue(),
                 Throws.InvalidOperationException.
                 With.Message.
                 EqualTo("Invalid operation. Queue is empty."));
        }

        [Test]
        public void Peek_EmptyQueue_ThrowsInvalidOperationEx()
        {
            var queue = new Queue<int>();

            Assert.That(() => queue.Peek(),
                 Throws.InvalidOperationException.
                 With.Message.
                 EqualTo("Invalid operation. Queue is empty."));
        }

        [Test]
        public void Enqueue_TwoElements_Count2()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.That(queue.Count, Is.EqualTo(2));
        }

        [Test]
        public void Enqueue_TwiceCapacity1_Resize()
        {
            var queue = new Queue<int>(1);

            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.That(queue.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_OnceWithOneElement_Count1andSameElement()
        {
            var num = 1;
            var queue = new Queue<int>();

            queue.Enqueue(num);
            var res = queue.Peek();

            Assert.Multiple(() =>
            {
                Assert.That(queue.Count, Is.EqualTo(1));
                Assert.That(res, Is.EqualTo(num));
            });
        }

        [Test]
        public void Dequeue_OnceWithOneElemnt_Count0()
        {
            var num = 1;
            var queue = new Queue<int>();

            queue.Enqueue(num);
            var res = queue.Dequeue();

            Assert.Multiple(() =>
            {
                Assert.That(queue.Count, Is.EqualTo(0));
                Assert.That(res, Is.EqualTo(num));
            });
        }

        [Test]
        public void Clear_TwoElements_Count0()
        {
            var queue = new Queue<int>(2);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Clear();

            Assert.That(queue.Count, Is.EqualTo(0));
        }
    }
}