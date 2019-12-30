using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Set<T> : IEnumerable<T> where T : class
    {
        private readonly Dictionary<T, object> data;

        public int Count
        {
            get { return data.Count; }
        }

        public Set()
        {
            data = new Dictionary<T, object>();
        }

        public Set(int capacity)
        {
            data = new Dictionary<T, object>(capacity);
        }

        public void Add(T item)
        {
            data[item] = null;
        }

        public void Clear()
        {
            data.Clear();
        }

        public bool Contains(T item)
        {
            return data.ContainsKey(item);
        }

        public bool Remove(T item)
        {
            return data.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item.Key;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item.Key;
            }
        }
    }
}
