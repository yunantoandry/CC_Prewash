using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    [Table("Reporting_risk")]
    public class Reporting_risk
    {
        [Key]
        public string Tanggal_batch { get; set; }
        public string Batch_Output { get; set; }
        public int time_ { get; set; }
        public int Data_Count { get; set; }
        public int bnf { get; set; }
        public int bf { get; set; }
        public decimal bf_persen { get; set; }
        public int Offer { get; set; }
        public int drop_ { get; set; }      
        public decimal Offer_rate { get; set; }
      //  public int NON_NTC_CUSTOMER { get; set; }
        public int rac_max_2_cc_issuers { get; set; }
        public int rac_age { get; set; }
        public int rac_minimum_income { get; set; }
        public int bad_bureau { get; set; }
        public int highest_cc_limit_kurang_dari_3mio { get; set; }
        public int rac_very_high_risk_segment { get; set; }
        public int mue_3x { get; set; }
        public int mue_7x { get; set; }
        public int final_limit_kurang_dari_3mio { get; set; }
    }
}
