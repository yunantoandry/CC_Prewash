using Dapper;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
   // [Table("tr_log_xml_trans")]
    public class tr_xml_trans
    {
        //[Key]
        //public int ID { get; set; }
        public string SAS_ID { get; set; }
        public string XML_REQUEST { get; set; }
        public string XML_RESPONSE { get; set; }
        public string STATUS_XML { get; set; }
        public string UniqueKey { get; set; }
        public string BATCH { get; set; }
        public string DIN { get; set; }
        public float TotalScore { get; set; }       
        public string LA_Segment_New { get; set; }
        public string FLAG_BUREAU { get; set; }
        public string FLAG_KKBL { get; set; }
        public string SCORE_CATEGORY { get; set; }
        public int jml_issuer { get; set; }
        public int NPWP_Status { get; set; }
        public float Final_Limit { get; set; }
        public string FinalRemarks { get; set; }
        public string Drop_Reason { get; set; }
        public TimeSpan response_time { get; set; }       
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }





    }
}
