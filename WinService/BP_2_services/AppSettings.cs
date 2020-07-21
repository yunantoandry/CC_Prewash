using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_2_services
{
    public static class AppSettings
    {
        public static int PollingInterval => GetInt("PollingInterval");

        public static bool RunAsConsoleApp => GetBool("RunAsConsoleApp");

        private static bool GetBool(string appSettingName)
        {
            var appSetting = GetRefreshedAppSetting(appSettingName);

            if (appSetting == null)
            {
                return false;
            }
            else
            {
                return appSetting.Trim().Equals("true", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        private static int GetInt(string appSettingName)
        {
            var appSetting = GetRefreshedAppSetting(appSettingName);

            if (string.IsNullOrWhiteSpace(appSetting))
            {
                throw new InvalidOperationException($"Could not get AppSetting '{appSettingName}' because it is either blank or nonexistent.");
            }

            try
            {
                return Convert.ToInt32(appSetting);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Could not get AppSetting '{appSettingName}' because an error occured while parsing it ({appSetting}) into an int.", ex);
            }
        }

        private static string GetRefreshedAppSetting(string appSettingName)
        {
            ConfigurationManager.RefreshSection("appSettings");
            return ConfigurationManager.AppSettings[appSettingName];
        }
    }
}
