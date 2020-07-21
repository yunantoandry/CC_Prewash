using log4net;
using System;
using System.Configuration;
using System.Linq;

namespace Common.Services.Scheduling
{
    /// <summary>
    /// Creates a <see cref="BackgroundProcess"/> that can be run in the
    /// background for a Windows service.
    /// </summary>
    public class BackgroundProcessCreator
    {
        private readonly ILog _log;

        public BackgroundProcessCreator()
        {
            _log = LogManager.GetLogger(typeof(BackgroundProcessCreator));
        }

        public BackgroundProcessCreator(ILog log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        /// <summary>
        /// Create a background process and log it.
        /// </summary>
        /// <param name="backgroundProcessName"></param>
        /// <param name="cronAppSettingName"></param>
        /// <param name="backgroundProcessAction"></param>
        /// <returns></returns>
        public BackgroundProcess CreateBackgroundProcess(
            string backgroundProcessName,
            string cronAppSettingName,
            Action backgroundProcessAction
        )
        {
            if (string.IsNullOrWhiteSpace(backgroundProcessName)) throw new ArgumentNullException(nameof(backgroundProcessName));
            if (string.IsNullOrWhiteSpace(cronAppSettingName)) throw new ArgumentNullException(nameof(cronAppSettingName));
            if (backgroundProcessAction == null) throw new ArgumentNullException(nameof(backgroundProcessAction));

            _log.Info($"Creating background process named '{backgroundProcessName}'.");

            _log.Info($"Checking for existence of '{cronAppSettingName}' in AppSettings.");

            if (!CheckCronAppSettingExists(cronAppSettingName))
            {
                throw new InvalidOperationException($"Could not create background process named '{backgroundProcessName}' because no AppSetting with the name '{cronAppSettingName}' could be found.");
            }

            _log.Info($"'{cronAppSettingName}' exists AppSettings.");

            var backgroundProcessAppSettingsReader = new BackgroundProcessAppSettingsReader(
                backgroundProcessName,
                cronAppSettingName,
                Constants.ShouldLogPollingAppSettingName
            );

            var backgroundProcess = new BackgroundProcess(
                backgroundProcessName,
                backgroundProcessAppSettingsReader,
                backgroundProcessAction
            );

            _log.Info(backgroundProcessAppSettingsReader);
            _log.Info(backgroundProcess);

            return backgroundProcess;
        }
        

        //=== Private ===
        private bool CheckCronAppSettingExists(string cronAppSettingName)
        {
            return ConfigurationManager.AppSettings.AllKeys.Contains(cronAppSettingName);
        }
    }
}
