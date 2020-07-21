using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class tr_log_transportservices
    {
        public int LOG_ID { get; set; }
        public string LOG_TYPE { get; set; }
        public string SOURCE_DIR { get; set; }
        public string DESTINATION_DIR { get; set; }
        public string FILE_NAME { get; set; }
        public DateTime WRITTEN_DATE { get; set; }
    }
}
