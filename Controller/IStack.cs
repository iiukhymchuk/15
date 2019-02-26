namespace Controller
{
    public interface IStack<T>
    {
        T Pop();
        void Push(T value);
        void Clear();
    }
}