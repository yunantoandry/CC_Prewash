using log4net;
using System;
using System.Configuration;

namespace Common.Services.Scheduling
{
    /// <summary>
    /// This class provides the settings that a BackgroundProcess can load at
    /// runtime. It lets you change when a BackgroundProcess runs in the
    /// .config file and whether it should log when it will run next.
    /// </summary>
    public class BackgroundProcessAppSettingsReader : IBackgroundProcessSettingsProvider
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(BackgroundProcessAppSettingsReader));

        private readonly string _backgroundProcessName;
        private readonly string _cronStringAppSettingsName;
        private readonly string _shouldLogPollingAppSettingsName;

        public BackgroundProcessAppSettingsReader(
            string backgroundProcessName,
            string cronStringAppSettingsName,
            string shouldLogPollingAppSettingsName
        )
        {
            _backgroundProcessName = backgroundProcessName ?? throw new ArgumentNullException(nameof(backgroundProcessName));
            _cronStringAppSettingsName = cronStringAppSettingsName ?? throw new ArgumentNullException(nameof(cronStringAppSettingsName));
            _shouldLogPollingAppSettingsName = shouldLogPollingAppSettingsName ?? throw new ArgumentNullException(nameof(shouldLogPollingAppSettingsName));
        }



        /// <summary>
        /// Get the cron string from AppSettings which determines when the
        /// BackgroundProcess will run next.
        /// </summary>
        /// <returns></returns>
        public string TryGetCronString()
        {
            var cronString = GetRefreshedAppSetting(_cronStringAppSettingsName);

            if (string.IsNullOrWhiteSpace(cronString))
            {
                return null;
            }

            return cronString.Trim();
        }

        /// <summary>
        /// Check whether polling events should be logged.
        /// </summary>
        /// <returns></returns>
        public bool CheckShouldLogPolling()
        {
            var shouldLogPollingString = GetRefreshedAppSetting(_shouldLogPollingAppSettingsName);

            if (string.IsNullOrWhiteSpace(shouldLogPollingString))
            {
                return false;
            }
            else
            {
                return shouldLogPollingString.Trim().Equals("true", StringComparison.InvariantCultureIgnoreCase);
            }
        }

        private string GetRefreshedAppSetting(string key)
        {
            ConfigurationManager.RefreshSection("appSettings");
            return ConfigurationManager.AppSettings[key];
        }

        public override string ToString()
        {
            return $"{nameof(BackgroundProcessAppSettingsReader)} using '{_cronStringAppSettingsName}' AppSetting as the cron string for '{_backgroundProcessName}'.";
        }
    }
}
