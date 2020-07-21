using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Email.Dto
{
    //TODO: Rename this class.

    /// <summary>
    /// DTO of information needed to access an email account.
    /// </summary>
    public class EmailAccountInformation
    {
        public string SmtpServer { get; set; }
        public string DefaultFromAddress { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPassword { get; set; }
        public bool ShouldUseDefaultSmtpCredentials { get; set; }
        public bool SmtpSsl { get; set; }
        public int SmtpPort { get; set; }

        public EmailAccountInformation()
        {
            SmtpPort = 993;
            SmtpSsl = true;
        }
    }
}
