namespace Model
{
    public interface IBoard
    {
        (int, int) BlankPosition { get; set; }
        int GetItem(int x, int y);
        void SetItem(int x, int y, int value);
        void SetSize(int size);
        void SetWinPosition();
    }
}