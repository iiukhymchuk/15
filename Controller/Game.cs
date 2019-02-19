using Model;

namespace Controller
{
    public class Game
    {
        private int size;
        private int spaceX;
        private int spaceY;
        private Board board = Board.Singleton;

        public static Game Singleton { get; } = new Game(4);

        private Game(int size)
        {
            StartNewGame(size);
        }

        public Board StartNewGame(int size)
        {
            SetSize(size);
            return SetBoard();
        }

        private void SetSize(int size)
        {
            if (size < 2) size = 2;
            if (size > 5) size = 5;
            this.size = size;
            spaceX = spaceY = size - 1;
        }

        private Board SetBoard()
        {
            board.SetSize(size);

            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    board[x, y] = Helpers.CoordsToIndex(x, y, size) + 1;
                }

            board[spaceX, spaceY] = 0;

            return board;
        }
    }
}