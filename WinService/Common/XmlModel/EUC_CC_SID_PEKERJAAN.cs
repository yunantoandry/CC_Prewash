using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.XmlModel
{
    [XmlRoot(ElementName = "EUC_CC_SID_KOLEKTIBILITAS")]
    public class EUC_CC_SID_PEKERJAAN
    {
        [XmlElement(ElementName = "IDIFILE")]
        public string IDIFILE { get; set; }
        [XmlElement(ElementName = "TGL_LAPORAN")]
        public string TGL_LAPORAN { get; set; }
        [XmlElement(ElementName = "PROGRAM")]
        public string PROGRAM { get; set; }
        [XmlElement(ElementName = "DIN")]
        public string DIN { get; set; }
        [XmlElement(ElementName = "NO")]
        public string NO { get; set; }
        [XmlElement(ElementName = "PEKERJAAN")]
        public string PEKERJAAN { get; set; }
        [XmlElement(ElementName = "TEMPAT")]
        public string TEMPAT { get; set; }
        [XmlElement(ElementName = "BIDANG_USAHA")]
        public string BIDANG_USAHA { get; set; }
        [XmlElement(ElementName = "UPDATE_DATE")]
        public string UPDATE_DATE { get; set; }
    }
}
