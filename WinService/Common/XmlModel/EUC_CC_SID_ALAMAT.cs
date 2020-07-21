using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.XmlModel
{
    [XmlRoot(ElementName = "EUC_CC_SID_ALAMAT")]
    public class EUC_CC_SID_ALAMAT
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
        [XmlElement(ElementName = "ALAMAT")]
        public string ALAMAT { get; set; }
        [XmlElement(ElementName = "KELURAHAN")]
        public string KELURAHAN { get; set; }
        [XmlElement(ElementName = "KECAMATAN")]
        public string KECAMATAN { get; set; }
        [XmlElement(ElementName = "DATI_II")]
        public string DATI_II { get; set; }
        [XmlElement(ElementName = "KODEPOS")]
        public string KODEPOS { get; set; }
        [XmlElement(ElementName = "NEGARA")]
        public string NEGARA { get; set; }
        [XmlElement(ElementName = "UPDATE_DATE")]
        public string UPDATE_DATE { get; set; }
        [XmlElement(ElementName = "PELAPOR")]
        public string PELAPOR { get; set; }

       
    }
}
