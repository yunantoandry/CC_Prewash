using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    public class euc_cc_sid_debitur
    {
        public string IDIFILE { get; set; }
        public DateTime TGL_LAPORAN { get; set; }
        public string PROGRAM { get; set; }
        public string DIN { get; set; }
        public string LAP_NO { get; set; }
        public DateTime LAP_POSISIAKHIR { get; set; }
        public string LAP_USER { get; set; }
        public DateTime PRM_TGL { get; set; }
        public string PRM_NO { get; set; }
        public string PRM_NAMA_DEBITUR { get; set; }
        public string PRM_TEMPAT_LAHIR { get; set; }
        public DateTime PRM_TGL_LAHIR { get; set; }
        public string PRM_NPWP { get; set; }
        public string PRM_KTP { get; set; }
        public string PRM_PASSPORT { get; set; }
        public string FlagValueKtp { get; set; }

        
    }
 
  
    }
