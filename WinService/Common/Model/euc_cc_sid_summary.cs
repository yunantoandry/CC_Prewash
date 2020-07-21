using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class euc_cc_sid_summary
    {
        public string IDIFILE { get; set; }
        public DateTime TGL_LAPORAN { get; set; }
        public string PROGRAM { get; set; }
        public string DIN { get; set; }
        public string No { get; set; }
        public decimal PLAFON_KREDIT { get; set; }
        public decimal PLAFON_LC { get; set; }
        public decimal PLAFON_GYD { get; set; }
        public decimal PLAFON_LAINNYA { get; set; }
        public decimal PLAFON_TOTAL { get; set; }
        public decimal BAKIDEBET_KREDIT { get; set; }
        public decimal BAKIDEBET_LC { get; set; }
        public decimal BAKIDEBET_BG { get; set; }
        public decimal BAKIDEBET_LAINNYA { get; set; }
        public decimal BAKIDEBET_TOTAL { get; set; }
        public string KOLEK_TERBURUK { get; set; }
        public string KOLEK_BULAN { get; set; }
    }
}
