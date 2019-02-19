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
        private Board board;

        private List<ToolStripMenuItem> MenuGameModes;
        private List<ToolStripMenuItem> MenuGameSizes;

        public Fifteen()
        {
            layoutCreators = new LayoutCreators(ButtonClick);
            game = Game.Singleton;
            SetUpLayout();
            InitializeComponent();
            SetUpInitialParameters();
        }

        private void SetUpLayout()
        {
            var layoutCreator = layoutCreators[4];
            layout = layoutCreator.CreateLayout();

            layout.Panel.SuspendLayout();
            Controls.Add(layout.Panel);
            layout.Panel.ResumeLayout(false);

            board = game.StartNewGame(4);
            SetButtonValues(board);
        }

        private void SetUpInitialParameters()
        {
            this.normalToolStripMenuItem.Checked = true;
            MenuGameModes = new List<ToolStripMenuItem>
            {
                easyToolStripMenuItem,
                normalToolStripMenuItem,
                hardrandomMovesToolStripMenuItem
            };

            this.x4ToolStripMenuItem.Checked = true;
            MenuGameSizes = new List<ToolStripMenuItem>
            {
                x3ToolStripMenuItem,
                x4ToolStripMenuItem,
                x5ToolStripMenuItem
            };
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            int index = Convert.ToInt16(((Button)sender).Tag);
            if (IsNeighbor(index))
            {
                game.ExecuteCommand(new MoveCommand(index, game));
                SetButtonValues(board);
            }
        }

        private void UndoClick(object sender, EventArgs e)
        {

        }

        private bool IsNeighbor(int index)
        {
            var (x, y) = Helpers.IndexToCoords(index, layout.Size);
            var (zeroX, zeroY) = board.PositionOfSpace;
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

            board = game.StartNewGame(size);
            SetButtonValues(board);
        }

        private void SetButtonValues(Board board)
        {
            for (var i = 0; i < layout.Buttons.Count; i++)
            {
                var button = layout.Buttons[i];
                var (x, y) = Helpers.IndexToCoords(i, layout.Size);
                var numberToDisplay = board[x, y];
                SetButton(button, numberToDisplay);
            }
        }

        private void SetButton(Button button, int value)
        {
            button.Text = value.ToString();
            button.Visible = value > 0;
        }
    }
}