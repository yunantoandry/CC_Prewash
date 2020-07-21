using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Email.Dto
{
    /// <summary>
    /// Represents the templates for creating an email's subject line and body.
    /// Templates usually look something like this
    /// 
    /// Hello {{USER_NAME}},
    /// 
    /// This is an email for {{ITEM}}
    /// 
    /// Where items in brackets are replaced with values from DTOs.
    /// </summary>
    public class EmailSubjectAndBodyTemplate
    {
        public string SubjectTemplate { get; set; }
        public string BodyTemplate { get; set; }
    }
}
