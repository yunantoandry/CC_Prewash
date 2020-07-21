using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.XmlModel
{
    [XmlRoot(ElementName = "EUC_CC_SID_KOLEKTIBILITAS")]
    public class EUC_CC_SID_KOLEKTIBILITAS
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
        [XmlElement(ElementName = "SIFAT")]
        public string SIFAT { get; set; }
        [XmlElement(ElementName = "NO_REK")]
        public string NO_REK { get; set; }
        [XmlElement(ElementName = "UPDATE_DATE")]
        public string UPDATE_DATE { get; set; }
        [XmlElement(ElementName = "AKTIF")]
        public string AKTIF { get; set; }
        [XmlElement(ElementName = "VALUTA")]
        public string VALUTA { get; set; }
        [XmlElement(ElementName = "BUNGA")]
        public string BUNGA { get; set; }
        [XmlElement(ElementName = "PLAFON")]
        public string PLAFON { get; set; }
        [XmlElement(ElementName = "BAKI_DEBET")]
        public string BAKI_DEBET { get; set; }
        [XmlElement(ElementName = "TG_POKOK")]
        public string TG_POKOK { get; set; }
        [XmlElement(ElementName = "TG_FREQ")]
        public string TG_FREQ { get; set; }
        [XmlElement(ElementName = "TG_BUNGA_ON")]
        public string TG_BUNGA_ON { get; set; }
        [XmlElement(ElementName = "TG_BUNGA_OFF")]
        public string TG_BUNGA_OFF { get; set; }
        [XmlElement(ElementName = "PG_SEKTOR_EK")]
        public string PG_SEKTOR_EK { get; set; }
        [XmlElement(ElementName = "PG_JENIS")]
        public string PG_JENIS { get; set; }
        [XmlElement(ElementName = "ST_KONDISI")]
        public string ST_KONDISI { get; set; }
        [XmlElement(ElementName = "ST_MACET")]
        public string ST_MACET { get; set; }
        [XmlElement(ElementName = "ST_TGL_KONDISI")]
        public string ST_TGL_KONDISI { get; set; }
        [XmlElement(ElementName = "ST_TGL_MACET")]
        public string ST_TGL_MACET { get; set; }
        [XmlElement(ElementName = "JG_AKAD_AWAL")]
        public string JG_AKAD_AWAL { get; set; }
        [XmlElement(ElementName = "JG_JATUH_TEMPO")]
        public string JG_JATUH_TEMPO { get; set; }
        [XmlElement(ElementName = "BL01")]
        public string BL01 { get; set; }
        [XmlElement(ElementName = "KK01")]
        public string KK01 { get; set; }
        [XmlElement(ElementName = "TG01")]
        public string TG01 { get; set; }
        [XmlElement(ElementName = "BL02")]
        public string BL02 { get; set; }
        [XmlElement(ElementName = "KK02")]
        public string KK02 { get; set; }
        [XmlElement(ElementName = "TG02")]
        public string TG02 { get; set; }
        [XmlElement(ElementName = "BL03")]
        public string BL03 { get; set; }
        [XmlElement(ElementName = "KK03")]
        public string KK03 { get; set; }
        [XmlElement(ElementName = "TG03")]
        public string TG03 { get; set; }
        [XmlElement(ElementName = "BL04")]
        public string BL04 { get; set; }
        [XmlElement(ElementName = "KK04")]
        public string KK04 { get; set; }
        [XmlElement(ElementName = "TG04")]
        public string TG04 { get; set; }
        [XmlElement(ElementName = "BL05")]
        public string BL05 { get; set; }
        [XmlElement(ElementName = "KK05")]
        public string KK05 { get; set; }
        [XmlElement(ElementName = "TG05")]
        public string TG05 { get; set; }
        [XmlElement(ElementName = "BL06")]
        public string BL06 { get; set; }
        [XmlElement(ElementName = "KK06")]
        public string KK06 { get; set; }
        [XmlElement(ElementName = "TG06")]
        public string TG06 { get; set; }
        [XmlElement(ElementName = "BL07")]
        public string BL07 { get; set; }
        [XmlElement(ElementName = "KK07")]
        public string KK07 { get; set; }
        [XmlElement(ElementName = "TG07")]
        public string TG07 { get; set; }
        [XmlElement(ElementName = "BL08")]
        public string BL08 { get; set; }
        [XmlElement(ElementName = "KK08")]
        public string KK08 { get; set; }
        [XmlElement(ElementName = "TG08")]
        public string TG08 { get; set; }
        [XmlElement(ElementName = "BL09")]
        public string BL09 { get; set; }
        [XmlElement(ElementName = "KK09")]
        public string KK09 { get; set; }
        [XmlElement(ElementName = "TG09")]
        public string TG09 { get; set; }
        [XmlElement(ElementName = "BL10")]
        public string BL10 { get; set; }
        [XmlElement(ElementName = "KK10")]
        public string KK10 { get; set; }
        [XmlElement(ElementName = "TG10")]
        public string TG10 { get; set; }
        [XmlElement(ElementName = "BL11")]
        public string BL11 { get; set; }
        [XmlElement(ElementName = "KK11")]
        public string KK11 { get; set; }
        [XmlElement(ElementName = "TG11")]
        public string TG11 { get; set; }
        [XmlElement(ElementName = "BL12")]
        public string BL12 { get; set; }
        [XmlElement(ElementName = "KK12")]
        public string KK12 { get; set; }
        [XmlElement(ElementName = "TG12")]
        public string TG12 { get; set; }
        [XmlElement(ElementName = "BL13")]
        public string BL13 { get; set; }
        [XmlElement(ElementName = "KK13")]
        public string KK13 { get; set; }
        [XmlElement(ElementName = "TG13")]
        public string TG13 { get; set; }
        [XmlElement(ElementName = "BL14")]
        public string BL14 { get; set; }
        [XmlElement(ElementName = "KK14")]
        public string KK14 { get; set; }
        [XmlElement(ElementName = "TG14")]
        public string TG14 { get; set; }
        [XmlElement(ElementName = "BL15")]
        public string BL15 { get; set; }
        [XmlElement(ElementName = "KK15")]
        public string KK15 { get; set; }
        [XmlElement(ElementName = "TG15")]
        public string TG15 { get; set; }
        [XmlElement(ElementName = "BL16")]
        public string BL16 { get; set; }
        [XmlElement(ElementName = "KK16")]
        public string KK16 { get; set; }
        [XmlElement(ElementName = "TG16")]
        public string TG16 { get; set; }
        [XmlElement(ElementName = "BL17")]
        public string BL17 { get; set; }
        [XmlElement(ElementName = "KK17")]
        public string KK17 { get; set; }
        [XmlElement(ElementName = "TG17")]
        public string TG17 { get; set; }
        [XmlElement(ElementName = "BL18")]
        public string BL18 { get; set; }
        [XmlElement(ElementName = "KK18")]
        public string KK18 { get; set; }
        [XmlElement(ElementName = "TG18")]
        public string TG18 { get; set; }
        [XmlElement(ElementName = "BL19")]
        public string BL19 { get; set; }
        [XmlElement(ElementName = "KK19")]
        public string KK19 { get; set; }
        [XmlElement(ElementName = "TG19")]
        public string TG19 { get; set; }
        [XmlElement(ElementName = "BL20")]
        public string BL20 { get; set; }
        [XmlElement(ElementName = "KK20")]
        public string KK20 { get; set; }
        [XmlElement(ElementName = "TG20")]
        public string TG20 { get; set; }
        [XmlElement(ElementName = "BL21")]
        public string BL21 { get; set; }
        [XmlElement(ElementName = "KK21")]
        public string KK21 { get; set; }
        [XmlElement(ElementName = "TG21")]
        public string TG21 { get; set; }
        [XmlElement(ElementName = "BL22")]
        public string BL22 { get; set; }
        [XmlElement(ElementName = "KK22")]
        public string KK22 { get; set; }
        [XmlElement(ElementName = "TG22")]
        public string TG22 { get; set; }
        [XmlElement(ElementName = "BL23")]
        public string BL23 { get; set; }
        [XmlElement(ElementName = "KK23")]
        public string KK23 { get; set; }
        [XmlElement(ElementName = "TG23")]
        public string TG23 { get; set; }
        [XmlElement(ElementName = "BL24")]
        public string BL24 { get; set; }
        [XmlElement(ElementName = "KK24")]
        public string KK24 { get; set; }
        [XmlElement(ElementName = "TG24")]
        public string TG24 { get; set; }
        [XmlElement(ElementName = "GOL_KREDIT")]
        public string GOL_KREDIT { get; set; }
        [XmlElement(ElementName = "ID_CREDIT")]
        public string ID_CREDIT { get; set; }
        [XmlElement(ElementName = "KD_PG_JENIS")]
        public string KD_PG_JENIS { get; set; }
        [XmlElement(ElementName = "JENIS_KREDIT_KET")]
        public string JENIS_KREDIT_KET { get; set; }
        [XmlElement(ElementName = "SIFAT_KREDIT")]
        public string SIFAT_KREDIT { get; set; }
        [XmlElement(ElementName = "SIFAT_KREDIT_KET")]
        public string SIFAT_KREDIT_KET { get; set; }
        [XmlElement(ElementName = "AKAD_PEMBIAYAAN")]
        public string AKAD_PEMBIAYAAN { get; set; }
        [XmlElement(ElementName = "AKAD_PEMBIAYAAN_KET")]
        public string AKAD_PEMBIAYAAN_KET { get; set; }
        [XmlElement(ElementName = "KATEGORI_DEBITUR_KET")]
        public string KATEGORI_DEBITUR_KET { get; set; }
        [XmlElement(ElementName = "CABANG_PELAPOR")]
        public string CABANG_PELAPOR { get; set; }
        [XmlElement(ElementName = "TGL_MULAI")]
        public string TGL_MULAI { get; set; }
        [XmlElement(ElementName = "KD_PG_SEKTOR_EK")]
        public string KD_PG_SEKTOR_EK { get; set; }
        [XmlElement(ElementName = "FREK_REST")]
        public string FREK_REST { get; set; }
        [XmlElement(ElementName = "TGL_REST_AKHIR")]
        public string TGL_REST_AKHIR { get; set; }
        [XmlElement(ElementName = "KODE_CARA_REST")]
        public string KODE_CARA_REST { get; set; }
        [XmlElement(ElementName = "CARA_REST")]
        public string CARA_REST { get; set; }
        [XmlElement(ElementName = "KODE_SUKU_BUNGA")]
        public string KODE_SUKU_BUNGA { get; set; }
        [XmlElement(ElementName = "JENIS_SUKU_BUNGA")]
        public string JENIS_SUKU_BUNGA { get; set; }
        [XmlElement(ElementName = "PLAFON_AWAL")]
        public string PLAFON_AWAL { get; set; }
        [XmlElement(ElementName = "TGL_AWAL_KREDIT")]
        public string TGL_AWAL_KREDIT { get; set; }
    }
}
