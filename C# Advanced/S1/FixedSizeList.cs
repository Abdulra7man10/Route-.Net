using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1
{
    public class FixedSizeList<T>
    {
        private T[] _items;
        private int _count;
        private readonly int _capacity;

        public FixedSizeList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be a positive integer.");
            }
            _capacity = capacity;
            _items = new T[capacity];
            _count = 0;
        }

        public int Count => _count;

        public int Capacity => _capacity;

        public void Add(T item)
        {
            if (_count >= _capacity)
            {
                throw new InvalidOperationException($"Cannot add more elements. The list full with capacity: {_capacity} :(");
            }

            _items[_count] = item;
            _count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                string message = $"Invalid index: {index}. The valid index range is 0 to {_count - 1}.";
                if (_count == 0)
                {
                    message = "The list is currently empty, and index 0 cannot be accessed.";
                }
                throw new IndexOutOfRangeException(message);
            }

            return _items[index];
        }
    }
}
