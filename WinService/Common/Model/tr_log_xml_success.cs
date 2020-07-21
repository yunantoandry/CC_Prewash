using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    [Table("tr_log_xml_success")]
    public class tr_log_xml_success
    {
        [Key]
        //public int TR_LOG_XML_SUCCESS_ID { get; set; }
        public string SAS_ID { get; set; }
        public string Batch { get; set; }
        public string Description { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
    }
}
