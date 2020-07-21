using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    public class tr_log_xml
    {
        //public int ID { get; set; }
        public string FILENAME { get; set; }
        public string METHOD { get; set; }
        public string STATUS { get; set; }
        public int COUNT_DATA { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }

    }
}
