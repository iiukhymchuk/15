namespace View
{
    partial class Fifteen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fifteen));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.gameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.startGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardrandomMovesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameMenu,
            this.optionsMenu});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(584, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // gameMenu
            // 
            this.gameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startGameToolStripMenuItem,
            this.toolStripMenuItem2,
            this.undoToolStripMenuItem});
            this.gameMenu.Name = "gameMenu";
            this.gameMenu.Size = new System.Drawing.Size(50, 20);
            this.gameMenu.Text = "Game";
            // 
            // startGameToolStripMenuItem
            // 
            this.startGameToolStripMenuItem.Name = "startGameToolStripMenuItem";
            this.startGameToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.startGameToolStripMenuItem.Text = "New game";
            this.startGameToolStripMenuItem.Click += new System.EventHandler(this.MenuStartGameClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(141, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoClick);
            // 
            // optionsMenu
            // 
            this.optionsMenu.CheckOnClick = true;
            this.optionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.hardrandomMovesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.x3ToolStripMenuItem,
            this.x4ToolStripMenuItem,
            this.x5ToolStripMenuItem});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(61, 20);
            this.optionsMenu.Text = "Options";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.CheckOnClick = true;
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.easyToolStripMenuItem.Tag = "easy";
            this.easyToolStripMenuItem.Text = "Easy";
            this.easyToolStripMenuItem.Click += new System.EventHandler(this.MenuGameModeClick);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.CheckOnClick = true;
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.normalToolStripMenuItem.Tag = "normal";
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.MenuGameModeClick);
            // 
            // hardrandomMovesToolStripMenuItem
            // 
            this.hardrandomMovesToolStripMenuItem.CheckOnClick = true;
            this.hardrandomMovesToolStripMenuItem.Name = "hardrandomMovesToolStripMenuItem";
            this.hardrandomMovesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.hardrandomMovesToolStripMenuItem.Tag = "hard";
            this.hardrandomMovesToolStripMenuItem.Text = "Hard (with random moves)";
            this.hardrandomMovesToolStripMenuItem.Click += new System.EventHandler(this.MenuGameModeClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(214, 6);
            // 
            // x3ToolStripMenuItem
            // 
            this.x3ToolStripMenuItem.CheckOnClick = true;
            this.x3ToolStripMenuItem.Name = "x3ToolStripMenuItem";
            this.x3ToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.x3ToolStripMenuItem.Tag = "3";
            this.x3ToolStripMenuItem.Text = "3 x 3";
            this.x3ToolStripMenuItem.Click += new System.EventHandler(this.MenuGameSizeClick);
            // 
            // x4ToolStripMenuItem
            // 
            this.x4ToolStripMenuItem.CheckOnClick = true;
            this.x4ToolStripMenuItem.Name = "x4ToolStripMenuItem";
            this.x4ToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.x4ToolStripMenuItem.Tag = "4";
            this.x4ToolStripMenuItem.Text = "4 x 4";
            this.x4ToolStripMenuItem.Click += new System.EventHandler(this.MenuGameSizeClick);
            // 
            // x5ToolStripMenuItem
            // 
            this.x5ToolStripMenuItem.CheckOnClick = true;
            this.x5ToolStripMenuItem.Name = "x5ToolStripMenuItem";
            this.x5ToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.x5ToolStripMenuItem.Tag = "5";
            this.x5ToolStripMenuItem.Text = "5 x 5";
            this.x5ToolStripMenuItem.Click += new System.EventHandler(this.MenuGameSizeClick);
            // 
            // Fifteen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "Fifteen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fifteen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fifteen_FormClosing);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem gameMenu;
        private System.Windows.Forms.ToolStripMenuItem startGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsMenu;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardrandomMovesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem x3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x5ToolStripMenuItem;
    }
}
