using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace View
{
    public partial class Fifteen : Form
    {
        private TableLayoutPanel tableLayoutPanel;
        private List<Button> buttons;

        private TableLayoutPanel size3TableLayoutPanel;
        private TableLayoutPanel size4TableLayoutPanel;
        private TableLayoutPanel size5TableLayoutPanel;

        private List<Button> size3Buttons;
        private List<Button> size4Buttons;
        private List<Button> size5Buttons;

        private List<ToolStripMenuItem> MenuGameModes;
        private List<ToolStripMenuItem> MenuGameSizes;

        public Fifteen()
        {
            SetUpLayout();
            InitializeComponent();
            SetUpInitialParameters();
        }

        private void SetUpLayout()
        {
            size3Buttons = CreateButtons(9);
            size4Buttons = CreateButtons(16);
            size5Buttons = CreateButtons(25);

            buttons = size4Buttons;

            size3TableLayoutPanel = GetTableLayoutPanel(3);
            size4TableLayoutPanel = GetTableLayoutPanel(4);
            size5TableLayoutPanel = GetTableLayoutPanel(5);

            tableLayoutPanel = size4TableLayoutPanel;
            tableLayoutPanel.Location = new Point(0, 24);

            tableLayoutPanel.SuspendLayout();
            this.Controls.Add(this.tableLayoutPanel);
            this.tableLayoutPanel.ResumeLayout(false);
        }

        private List<Button> CreateButtons(int length)
        {
            var list = new List<Button>(length);
            for (int i = 0; i < length; i++)
            {
                list.Add(CreateButton(i));
            }
            return list;
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

        private Button CreateButton(int index)
        {
            var indexText = index.ToString();
            var button = new Button();
            button.Dock = DockStyle.Fill;
            button.Font = new Font("Mistral", 47F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(204)));
            button.Margin = new Padding(10);
            button.Name = "button" + indexText;
            button.Size = new Size(124, 113);
            button.TabIndex = index;
            button.Tag = indexText;
            button.Text = "-";
            button.UseVisualStyleBackColor = true;
            button.Click += this.ButtonClick;

            return button;
        }

        private TableLayoutPanel GetTableLayoutPanel(int size)
        {
            var tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Location = new Point(0, 24);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel.TabIndex = 0;
            tableLayoutPanel.Size = new Size(584, 537);

            tableLayoutPanel.ColumnCount = size;
            tableLayoutPanel.RowCount = size;
            for (int i = 0; i < size; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / size));
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / size));
            }

            int count = 0;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    var button = GetCachedButtons(size)[count++];
                    tableLayoutPanel.Controls.Add(button, y, x);
                }
            }
            return tableLayoutPanel;
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
            return buttons[index] ?? (buttons[index] = CreateButton(index));
            //return tableLayoutPanel.Controls
            //    .Cast<Control>()
            //    .First(i => i.Tag.ToString() == index.ToString()) as Button;
        }

        private void MenuStartGameClick(object sender, EventArgs e)
        {
            var selectedGameSize = MenuGameSizes.First(x => x.Checked);
            var size = Convert.ToInt16(selectedGameSize.Tag);

            tableLayoutPanel.SuspendLayout();

            Controls.Remove(tableLayoutPanel);

            tableLayoutPanel = GetCachedTableLayoutPanel(size);
            buttons = GetCachedButtons(size);

            Controls.Remove(menu);
            Controls.Add(tableLayoutPanel);
            Controls.Add(menu);
            tableLayoutPanel.ResumeLayout(false);
        }

        private TableLayoutPanel GetCachedTableLayoutPanel(int size)
        {
            switch (size)
            {
                case 3: return size3TableLayoutPanel;
                case 4: return size4TableLayoutPanel;
                case 5: return size5TableLayoutPanel;
                default: return null;
            }
        }

        private List<Button> GetCachedButtons(int size)
        {
            switch (size)
            {
                case 3: return size3Buttons;
                case 4: return size4Buttons;
                case 5: return size5Buttons;
                default: return null;
            }
        }
    }
}