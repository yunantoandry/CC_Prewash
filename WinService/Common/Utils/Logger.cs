using System;
using System.ComponentModel;
using System.Configuration;
using System.Reflection;

namespace Common.Utils
{
    public sealed class Logger
    {
        // ReSharper disable once InconsistentNaming
        static readonly log4net.ILog logger = log4net.LogManager.GetLogger(ConfigurationManager.AppSettings["LoggerName"]);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logKey"></param>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="methodBase"></param>
        /// <param name="exception"></param>
        public static void WriteLog(out string logKey, LogLevel logLevel, string message, MethodBase methodBase, Exception exception = null)
        {

            logKey = Guid.NewGuid().ToString();

            var msgToLog = "Log Key : " + logKey + Environment.NewLine 
                         + "Method : " + GetMethodName(methodBase) + Environment.NewLine 
                         + "Class : " + GetClassName(methodBase) + Environment.NewLine 
                         + message;

            switch (logLevel)
            {
                case LogLevel.Info:
                    logger.Info(msgToLog);
                    break;
                case LogLevel.Warn:
                    logger.Warn(msgToLog);
                    break;
                case LogLevel.Debug:
                    logger.Debug(msgToLog);
                    break;
                case LogLevel.Error:
                    logger.Error(msgToLog, exception);
                    break;
                case LogLevel.Fatal:
                    logger.Fatal(msgToLog, exception);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logKey"></param>
        /// <param name="loggerName"></param>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="methodBase"></param>
        /// <param name="exception"></param>
        public static void WriteSpecificLog(out string logKey, string loggerName, LogLevel logLevel, string message, MethodBase methodBase, Exception exception = null)
        {
            logKey = Guid.NewGuid().ToString();
            var specificLogger = log4net.LogManager.GetLogger(loggerName);
            var msgToLog = "Log Key : " + logKey + Environment.NewLine
                         + "Method : " + GetMethodName(methodBase) + Environment.NewLine
                         + "Class : " + GetClassName(methodBase) + Environment.NewLine
                         + message;
            switch (logLevel)
            {
                case LogLevel.Info:
                    specificLogger.Info(msgToLog);
                    break;
                case LogLevel.Warn:
                    specificLogger.Warn(msgToLog);
                    break;
                case LogLevel.Debug:
                    specificLogger.Debug(msgToLog);
                    break;
                case LogLevel.Error:
                    specificLogger.Error(msgToLog, exception);
                    break;
                case LogLevel.Fatal:
                    specificLogger.Fatal(msgToLog, exception);
                    break;
            }
        }

        #region ---------------- Private Methods ---------------

        private static string GetClassName(MethodBase aMethod)
        {
            return aMethod.Module.FullyQualifiedName;
        }
        private static string GetMethodName(MethodBase aMethod)
        {
            return aMethod.Name;
        }

        #endregion

    }

    public enum LogLevel
    {
        [Description("Info")]
        Info,
        [Description("Debug")]
        Debug,
        [Description("Warning")]
        Warn,
        [Description("Error")]
        Error,
        [Description("Fatal")]
        Fatal
    }

}
