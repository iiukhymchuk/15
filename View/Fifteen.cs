using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace View
{
    public partial class Fifteen : Form
    {
        private LayoutCreators layoutCreators;
        private ILayout layout;
        private Game game;
        private IBoard board;
        private static readonly Random random = new Random();

        private List<ToolStripMenuItem> MenuGameModes;
        private List<ToolStripMenuItem> MenuGameSizes;

        public Fifteen()
        {
            layoutCreators = new LayoutCreators(ButtonClick);
            game = new Game(4, 1, Board.Singleton);
            SetUpLayout();
            InitializeComponent();
            SetUpInitialParameters();
        }

        private void SetUpLayout()
        {
            var (mode, size) = XmlManager.Load();
            var modeNumber = Helpers.GetModeNumber(mode);

            var layoutCreator = layoutCreators[size];
            layout = layoutCreator.CreateLayout();

            layout.Panel.SuspendLayout();
            Controls.Add(layout.Panel);
            layout.Panel.ResumeLayout(false);

            board = game.StartNewGame(size, modeNumber);
            SetButtonValues(board);
        }

        private void SetUpInitialParameters()
        {
            var (mode, size) = XmlManager.Load();

            MenuGameModes = new List<ToolStripMenuItem>
            {
                easyToolStripMenuItem,
                normalToolStripMenuItem,
                hardrandomMovesToolStripMenuItem
            };

            var selectedMode = MenuGameModes.FirstOrDefault(x => x.Tag.ToString() == mode);
            selectedMode.Checked = true;

            MenuGameSizes = new List<ToolStripMenuItem>
            {
                x3ToolStripMenuItem,
                x4ToolStripMenuItem,
                x5ToolStripMenuItem
            };
            var selectedSize = MenuGameSizes.FirstOrDefault(x => x.Tag.ToString() == size.ToString());
            selectedSize.Checked = true;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int index = Convert.ToInt16(button.Tag);
            if (IsNeighbor(index))
            {
                var selectedGameMode = MenuGameModes.First(x => x.Checked);
                var mode = Helpers.GetModeNumber(selectedGameMode.Tag.ToString());
                if (random.NextDouble() < mode * 0.05)
                {
                    game.ExecuteCommand(new MoveThreeRandomCommand(game));
                }
                else
                {
                    game.ExecuteCommand(new MoveCommand(index, game));
                }

                SetButtonValues(board);
            }
        }

        private void UndoClick(object sender, EventArgs e)
        {
            game.Undo();
            SetButtonValues(board);
        }

        private bool IsNeighbor(int index)
        {
            var (x, y) = Model.Helpers.IndexToCoords(index, layout.Size);
            var (zeroX, zeroY) = board.BlankPosition;
            return Math.Abs(x - zeroX) + Math.Abs(y - zeroY) == 1;
        }

        private void MenuGameModeClick(object sender, EventArgs e)
        {
            MenuGameModes.UncheckOtherMenuItems((ToolStripMenuItem)sender);
        }

        private void MenuGameSizeClick(object sender, EventArgs e)
        {
            MenuGameSizes.UncheckOtherMenuItems((ToolStripMenuItem)sender);
        }

        private void MenuStartGameClick(object sender, EventArgs e)
        {
            var selectedGameSize = MenuGameSizes.First(x => x.Checked);
            var size = Convert.ToInt16(selectedGameSize.Tag);

            var layoutCreator = layoutCreators[size];

            Controls.Remove(layout.Panel);
            layout = layoutCreator.CreateLayout();
            Controls.Remove(menu);

            layout.Panel.SuspendLayout();
            Controls.Add(layout.Panel);
            Controls.Add(menu);

            layout.Panel.ResumeLayout(false);

            var selectedGameMode = MenuGameModes.First(x => x.Checked);
            var mode = Helpers.GetModeNumber(selectedGameMode.Tag.ToString());

            board = game.StartNewGame(size, mode);
            SetButtonValues(board);
        }

        private void SetButtonValues(IBoard board)
        {
            for (var i = 0; i < layout.Buttons.Count; i++)
            {
                var button = layout.Buttons[i];
                var (x, y) = Model.Helpers.IndexToCoords(i, layout.Size);
                var numberToDisplay = board.GetItem(x, y);
                SetButton(button, numberToDisplay);
            }
        }

        private void SetButton(Button button, int value)
        {
            button.Text = value.ToString();
            button.Visible = value > 0;
        }

        private void Fifteen_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mode = MenuGameModes.FirstOrDefault(x => x.Checked)?.Tag?.ToString();
            var size = MenuGameSizes.FirstOrDefault(x => x.Checked)?.Tag?.ToString();

            var isParsed = int.TryParse(size, out int sizeInt);

            if (isParsed && mode != null)
            {
                XmlManager.Save(mode, sizeInt);
            }
        }
    }
}