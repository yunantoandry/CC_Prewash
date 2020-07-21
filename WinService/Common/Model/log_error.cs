using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Common.Model
{
    [Serializable]
    [Table("log_error")]
    public class log_error
    {
        [Key]
      //  public int TR_LOG_XML_ERROR_ID { get; set; }
        public string FILE_PATH { get; set; }
        public string FILE_CATEGORY { get; set; }
        public string FILE_NAME { get; set; }
        public string BATCH { get; set; }
        public string KEY_ID { get; set; }
        public string DESCRIPTION_MESSAGE { get; set; }
        public string DESCRIPTION_TRACE { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public DateTime MODIFIED_DATE { get; set; }
    }
}
