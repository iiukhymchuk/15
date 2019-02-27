using System;

namespace Model
{
    public class Board : IBoard
    {
        private int size;
        private int[,] board;

        public static Board Singleton { get; set; } = new Board();
        public (int, int) BlankPosition { get; set; }

        private Board() { }

        public int GetItem(int x, int y)
        {
            if (x < 0 || x >= size) return -1;
            if (y < 0 || y >= size) return -1;
            return board[x, y];
        }

        public void SetItem(int x, int y, int value)
        {
            if (x < 0 || x >= size) return;
            if (y < 0 || y >= size) return;
            board[x, y] = value;
        }

        public void SetSize(int size)
        {
            if (size < 3 || size > 5)
                throw new InvalidOperationException("The size should be in range [3, 5].");

            this.size = size;
            board = new int[size, size];
        }

        public void SetWinPosition()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    board[x, y] = Helpers.CoordsToIndex(x, y, size) + 1;
                }
            int zeroPosition = size - 1;
            board[zeroPosition, zeroPosition] = 0;
            BlankPosition = (zeroPosition, zeroPosition);
        }
    }
}