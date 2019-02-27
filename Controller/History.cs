using System.Collections.Generic;

namespace Controller
{
    public class History<T> : IStack<T>
    {
        private readonly int capacity;
        private readonly List<T> history;

        public History() : this(20) { }

        public History(int capacity)
        {
            this.capacity = capacity;
            history = new List<T>(capacity);
        }

        public virtual T Pop()
        {
            if (history.Count == 0)
                return default(T);

            var diff = history[history.Count - 1];
            history.RemoveAt(history.Count - 1);

            return diff;
        }

        public virtual void Push(T value)
        {
            if (history.Count == capacity)
            {
                history.RemoveAt(0);
            }

            history.Add(value);
        }

        public virtual void Clear()
        {
            history.Clear();
        }
    }
}