namespace TrayCPUTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip = new MenuStrip();
            menuItemSetting = new ToolStripMenuItem();
            menuItemAbout = new ToolStripMenuItem();
            mainPanel = new Panel();
            mainNotifyIcon = new NotifyIcon(components);
            mainNotifyContextMenuStrip = new ContextMenuStrip(components);
            exitToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            mainNotifyContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { menuItemSetting, menuItemAbout });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(334, 25);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // menuItemSetting
            // 
            menuItemSetting.Name = "menuItemSetting";
            menuItemSetting.Size = new Size(44, 21);
            menuItemSetting.Text = "设置";
            menuItemSetting.Click += menuItemSetting_Click;
            // 
            // menuItemAbout
            // 
            menuItemAbout.Name = "menuItemAbout";
            menuItemAbout.Size = new Size(44, 21);
            menuItemAbout.Text = "关于";
            menuItemAbout.Click += menuItemAbout_Click;
            // 
            // mainPanel
            // 
            mainPanel.Location = new Point(0, 28);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(334, 121);
            mainPanel.TabIndex = 1;
            // 
            // mainNotifyIcon
            // 
            mainNotifyIcon.ContextMenuStrip = mainNotifyContextMenuStrip;
            mainNotifyIcon.Icon = (Icon)resources.GetObject("mainNotifyIcon.Icon");
            mainNotifyIcon.Text = "TrayCPUTool";
            mainNotifyIcon.Visible = true;
            mainNotifyIcon.MouseClick += mainNotifyIcon_MouseClick;
            // 
            // mainNotifyContextMenuStrip
            // 
            mainNotifyContextMenuStrip.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            mainNotifyContextMenuStrip.Name = "mainNotifyContextMenuStrip";
            mainNotifyContextMenuStrip.Size = new Size(181, 48);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = Properties.Resources.exit;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 161);
            Controls.Add(mainPanel);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "MainForm";
            Text = "TrayCPUTool";
            FormClosing += MainForm_FormClosing;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            mainNotifyContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem menuItemSetting;
        private ToolStripMenuItem menuItemAbout;
        private Panel mainPanel;
        private NotifyIcon mainNotifyIcon;
        private ContextMenuStrip mainNotifyContextMenuStrip;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}
