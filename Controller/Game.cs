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
        private IBoard board;
        private IStack<BoardDifference> history;

        private static readonly Random random = new Random();

        public Game(int size, int mode, IBoard board = null, IStack<BoardDifference> history = null)
        {
            this.board = board ?? Board.Singleton;
            this.history = history ?? new History<BoardDifference>(20);
            StartNewGame(size, mode);
        }

        public IBoard StartNewGame(int size, int modeNumber)
        {
            SetSize(size);
            SetBoard();

            var number = 50 + 50 * 2 * modeNumber;
            Enumerable.Range(0, number).ToList().ForEach(x => ShuffleBoard());

            return board;
        }

        public void ExecuteCommand(ICommand command)
        {
            var saveToHistory = command.Execute();
            if (saveToHistory)
            {
                var previousPositionOfSpace = board.BlankPosition;
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
            var value = board.GetItem(x, y);
            if (value == -1) return false; ;
            board.SetItem(x, y, 0);

            var (_x, _y) = board.BlankPosition;
            board.SetItem(_x, _y, value);
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
            var value = board.GetItem(x, y);
            if (value == -1)
                return;
            board.SetItem(x, y, 0);
            board.BlankPosition = diff.PreviousPositionOfSpace;

            var (_x, _y) = diff.PositionOfSpace;
            board.SetItem(_x, _y, value);
        }
    }
}