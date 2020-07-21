using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    public class Smtp
    {
        public Smtp() { }
        public string SMTPServer { get; set; }
        public string EmailFrom { get; set; }
        public int SMTPPort { get; set; }
        public bool SMTPSSL { get; set; }
        public string SMTPPassword { get; set; }
        public bool? SMTPDefaultCredentials { get; set; }
        public string SMTPUser { get; set; }
    }
}
