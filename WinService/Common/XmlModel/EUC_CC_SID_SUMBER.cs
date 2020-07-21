using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.XmlModel
{
    [XmlRoot(ElementName = "EUC_CC_SID_SUMBER")]
    public class EUC_CC_SID_SUMBER
    {
        [XmlElement(ElementName = "IDIFILE")]
        public string IDIFILE { get; set; }
        [XmlElement(ElementName = "TGL_LAPORAN")]
        public string TGL_LAPORAN { get; set; }
        [XmlElement(ElementName = "PROGRAM")]
        public string PROGRAM { get; set; }
        [XmlElement(ElementName = "DIN")]
        public string DIN { get; set; }
        [XmlElement(ElementName = "KODE")]
        public string KODE { get; set; }
        [XmlElement(ElementName = "NAMA")]
        public string NAMA { get; set; }
        [XmlElement(ElementName = "CABANG_PELAPOR")]
        public string CABANG_PELAPOR { get; set; }
    }
}
