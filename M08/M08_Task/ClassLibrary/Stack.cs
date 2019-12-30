using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] array; 
        private const int DefaultCapacity = 4;

        public int Count { get; private set; }

        public Stack()
        {
            array = Array.Empty<T>();
        }

        public Stack(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Non-negative number required");
            }

            array = new T[capacity];
        }

        public void Push(T item)
        {
            int size = Count;
            var array = this.array;

            if ((uint)size < (uint)array.Length)
            {
                array[size] = item;
                Count = size + 1;
            }
            else
            {
                PushWithResize(item);
            }
        }

        private void PushWithResize(T item)
        {
            Array.Resize(ref array, (array.Length == 0) ? DefaultCapacity : 2 * array.Length);
            array[Count] = item;
            Count++;
        }

        public T Pop()
        {
            int size = this.Count - 1;
            var array = this.array;

            if ((uint)size >= (uint)array.Length)
            {
                ThrowForEmptyStack();
            }

            this.Count = size;
            var item = array[size];

            array[size] = default;
            
            return item;
        }

        public T Peek()
        {
            int size = Count - 1;
            T[] array = this.array;

            if ((uint)size >= (uint)array.Length)
            {
                ThrowForEmptyStack();
            }

            return array[size];
        }
        
        private void ThrowForEmptyStack()
        {
            throw new InvalidOperationException("Invalid operation. Stack is empty.");
        }

        public void Clear()
        {
            Array.Clear(array, 0, Count);

            Count = 0;            
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private readonly Stack<T> stack;
            private int index;
            private T currentElement;

            internal Enumerator(Stack<T> stack)
            {
                this.stack = stack;
                index = -2;
                currentElement = default;
            }

            public T Current
            {
                get
                {
                    if (index < 0)
                    {
                        throw new InvalidOperationException(index == -2 ? "Invalid Operation. Enumeration not started." :
                                                                          "Invalid operation. Enumeration not ended.");
                    }

                    return currentElement;
                }
            }

            object IEnumerator.Current { get { return Current; } }

            public void Dispose()
            {
                index = -1;
            }

            public bool MoveNext()
            {
                bool retval;
                if (index == -2) // First call to enumerator.
                { 
                    index = stack.Count - 1;
                    retval = (index >= 0);
                    if (retval)
                    {
                        currentElement = stack.array[index];
                    }
                    return retval;
                }

                if (index == -1) // End of enumeration.
                {  
                    return false;
                }

                retval = (--index >= 0);
                if (retval)
                {
                    currentElement = stack.array[index];
                }
                else
                {
                    currentElement = default;
                }
                return retval;
            }

            public void Reset()
            {
                index = -2;
                currentElement = default;
            }
        }
    }

}