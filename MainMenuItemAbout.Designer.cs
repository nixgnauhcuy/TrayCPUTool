namespace TrayCPUTool
{
    partial class MainMenuItemAbout
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            titleLabel = new Label();
            titlePictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)titlePictureBox).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold);
            titleLabel.Location = new Point(40, 16);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(136, 26);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "TrayCPUTool";
            // 
            // titlePictureBox
            // 
            titlePictureBox.Image = Properties.Resources.main_png;
            titlePictureBox.Location = new Point(3, 11);
            titlePictureBox.Name = "titlePictureBox";
            titlePictureBox.Size = new Size(33, 35);
            titlePictureBox.TabIndex = 1;
            titlePictureBox.TabStop = false;
            // 
            // MainMenuItemAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(titlePictureBox);
            Controls.Add(titleLabel);
            Name = "MainMenuItemAbout";
            Size = new Size(334, 121);
            ((System.ComponentModel.ISupportInitialize)titlePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private PictureBox titlePictureBox;
    }
}
