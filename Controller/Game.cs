using Model;

namespace Controller
{
    public class Game
    {
        private int size;
        private int spaceX;
        private int spaceY;
        private Board board = Board.Singleton;
        private History<BoardDifference> history = new History<BoardDifference>(20);

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

        public void ExecuteCommand(ICommand command)
        {
            var previousPositionOfSpace = board.PositionOfSpace;
            command.Execute();
            var memento = new BoardDifference
            {
                PositionOfSpace = board.PositionOfSpace,
                PreviousPositionOfSpace = previousPositionOfSpace
            };

            history.Push(memento);
        }

        public void Undo()
        {
            var memento = history.Pop();
            RevertBoardState(memento);
        }

        public void MoveSquare(int index)
        {
            var (x, y) = Helpers.IndexToCoords(index, size);
            var value = board[x, y];
            board[x, y] = 0;

            var (_x, _y) = board.PositionOfSpace;
            board[_x, _y] = value;
            board.PositionOfSpace = (x, y);
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
            board.PositionOfSpace = (spaceX, spaceY);

            return board;
        }

        private void RevertBoardState(BoardDifference diff)
        {
            var (x, y) = diff.PositionOfSpace;
            var value = board[x, y];
            board[x, y] = 0;
            board.PositionOfSpace = diff.PositionOfSpace;

            var (_x, _y) = diff.PreviousPositionOfSpace;
            board[_x, _y] = value;
        }
    }
}