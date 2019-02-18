using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    class Layout : ILayout
    {
        public int Size { get; private set; }
        public List<Button> Buttons { get; private set; }
        public TableLayoutPanel Panel { get; private set; }

        private Layout() { }

        public class Builder
        {
            private Layout layout;

            public Builder()
            {
                layout = new Layout
                {
                    Size = -1
                };
            }

            public Builder SetPanelSize(int size)
            {
                layout.Size = size;
                return this;
            }

            public Builder SetButtons(EventHandler handler)
            {
                int size = layout.Size;
                if (size == -1)
                {
                    throw new InvalidOperationException("Panel size should be set before buttons.");
                }

                int number = size * size;
                var list = new List<Button>(number);
                for (int i = 0; i < number; i++)
                {
                    list.Add(CreateButton(i, handler));
                }
                layout.Buttons = list;
                return this;
            }

            public Builder SetPanel()
            {
                int size = layout.Size;
                List<Button> buttons = layout.Buttons;
                if (buttons is null)
                {
                    throw new InvalidOperationException("Buttons should be set before panel.");
                }

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
                        var button = buttons[count++];
                        tableLayoutPanel.Controls.Add(button, y, x);
                    }
                }
                layout.Panel = tableLayoutPanel;
                return this;
            }

            public Layout Build()
            {
                if (layout is null)
                {
                    throw new InvalidOperationException("Build method should be called once.");
                }

                var result = layout;
                layout = null;
                return result;
            }

            private Button CreateButton(int index, EventHandler handler)
            {
                var indexText = index.ToString();
                var button = new Button();
                button.Dock = DockStyle.Fill;
                button.Font = new Font("Mistral", 47F, FontStyle.Italic, GraphicsUnit.Point, 204);
                button.Margin = new Padding(10);
                button.Name = "button" + indexText;
                button.Size = new Size(124, 113);
                button.TabIndex = index;
                button.Tag = indexText;
                button.Text = "-";
                button.UseVisualStyleBackColor = true;
                button.Click += handler;

                return button;
            }
        }
    }
}