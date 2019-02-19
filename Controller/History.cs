using Model;
using System.Collections.Generic;

namespace Controller
{
    class History<T>
    {
        private readonly int capacity;
        private readonly List<T> history;

        public History(int capacity)
        {
            capacity = 5;
            this.capacity = capacity;
            history = new List<T>(capacity);
        }

        public T Pop()
        {
            if (history.Count == 0)
                return default(T);

            var diff = history[history.Count - 1];
            history.RemoveAt(history.Count - 1);

            return diff;
        }

        public void Push(T value)
        {
            if (history.Count == capacity)
            {
                history.RemoveAt(0);
            }

            history.Add(value);
        }
    }
}