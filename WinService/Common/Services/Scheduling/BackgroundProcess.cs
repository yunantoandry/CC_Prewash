using Common.Extensions;
using Common.Services.Scheduling.DTO;
using log4net;
//using Mds.Common.Extensions;

using System;
using System.Timers;

namespace Common.Services.Scheduling
{
    /// <summary>
    /// Represents a process that runs in the background.
    /// </summary>
    public class BackgroundProcess : IDisposable
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(BackgroundProcess));

        /// <summary>
        /// How often in miliseconds to check if the process should run or not. 
        /// </summary>
        private readonly int _pollingIntervalMiliseconds = 5000;

        /// <summary>
        /// The name of the process.
        /// </summary>
        private readonly string _processName;
        private IBackgroundProcessSettingsProvider _cronStringProvider;
        private readonly Action _processAction;
        private bool _processIsAlreadyRunning;
        private bool _processShouldRunThisInterval;
        private bool _pollingLogShouldRunThisInterval;
        private readonly Timer _timer;

        public BackgroundProcess(
            string label,
            IBackgroundProcessSettingsProvider cronStringProvider,
            Action action,
            bool shouldEnableImmediately = true
        )
        {
            _processName = label ?? throw new ArgumentNullException(nameof(label));
            _processAction = action ?? throw new ArgumentNullException(nameof(action));
            _cronStringProvider = cronStringProvider ?? throw new ArgumentNullException(nameof(cronStringProvider));

            // Every couple of miliseconds, poll the settings (usually the
            // App.config file) to see if it is time to run the service.

            _timer = new Timer(_pollingIntervalMiliseconds);
            _timer.Elapsed += RunPolling;
            _timer.AutoReset = true;

            if (shouldEnableImmediately)
            {
                _timer.Start();
            }
        }

        /// <summary>
        /// Start the timer if it is not already started.
        /// </summary>
        public void Start()
        {
            _timer.Start();
        }

        /// <summary>
        /// Every milisecond, check if it is time to run this process or not
        /// based on a cron string. And then, check if the task should be done
        /// the next poll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunPolling(object sender, ElapsedEventArgs e)
        {
            // Check if we should run the action this poll.

            if (_processShouldRunThisInterval)
            {
                if (!_processIsAlreadyRunning)
                {
                    _processIsAlreadyRunning = true;

                    _log.Info($"Running '{_processName}'.");

                    try
                    {
                        _processAction();
                        _log.Info($"Succeeded running '{_processName}'.");
                    }
                    catch (Exception ex)
                    {
                        _log.Error($"Failed running '{_processName}'. {ex.GetMessageAndInnerMessage()}", ex);
                    }

                    _processIsAlreadyRunning = false;
                }
                else
                {
                    _log.Info($"Cancelled running '{_processName}' because it is already running.");
                }
            }

            // Check if we should run the action in the following poll.

            _processShouldRunThisInterval = CheckShouldRunNextPoll();

            // The polling log (the log that states when the next run will
            // occur) should only run every odd interval so the log file
            // doesn't get too big.

            _pollingLogShouldRunThisInterval = !_pollingLogShouldRunThisInterval;
        }

        /// <summary>
        /// The actual function that determines if the next poll should run the
        /// task.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool CheckShouldRunNextPoll()
        {
            var shouldRunNextPoll = false;
            var utcNow = DateTime.UtcNow;

            try
            {
                var cronString = _cronStringProvider.TryGetCronString();

                var whenToRunNextResult = WhenToRunNextHelper.TryGetWhenToRunNext(
                    utcNow,
                    cronString
                );

                if (whenToRunNextResult.ResultType == WhenToRunNextResultType.CronIsValid)
                {
                    var timeNextPoll = utcNow.AddMilliseconds(_pollingIntervalMiliseconds);
                    shouldRunNextPoll = whenToRunNextResult.DateTime.Value <= timeNextPoll;
                }

                if (_pollingLogShouldRunThisInterval && _cronStringProvider.CheckShouldLogPolling())
                {
                    if (whenToRunNextResult.ResultType == WhenToRunNextResultType.CronIsValid)
                    {
                        _log.Info($"'{_processName}' will run on {whenToRunNextResult.DateTime.Value} (UTC). It is now {utcNow} (UTC).");
                    }
                    else if (whenToRunNextResult.ResultType == WhenToRunNextResultType.CronIsEmpty)
                    {
                        _log.Info($"'{_processName}' will not run because the cron string is empty.");
                    }
                    else if (whenToRunNextResult.ResultType == WhenToRunNextResultType.CronIsInvalid)
                    {
                        _log.Info($"'{_processName}' will not run because the cron string '{cronString}' is invalid.");
                    }
                    else if (whenToRunNextResult.ResultType == WhenToRunNextResultType.ProcessIsDisabled)
                    {
                        _log.Info($"'{_processName}' will not run because the cron string is set to '{cronString}' which disables the process.");
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error($"An error while trying to determine if next poll should run. {ex.GetMessageAndInnerMessage()}", ex);
            }

            return shouldRunNextPoll;
        }

        public override string ToString()
        {
            var isEnabledString = _timer.Enabled
                ? "Enabled"
                : "Not Enabled";

            return $"'{_processName}' timer: {_timer.Interval}ms interval ({isEnabledString})";
        }

        public void Dispose()
        {
            _timer?.Stop();
        }
    }

}
