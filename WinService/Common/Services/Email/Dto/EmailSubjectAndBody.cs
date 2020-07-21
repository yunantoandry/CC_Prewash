using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Email.Dto
{
    /// <summary>
    /// Represents the strings for an email's subject line and body.
    /// </summary>
    public class EmailSubjectAndBody
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
