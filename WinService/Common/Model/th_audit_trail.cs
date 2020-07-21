using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    [Dapper.Table("th_audit_trail")]
    public class th_audit_trail
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Module { get; set; }
        public DateTime ActionDate { get; set; }
        public string Description { get; set; }
        public bool IsError { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
