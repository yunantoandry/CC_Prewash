using Common.Services.Email.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Email
{
    /// <summary>
    /// The class responsible for sending <see cref="MailMessage"/>.
    /// </summary>
    public interface IEmailSender
    {
        void SendMailMessage(
            MailMessage mailMessage,
            EmailAccountInformation emailAccountInformation
        );
    }
    //public interface ISystemEmailSettingsGetter
    //{
    //    EmailAccountInformation GetSystemEmailSettings();
    //}
}
