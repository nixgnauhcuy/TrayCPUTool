namespace TrayCPUTool
{
    partial class MainMenuItemSetting
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
            gifPathLabel = new Label();
            gifPathTextBox = new TextBox();
            gifPathButton = new Button();
            autoStartCheckBox = new CheckBox();
            systemAdminCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // gifPathLabel
            // 
            gifPathLabel.AutoSize = true;
            gifPathLabel.Location = new Point(3, 9);
            gifPathLabel.Name = "gifPathLabel";
            gifPathLabel.Size = new Size(65, 17);
            gifPathLabel.TabIndex = 0;
            gifPathLabel.Text = "GIF PATH:";
            // 
            // gifPathTextBox
            // 
            gifPathTextBox.Location = new Point(74, 3);
            gifPathTextBox.Name = "gifPathTextBox";
            gifPathTextBox.ReadOnly = true;
            gifPathTextBox.Size = new Size(218, 23);
            gifPathTextBox.TabIndex = 1;
            // 
            // gifPathButton
            // 
            gifPathButton.Location = new Point(294, 0);
            gifPathButton.Name = "gifPathButton";
            gifPathButton.Size = new Size(37, 29);
            gifPathButton.TabIndex = 2;
            gifPathButton.Text = "...";
            gifPathButton.UseVisualStyleBackColor = true;
            gifPathButton.Click += gifPathButton_Click;
            // 
            // autoStartCheckBox
            // 
            autoStartCheckBox.AutoSize = true;
            autoStartCheckBox.Location = new Point(9, 32);
            autoStartCheckBox.Name = "autoStartCheckBox";
            autoStartCheckBox.Size = new Size(85, 21);
            autoStartCheckBox.TabIndex = 3;
            autoStartCheckBox.Text = "Auto Start";
            autoStartCheckBox.UseVisualStyleBackColor = true;
            autoStartCheckBox.CheckedChanged += autoStartCheckBox_CheckedChanged;
            // 
            // systemAdminCheckBox
            // 
            systemAdminCheckBox.AutoSize = true;
            systemAdminCheckBox.Location = new Point(115, 33);
            systemAdminCheckBox.Name = "systemAdminCheckBox";
            systemAdminCheckBox.Size = new Size(109, 21);
            systemAdminCheckBox.TabIndex = 4;
            systemAdminCheckBox.Text = "System Admin";
            systemAdminCheckBox.UseVisualStyleBackColor = true;
            systemAdminCheckBox.CheckedChanged += systemAdminCheckBox_CheckedChanged;
            // 
            // MainMenuItemSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(systemAdminCheckBox);
            Controls.Add(autoStartCheckBox);
            Controls.Add(gifPathButton);
            Controls.Add(gifPathTextBox);
            Controls.Add(gifPathLabel);
            Name = "MainMenuItemSetting";
            Size = new Size(334, 121);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label gifPathLabel;
        private TextBox gifPathTextBox;
        private Button gifPathButton;
        private CheckBox autoStartCheckBox;
        private CheckBox systemAdminCheckBox;
    }
}
