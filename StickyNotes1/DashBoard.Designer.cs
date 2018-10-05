namespace StickyNotes1
{
    partial class DashBoard
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.noteManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.userManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.stickiedChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOGOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noteManageToolStripMenuItem,
            this.categoryManageToolStripMenuItem,
            this.userManageToolStripMenuItem,
            this.stickiedChartToolStripMenuItem,
            this.searchNoteToolStripMenuItem,
            this.lOGOUTToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(929, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // noteManageToolStripMenuItem
            // 
            this.noteManageToolStripMenuItem.BackColor = System.Drawing.Color.Blue;
            this.noteManageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.listToolStripMenuItem});
            this.noteManageToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteManageToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow;
            this.noteManageToolStripMenuItem.Name = "noteManageToolStripMenuItem";
            this.noteManageToolStripMenuItem.Size = new System.Drawing.Size(145, 29);
            this.noteManageToolStripMenuItem.Text = "Note Manage";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(121, 30);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(121, 30);
            this.listToolStripMenuItem.Text = "List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // categoryManageToolStripMenuItem
            // 
            this.categoryManageToolStripMenuItem.BackColor = System.Drawing.Color.Blue;
            this.categoryManageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.listToolStripMenuItem1});
            this.categoryManageToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryManageToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow;
            this.categoryManageToolStripMenuItem.Name = "categoryManageToolStripMenuItem";
            this.categoryManageToolStripMenuItem.Size = new System.Drawing.Size(183, 29);
            this.categoryManageToolStripMenuItem.Text = "Category Manage";
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(121, 30);
            this.addToolStripMenuItem1.Text = "Add";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
            // 
            // listToolStripMenuItem1
            // 
            this.listToolStripMenuItem1.Name = "listToolStripMenuItem1";
            this.listToolStripMenuItem1.Size = new System.Drawing.Size(121, 30);
            this.listToolStripMenuItem1.Text = "List";
            this.listToolStripMenuItem1.Click += new System.EventHandler(this.listToolStripMenuItem1_Click);
            // 
            // userManageToolStripMenuItem
            // 
            this.userManageToolStripMenuItem.BackColor = System.Drawing.Color.Blue;
            this.userManageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem2,
            this.listToolStripMenuItem2});
            this.userManageToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userManageToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow;
            this.userManageToolStripMenuItem.Name = "userManageToolStripMenuItem";
            this.userManageToolStripMenuItem.Size = new System.Drawing.Size(141, 29);
            this.userManageToolStripMenuItem.Text = "User Manage";
            // 
            // addToolStripMenuItem2
            // 
            this.addToolStripMenuItem2.Name = "addToolStripMenuItem2";
            this.addToolStripMenuItem2.Size = new System.Drawing.Size(121, 30);
            this.addToolStripMenuItem2.Text = "Add";
            this.addToolStripMenuItem2.Click += new System.EventHandler(this.addToolStripMenuItem2_Click);
            // 
            // listToolStripMenuItem2
            // 
            this.listToolStripMenuItem2.Name = "listToolStripMenuItem2";
            this.listToolStripMenuItem2.Size = new System.Drawing.Size(121, 30);
            this.listToolStripMenuItem2.Text = "List";
            this.listToolStripMenuItem2.Click += new System.EventHandler(this.listToolStripMenuItem2_Click);
            // 
            // stickiedChartToolStripMenuItem
            // 
            this.stickiedChartToolStripMenuItem.BackColor = System.Drawing.Color.Blue;
            this.stickiedChartToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stickiedChartToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow;
            this.stickiedChartToolStripMenuItem.Name = "stickiedChartToolStripMenuItem";
            this.stickiedChartToolStripMenuItem.Size = new System.Drawing.Size(202, 29);
            this.stickiedChartToolStripMenuItem.Text = "Show Stickied Chart";
            this.stickiedChartToolStripMenuItem.Click += new System.EventHandler(this.stickiedChartToolStripMenuItem_Click);
            // 
            // searchNoteToolStripMenuItem
            // 
            this.searchNoteToolStripMenuItem.BackColor = System.Drawing.Color.Blue;
            this.searchNoteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchNoteToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow;
            this.searchNoteToolStripMenuItem.Name = "searchNoteToolStripMenuItem";
            this.searchNoteToolStripMenuItem.Size = new System.Drawing.Size(137, 29);
            this.searchNoteToolStripMenuItem.Text = "Note Search ";
            this.searchNoteToolStripMenuItem.Click += new System.EventHandler(this.searchNoteToolStripMenuItem_Click);
            // 
            // lOGOUTToolStripMenuItem
            // 
            this.lOGOUTToolStripMenuItem.BackColor = System.Drawing.Color.Red;
            this.lOGOUTToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lOGOUTToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow;
            this.lOGOUTToolStripMenuItem.Name = "lOGOUTToolStripMenuItem";
            this.lOGOUTToolStripMenuItem.Size = new System.Drawing.Size(109, 29);
            this.lOGOUTToolStripMenuItem.Text = "LOG-OUT";
            this.lOGOUTToolStripMenuItem.Click += new System.EventHandler(this.lOGOUTToolStripMenuItem_Click);
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.Color.SteelBlue;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 33);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(929, 405);
            this.panel.TabIndex = 1;
            //this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(929, 438);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DashBoard";
            this.Text = "DashBoard";
            this.Load += new System.EventHandler(this.DashBoard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem noteManageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryManageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem userManageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem2;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripMenuItem stickiedChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOGOUTToolStripMenuItem;
    }
}