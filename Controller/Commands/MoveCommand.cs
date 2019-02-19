using Model;

namespace Controller
{
    public class MoveCommand : ICommand
    {
        private readonly int index;
        private readonly Game game;

        public MoveCommand(int index, Game game)
        {
            this.index = index;
            this.game = game;
        }

        public void Execute()
        {
            game.MoveSquare(index);
        }
    }
}