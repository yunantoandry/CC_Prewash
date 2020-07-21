using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.XmlModel
{
    [XmlRoot(ElementName = "EUC_CC_SID_SUMMARY")]
    public class EUC_CC_SID_SUMMARY
    {
        [XmlElement(ElementName = "IDIFILE")]
        public string IDIFILE { get; set; }
        [XmlElement(ElementName = "TGL_LAPORAN")]
        public string TGL_LAPORAN { get; set; }
        [XmlElement(ElementName = "PROGRAM")]
        public string PROGRAM { get; set; }
        [XmlElement(ElementName = "DIN")]
        public string DIN { get; set; }
        [XmlElement(ElementName = "No")]
        public string No { get; set; }
        [XmlElement(ElementName = "PLAFON_KREDIT")]
        public string PLAFON_KREDIT { get; set; }
        [XmlElement(ElementName = "PLAFON_LC")]
        public string PLAFON_LC { get; set; }
        [XmlElement(ElementName = "PLAFON_GYD")]
        public string PLAFON_GYD { get; set; }
        [XmlElement(ElementName = "PLAFON_LAINNYA")]
        public string PLAFON_LAINNYA { get; set; }
        [XmlElement(ElementName = "PLAFON_TOTAL")]
        public string PLAFON_TOTAL { get; set; }
        [XmlElement(ElementName = "BAKIDEBET_KREDIT")]
        public string BAKIDEBET_KREDIT { get; set; }
        [XmlElement(ElementName = "BAKIDEBET_LC")]
        public string BAKIDEBET_LC { get; set; }
        [XmlElement(ElementName = "BAKIDEBET_BG")]
        public string BAKIDEBET_BG { get; set; }
        [XmlElement(ElementName = "BAKIDEBET_LAINNYA")]
        public string BAKIDEBET_LAINNYA { get; set; }
        [XmlElement(ElementName = "BAKIDEBET_TOTAL")]
        public string BAKIDEBET_TOTAL { get; set; }
        [XmlElement(ElementName = "KOLEK_TERBURUK")]
        public string KOLEK_TERBURUK { get; set; }
        [XmlElement(ElementName = "KOLEK_BULAN")]
        public string KOLEK_BULAN { get; set; }
    }}
