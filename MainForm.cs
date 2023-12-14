using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using static TrayCPUTool.Config;

namespace TrayCPUTool
{
    public partial class MainForm : Form
    {
        private MainMenuItemSetting settingControl;
        private MainMenuItemAbout aboutControl;

        private Config config = new Config();
        private ComputerCpu cpu = new ComputerCpu();

        private System.Windows.Forms.Timer uiTimer = new System.Windows.Forms.Timer();
        private static int uiTimerInterval = 100;

        private static bool windowCreateFlag = true;
        private static bool keepAnimationAlive = false;
        private static bool iconsLoadedFlag = false;

        private const string imagePath = @".\image";
        private const string icoPath = @".\ico";

        private static int animationCounter = 0;
        private static int iconsArrayCounter = 0;
        private Icon[] iconsArray = Array.Empty<Icon>();


        public MainForm()
        {
            InitializeComponent();

            settingControl = new MainMenuItemSetting(this);
            aboutControl = new MainMenuItemAbout();

            mainPanel.Controls.Add(settingControl);

            uiTimer = new System.Windows.Forms.Timer();
            uiTimer.Interval = uiTimerInterval;
            uiTimer.Tick += new EventHandler(uiTimerUpdateUI);

            mainTrayGifAnimationSet(config.configParameter.gifPath);
            mainTrayGifAnimateLoadIcons();
            mainTrayGifAnimateStart(uiTimerInterval);
        }

        private void uiTimerUpdateUICb()
        {
            if (keepAnimationAlive == false)
            {
                uiTimer.Stop();
                animationCounter = 0;
            }
            else
            {
                this.mainNotifyIcon.Icon = (Icon)iconsArray[animationCounter];
                if (++animationCounter == iconsArrayCounter)
                    animationCounter = 0;

                uiTimer.Interval = (101 - (int)cpu.cpuUtilizationGet());
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            if (windowCreateFlag)
            {
                base.Visible = false;
                windowCreateFlag = false;
            }
            base.OnActivated(e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void menuItemSetting_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(settingControl);
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(aboutControl);
        }

        private void mainNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            if (this.Visible)
            {
                this.Visible = false;
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        public void mainTrayGifAnimateStart(int timerinterval)
        {
            if (iconsLoadedFlag)
                return;

            if (iconsArrayCounter > 0)
            {
                uiTimer.Interval = (timerinterval > 1000 || timerinterval < 100) ? 100 : timerinterval;
                keepAnimationAlive = true;
                uiTimer.Start();
            }
        }

        public void mainTrayGifAnimateStop()
        {
            if (iconsLoadedFlag)
                return;

            animationCounter = 0;
            keepAnimationAlive = false;
            uiTimer.Stop();
        }


        public static bool mainPngToIcon(string origin, string destination, Size iconSize)
        {
            if (iconSize.Width > 255 || iconSize.Height > 255) { return false; }

            Image image = new Bitmap(new Bitmap(origin), iconSize);
            MemoryStream bitMapStream = new MemoryStream();
            MemoryStream iconStream = new MemoryStream();
            image.Save(bitMapStream, ImageFormat.Png);
            BinaryWriter iconWriter = new BinaryWriter(iconStream);

            iconWriter.Write((short)0);
            iconWriter.Write((short)1);
            iconWriter.Write((short)1);
            iconWriter.Write((byte)image.Width);
            iconWriter.Write((byte)image.Height);
            iconWriter.Write((short)0);
            iconWriter.Write((short)0);
            iconWriter.Write((short)32);
            iconWriter.Write((int)bitMapStream.Length);
            iconWriter.Write(22);
            iconWriter.Write(bitMapStream.ToArray());
            iconWriter.Flush();
            iconWriter.Seek(0, SeekOrigin.Begin);

            Stream iconFileStream = new FileStream(destination, FileMode.Create);
            Icon icon = new Icon(iconStream);
            icon.Save(iconFileStream);

            iconFileStream.Close();
            iconWriter.Close();
            iconStream.Close();
            bitMapStream.Close();
            iconFileStream.Dispose();
            iconWriter.Dispose();
            iconStream.Dispose();
            bitMapStream.Dispose();
            icon.Dispose();
            image.Dispose();
            return File.Exists(destination);
        }

        public int mainTrayGifAnimateLoadIcons()
        {
            int tmpCounter, validNum = 0;
            Icon tmpIcon;

            iconsLoadedFlag = true;
            iconsArrayCounter = 0;

            if (!Directory.Exists(icoPath))
                return -1;

            tmpCounter = Directory.GetFiles(icoPath, "*.ico").Length;
            if (tmpCounter == 0)
                return -1;


            Icon[] tmpArray = new Icon[tmpCounter];
            for (int i = 0; i < tmpCounter; i++)
            {
                try
                {
                    var _iconPath = Path.Combine(icoPath, string.Format("{0}.ico", i));
                    if (File.Exists(_iconPath))
                    {
                        tmpIcon = new Icon(_iconPath);
                        if ((tmpIcon.Size.Height > 0 && tmpIcon.Size.Width > 0) && (tmpIcon.Size.Height <= 32 && tmpIcon.Size.Width <= 32))
                            tmpArray[validNum++] = tmpIcon;
                    }
                }
                catch (Exception)
                {
                    return -1;
                }
            }

            if (validNum == 0)
                return -1;

            iconsArray = tmpArray;
            iconsArrayCounter = validNum;
            iconsLoadedFlag = false;
            return 0;
        }

        public void mainTrayGifAnimationSet(String gifPath)
        {
            Image imgGif;
            try
            {
                if (File.Exists(gifPath))
                    imgGif = Image.FromFile(gifPath);
                else
                    imgGif = Properties.Resources.main_gif;

                if (ImageAnimator.CanAnimate(imgGif))
                {
                    if (!Directory.Exists(imagePath))
                        Directory.CreateDirectory(imagePath);

                    if (!Directory.Exists(icoPath))
                    {
                        Directory.CreateDirectory(icoPath);
                    }
                    else
                    {
                        DirectoryInfo dir = new DirectoryInfo(icoPath);
                        foreach (FileInfo file in dir.GetFiles()) file.Delete();
                    }

                    FrameDimension imgFrmDim = new FrameDimension(imgGif.FrameDimensionsList[0]);
                    int nFdCount = imgGif.GetFrameCount(imgFrmDim);
                    for (int i = 0; i < nFdCount; i++)
                    {
                        imgGif.SelectActiveFrame(imgFrmDim, i);
                        var imgSavePath = Path.Combine(imagePath, string.Format("{0}.png", i));
                        imgGif.Save(imgSavePath, ImageFormat.Png);
                        var icoSavePath = Path.Combine(icoPath, string.Format("{0}.ico", i));
                        mainPngToIcon(imgSavePath, icoSavePath, new Size(32, 32));
                    }
                    imgGif.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    Directory.Delete(imagePath, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void uiTimerUpdateUI(object? sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(uiTimerUpdateUICb));
            else
                uiTimerUpdateUICb();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
