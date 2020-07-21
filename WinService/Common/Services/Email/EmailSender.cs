using Common.Services.Email.Dto;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Email
{
    /// <summary>
    /// The class responsible for sending <see cref="MailMessage"/>.
    /// </summary>
    public class EmailSender : IEmailSender
    {
        private readonly ILog _log;

        public EmailSender(ILog log)
        {
            _log = log;
        }

        public EmailSender()
        {
            _log = LogManager.GetLogger(typeof(EmailSender));
        }

        /// <summary>
        /// Send an email.
        /// </summary>
        /// <param name="mailMessage"></param>
        /// <param name="emailAccountInformation"></param>
        public void SendMailMessage(
            MailMessage mailMessage,
            EmailAccountInformation emailAccountInformation
        )
        {
            _log.Debug($"Trying to send email to {string.Join(", ", mailMessage.To.Select(x => x.Address))} addresses.");

            var client = new SmtpClient(emailAccountInformation.SmtpServer)
            {
                Port = emailAccountInformation.SmtpPort,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = emailAccountInformation.ShouldUseDefaultSmtpCredentials
            };

            var passwordAndUsernameIsIncomplete = !string.IsNullOrWhiteSpace(emailAccountInformation.SmtpUser)
                && !string.IsNullOrWhiteSpace(emailAccountInformation.SmtpPassword);

            if (emailAccountInformation.ShouldUseDefaultSmtpCredentials || passwordAndUsernameIsIncomplete)
            {
                if (emailAccountInformation.ShouldUseDefaultSmtpCredentials)
                {
                    _log.Debug($"Overriding credentials with default credentials because it was set that way.");
                }
                else
                {
                    _log.Debug($"Using default credentials because either the username or password is null or whitespace.");
                }
                client.Credentials = CredentialCache.DefaultNetworkCredentials;
            }

            else
            {
                _log.Debug("Using non-default network credentials.");

                client.Credentials = new NetworkCredential(
                    emailAccountInformation.SmtpUser,
                    emailAccountInformation.SmtpPassword
                );
            }

            client.EnableSsl = emailAccountInformation.SmtpSsl;

            client.Send(mailMessage);
        }
    }
}
