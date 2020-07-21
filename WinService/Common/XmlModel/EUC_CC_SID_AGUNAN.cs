using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.XmlModel
{
    [XmlRoot(ElementName = "EUC_CC_SID_AGUNAN")]
    public class EUC_CC_SID_AGUNAN
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
        [XmlElement(ElementName = "PELAPOR")]
        public string PELAPOR { get; set; }
        [XmlElement(ElementName = "JENIS")]
        public string JENIS { get; set; }
        [XmlElement(ElementName = "UPDATE_DATE")]
        public string UPDATE_DATE { get; set; }
        [XmlElement(ElementName = "NILAI_BANK")]
        public string NILAI_BANK { get; set; }
        [XmlElement(ElementName = "NILAI_TGL")]
        public string NILAI_TGL { get; set; }
        [XmlElement(ElementName = "NILAI_INDPDNT")]
        public string NILAI_INDPDNT { get; set; }
        [XmlElement(ElementName = "PENILAI")]
        public string PENILAI { get; set; }
        [XmlElement(ElementName = "NJOP")]
        public string NJOP { get; set; }
        [XmlElement(ElementName = "PARIPASU")]
        public string PARIPASU { get; set; }
        [XmlElement(ElementName = "PEMILIK")]
        public string PEMILIK { get; set; }
        [XmlElement(ElementName = "BUKTI")]
        public string BUKTI { get; set; }
        [XmlElement(ElementName = "PENGIKATAN")]
        public string PENGIKATAN { get; set; }
        [XmlElement(ElementName = "ALAMAT")]
        public string DATI_II { get; set; }
        [XmlElement(ElementName = "DATI_II")]
        public string ALAMAT { get; set; }
        [XmlElement(ElementName = "SSB")]
        public string SSB { get; set; }
        [XmlElement(ElementName = "ASURANSI")]
        public string ASURANSI { get; set; }
        [XmlElement(ElementName = "ID_CREDIT")]
        public string ID_CREDIT { get; set; }
        [XmlElement(ElementName = "TGL_PENGIKATAN")]
        public string TGL_PENGIKATAN { get; set; }
        [XmlElement(ElementName = "TGL_PENILAI_INDEPENDENT")]
        public string TGL_PENILAI_INDEPENDENT { get; set; }
    }
}
