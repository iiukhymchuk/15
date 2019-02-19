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

            var board = game.StartNewGame(4);
            SetInitialButtonValues(board, 4);
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
            //layout.Buttons[index].Text = index.ToString();
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

            var board = game.StartNewGame(size);
            SetInitialButtonValues(board, size);
        }

        private void SetInitialButtonValues(Board board, int size)
        {
            for (var i = 0; i < layout.Buttons.Count; i++)
            {
                var button = layout.Buttons[i];
                var (x, y) = Helpers.IndexToCoords(i, size);
                var numberToDisplay = board[x, y];
                var text = numberToDisplay == 0 ? "" : numberToDisplay.ToString();
                button.Text = text;
            }
        }
    }
}