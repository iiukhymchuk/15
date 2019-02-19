using System.Linq;

namespace Controller
{
    public class MoveThreeRandomCommand : ICommand
    {
        private readonly Game game;

        public MoveThreeRandomCommand(Game game)
        {
            this.game = game;
        }

        public bool Execute()
        {
            Enumerable.Range(0, 3).ToList().ForEach(x => game.ShuffleBoard());
            return false;
        }
    }
}