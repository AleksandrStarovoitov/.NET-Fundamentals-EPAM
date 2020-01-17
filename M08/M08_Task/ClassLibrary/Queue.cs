using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] array;
        private int head; // The index from which to dequeue if the queue isn't empty.
        private int tail; // The index at which to enqueue if the queue isn't full.

        private const int MinimumGrow = 4;
        private const int GrowFactor = 200;  // double each time

        public int Count { get; private set; }

        public Queue()
        {
            array = Array.Empty<T>();
        }

        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Non-negative number required");
            }
            
            array = new T[capacity];
        }

        public void Enqueue(T item)
        {
            if (Count == array.Length)
            {
                int newcapacity = (int)(array.Length * (long)GrowFactor / 100);
                if (newcapacity < array.Length + MinimumGrow)
                {
                    newcapacity = array.Length + MinimumGrow;
                }

                SetCapacity(newcapacity);
            }

            array[tail] = item;
            MoveNext(ref tail);
            Count++;
        }

        private void MoveNext(ref int index)
        {
            int tmp = index + 1;
            if (tmp == array.Length)
            {
                tmp = 0;
            }
            index = tmp;
        }

        private void SetCapacity(int capacity)
        {
            T[] newarray = new T[capacity];
            if (Count > 0)
            {
                if (head < tail)
                {
                    Array.Copy(array, head, newarray, 0, Count);
                }
                else
                {
                    Array.Copy(array, head, newarray, 0, array.Length - head);
                    Array.Copy(array, 0, newarray, array.Length - head, tail);
                }
            }

            array = newarray;
            head = 0;
            tail = (Count == capacity) ? 0 : Count;
        }

        public T Dequeue()
        {
            int head = this.head;
            var array = this.array;

            if (Count == 0)
            {
                ThrowForEmptyQueue();
            }

            var removed = array[head];

            Count--;

            return removed;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                ThrowForEmptyQueue();
            }

            return array[head];
        }

        private void ThrowForEmptyQueue()
        {
            throw new InvalidOperationException("Invalid operation. Queue is empty.");
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        public void Clear()
        {
            if (Count != 0)
            {
                if (head < tail)
                {
                    Array.Clear(array, head, Count);
                }
                else
                {
                    Array.Clear(array, head, array.Length - head);
                    Array.Clear(array, 0, tail);
                }

                Count = 0;
            }

            head = 0;
            tail = 0;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private readonly Queue<T> _q;
            private int _index;   // -1 = not started, -2 = ended/disposed
            private T _currentElement;

            internal Enumerator(Queue<T> q)
            {
                _q = q;
                _index = -1;
                _currentElement = default;
            }

            public void Dispose()
            {
                _index = -2;
                _currentElement = default;
            }

            public bool MoveNext()
            {
                if (_index == -2)
                {
                    return false;
                }

                _index++;

                if (_index == _q.Count)
                {
                    // We've run past the last element
                    _index = -2;
                    _currentElement = default;
                    return false;
                }

                T[] array = _q.array;
                int capacity = array.Length;

                // _index represents the 0-based index into the queue, however the queue
                // doesn't have to start from 0 and it may not even be stored contiguously in memory.

                int arrayIndex = _q.head + _index; // this is the actual index into the queue's backing array
                if (arrayIndex >= capacity)
                {
                    arrayIndex -= capacity; // wrap around if needed
                }

                _currentElement = array[arrayIndex];
                return true;
            }

            public T Current
            {
                get
                {
                    if (_index < 0)
                    {
                        throw new InvalidOperationException(_index == -1 ? "Invalid Operation. Enumeration not started." :
                                                                      "Invalid operation. Enumeration not ended.");
                    }

                    return _currentElement;
                }
            }
            
            object IEnumerator.Current
            {
                get { return Current; }
            }

            void IEnumerator.Reset()
            {
                _index = -1;
                _currentElement = default;
            }
        }
    }
}
