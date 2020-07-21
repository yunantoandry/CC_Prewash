using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UserFriendlyException:Exception
    {
        public string UserFriendlyMessage { get; private set; }


        public static UserFriendlyException FromFriendlyMessage(string userFriendlyMessage)
        {
            return new UserFriendlyException(userFriendlyMessage, userFriendlyMessage);
        }

        public static UserFriendlyException FromNonFriendlyMessage(string nonUserFriendlyMessage)
        {
            return new UserFriendlyException(nonUserFriendlyMessage);
        }

        public UserFriendlyException(string userFriendlyMessage, string message) : base(message)
        {
            if (string.IsNullOrWhiteSpace(userFriendlyMessage))
            {
                userFriendlyMessage = Constants.StandardUserFriendlyExceptionMessageIfFriendlyMessageIsMissing;
            }

            UserFriendlyMessage = userFriendlyMessage;
        }

        public UserFriendlyException(string message) : base(message)
        {
            UserFriendlyMessage = Constants.StandardUserFriendlyExceptionMessage;
        }

        public UserFriendlyException(string message, Exception innerException) : base(message, innerException)
        {
            UserFriendlyMessage = Constants.StandardUserFriendlyExceptionMessage;
        }
    }
}
