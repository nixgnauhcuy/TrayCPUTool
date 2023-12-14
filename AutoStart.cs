using System.Diagnostics;
using IWshRuntimeLibrary;

namespace TrayCPUTool
{
    internal class AutoStart
    {
        private const string appName = "TrayCPUTool";

        private static string appPath => Process.GetCurrentProcess().MainModule.FileName;

        private static string startupFolderPath => Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        private static string GetShortcutPath(string appName) => Path.Combine(startupFolderPath, $"{appName}.lnk");

       
        public static bool CreateAutoStartShortcut()
        {
            try
            {
                string shortcutLocation = GetShortcutPath(appName);

                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                shortcut.Description = "Shortcut for " + appName;
                shortcut.TargetPath = appPath;
                shortcut.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the startup shortcut: {ex.Message}");
                return false;
            }
        }

        public static bool IsAutoStartShortcutPresent()
        {
            string shortcutPath = GetShortcutPath(appName);
            return System.IO.File.Exists(shortcutPath);
        }

        public static bool RemoveAutoStartShortcut()
        {
            try
            {
                string shortcutPath = GetShortcutPath(appName);

                if (IsAutoStartShortcutPresent())
                {
                    System.IO.File.Delete(shortcutPath);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the startup shortcut: {ex.Message}");
                return false;
            }
        }

        public static bool AutoStartSet(bool enable)
        {
            bool result = false;
            if (enable)
            {
                result = CreateAutoStartShortcut();
            }
            else
            {
                result = RemoveAutoStartShortcut();
            }
            return result;
        }
    }
}
