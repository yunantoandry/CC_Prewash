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
    /// A class responsible for creating the strings in emails and the
    /// <see cref="MailMessage"/> itself using templates and DTOs.
    /// </summary>
    public interface IEmailCreator
    {
        MailMessage CreateMailMessage(CreateMailMessageInput input);
        //EmailSubjectAndBody CreateEmailSubjectAndBodyFromDatabase(
        //    string subjectParameterCode,
        //    string bodyParameterCode,
        //    object dto
        //);
        EmailSubjectAndBody CreateEmailSubjectAndBodyFromEmbeddedResource(
            string subjectTemplate,
            string bodyTemplate,
            object dto
        );
    }
}
