using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    [Table("log_error")]
   public  class Table_RAC
    {
        [Key]
        //public int TR_LOG_XML_ERROR_ID { get; set; }
        public string SAS_ID { get; set; }
        public int Sequence_Number { get; set; }
        public string Criteria_Name { get; set; }
        public string Reason_Code { get; set; }
        public string Reason_Description { get; set; }
        public string Mandatory { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public DateTime MODIFIED_DATE { get; set; }
    }
}
