using Common.Services.Email.Dto;
using HandlebarsDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Services.Email
{
    public class EmailCreator : IEmailCreator
    {
      //  private readonly ISystemService _systemService;

        public EmailCreator()
        {
         //   _systemService = systemService ?? throw new ArgumentNullException(nameof(systemService));
        }

        

        /// <summary>
        /// Create a <see cref="MailMessage"/> that you can take and send.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public MailMessage CreateMailMessage(CreateMailMessageInput input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var mailMessage = new MailMessage
            {
                From = new MailAddress(input.FromAddress),
                Subject = input.Subject,
                Body = input.Body,
                IsBodyHtml = input.IsBodyHtml,
                Priority = MailPriority.High,
            };

            if (input.Attachments != null && input.Attachments.Any())
            {
                foreach (var attachment in input.Attachments)
                {
                    if (attachment != null)
                    {
                        mailMessage.Attachments.Add(attachment);
                    }
                }
            }

            foreach (var toAddress in input.ToAddresses)
            {
                mailMessage.To.Add(toAddress);
            }

            return mailMessage;
        }

        /// <summary>
        /// Create a DTO that contains the strings necessary to create an
        /// email's subject and body using an embedded .html file in the folder
        /// Mds.Common/Services/Email/EmailTemplates.
        /// </summary>
        /// <param name="subjectTemplate"></param>
        /// <param name="embeddedEmailBodyTemplateFileName"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public EmailSubjectAndBody CreateEmailSubjectAndBodyFromEmbeddedResource(
            string subjectTemplate,
            string embeddedEmailBodyTemplateFileName,
            object dto
        )
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var bodyTemplate = GetEmbeddedEmailBodyTemplate(embeddedEmailBodyTemplateFileName);

            var createSubject = Handlebars.Compile(subjectTemplate);
            var createBody = Handlebars.Compile(bodyTemplate);

            return new EmailSubjectAndBody
            {
                Subject = createSubject(dto),
                Body = createBody(dto)
            };
        }

        /// <summary>
        /// Create a DTO that contains the strings necessary to create an
        /// email's subject and body using string templates stored in the
        /// database.
        /// </summary>
        /// <param name="subjectParameterCode"></param>
        /// <param name="bodyParameterCode"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        //public EmailSubjectAndBody CreateEmailSubjectAndBodyFromDatabase(
        //    string subjectParameterCode,
        //    string bodyParameterCode,
        //    object dto
        //)
        //{
        //    if (dto == null) throw new ArgumentNullException(nameof(dto));

        //    var template = GetEmailTemplateFromDatabase(
        //        subjectParameterCode,
        //        bodyParameterCode
        //    );

        //    var createSubject = Handlebars.Compile(template.SubjectTemplate);
        //    var createBody = Handlebars.Compile(template.BodyTemplate);

        //    return new EmailSubjectAndBody
        //    {
        //        Subject = createSubject(dto),
        //        Body = createBody(dto)
        //    };
        //}

        /// <summary>
        /// 'Legacy' templates look like this
        /// 
        /// Hello {UserName}
        /// 
        /// while 'new' templates (that match existing standards) are like this
        /// 
        /// Hello {{UserName}}
        /// 
        /// This function turns 'legacy' templates into 'new' templates.
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public string StandardizeTemplate(string template)
        {
            var singleCurlyBracesTemplateRegex = @"(?<!\{)(\{[A-Za-z0-9_\- ]+\})(?!\})";

            return Regex.Replace(template, singleCurlyBracesTemplateRegex, "{$1}");
        }

        /// <summary>
        /// Get the email template strings from the database.
        /// </summary>
        /// <param name="subjectParameterCode"></param>
        /// <param name="bodyParameterCode"></param>
        /// <returns></returns>
      //  private EmailSubjectAndBodyTemplate GetEmailTemplateFromDatabase(string subjectParameterCode, string bodyParameterCode)
     //   {
            //var emailSubjectAndBodyTemplate = _systemService.GetSystemParameters(new List<string>
            //{
            //    subjectParameterCode,
            //    bodyParameterCode
            //}, v =>
            //{
            //    return new EmailSubjectAndBodyTemplate
            //    {
            //        SubjectTemplate = v.Get(subjectParameterCode),
            //        BodyTemplate = v.Get(bodyParameterCode)
            //    };
            //});

            //emailSubjectAndBodyTemplate.SubjectTemplate = StandardizeTemplate(emailSubjectAndBodyTemplate.SubjectTemplate);
            //emailSubjectAndBodyTemplate.BodyTemplate = StandardizeTemplate(emailSubjectAndBodyTemplate.BodyTemplate);

         //   return emailSubjectAndBodyTemplate;
      //  }

        /// <summary>
        /// Get the email template strings from an embedded file.
        /// </summary>
        /// <param name="embeddedEmailBodyTemplateFileName"></param>
        /// <returns></returns>
        public string GetEmbeddedEmailBodyTemplate(string embeddedEmailBodyTemplateFileName)
        {
            var embeddedEmailTemplate = $"Common.Services.Email.EmailTemplates.{embeddedEmailBodyTemplateFileName}";

            try
            {
                using (var stream = typeof(EmailCreator).Assembly.GetManifestResourceStream(embeddedEmailTemplate))
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Could not get email template for '{embeddedEmailBodyTemplateFileName}' at '{embeddedEmailTemplate}'.", ex);
            }
        }
        
    }
}
