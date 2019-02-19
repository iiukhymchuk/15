using Model;
using System.Collections.Generic;

namespace Controller
{
    class History<T>
    {
        private readonly int maxCapacity;
        private int currentIndex;
        private int capacity;
        private readonly int limit;
        private readonly List<T> hist;

        public History(int maxCapacity)
        {
            this.maxCapacity = maxCapacity;
            currentIndex = 0;
            capacity = 0;
            limit = 20;
            hist = new List<T>(limit);
        }

        public T Pop()
        {
            if (capacity == 0)
                return default(T);
            T r = hist[currentIndex];
            hist.RemoveAt(currentIndex);
            currentIndex = (maxCapacity + currentIndex - 1) % maxCapacity;
            capacity--;
            return r;
        }

        public void Push(T value)
        {
            if (capacity <= maxCapacity)
            {
                capacity++;
            }

            var index = (currentIndex) % maxCapacity;
            if (index == hist.Count)
                hist.Insert(index, value);
            else
                hist[index] = value;
        }
    }
}