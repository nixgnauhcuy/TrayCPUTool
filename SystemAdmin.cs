using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;

namespace TrayCPUTool
{
    internal class SystemAdmin
    {
        public static bool SystemAdminIsEnable()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
            {
                isAdmin = false;
            }
            return isAdmin;
        }

        public static void SystemAdminSet(bool enable)
        {
            bool isAdmin = SystemAdminIsEnable();
            
            if (enable)
            {
                if (!isAdmin)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.UseShellExecute = true;
                    startInfo.WorkingDirectory = Environment.CurrentDirectory;
                    startInfo.FileName = Application.ExecutablePath;
                    startInfo.Verb = "runas";
                    Process.Start(startInfo);
                    Application.Exit();
                }
            }
            else
            {
                if (isAdmin)
                {
                    Process.Start("explorer.exe", Assembly.GetEntryAssembly().Location);
                    Application.Exit();
                }
            }
        }

        public static void SystemAdminCancel()
        {
            bool isAdmin = SystemAdminIsEnable();

            if (isAdmin)
            {
                Process.Start("explorer.exe", Assembly.GetEntryAssembly().Location);
            }
        }
    }
}
