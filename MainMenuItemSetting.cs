using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TrayCPUTool.Config;

namespace TrayCPUTool
{
    public partial class MainMenuItemSetting : UserControl
    {
        private MainForm mainForm;

        Config config = new Config();
        public MainMenuItemSetting(MainForm parentForm)
        {
            InitializeComponent();

            mainForm = parentForm;

            if (config.configParameter.systemAdminEn)
                this.systemAdminCheckBox.Checked = true;
            if (config.configParameter.autoStartEn)
                this.autoStartCheckBox.Checked = true;

            this.gifPathTextBox.Text = config.configParameter.gifPath;
        }

        private void gifPathButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Files (*.gif)|*.gif";
                var result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    this.gifPathTextBox.Text = path;
                    config.ConfigWrite(configSection[(int)ConfigSectionEnum.CONFIG_SECTION_DEFAULT], configDefaultKey[(int)configDefaultKeyEnum.CONFIG_KEY_GIF_PATH], path);
                    mainForm.mainTrayGifAnimateStop();
                    mainForm.mainTrayGifAnimationSet(path);
                    mainForm.mainTrayGifAnimateLoadIcons();
                    mainForm.mainTrayGifAnimateStart(100);
                }
            }
        }

        private void systemAdminCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isCheck = this.systemAdminCheckBox.Checked;
            SystemAdmin.SystemAdminSet(isCheck);
            config.ConfigWrite(configSection[(int)ConfigSectionEnum.CONFIG_SECTION_DEFAULT], configDefaultKey[(int)configDefaultKeyEnum.CONFIG_KEY_SYSTEM_ADMIN], isCheck.ToString());
        }

        private void autoStartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isCheck = this.autoStartCheckBox.Checked;
            AutoStart.AutoStartSet(isCheck);
            config.ConfigWrite(configSection[(int)ConfigSectionEnum.CONFIG_SECTION_DEFAULT], configDefaultKey[(int)configDefaultKeyEnum.CONFIG_KEY_AUTO_START], isCheck.ToString());
        }

    }
}
