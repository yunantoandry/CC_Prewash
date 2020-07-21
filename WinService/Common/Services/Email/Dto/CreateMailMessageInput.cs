using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Email.Dto
{
    /// <summary>
    /// Parameters for sending an email, mainly used when creating emails.
    /// </summary>
    public class CreateMailMessageInput
    {
        public string FromAddress { get; set; }
        public IEnumerable<string> ToAddresses { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }

        public CreateMailMessageInput()
        {
            IsBodyHtml = true;
            ToAddresses = new List<string>();
            Attachments = new List<Attachment>();
        }
    }
}
