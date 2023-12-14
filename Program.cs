using System.Diagnostics;

namespace TrayCPUTool
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Config config = new Config();
            bool isAdmin = SystemAdmin.SystemAdminIsEnable();

            if (config.configParameter.systemAdminEn)
            {
                if (isAdmin)
                    Application.Run(new MainForm());
                else
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Environment.CurrentDirectory,
                        FileName = Application.ExecutablePath,
                        Verb = "runas"
                    };
                    Process.Start(startInfo);
                }
            }
            else
            {
                if (!isAdmin)
                    Application.Run(new MainForm());
                else
                    SystemAdmin.SystemAdminCancel();
            }
        }
    }
}