using Controller;
using System.Collections.Generic;

namespace Tests
{
    public class FakeHistory<T> : IStack<T>
    {
        private readonly List<T> history;

        public FakeHistory()
        {
            history = new List<T>();
        }

        public virtual T Pop()
        {
            var diff = history[history.Count - 1];
            history.RemoveAt(history.Count - 1);

            return diff;
        }

        public virtual void Push(T value)
        {
            history.Add(value);
        }

        public virtual void Clear()
        {
            history.Clear();
        }
    }
}