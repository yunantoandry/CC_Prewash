using Common.Model;
using Common.XmlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Common.XmlModel
{

    [XmlRoot(ElementName = "Application_Header")]
    public class Application_Header
    {
        [XmlElement(ElementName = "Source")]
        public string Source { get; set; }
        [XmlElement(ElementName = "CallType")]
        public string CallType { get; set; }
    }

    [XmlRoot(ElementName = "Application")]
    public class Application
    {
        [XmlElement(ElementName = "ApplicationNumber")]
        public string ApplicationNumber { get; set; }
        [XmlElement(ElementName = "IsBIDown")]
        public string IsBIDown { get; set; }
    }

    [XmlRoot(ElementName = "EUC_CC_INPUT_DATA")]
    public class EUC_CC_INPUT_DATA
    {
        [XmlElement(ElementName = "EUC_CC_INPUT")]
        public EUC_CC_INPUT EUC_CC_INPUT { get; set; }
    }

    [XmlRoot(ElementName = "EUC_CC_SID_DEBITUR_DATA")]
    public class EUC_CC_SID_DEBITUR_DATA
    {
        [XmlElement(ElementName = "EUC_CC_SID_DEBITUR")]
        public List<EUC_CC_SID_DEBITUR> EUC_CC_SID_DEBITUR { get; set; }

    }

    [XmlRoot(ElementName = "EUC_CC_SID_ALAMAT_DATA")]
    public class EUC_CC_SID_ALAMAT_DATA
    {
        [XmlElement(ElementName = "EUC_CC_SID_ALAMAT")]
        public List<EUC_CC_SID_ALAMAT> EUC_CC_SID_ALAMAT { get; set; }
    }
    [XmlRoot(ElementName = "EUC_CC_SID_AGUNAN_DATA")]
    public class EUC_CC_SID_AGUNAN_DATA
    {
        [XmlElement(ElementName = "EUC_CC_SID_AGUNAN")]
        public List<EUC_CC_SID_AGUNAN> EUC_CC_SID_AGUNAN { get; set; }
    }
    [XmlRoot(ElementName = "EUC_CC_SID_KOLEKTIBILITAS_DATA")]
    public class EUC_CC_SID_KOLEKTIBILITAS_DATA
    {
        [XmlElement(ElementName = "EUC_CC_SID_KOLEKTIBILITAS")]
        public List<EUC_CC_SID_KOLEKTIBILITAS> EUC_CC_SID_KOLEKTIBILITAS { get; set; }
    }
    [XmlRoot(ElementName = "EUC_CC_SID_PEKERJAAN_DATA")]
    public class EUC_CC_SID_PEKERJAAN_DATA
    {
        [XmlElement(ElementName = "EUC_CC_SID_PEKERJAAN")]

        public List<EUC_CC_SID_PEKERJAAN> EUC_CC_SID_PEKERJAAN { get; set; }
    }

    [XmlRoot(ElementName = "EUC_CC_SID_SUMBER_DATA")]
    public class EUC_CC_SID_SUMBER_DATA
    {
        [XmlElement(ElementName = "EUC_CC_SID_SUMBER")]
        public List<EUC_CC_SID_SUMBER> EUC_CC_SID_SUMBER { get; set; }
    }

    [XmlRoot(ElementName = "EUC_CC_SID_SUMMARY_DATA")]
    public class EUC_CC_SID_SUMMARY_DATA
    {
        [XmlElement(ElementName = "EUC_CC_SID_SUMMARY")]
        public List<EUC_CC_SID_SUMMARY> EUC_CC_SID_SUMMARY { get; set; }

    }

    [XmlRoot(ElementName = "CRDECreditScoringRequest")]
    public class CRDECreditScoringRequest
    {
        [XmlElement(ElementName = "Application_Header")]
        public Application_Header Application_Header { get; set; }
        [XmlElement(ElementName = "Application")]
        public Application Application { get; set; }
        [XmlElement(ElementName = "EUC_CC_INPUT")]
        public EUC_CC_INPUT EUC_CC_INPUT { get; set; }
        [XmlElement(ElementName = "EUC_CC_SID_DEBITUR_DATA")]
        public EUC_CC_SID_DEBITUR_DATA EUC_CC_SID_DEBITUR_DATA { get; set; }

        [XmlElement(ElementName = "EUC_CC_SID_ALAMAT_DATA")]
        public EUC_CC_SID_ALAMAT_DATA EUC_CC_SID_ALAMAT_DATA { get; set; }

        [XmlElement(ElementName = "EUC_CC_SID_AGUNAN_DATA")]
        public EUC_CC_SID_AGUNAN_DATA EUC_CC_SID_AGUNAN_DATA { get; set; }

        [XmlElement(ElementName = "EUC_CC_SID_KOLEKTIBILITAS_DATA")]
        public EUC_CC_SID_KOLEKTIBILITAS_DATA EUC_CC_SID_KOLEKTIBILITAS_DATA { get; set; }

        [XmlElement(ElementName = "EUC_CC_SID_PEKERJAAN_DATA")]
        public EUC_CC_SID_PEKERJAAN_DATA EUC_CC_SID_PEKERJAAN_DATA { get; set; }

        [XmlElement(ElementName = "EUC_CC_SID_SUMBER_DATA")]
        public EUC_CC_SID_SUMBER_DATA EUC_CC_SID_SUMBER_DATA { get; set; }

        [XmlElement(ElementName = "EUC_CC_SID_SUMMARY_DATA")]
        public EUC_CC_SID_SUMMARY_DATA EUC_CC_SID_SUMMARY_DATA { get; set; }
    }
    //[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
    //public string Xsi { get; set; }
    //[XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
    //public string Xsd { get; set; }

}
