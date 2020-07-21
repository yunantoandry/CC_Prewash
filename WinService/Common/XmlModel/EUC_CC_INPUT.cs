using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.XmlModel
{

    [XmlRoot(ElementName = "EUC_CC_INPUT")]
    public class EUC_CC_INPUT
    {
        [XmlElement(ElementName = "NAME")]
        public string NAME { get; set; }
        [XmlElement(ElementName = "DOB")]
        public string DOB { get; set; }
        [XmlElement(ElementName = "GENDER")]
        public string GENDER { get; set; }
        //[XmlElement(ElementName = "SAS_ID")]
        //public string SAS_ID { get; set; }
        [XmlElement(ElementName = "DOB2")]
        public string DOB2 { get; set; }
        [XmlElement(ElementName = "NOMORCIF")]
        public string NOMORCIF { get; set; }
        [XmlElement(ElementName = "NATIONALITY")]
        public string NATIONALITY { get; set; }
        [XmlElement(ElementName = "SEGMENT")]
        public string SEGMENT { get; set; }
        [XmlElement(ElementName = "LEADS_DATE")]
        public string LEADS_DATE { get; set; }
        [XmlElement(ElementName = "POB")]
        public string POB { get; set; }
        [XmlElement(ElementName = "DES")]
        public string DES { get; set; }
        [XmlElement(ElementName = "EDU_DESC")]
        public string EDU_DESC { get; set; }
        [XmlElement(ElementName = "MR_DESC")]
        public string MR_DESC { get; set; }
        [XmlElement(ElementName = "EMAIL")]
        public string EMAIL { get; set; }
        [XmlElement(ElementName = "HOME_ZIPCODE")]
        public string HOME_ZIPCODE { get; set; }
        [XmlElement(ElementName = "MGROSS_INCOME")]
        public string MGROSS_INCOME { get; set; }
        [XmlElement(ElementName = "AGROSS_INCOME")]
        public string AGROSS_INCOME { get; set; }
        [XmlElement(ElementName = "SALES_CH")]
        public string SALES_CH { get; set; }
        [XmlElement(ElementName = "BUS_TYPE")]
        public string BUS_TYPE { get; set; }
        [XmlElement(ElementName = "ADDRESS_1A")]
        public string ADDRESS_1A { get; set; }
        [XmlElement(ElementName = "ADDRESS_1B")]
        public string ADDRESS_1B { get; set; }
        [XmlElement(ElementName = "ADDRESS_1C")]
        public string ADDRESS_1C { get; set; }
        [XmlElement(ElementName = "ADDRESS_1D")]
        public string ADDRESS_1D { get; set; }
        [XmlElement(ElementName = "ADDRESS_1E")]
        public string ADDRESS_1E { get; set; }
        [XmlElement(ElementName = "ADDRESS_2A")]
        public string ADDRESS_2A { get; set; }
        [XmlElement(ElementName = "ADDRESS_2B")]
        public string ADDRESS_2B { get; set; }
        [XmlElement(ElementName = "ADDRESS_2C")]
        public string ADDRESS_2C { get; set; }
        [XmlElement(ElementName = "ADDRESS_2D")]
        public string ADDRESS_2D { get; set; }
        [XmlElement(ElementName = "ADDRESS_2E")]
        public string ADDRESS_2E { get; set; }
        [XmlElement(ElementName = "ADDRESS_3A")]
        public string ADDRESS_3A { get; set; }
        [XmlElement(ElementName = "ADDRESS_3B")]
        public string ADDRESS_3B { get; set; }
        [XmlElement(ElementName = "ADDRESS_3C")]
        public string ADDRESS_3C { get; set; }
        [XmlElement(ElementName = "ADDRESS_3D")]
        public string ADDRESS_3D { get; set; }
        [XmlElement(ElementName = "ADDRESS_3E")]
        public string ADDRESS_3E { get; set; }
        [XmlElement(ElementName = "ADDRESS_4A")]
        public string ADDRESS_4A { get; set; }
        [XmlElement(ElementName = "ADDRESS_4B")]
        public string ADDRESS_4B { get; set; }
        [XmlElement(ElementName = "ADDRESS_4C")]
        public string ADDRESS_4C { get; set; }
        [XmlElement(ElementName = "ADDRESS_4D")]
        public string ADDRESS_4D { get; set; }
        [XmlElement(ElementName = "ADDRESS_4E")]
        public string ADDRESS_4E { get; set; }
        [XmlElement(ElementName = "CITY_A")]
        public string CITY_A { get; set; }
        [XmlElement(ElementName = "CITY_B")]
        public string CITY_B { get; set; }
        [XmlElement(ElementName = "CITY_C")]
        public string CITY_C { get; set; }
        [XmlElement(ElementName = "CITY_D")]
        public string CITY_D { get; set; }
        [XmlElement(ElementName = "CITY_E")]
        public string CITY_E { get; set; }
        [XmlElement(ElementName = "PROVINCE_A")]
        public string PROVINCE_A { get; set; }
        [XmlElement(ElementName = "PROVINCE_B")]
        public string PROVINCE_B { get; set; }
        [XmlElement(ElementName = "PROVINCE_C")]
        public string PROVINCE_C { get; set; }
        [XmlElement(ElementName = "PROVINCE_D")]
        public string PROVINCE_D { get; set; }
        [XmlElement(ElementName = "PROVINCE_E")]
        public string PROVINCE_E { get; set; }
        [XmlElement(ElementName = "ZIPCODE_A")]
        public string ZIPCODE_A { get; set; }
        [XmlElement(ElementName = "ZIPCODE_B")]
        public string ZIPCODE_B { get; set; }
        [XmlElement(ElementName = "ZIPCODE_C")]
        public string ZIPCODE_C { get; set; }
        [XmlElement(ElementName = "ZIPCODE_D")]
        public string ZIPCODE_D { get; set; }
        [XmlElement(ElementName = "ZIPCODE_E")]
        public string ZIPCODE_E { get; set; }
        [XmlElement(ElementName = "NPWP")]
        public string NPWP { get; set; }
        [XmlElement(ElementName = "KTP1")]
        public string KTP1 { get; set; }
        [XmlElement(ElementName = "KTP2")]
        public string KTP2 { get; set; }
        [XmlElement(ElementName = "KTP3")]
        public string KTP3 { get; set; }
        [XmlElement(ElementName = "KTP4")]
        public string KTP4 { get; set; }
        [XmlElement(ElementName = "KTP5")]
        public string KTP5 { get; set; }
        [XmlElement(ElementName = "KTP6")]
        public string KTP6 { get; set; }
        [XmlElement(ElementName = "KTP7")]
        public string KTP7 { get; set; }
        [XmlElement(ElementName = "KTP8")]
        public string KTP8 { get; set; }
        [XmlElement(ElementName = "KTP9")]
        public string KTP9 { get; set; }
        [XmlElement(ElementName = "KTP10")]
        public string KTP10 { get; set; }
        [XmlElement(ElementName = "NO_OF_DEPENDANT")]
        public string NO_OF_DEPENDANT { get; set; }
        [XmlElement(ElementName = "FLAG_AUM")]
        public string FLAG_AUM { get; set; }
        [XmlElement(ElementName = "BATCH")]
        public string BATCH { get; set; }

        [XmlElement(ElementName = "Reserved_1")]
        public string Reserved_1 { get; set; }
        [XmlElement(ElementName = "Reserved_2")]
        public string Reserved_2 { get; set; }
        [XmlElement(ElementName = "Reserved_3")]
        public string Reserved_3 { get; set; }
        [XmlElement(ElementName = "Reserved_4")]
        public string Reserved_4 { get; set; }
        [XmlElement(ElementName = "Reserved_5")]
        public string Reserved_5 { get; set; }
        [XmlElement(ElementName = "Reserved_6")]
        public string Reserved_6 { get; set; }
        [XmlElement(ElementName = "Reserved_7")]
        public string Reserved_7 { get; set; }
        [XmlElement(ElementName = "Reserved_8")]
        public string Reserved_8 { get; set; }
        [XmlElement(ElementName = "Reserved_9")]
        public string Reserved_9 { get; set; }
        [XmlElement(ElementName = "Reserved_10")]
        public string Reserved_10 { get; set; }
    }
}
