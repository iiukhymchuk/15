using Model;
using System;
using System.Linq;

namespace Controller
{
    public class Game
    {
        private int size;
        private int spaceX;
        private int spaceY;
        private Board board = Board.Singleton;
        private History<BoardDifference> history = new History<BoardDifference>(20);

        private static readonly Random random = new Random();

        public static Game Singleton { get; } = new Game(4, 1);

        private Game(int size, int mode)
        {
            StartNewGame(size, mode);
        }

        public Board StartNewGame(int size, int mode)
        {
            SetSize(size);
            SetBoard();

            var number = 50 + 50 * 2 * mode;
            Enumerable.Range(0, number).ToList().ForEach(x => ShuffleBoard());

            return board;
        }

        public void ExecuteCommand(ICommand command)
        {
            var previousPositionOfSpace = board.BlankPosition;
            var saveToHistory = command.Execute();
            if (saveToHistory)
            {
                var memento = new BoardDifference
                {
                    PositionOfSpace = board.BlankPosition,
                    PreviousPositionOfSpace = previousPositionOfSpace
                };

                history.Push(memento);
            }
            else
            {
                history.Clear();
            }
        }

        public void Undo()
        {
            var memento = history.Pop();
            if (memento != null)
            {
                RevertBoardState(memento);
            }
        }

        public bool MoveSquare(int index)
        {
            var (x, y) = Helpers.IndexToCoords(index, size);
            return MoveSquareInternal(x, y);
        }

        private bool MoveSquareInternal(int x, int y)
        {
            var value = board[x, y];
            if (value == -1) return false; ;
            board[x, y] = 0;

            var (_x, _y) = board.BlankPosition;
            board[_x, _y] = value;
            board.BlankPosition = (x, y);

            return true;
        }

        private void SetSize(int size)
        {
            if (size < 2) size = 2;
            if (size > 5) size = 5;
            this.size = size;
            spaceX = spaceY = size - 1;
        }

        private void SetBoard()
        {
            board.SetSize(size);
            board.SetWinPosition();
        }

        internal void ShuffleBoard()
        {
            int number = random.Next(4);
            int x;
            int y;
            do
            {
                x = spaceX;
                y = spaceY;
                switch (number)
                {
                    case 0: x--; break;
                    case 1: x++; break;
                    case 2: y--; break;
                    case 3: y++; break;
                }
                number = (number + 1) % 4;
            }
            while (!MoveSquareInternal(x, y));
            spaceX = x;
            spaceY = y;
            board.BlankPosition = (x, y);
        }

        private void RevertBoardState(BoardDifference diff)
        {
            var (x, y) = diff.PreviousPositionOfSpace;
            var value = board[x, y];
            if (value == -1)
                return;
            board[x, y] = 0;
            board.BlankPosition = diff.PreviousPositionOfSpace;

            var (_x, _y) = diff.PositionOfSpace;
            board[_x, _y] = value;
        }
    }
}