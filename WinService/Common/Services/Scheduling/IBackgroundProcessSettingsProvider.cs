namespace Common.Services.Scheduling
{
    /// <summary>
    /// This class provides the settings that a BackgroundProcess can load at
    /// runtime. It lets you change when a BackgroundProcess runs in the
    /// .config file and whether it should log when it will run next.
    /// </summary>
    public interface IBackgroundProcessSettingsProvider
    {
        string TryGetCronString();
        bool CheckShouldLogPolling();
    }
}
