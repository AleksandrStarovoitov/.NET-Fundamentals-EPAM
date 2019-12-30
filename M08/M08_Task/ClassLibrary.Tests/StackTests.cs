using NUnit.Framework;
using System;
//using System.Collections.Generic;
using System.Text;
using ClassLibrary;

namespace ClassLibrary.Tests
{
    [TestFixture]
    class StackTests
    {
        [Test]
        public void Constructor_NegativeCapacity_ThrowsArgumentOutOfRangeEx()
        {
            Assert.That(() => new Stack<int>(-1), 
                Throws.Exception.
                With.Message.
                EqualTo("Non-negative number required\r\nParameter name: capacity\r\nActual value was -1."));
        }
        
        [Test]
        public void Pop_EmptyStack_ThrowsInvalidOperationEx()
        {
            var stack = new Stack<int>();

            Assert.That(() => stack.Pop(),
                 Throws.InvalidOperationException.
                 With.Message.
                 EqualTo("Invalid operation. Stack is empty."));
        }

        [Test]
        public void Peek_EmptyStack_ThrowsInvalidOperationEx()
        {
            var stack = new Stack<int>();

            Assert.That(() => stack.Peek(),
                 Throws.InvalidOperationException.
                 With.Message.
                 EqualTo("Invalid operation. Stack is empty."));
        }

        [Test]
        public void Push_TwoElements_Count2()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);

            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Push_TwiceCapacity1_Resize()
        {
            var stack = new Stack<int>(1);

            stack.Push(1);
            stack.Push(2);

            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_OnceWithOneElement_Count1andSameElement()
        {
            var num = 1;
            var stack = new Stack<int>();

            stack.Push(num);
            var res = stack.Peek();

            Assert.Multiple(() =>
            {
                Assert.That(stack.Count, Is.EqualTo(1));
                Assert.That(res, Is.EqualTo(num));
            });
        }

        [Test]
        public void Pop_OnceWithOneElemnt_Count0()
        {
            var num = 1;
            var stack = new Stack<int>();

            stack.Push(num);
            var res = stack.Pop();

            Assert.Multiple(() =>
            {
                Assert.That(stack.Count, Is.EqualTo(0));
                Assert.That(res, Is.EqualTo(num));
            });
        }

        [Test]
        public void Clear_TwoElements_Count0()
        {
            var stack = new Stack<int>(2);

            stack.Push(1);
            stack.Push(2);
            stack.Clear();

            Assert.That(stack.Count, Is.EqualTo(0));          
        }
    }
}
