using System.Collections.Generic;

namespace HairSystem.Optimization.Dirty
{
    public sealed class DirtyCollection
    {
        private readonly HashSet<int> _items;

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public DirtyCollection()
        {
            _items = new HashSet<int>();
        }

        public void Add(int index)
        {
            _items.Add(index);
        }

        public bool Remove(int index)
        {
            return _items.Remove(index);
        }

        public bool Contains(int index)
        {
            return _items.Contains(index);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public HashSet<int>.Enumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}