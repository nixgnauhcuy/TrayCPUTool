using System.Diagnostics;
using System.Text;

namespace TrayCPUTool
{
    internal class Config
    {
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);

        public enum ConfigSectionEnum
        {
            CONFIG_SECTION_DEFAULT,
            CONFIG_SECTION_MAX
        }
        public static readonly string[] configSection = [
            "ConfigDefault",
        ];

        public enum configDefaultKeyEnum
        {
            CONFIG_KEY_GIF_PATH,
            CONFIG_KEY_AUTO_START,
            CONFIG_KEY_SYSTEM_ADMIN,
            CONFIG_KEY_MAX
        }
        public static readonly string[] configDefaultKey = [
            "GIF_PATH",
            "AUTO_START",
            "SYSTEM_ADMIN"
        ];

        private static string configDefaultPath = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "config.ini";

        public struct ConfigParameter
        {
            public string gifPath;
            public bool autoStartEn;
            public bool systemAdminEn;
        }
        public ConfigParameter configParameter;


        public Config()
        {
            if (!System.IO.File.Exists(configDefaultPath))
            {
                configParameter.gifPath = "";
                configParameter.autoStartEn = false;
                configParameter.systemAdminEn = false;

                ConfigWrite(configSection[(int)ConfigSectionEnum.CONFIG_SECTION_DEFAULT], configDefaultKey[(int)configDefaultKeyEnum.CONFIG_KEY_GIF_PATH], configParameter.gifPath);
                ConfigWrite(configSection[(int)ConfigSectionEnum.CONFIG_SECTION_DEFAULT], configDefaultKey[(int)configDefaultKeyEnum.CONFIG_KEY_AUTO_START], configParameter.autoStartEn.ToString());
                ConfigWrite(configSection[(int)ConfigSectionEnum.CONFIG_SECTION_DEFAULT], configDefaultKey[(int)configDefaultKeyEnum.CONFIG_KEY_SYSTEM_ADMIN], configParameter.systemAdminEn.ToString());
            }
            else
            {
                configParameter.gifPath = ConfigRead(configSection[(int)ConfigSectionEnum.CONFIG_SECTION_DEFAULT], configDefaultKey[(int)configDefaultKeyEnum.CONFIG_KEY_GIF_PATH]);
                if (!System.IO.File.Exists(configParameter.gifPath))
                { 
                    configParameter.gifPath = "";
                    ConfigWrite(configSection[(int)ConfigSectionEnum.CONFIG_SECTION_DEFAULT], configDefaultKey[(int)configDefaultKeyEnum.CONFIG_KEY_GIF_PATH], configParameter.gifPath);
                }
                configParameter.autoStartEn = Convert.ToBoolean(ConfigRead(configSection[(int)ConfigSectionEnum.CONFIG_SECTION_DEFAULT], configDefaultKey[(int)configDefaultKeyEnum.CONFIG_KEY_AUTO_START]));
                configParameter.systemAdminEn = Convert.ToBoolean(ConfigRead(configSection[(int)ConfigSectionEnum.CONFIG_SECTION_DEFAULT], configDefaultKey[(int)configDefaultKeyEnum.CONFIG_KEY_SYSTEM_ADMIN]));
            }
        }

        public ConfigParameter ConfigParameterGet()
        {
            return configParameter;
        }

        public void ConfigWrite(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, configDefaultPath);
        }

        public string ConfigRead(string section, string key)
        {
            StringBuilder tmpText = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", tmpText, 255, configDefaultPath);
            return tmpText.ToString();
        }
    }
}
