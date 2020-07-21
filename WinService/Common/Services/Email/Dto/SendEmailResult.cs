using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Email.Dto
{
    /// <summary>
    /// The result of an email delivery, whether it succeeded and if any
    /// Exceptions occured.
    /// </summary>
    public class SendEmailResult
    {
        public bool IsDeliverySuccessful { get; private set; }
        public Exception Exception { get; private set; }

        public SendEmailResult(bool isDeliverySuccessful, Exception exception = null)
        {
            IsDeliverySuccessful = isDeliverySuccessful;
            Exception = exception;
        }
    }

}
