using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Common.Model
{
    [Serializable]
    [Dapper.Table("ms_system_parameter")]
    public class ms_system_parameter
    {
        [Key]
        public int Id { get; set; }
        public string ParameterCode { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ParameterValue { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
