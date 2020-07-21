using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    public class JsonResultMessage
    {
        public string ID { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
