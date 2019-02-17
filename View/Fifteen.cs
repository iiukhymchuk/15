using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace View
{
    public partial class Fifteen : Form
    {
        List<ToolStripMenuItem> MenuGameModes;
        List<ToolStripMenuItem> MenuGameSizes;

        public Fifteen()
        {
            InitializeComponent();
            SetUpInitialParameters();
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
            GetButton(index).Text = index.ToString();
        }

        private void MenuGameModeClick(object sender, EventArgs e)
        {
            MenuGameModes.UncheckOtherMenuItems((ToolStripMenuItem)sender);
        }

        private void MenuGameSizeClick(object sender, EventArgs e)
        {
            MenuGameSizes.UncheckOtherMenuItems((ToolStripMenuItem)sender);
        }

        private Button GetButton(int index)
        {
            return tableLayoutPanel.Controls
                .Cast<Control>()
                .First(i => i.Tag.ToString() == index.ToString()) as Button;
        }
    }
}