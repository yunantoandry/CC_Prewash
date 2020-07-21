using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.XmlModel
{
    
    [XmlRoot(ElementName = "EUC_CC_SID_DEBITUR")]
    public class EUC_CC_SID_DEBITUR
    {
        [XmlElement(ElementName = "IDIFILE")]
        public string IDIFILE { get; set; }
        [XmlElement(ElementName = "TGL_LAPORAN")]
        public string TGL_LAPORAN { get; set; }
        [XmlElement(ElementName = "PROGRAM")]
        public string PROGRAM { get; set; }
        [XmlElement(ElementName = "DIN")]
        public string DIN { get; set; }
        [XmlElement(ElementName = "LAP_NO")]
        public string LAP_NO { get; set; }
        [XmlElement(ElementName = "LAP_POSISIAKHIR")]
        public string LAP_POSISIAKHIR { get; set; }
        [XmlElement(ElementName = "LAP_USER")]
        public string LAP_USER { get; set; }
        [XmlElement(ElementName = "PRM_TGL")]
        public string PRM_TGL { get; set; }
        [XmlElement(ElementName = "PRM_NO")]
        public string PRM_NO { get; set; }
        [XmlElement(ElementName = "PRM_NAMA_DEBITUR")]
        public string PRM_NAMA_DEBITUR { get; set; }
        [XmlElement(ElementName = "PRM_TEMPAT_LAHIR")]
        public string PRM_TEMPAT_LAHIR { get; set; }
        [XmlElement(ElementName = "PRM_TGL_LAHIR")]
        public string PRM_TGL_LAHIR { get; set; }
        [XmlElement(ElementName = "PRM_NPWP")]
        public string PRM_NPWP { get; set; }
        [XmlElement(ElementName = "PRM_KTP")]
        public string PRM_KTP { get; set; }
        [XmlElement(ElementName = "PRM_PASSPORT")]
        public string PRM_PASSPORT { get; set; }
    }
}
