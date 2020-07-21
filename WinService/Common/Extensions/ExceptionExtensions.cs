using Common;
using System;

namespace Common.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Return a string that is a combination of both the current Exception
        /// message and the inner Exception message, if it exists. Otherwise
        /// just return the current Exception message.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetMessageAndInnerMessage(this Exception ex)
        {
            if (ex == null) throw new ArgumentNullException(nameof(ex));

            if (ex.InnerException == null)
            {
                return ex.Message;
            }
            else
            {
                return $"{ex.Message} {ex.InnerException.Message}";
            }
        }

        /// <summary>
        /// Get the user friendly message from an Exception if at all possible.
        /// Otherwise, return the standard user friendly error message.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string TryGetUserFriendlyMessage(this Exception ex)
        {
            if (ex == null) return "";

            if (ex is UserFriendlyException exu)
            {
                if (!string.IsNullOrWhiteSpace(exu.UserFriendlyMessage))
                {
                    return exu.UserFriendlyMessage;
                }
            }

            return Constants.StandardUserFriendlyExceptionMessage;
        }
    }
}
