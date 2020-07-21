
using Common.Model;
using Common.Repository;
using Common.Utils;
using Common.XmlModel;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Common.XML
{
    public class XMLCreateCRDE : CreateFiles
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public XMLCreateCRDE()
        {

        }
        public void Handle(euc_cc_input euc_cc_input)
        {
            _log.Info($"Create XML sas_id {euc_cc_input.SAS_ID}");
           // IDbTransaction trans = null;
            //string fldTemp = Constants.WmosTempTransactionsReadySubFolder;
            using (DBHelper db = new DBHelper())
            {
              //  trans = db.OpenTransaction();
                try
                {
                    CRDECreditScoringRequest crdeXml = new CRDECreditScoringRequest
                    {
                        Application_Header = new Application_Header
                        {
                            Source = "ECC",
                            CallType = "EUC",
                        },
                        Application = new Application
                        {
                            ApplicationNumber = euc_cc_input.SAS_ID,
                            IsBIDown = "N",
                        },
                        //yyyyMMddHHmmssfff
                        EUC_CC_INPUT = new EUC_CC_INPUT
                        {
                            // = new euc_cc_input();
                            NAME = !string.IsNullOrEmpty(euc_cc_input.NAME) ? euc_cc_input.NAME : "",
                            DOB = euc_cc_input.DOB != DateTime.MinValue ? euc_cc_input.DOB.ToString("yyyy-MM-dd") : "",
                            DOB2 = euc_cc_input.DOB2 != DateTime.MinValue ? euc_cc_input.DOB2.ToString("yyyy-MM-dd") : "",
                            GENDER = !string.IsNullOrEmpty(euc_cc_input.GENDER) ? euc_cc_input.GENDER : "",
                            //SAS_ID = !string.IsNullOrEmpty(euc_cc_input.SAS_ID) ? euc_cc_input.SAS_ID : "",                     
                            NOMORCIF = !string.IsNullOrEmpty(euc_cc_input.NOMORCIF) ? euc_cc_input.NOMORCIF : "",
                            NATIONALITY = !string.IsNullOrEmpty(euc_cc_input.NATIONALITY) ? euc_cc_input.NATIONALITY : "",
                            SEGMENT = !string.IsNullOrEmpty(euc_cc_input.SEGMENT) ? euc_cc_input.SEGMENT : "",
                            LEADS_DATE = euc_cc_input.LEADS_DATE != DateTime.MinValue ? euc_cc_input.LEADS_DATE.ToString("yyyy-MM-dd") : "",
                            POB = !string.IsNullOrEmpty(euc_cc_input.POB) ? euc_cc_input.POB : "",
                            DES = !string.IsNullOrEmpty(euc_cc_input.DES) ? euc_cc_input.DES : "",
                            EDU_DESC = !string.IsNullOrEmpty(euc_cc_input.EDU_DESC) ? euc_cc_input.EDU_DESC : "",
                            MR_DESC = !string.IsNullOrEmpty(euc_cc_input.MR_DESC) ? euc_cc_input.MR_DESC : "",
                            EMAIL = !string.IsNullOrEmpty(euc_cc_input.EMAIL) ? euc_cc_input.EMAIL : "",                          
                            HOME_ZIPCODE = !string.IsNullOrEmpty(euc_cc_input.HOME_ZIPCODE) ? euc_cc_input.HOME_ZIPCODE : "",
                            MGROSS_INCOME = euc_cc_input.MGROSS_INCOME.ToString("#.##"),
                            AGROSS_INCOME = euc_cc_input.AGROSS_INCOME.ToString("#.##"),
                            SALES_CH = !string.IsNullOrEmpty(euc_cc_input.SALES_CH) ? euc_cc_input.SALES_CH : "",
                            BUS_TYPE = !string.IsNullOrEmpty(euc_cc_input.BUS_TYPE) ? euc_cc_input.BUS_TYPE : "",
                            ADDRESS_1A = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_1A) ? euc_cc_input.ADDRESS_1A : "",
                            ADDRESS_1B = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_1B) ? euc_cc_input.ADDRESS_1B : "",
                            ADDRESS_1C = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_1C) ? euc_cc_input.ADDRESS_1C : "",
                            ADDRESS_1D = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_1D) ? euc_cc_input.ADDRESS_1D : "",
                            ADDRESS_1E = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_1E) ? euc_cc_input.ADDRESS_1E : "",
                            ADDRESS_2A = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_2A) ? euc_cc_input.ADDRESS_2A : "",
                            ADDRESS_2B = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_2B) ? euc_cc_input.ADDRESS_2B : "",
                            ADDRESS_2C = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_2C) ? euc_cc_input.ADDRESS_2C : "",
                            ADDRESS_2D = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_2D) ? euc_cc_input.ADDRESS_2D : "",
                            ADDRESS_2E = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_2E) ? euc_cc_input.ADDRESS_2E : "",
                            ADDRESS_3A = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_3A) ? euc_cc_input.ADDRESS_3A : "",
                            ADDRESS_3B = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_3B) ? euc_cc_input.ADDRESS_3B : "",
                            ADDRESS_3C = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_3C) ? euc_cc_input.ADDRESS_3C : "",
                            ADDRESS_3D = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_3D) ? euc_cc_input.ADDRESS_3D : "",
                            ADDRESS_3E = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_3E) ? euc_cc_input.ADDRESS_3E : "",
                            ADDRESS_4A = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_4A) ? euc_cc_input.ADDRESS_4A : "",
                            ADDRESS_4B = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_4B) ? euc_cc_input.ADDRESS_4B : "",
                            ADDRESS_4C = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_4C) ? euc_cc_input.ADDRESS_4C : "",
                            ADDRESS_4D = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_4D) ? euc_cc_input.ADDRESS_4D : "",
                            ADDRESS_4E = !string.IsNullOrEmpty(euc_cc_input.ADDRESS_4E) ? euc_cc_input.ADDRESS_4E : "",
                            CITY_A = !string.IsNullOrEmpty(euc_cc_input.CITY_A) ? euc_cc_input.CITY_A : "",
                            CITY_B = !string.IsNullOrEmpty(euc_cc_input.CITY_B) ? euc_cc_input.CITY_B : "",
                            CITY_C = !string.IsNullOrEmpty(euc_cc_input.CITY_C) ? euc_cc_input.CITY_C : "",
                            CITY_D = !string.IsNullOrEmpty(euc_cc_input.CITY_D) ? euc_cc_input.CITY_D : "",
                            CITY_E = !string.IsNullOrEmpty(euc_cc_input.CITY_E) ? euc_cc_input.CITY_E : "",
                            PROVINCE_A = !string.IsNullOrEmpty(euc_cc_input.PROVINCE_A) ? euc_cc_input.PROVINCE_A : "",
                            PROVINCE_B = !string.IsNullOrEmpty(euc_cc_input.PROVINCE_B) ? euc_cc_input.PROVINCE_B : "",
                            PROVINCE_C = !string.IsNullOrEmpty(euc_cc_input.PROVINCE_C) ? euc_cc_input.PROVINCE_C : "",
                            PROVINCE_D = !string.IsNullOrEmpty(euc_cc_input.PROVINCE_D) ? euc_cc_input.PROVINCE_D : "",
                            PROVINCE_E = !string.IsNullOrEmpty(euc_cc_input.PROVINCE_E) ? euc_cc_input.PROVINCE_E : "",
                            ZIPCODE_A = !string.IsNullOrEmpty(euc_cc_input.ZIPCODE_A) ? euc_cc_input.ZIPCODE_A : "",
                            ZIPCODE_B = !string.IsNullOrEmpty(euc_cc_input.ZIPCODE_B) ? euc_cc_input.ZIPCODE_B : "",
                            ZIPCODE_C = !string.IsNullOrEmpty(euc_cc_input.ZIPCODE_C) ? euc_cc_input.ZIPCODE_C : "",
                            ZIPCODE_D = !string.IsNullOrEmpty(euc_cc_input.ZIPCODE_D) ? euc_cc_input.ZIPCODE_D : "",
                            ZIPCODE_E = !string.IsNullOrEmpty(euc_cc_input.ZIPCODE_E) ? euc_cc_input.ZIPCODE_E : "",
                            NPWP = !string.IsNullOrEmpty(euc_cc_input.NPWP) ? euc_cc_input.NPWP : "",
                            KTP1 = !string.IsNullOrEmpty(euc_cc_input.KTP1) ? euc_cc_input.KTP1 : "",
                            KTP2 = !string.IsNullOrEmpty(euc_cc_input.KTP2) ? euc_cc_input.KTP2 : "",
                            KTP3 = !string.IsNullOrEmpty(euc_cc_input.KTP3) ? euc_cc_input.KTP3 : "",
                            KTP4 = !string.IsNullOrEmpty(euc_cc_input.KTP4) ? euc_cc_input.KTP4 : "",
                            KTP5 = !string.IsNullOrEmpty(euc_cc_input.KTP5) ? euc_cc_input.KTP5 : "",
                            KTP6 = !string.IsNullOrEmpty(euc_cc_input.KTP6) ? euc_cc_input.KTP6 : "",
                            KTP7 = !string.IsNullOrEmpty(euc_cc_input.KTP7) ? euc_cc_input.KTP7 : "",
                            KTP8 = !string.IsNullOrEmpty(euc_cc_input.KTP8) ? euc_cc_input.KTP8 : "",
                            KTP9 = !string.IsNullOrEmpty(euc_cc_input.KTP9) ? euc_cc_input.KTP9 : "",
                            KTP10 = !string.IsNullOrEmpty(euc_cc_input.KTP10) ? euc_cc_input.KTP10 : "",
                            NO_OF_DEPENDANT = !string.IsNullOrEmpty(euc_cc_input.NO_OF_DEPENDANT) ? euc_cc_input.NO_OF_DEPENDANT : "",
                            FLAG_AUM = !string.IsNullOrEmpty(euc_cc_input.FLAG_AUM) ? euc_cc_input.FLAG_AUM : "",
                            BATCH = !string.IsNullOrEmpty(euc_cc_input.BATCH) ? euc_cc_input.BATCH : "",
                            Reserved_1 = !string.IsNullOrEmpty(euc_cc_input.Reserved_1) ? euc_cc_input.Reserved_1 : "",
                            Reserved_2 = !string.IsNullOrEmpty(euc_cc_input.Reserved_2) ? euc_cc_input.Reserved_2 : "",
                            Reserved_3 = !string.IsNullOrEmpty(euc_cc_input.Reserved_3) ? euc_cc_input.Reserved_3 : "",
                            Reserved_4 = !string.IsNullOrEmpty(euc_cc_input.Reserved_4) ? euc_cc_input.Reserved_4 : "",
                            Reserved_5 = !string.IsNullOrEmpty(euc_cc_input.Reserved_5) ? euc_cc_input.Reserved_5 : "",
                            Reserved_6 = !string.IsNullOrEmpty(euc_cc_input.Reserved_6) ? euc_cc_input.Reserved_6 : "",
                            Reserved_7 = !string.IsNullOrEmpty(euc_cc_input.Reserved_7) ? euc_cc_input.Reserved_7 : "",
                            Reserved_8 = !string.IsNullOrEmpty(euc_cc_input.Reserved_8) ? euc_cc_input.Reserved_8 : "",
                            Reserved_9 = !string.IsNullOrEmpty(euc_cc_input.Reserved_9) ? euc_cc_input.Reserved_9 : "",
                            Reserved_10 = !string.IsNullOrEmpty(euc_cc_input.Reserved_10) ? euc_cc_input.Reserved_10 : "",

                        },


                        EUC_CC_SID_DEBITUR_DATA = new EUC_CC_SID_DEBITUR_DATA
                        {
                            EUC_CC_SID_DEBITUR = new List<EUC_CC_SID_DEBITUR>(),
                        },

                        EUC_CC_SID_ALAMAT_DATA = new EUC_CC_SID_ALAMAT_DATA
                        {
                            EUC_CC_SID_ALAMAT = new List<EUC_CC_SID_ALAMAT>(),
                        },

                        EUC_CC_SID_AGUNAN_DATA = new EUC_CC_SID_AGUNAN_DATA
                        {
                            EUC_CC_SID_AGUNAN = new List<EUC_CC_SID_AGUNAN>(),
                        },
                        EUC_CC_SID_KOLEKTIBILITAS_DATA = new EUC_CC_SID_KOLEKTIBILITAS_DATA
                        {
                            EUC_CC_SID_KOLEKTIBILITAS = new List<EUC_CC_SID_KOLEKTIBILITAS>(),
                        },
                        EUC_CC_SID_PEKERJAAN_DATA = new EUC_CC_SID_PEKERJAAN_DATA
                        {
                            EUC_CC_SID_PEKERJAAN = new List<EUC_CC_SID_PEKERJAAN>(),
                        },
                        EUC_CC_SID_SUMBER_DATA = new EUC_CC_SID_SUMBER_DATA
                        {
                            EUC_CC_SID_SUMBER = new List<EUC_CC_SID_SUMBER>(),
                        },
                        EUC_CC_SID_SUMMARY_DATA = new EUC_CC_SID_SUMMARY_DATA
                        {
                            EUC_CC_SID_SUMMARY = new List<EUC_CC_SID_SUMMARY>(),
                        },
                    };
                    Rep_ms_euc_cc_input Rep_ms_euc_cc_input = new Rep_ms_euc_cc_input(db);
                    Rep_ms_euc_cc_sid_debitur Rep_ms_euc_cc_sid_debitur = new Rep_ms_euc_cc_sid_debitur(db);


                    List<euc_cc_input> listEucCcInput = Rep_ms_euc_cc_input.GetAll(string.Format(" WHERE SAS_ID='{0}' ", euc_cc_input.SAS_ID));
                    List<euc_cc_sid_debitur> listEucCcSidDebitur = Rep_ms_euc_cc_sid_debitur.GetAll(string.Format(" WHERE SAS_ID ='{0}' ", euc_cc_input.SAS_ID));

                    foreach (euc_cc_sid_debitur oDebitur in listEucCcSidDebitur)
                    {
                        EUC_CC_SID_DEBITUR debitur = new EUC_CC_SID_DEBITUR
                        {
                            IDIFILE = !string.IsNullOrEmpty(oDebitur.IDIFILE) ? oDebitur.IDIFILE : "",
                            TGL_LAPORAN = oDebitur.TGL_LAPORAN != DateTime.MinValue ? oDebitur.TGL_LAPORAN.ToString("yyyy-MM-dd") : "",

                            PROGRAM = !string.IsNullOrEmpty(oDebitur.PROGRAM) ? oDebitur.PROGRAM : "",
                            DIN = !string.IsNullOrEmpty(oDebitur.DIN) ? oDebitur.DIN : "",
                            LAP_NO = !string.IsNullOrEmpty(oDebitur.LAP_NO) ? oDebitur.LAP_NO : "",
                            LAP_POSISIAKHIR = oDebitur.LAP_POSISIAKHIR != DateTime.MinValue ? oDebitur.LAP_POSISIAKHIR.ToString("yyyy-MM-dd") : "",
                            LAP_USER = !string.IsNullOrEmpty(oDebitur.LAP_USER) ? oDebitur.LAP_USER : "",
                            PRM_TGL = oDebitur.PRM_TGL != DateTime.MinValue ? oDebitur.PRM_TGL.ToString("yyyy-MM-dd") : "",
                            PRM_NO = !string.IsNullOrEmpty(oDebitur.PRM_NO) ? oDebitur.PRM_NO : "",
                            PRM_NAMA_DEBITUR = !string.IsNullOrEmpty(oDebitur.PRM_NAMA_DEBITUR) ? oDebitur.PRM_NAMA_DEBITUR : "",
                            PRM_TEMPAT_LAHIR = !string.IsNullOrEmpty(oDebitur.PRM_TEMPAT_LAHIR) ? oDebitur.PRM_TEMPAT_LAHIR : "",
                            PRM_TGL_LAHIR = oDebitur.PRM_TGL_LAHIR != DateTime.MinValue ? oDebitur.PRM_TGL_LAHIR.ToString("yyyy-MM-dd") : "",
                            PRM_NPWP = !string.IsNullOrEmpty(oDebitur.PRM_NPWP) ? oDebitur.PRM_NPWP : "",
                            PRM_KTP = !string.IsNullOrEmpty(oDebitur.PRM_KTP) ? oDebitur.PRM_KTP : "",
                            PRM_PASSPORT = !string.IsNullOrEmpty(oDebitur.PRM_PASSPORT) ? oDebitur.PRM_PASSPORT : "",
                        };
                        crdeXml.EUC_CC_SID_DEBITUR_DATA.EUC_CC_SID_DEBITUR.Add(debitur);
                    }
                    Rep_ms_euc_cc_sid_alamat Rep_ms_euc_cc_sid_alamat = new Rep_ms_euc_cc_sid_alamat(db);
                    List<euc_cc_sid_alamat> listEucCcSidAlamat = Rep_ms_euc_cc_sid_alamat.GetAll(string.Format("WHERE SAS_ID ='{0}' ", euc_cc_input.SAS_ID));

                    foreach (euc_cc_sid_alamat oAlamat in listEucCcSidAlamat)
                    {
                        EUC_CC_SID_ALAMAT alamat = new EUC_CC_SID_ALAMAT
                        {
                            IDIFILE = !string.IsNullOrEmpty(oAlamat.IDIFILE) ? oAlamat.IDIFILE : "",
                            TGL_LAPORAN = oAlamat.TGL_LAPORAN != DateTime.MinValue ? oAlamat.TGL_LAPORAN.ToString("yyyy-MM-dd") : "",
                            PROGRAM = !string.IsNullOrEmpty(oAlamat.PROGRAM) ? oAlamat.PROGRAM : "",
                            DIN = !string.IsNullOrEmpty(oAlamat.DIN) ? oAlamat.DIN : "",
                            NO = !string.IsNullOrEmpty(oAlamat.NO) ? oAlamat.NO : "",
                            ALAMAT = !string.IsNullOrEmpty(oAlamat.ALAMAT) ? oAlamat.ALAMAT : "",
                            KELURAHAN = !string.IsNullOrEmpty(oAlamat.KELURAHAN) ? oAlamat.KELURAHAN : "",
                            KECAMATAN = !string.IsNullOrEmpty(oAlamat.KECAMATAN) ? oAlamat.KECAMATAN : "",
                            DATI_II = !string.IsNullOrEmpty(oAlamat.DATI_II) ? oAlamat.DATI_II : "",
                            KODEPOS = !string.IsNullOrEmpty(oAlamat.KODEPOS) ? oAlamat.KODEPOS : "",
                            NEGARA = !string.IsNullOrEmpty(oAlamat.NEGARA) ? oAlamat.NEGARA : "",
                            UPDATE_DATE = oAlamat.UPDATE_DATE != DateTime.MinValue ? oAlamat.UPDATE_DATE.ToString("yyyy-MM-dd") : "",
                            PELAPOR = !string.IsNullOrEmpty(oAlamat.PELAPOR) ? oAlamat.PELAPOR : "",
                        };
                        crdeXml.EUC_CC_SID_ALAMAT_DATA.EUC_CC_SID_ALAMAT.Add(alamat);
                    }


                    Rep_ms_euc_cc_sid_agunan Rep_ms_euc_cc_sid_agunan = new Rep_ms_euc_cc_sid_agunan(db);
                    List<euc_cc_sid_agunan> listEucCcSidAgunan = Rep_ms_euc_cc_sid_agunan.GetAll(string.Format(" WHERE SAS_ID ='{0}' ", euc_cc_input.SAS_ID));

                    foreach (euc_cc_sid_agunan oAgunan in listEucCcSidAgunan)
                    {
                        EUC_CC_SID_AGUNAN agunan = new EUC_CC_SID_AGUNAN
                        {
                            IDIFILE = !string.IsNullOrEmpty(oAgunan.IDIFILE) ? oAgunan.IDIFILE : "",
                            TGL_LAPORAN = oAgunan.TGL_LAPORAN != DateTime.MinValue ? oAgunan.TGL_LAPORAN.ToString("yyyy-MM-dd") : "",
                            PROGRAM = !string.IsNullOrEmpty(oAgunan.PROGRAM) ? oAgunan.PROGRAM : "",
                            DIN = !string.IsNullOrEmpty(oAgunan.DIN) ? oAgunan.DIN : "",
                            NO = !string.IsNullOrEmpty(oAgunan.NO) ? oAgunan.NO : "",
                            PELAPOR = !string.IsNullOrEmpty(oAgunan.PELAPOR) ? oAgunan.PELAPOR : "",
                            JENIS = !string.IsNullOrEmpty(oAgunan.JENIS) ? oAgunan.JENIS : "",
                            UPDATE_DATE = oAgunan.UPDATE_DATE != DateTime.MinValue ? oAgunan.UPDATE_DATE.ToString("yyyy-MM-dd") : "",
                            NILAI_BANK = !string.IsNullOrEmpty(oAgunan.NILAI_BANK) ? oAgunan.NILAI_BANK : "",
                            NILAI_TGL = !string.IsNullOrEmpty(oAgunan.NILAI_TGL) ? oAgunan.NILAI_TGL : "",
                            NILAI_INDPDNT = !string.IsNullOrEmpty(oAgunan.NILAI_INDPDNT) ? oAgunan.NILAI_INDPDNT : "",
                            PENILAI = !string.IsNullOrEmpty(oAgunan.PENILAI) ? oAgunan.PENILAI : "",
                            NJOP = !string.IsNullOrEmpty(oAgunan.NJOP) ? oAgunan.NJOP : "",
                            PARIPASU = !string.IsNullOrEmpty(oAgunan.PARIPASU) ? oAgunan.PARIPASU : "",
                            PEMILIK = !string.IsNullOrEmpty(oAgunan.PEMILIK) ? oAgunan.PEMILIK : "",
                            BUKTI = !string.IsNullOrEmpty(oAgunan.BUKTI) ? oAgunan.BUKTI : "",
                            PENGIKATAN = !string.IsNullOrEmpty(oAgunan.PENGIKATAN) ? oAgunan.PENGIKATAN : "",
                            ALAMAT = !string.IsNullOrEmpty(oAgunan.ALAMAT) ? oAgunan.ALAMAT : "",
                            DATI_II = !string.IsNullOrEmpty(oAgunan.DATI_II) ? oAgunan.DATI_II : "",
                            SSB = !string.IsNullOrEmpty(oAgunan.SSB) ? oAgunan.SSB : "",
                            ASURANSI = !string.IsNullOrEmpty(oAgunan.ASURANSI) ? oAgunan.ASURANSI : "",
                            ID_CREDIT = !string.IsNullOrEmpty(oAgunan.ID_CREDIT) ? oAgunan.ID_CREDIT : "",
                            TGL_PENGIKATAN = oAgunan.TGL_PENGIKATAN != DateTime.MinValue ? oAgunan.TGL_PENGIKATAN.ToString("yyyy-MM-dd") : "",      TGL_PENILAI_INDEPENDENT = oAgunan.TGL_PENILAI_INDEPENDENT != DateTime.MinValue ? oAgunan.TGL_PENILAI_INDEPENDENT.ToString("yyyy-MM-dd") : "",
                        };
                        crdeXml.EUC_CC_SID_AGUNAN_DATA.EUC_CC_SID_AGUNAN.Add(agunan);
                    }

                    Rep_ms_euc_cc_sid_kolektibilitas Rep_ms_euc_cc_sid_kolektibilitas = new Rep_ms_euc_cc_sid_kolektibilitas(db);
                    List<euc_cc_sid_kolektibilitas> listEucCcSidKolektibilitas = Rep_ms_euc_cc_sid_kolektibilitas.GetAll(string.Format(" WHERE SAS_ID ='{0}' ", euc_cc_input.SAS_ID));

                    foreach (euc_cc_sid_kolektibilitas oKolektibilitas in listEucCcSidKolektibilitas)
                    {
                        EUC_CC_SID_KOLEKTIBILITAS kolektibilitas = new EUC_CC_SID_KOLEKTIBILITAS
                        {
                            IDIFILE = !string.IsNullOrEmpty(oKolektibilitas.IDIFILE) ? oKolektibilitas.IDIFILE : "",
                            TGL_LAPORAN = oKolektibilitas.TGL_LAPORAN != DateTime.MinValue ? oKolektibilitas.TGL_LAPORAN.ToString("yyyy-MM-dd") : "",
                            PROGRAM = !string.IsNullOrEmpty(oKolektibilitas.PROGRAM) ? oKolektibilitas.PROGRAM : "",
                            DIN = !string.IsNullOrEmpty(oKolektibilitas.DIN) ? oKolektibilitas.DIN : "",
                            NO = !string.IsNullOrEmpty(oKolektibilitas.NO_) ? oKolektibilitas.NO_ : "",
                            PELAPOR = !string.IsNullOrEmpty(oKolektibilitas.PELAPOR) ? oKolektibilitas.PELAPOR : "",
                            SIFAT = !string.IsNullOrEmpty(oKolektibilitas.SIFAT) ? oKolektibilitas.SIFAT : "",
                            NO_REK = !string.IsNullOrEmpty(oKolektibilitas.NO_REK) ? oKolektibilitas.NO_REK : "",
                            UPDATE_DATE = oKolektibilitas.UPDATE_DATE != DateTime.MinValue ? oKolektibilitas.UPDATE_DATE.ToString("yyyy-MM-dd") : "",
                            AKTIF = !string.IsNullOrEmpty(oKolektibilitas.AKTIF) ? oKolektibilitas.AKTIF : "",
                            VALUTA = !string.IsNullOrEmpty(oKolektibilitas.VALUTA) ? oKolektibilitas.VALUTA : "",
                            BUNGA = !string.IsNullOrEmpty(oKolektibilitas.BUNGA) ? oKolektibilitas.BUNGA : "",
                            PLAFON = !string.IsNullOrEmpty(oKolektibilitas.PLAFON) ? oKolektibilitas.PLAFON : "",
                            BAKI_DEBET = !string.IsNullOrEmpty(oKolektibilitas.BAKI_DEBET) ? oKolektibilitas.BAKI_DEBET : "",
                            TG_POKOK = !string.IsNullOrEmpty(oKolektibilitas.TG_POKOK) ? oKolektibilitas.TG_POKOK : "",
                            TG_FREQ = !string.IsNullOrEmpty(oKolektibilitas.TG_FREQ) ? oKolektibilitas.TG_FREQ : "",
                            TG_BUNGA_ON = !string.IsNullOrEmpty(oKolektibilitas.TG_BUNGA_ON) ? oKolektibilitas.TG_BUNGA_ON : "",
                            TG_BUNGA_OFF = !string.IsNullOrEmpty(oKolektibilitas.TG_BUNGA_OFF) ? oKolektibilitas.TG_BUNGA_OFF : "",
                            PG_SEKTOR_EK = !string.IsNullOrEmpty(oKolektibilitas.PG_SEKTOR_EK) ? oKolektibilitas.PG_SEKTOR_EK : "",
                            PG_JENIS = !string.IsNullOrEmpty(oKolektibilitas.PG_JENIS) ? oKolektibilitas.PG_JENIS : "",
                            ST_KONDISI = !string.IsNullOrEmpty(oKolektibilitas.ST_KONDISI) ? oKolektibilitas.ST_KONDISI : "",
                            ST_MACET = !string.IsNullOrEmpty(oKolektibilitas.ST_MACET) ? oKolektibilitas.ST_MACET : "",
                            ST_TGL_KONDISI = oKolektibilitas.ST_TGL_KONDISI != DateTime.MinValue ? oKolektibilitas.ST_TGL_KONDISI.ToString("yyyy-MM-dd") : "",
                            ST_TGL_MACET = oKolektibilitas.ST_TGL_MACET != DateTime.MinValue ? oKolektibilitas.ST_TGL_MACET.ToString("yyyy-MM-dd") : "",
                            JG_AKAD_AWAL = oKolektibilitas.JG_AKAD_AWAL != DateTime.MinValue ? oKolektibilitas.JG_AKAD_AWAL.ToString("yyyy-MM-dd") : "",
                            JG_JATUH_TEMPO = oKolektibilitas.JG_JATUH_TEMPO != DateTime.MinValue ? oKolektibilitas.JG_JATUH_TEMPO.ToString("yyyy-MM-dd") : "",
                            BL01 = !string.IsNullOrEmpty(oKolektibilitas.BL01) ? oKolektibilitas.BL01 : "",
                            KK01 = !string.IsNullOrEmpty(oKolektibilitas.KK01) ? oKolektibilitas.KK01 : "",
                            TG01 = !string.IsNullOrEmpty(oKolektibilitas.TG01) ? oKolektibilitas.TG01 : "",
                            BL02 = !string.IsNullOrEmpty(oKolektibilitas.BL02) ? oKolektibilitas.BL02 : "",
                            KK02 = !string.IsNullOrEmpty(oKolektibilitas.KK02) ? oKolektibilitas.KK02 : "",
                            TG02 = !string.IsNullOrEmpty(oKolektibilitas.TG02) ? oKolektibilitas.TG02 : "",
                            BL03 = !string.IsNullOrEmpty(oKolektibilitas.BL03) ? oKolektibilitas.BL03 : "",
                            KK03 = !string.IsNullOrEmpty(oKolektibilitas.KK03) ? oKolektibilitas.KK03 : "",
                            TG03 = !string.IsNullOrEmpty(oKolektibilitas.TG03) ? oKolektibilitas.TG03 : "",
                            BL04 = !string.IsNullOrEmpty(oKolektibilitas.BL04) ? oKolektibilitas.BL04 : "",
                            KK04 = !string.IsNullOrEmpty(oKolektibilitas.KK04) ? oKolektibilitas.KK04 : "",
                            TG04 = !string.IsNullOrEmpty(oKolektibilitas.TG04) ? oKolektibilitas.TG04 : "",
                            BL05 = !string.IsNullOrEmpty(oKolektibilitas.BL05) ? oKolektibilitas.BL05 : "",
                            KK05 = !string.IsNullOrEmpty(oKolektibilitas.KK05) ? oKolektibilitas.KK05 : "",
                            TG05 = !string.IsNullOrEmpty(oKolektibilitas.TG05) ? oKolektibilitas.TG05 : "",
                            BL06 = !string.IsNullOrEmpty(oKolektibilitas.BL06) ? oKolektibilitas.BL06 : "",
                            KK06 = !string.IsNullOrEmpty(oKolektibilitas.KK06) ? oKolektibilitas.KK06 : "",
                            TG06 = !string.IsNullOrEmpty(oKolektibilitas.TG06) ? oKolektibilitas.TG06 : "",
                            BL07 = !string.IsNullOrEmpty(oKolektibilitas.BL07) ? oKolektibilitas.BL07 : "",
                            KK07 = !string.IsNullOrEmpty(oKolektibilitas.KK07) ? oKolektibilitas.KK07 : "",
                            TG07 = !string.IsNullOrEmpty(oKolektibilitas.TG07) ? oKolektibilitas.TG07 : "",
                            BL08 = !string.IsNullOrEmpty(oKolektibilitas.BL08) ? oKolektibilitas.BL08 : "",
                            KK08 = !string.IsNullOrEmpty(oKolektibilitas.KK08) ? oKolektibilitas.KK08 : "",
                            TG08 = !string.IsNullOrEmpty(oKolektibilitas.TG08) ? oKolektibilitas.TG08 : "",
                            BL09 = !string.IsNullOrEmpty(oKolektibilitas.BL09) ? oKolektibilitas.BL09 : "",
                            KK09 = !string.IsNullOrEmpty(oKolektibilitas.KK09) ? oKolektibilitas.KK09 : "",
                            TG09 = !string.IsNullOrEmpty(oKolektibilitas.TG09) ? oKolektibilitas.TG09 : "",
                            BL10 = !string.IsNullOrEmpty(oKolektibilitas.BL10) ? oKolektibilitas.BL10 : "",
                            KK10 = !string.IsNullOrEmpty(oKolektibilitas.KK10) ? oKolektibilitas.KK10 : "",
                            TG10 = !string.IsNullOrEmpty(oKolektibilitas.TG10) ? oKolektibilitas.TG10 : "",
                            BL11 = !string.IsNullOrEmpty(oKolektibilitas.BL11) ? oKolektibilitas.BL11 : "",
                            KK11 = !string.IsNullOrEmpty(oKolektibilitas.KK11) ? oKolektibilitas.KK11 : "",
                            TG11 = !string.IsNullOrEmpty(oKolektibilitas.TG11) ? oKolektibilitas.TG11 : "",
                            BL12 = !string.IsNullOrEmpty(oKolektibilitas.BL12) ? oKolektibilitas.BL12 : "",
                            KK12 = !string.IsNullOrEmpty(oKolektibilitas.KK12) ? oKolektibilitas.KK12 : "",
                            TG12 = !string.IsNullOrEmpty(oKolektibilitas.TG12) ? oKolektibilitas.TG12 : "",
                            BL13 = !string.IsNullOrEmpty(oKolektibilitas.BL13) ? oKolektibilitas.BL13 : "",
                            KK13 = !string.IsNullOrEmpty(oKolektibilitas.KK13) ? oKolektibilitas.KK13 : "",
                            TG13 = !string.IsNullOrEmpty(oKolektibilitas.TG13) ? oKolektibilitas.TG13 : "",
                            BL14 = !string.IsNullOrEmpty(oKolektibilitas.BL14) ? oKolektibilitas.BL14 : "",
                            KK14 = !string.IsNullOrEmpty(oKolektibilitas.KK14) ? oKolektibilitas.KK14 : "",
                            TG14 = !string.IsNullOrEmpty(oKolektibilitas.TG14) ? oKolektibilitas.TG14 : "",
                            BL15 = !string.IsNullOrEmpty(oKolektibilitas.BL15) ? oKolektibilitas.BL15 : "",
                            KK15 = !string.IsNullOrEmpty(oKolektibilitas.KK15) ? oKolektibilitas.KK15 : "",
                            TG15 = !string.IsNullOrEmpty(oKolektibilitas.TG15) ? oKolektibilitas.TG15 : "",
                            BL16 = !string.IsNullOrEmpty(oKolektibilitas.BL16) ? oKolektibilitas.BL16 : "",
                            KK16 = !string.IsNullOrEmpty(oKolektibilitas.KK16) ? oKolektibilitas.KK16 : "",
                            TG16 = !string.IsNullOrEmpty(oKolektibilitas.TG16) ? oKolektibilitas.TG16 : "",
                            BL17 = !string.IsNullOrEmpty(oKolektibilitas.BL17) ? oKolektibilitas.BL17 : "",
                            KK17 = !string.IsNullOrEmpty(oKolektibilitas.KK17) ? oKolektibilitas.KK17 : "",
                            TG17 = !string.IsNullOrEmpty(oKolektibilitas.TG17) ? oKolektibilitas.TG17 : "",
                            BL18 = !string.IsNullOrEmpty(oKolektibilitas.BL18) ? oKolektibilitas.BL18 : "",
                            KK18 = !string.IsNullOrEmpty(oKolektibilitas.KK18) ? oKolektibilitas.KK18 : "",
                            TG18 = !string.IsNullOrEmpty(oKolektibilitas.TG18) ? oKolektibilitas.TG18 : "",
                            BL19 = !string.IsNullOrEmpty(oKolektibilitas.BL19) ? oKolektibilitas.BL19 : "",
                            KK19 = !string.IsNullOrEmpty(oKolektibilitas.KK19) ? oKolektibilitas.KK19 : "",
                            TG19 = !string.IsNullOrEmpty(oKolektibilitas.TG19) ? oKolektibilitas.TG19 : "",
                            BL20 = !string.IsNullOrEmpty(oKolektibilitas.BL20) ? oKolektibilitas.BL20 : "",
                            KK20 = !string.IsNullOrEmpty(oKolektibilitas.KK20) ? oKolektibilitas.KK20 : "",
                            TG20 = !string.IsNullOrEmpty(oKolektibilitas.TG20) ? oKolektibilitas.TG20 : "",
                            BL21 = !string.IsNullOrEmpty(oKolektibilitas.BL21) ? oKolektibilitas.BL21 : "",
                            KK21 = !string.IsNullOrEmpty(oKolektibilitas.KK21) ? oKolektibilitas.KK21 : "",
                            TG21 = !string.IsNullOrEmpty(oKolektibilitas.TG21) ? oKolektibilitas.TG21 : "",
                            BL22 = !string.IsNullOrEmpty(oKolektibilitas.BL22) ? oKolektibilitas.BL22 : "",
                            KK22 = !string.IsNullOrEmpty(oKolektibilitas.KK22) ? oKolektibilitas.KK22 : "",
                            TG22 = !string.IsNullOrEmpty(oKolektibilitas.TG22) ? oKolektibilitas.TG22 : "",
                            BL23 = !string.IsNullOrEmpty(oKolektibilitas.BL23) ? oKolektibilitas.BL23 : "",
                            KK23 = !string.IsNullOrEmpty(oKolektibilitas.KK23) ? oKolektibilitas.KK23 : "",
                            TG23 = !string.IsNullOrEmpty(oKolektibilitas.TG23) ? oKolektibilitas.TG23 : "",
                            BL24 = !string.IsNullOrEmpty(oKolektibilitas.BL24) ? oKolektibilitas.BL24 : "",
                            KK24 = !string.IsNullOrEmpty(oKolektibilitas.KK24) ? oKolektibilitas.KK24 : "",
                            TG24 = !string.IsNullOrEmpty(oKolektibilitas.TG24) ? oKolektibilitas.TG24 : "",
                            GOL_KREDIT = !string.IsNullOrEmpty(oKolektibilitas.GOL_KREDIT) ? oKolektibilitas.GOL_KREDIT : "",
                            ID_CREDIT = !string.IsNullOrEmpty(oKolektibilitas.ID_CREDIT) ? oKolektibilitas.ID_CREDIT : "",
                            KD_PG_JENIS = !string.IsNullOrEmpty(oKolektibilitas.KD_PG_JENIS) ? oKolektibilitas.KD_PG_JENIS : "",
                            JENIS_KREDIT_KET = !string.IsNullOrEmpty(oKolektibilitas.JENIS_KREDIT_KET) ? oKolektibilitas.JENIS_KREDIT_KET : "",
                            SIFAT_KREDIT = !string.IsNullOrEmpty(oKolektibilitas.SIFAT_KREDIT) ? oKolektibilitas.SIFAT_KREDIT : "",
                            SIFAT_KREDIT_KET = !string.IsNullOrEmpty(oKolektibilitas.SIFAT_KREDIT_KET) ? oKolektibilitas.SIFAT_KREDIT_KET : "",
                            AKAD_PEMBIAYAAN = !string.IsNullOrEmpty(oKolektibilitas.AKAD_PEMBIAYAAN) ? oKolektibilitas.AKAD_PEMBIAYAAN : "",
                            AKAD_PEMBIAYAAN_KET = !string.IsNullOrEmpty(oKolektibilitas.AKAD_PEMBIAYAAN_KET) ? oKolektibilitas.AKAD_PEMBIAYAAN_KET : "",
                            KATEGORI_DEBITUR_KET = !string.IsNullOrEmpty(oKolektibilitas.KATEGORI_DEBITUR_KET) ? oKolektibilitas.KATEGORI_DEBITUR_KET : "",
                            CABANG_PELAPOR = !string.IsNullOrEmpty(oKolektibilitas.CABANG_PELAPOR) ? oKolektibilitas.CABANG_PELAPOR : "",
                            TGL_MULAI = oKolektibilitas.TGL_MULAI != DateTime.MinValue ? oKolektibilitas.TGL_MULAI.ToString("yyyy-MM-dd") : "",
                            KD_PG_SEKTOR_EK = !string.IsNullOrEmpty(oKolektibilitas.KD_PG_SEKTOR_EK) ? oKolektibilitas.KD_PG_SEKTOR_EK : "",
                            FREK_REST = !string.IsNullOrEmpty(oKolektibilitas.FREK_REST) ? oKolektibilitas.FREK_REST : "",
                            TGL_REST_AKHIR = oKolektibilitas.TGL_REST_AKHIR != DateTime.MinValue ? oKolektibilitas.TGL_REST_AKHIR.ToString("yyyy-MM-dd") : "",
                            KODE_CARA_REST = !string.IsNullOrEmpty(oKolektibilitas.KODE_CARA_REST) ? oKolektibilitas.KODE_CARA_REST : "",
                            CARA_REST = !string.IsNullOrEmpty(oKolektibilitas.CARA_REST) ? oKolektibilitas.CARA_REST : "",
                            KODE_SUKU_BUNGA = !string.IsNullOrEmpty(oKolektibilitas.KODE_SUKU_BUNGA) ? oKolektibilitas.KODE_SUKU_BUNGA : "",
                            JENIS_SUKU_BUNGA = !string.IsNullOrEmpty(oKolektibilitas.JENIS_SUKU_BUNGA) ? oKolektibilitas.JENIS_SUKU_BUNGA : "",
                            PLAFON_AWAL = !string.IsNullOrEmpty(oKolektibilitas.PLAFON_AWAL) ? oKolektibilitas.PLAFON_AWAL : "",
                            TGL_AWAL_KREDIT = oKolektibilitas.TGL_AWAL_KREDIT != DateTime.MinValue ? oKolektibilitas.TGL_AWAL_KREDIT.ToString("yyyy-MM-dd") : "",
                        };
                        crdeXml.EUC_CC_SID_KOLEKTIBILITAS_DATA.EUC_CC_SID_KOLEKTIBILITAS.Add(kolektibilitas);
                    }

                    Rep_ms_euc_cc_sid_pekerjaan Rep_ms_euc_cc_sid_pekerjaan = new Rep_ms_euc_cc_sid_pekerjaan(db);
                    List<euc_cc_sid_pekerjaan> listEucCcSidPekerjaan = Rep_ms_euc_cc_sid_pekerjaan.GetAll(string.Format(" WHERE SAS_ID ='{0}' ", euc_cc_input.SAS_ID));

                    foreach (euc_cc_sid_pekerjaan oPekerjaan in listEucCcSidPekerjaan)
                    {
                        EUC_CC_SID_PEKERJAAN pekerjaan = new EUC_CC_SID_PEKERJAAN
                        {
                            IDIFILE = !string.IsNullOrEmpty(oPekerjaan.IDIFILE) ? oPekerjaan.IDIFILE : "",
                            TGL_LAPORAN = oPekerjaan.TGL_LAPORAN != DateTime.MinValue ? oPekerjaan.TGL_LAPORAN.ToString("yyyy-MM-dd") : "",
                            PROGRAM = !string.IsNullOrEmpty(oPekerjaan.PROGRAM) ? oPekerjaan.PROGRAM : "",
                            DIN = !string.IsNullOrEmpty(oPekerjaan.DIN) ? oPekerjaan.DIN : "",
                            NO = !string.IsNullOrEmpty(oPekerjaan.NO) ? oPekerjaan.NO : "",
                            PEKERJAAN = !string.IsNullOrEmpty(oPekerjaan.PEKERJAAN) ? oPekerjaan.PEKERJAAN : "",
                            TEMPAT = !string.IsNullOrEmpty(oPekerjaan.TEMPAT) ? oPekerjaan.TEMPAT : "",
                            BIDANG_USAHA = !string.IsNullOrEmpty(oPekerjaan.BIDANG_USAHA) ? oPekerjaan.BIDANG_USAHA : "",
                            UPDATE_DATE = oPekerjaan.UPDATE_DATE != DateTime.MinValue ? oPekerjaan.UPDATE_DATE.ToString("yyyy-MM-dd") : "",
                        };
                        crdeXml.EUC_CC_SID_PEKERJAAN_DATA.EUC_CC_SID_PEKERJAAN.Add(pekerjaan);
                    }

                    Rep_ms_euc_cc_sid_sumber Rep_ms_euc_cc_sid_sumber = new Rep_ms_euc_cc_sid_sumber(db);
                    List<euc_cc_sid_sumber> listEucCcSidSumber = Rep_ms_euc_cc_sid_sumber.GetAll(string.Format(" WHERE SAS_ID ='{0}' ", euc_cc_input.SAS_ID));

                    foreach (euc_cc_sid_sumber oSumber in listEucCcSidSumber)
                    {
                        EUC_CC_SID_SUMBER sumber = new EUC_CC_SID_SUMBER
                        {
                            IDIFILE = !string.IsNullOrEmpty(oSumber.IDIFILE) ? oSumber.IDIFILE : "",
                            TGL_LAPORAN = oSumber.TGL_LAPORAN != DateTime.MinValue ? oSumber.TGL_LAPORAN.ToString("yyyy-MM-dd") : "",
                            PROGRAM = !string.IsNullOrEmpty(oSumber.PROGRAM) ? oSumber.PROGRAM : "",
                            DIN = !string.IsNullOrEmpty(oSumber.DIN) ? oSumber.DIN : "",
                            KODE = !string.IsNullOrEmpty(oSumber.KODE) ? oSumber.KODE : "",
                            NAMA = !string.IsNullOrEmpty(oSumber.NAMA) ? oSumber.NAMA : "",
                            CABANG_PELAPOR = !string.IsNullOrEmpty(oSumber.CABANG_PELAPOR) ? oSumber.CABANG_PELAPOR : "",
                        };
                        crdeXml.EUC_CC_SID_SUMBER_DATA.EUC_CC_SID_SUMBER.Add(sumber);
                    }

                    Rep_ms_euc_cc_sid_summary Rep_ms_euc_cc_sid_summary = new Rep_ms_euc_cc_sid_summary(db);
                    List<euc_cc_sid_summary> listEucCcSidSummary = Rep_ms_euc_cc_sid_summary.GetAll(string.Format(" WHERE SAS_ID ='{0}' ", euc_cc_input.SAS_ID));

                    foreach (euc_cc_sid_summary oSummary in listEucCcSidSummary)
                    {
                        EUC_CC_SID_SUMMARY summary = new EUC_CC_SID_SUMMARY
                        {
                            IDIFILE = !string.IsNullOrEmpty(oSummary.IDIFILE) ? oSummary.IDIFILE : "",
                            TGL_LAPORAN = oSummary.TGL_LAPORAN != DateTime.MinValue ? oSummary.TGL_LAPORAN.ToString("yyyy-MM-dd") : "",
                            PROGRAM = !string.IsNullOrEmpty(oSummary.PROGRAM) ? oSummary.PROGRAM : "",
                            DIN = !string.IsNullOrEmpty(oSummary.DIN) ? oSummary.DIN : "",
                            No = !string.IsNullOrEmpty(oSummary.No) ? oSummary.No : "",
                            PLAFON_KREDIT = oSummary.PLAFON_KREDIT.ToString("#.##"),
                            PLAFON_LC = oSummary.PLAFON_LC.ToString("#.##"),
                            PLAFON_GYD = oSummary.PLAFON_GYD.ToString("#.##"),
                            PLAFON_LAINNYA = oSummary.PLAFON_LAINNYA.ToString("#.##"),
                            PLAFON_TOTAL = oSummary.PLAFON_TOTAL.ToString("#.##"),
                            BAKIDEBET_KREDIT = oSummary.BAKIDEBET_KREDIT.ToString("#.##"),
                            BAKIDEBET_LC = oSummary.BAKIDEBET_TOTAL.ToString("#.##"),
                            BAKIDEBET_BG = oSummary.BAKIDEBET_TOTAL.ToString("#.##"),
                            BAKIDEBET_LAINNYA = oSummary.BAKIDEBET_TOTAL.ToString("#.##"),
                            BAKIDEBET_TOTAL = oSummary.BAKIDEBET_TOTAL.ToString("#.##"),
                            KOLEK_TERBURUK = !string.IsNullOrEmpty(oSummary.KOLEK_TERBURUK) ? oSummary.KOLEK_TERBURUK : "",                          
                            KOLEK_BULAN = !string.IsNullOrEmpty(oSummary.KOLEK_BULAN) ? oSummary.KOLEK_BULAN : "",
                        };
                        crdeXml.EUC_CC_SID_SUMMARY_DATA.EUC_CC_SID_SUMMARY.Add(summary);
                    }

                    StringBuilder xml = new StringBuilder();
                    xml.Append(new Serializer().Serialize<CRDECreditScoringRequest>(crdeXml));

                    var sw = new StringWriterUtf8(xml);

                    //  Save.SaveAllFilesXmlToDatabase(euc_cc_input.SAS_ID, sw.ToString());

                    Rep_tr_xml_trans Rep_tr_xml_trans = new Rep_tr_xml_trans(db);

                    tr_xml_trans tr_xml_trans = new tr_xml_trans();
                    tr_xml_trans.SAS_ID = euc_cc_input.SAS_ID;
                    tr_xml_trans.XML_REQUEST = sw.ToString();
                    tr_xml_trans.STATUS_XML = "ready";
                    tr_xml_trans.CREATED_BY = "Services";
                    //  tr_xml_trans.MODIFIED_BY = "Services";
                    tr_xml_trans.CREATED_DATE = DateTime.Now;
                    // tr_xml_trans.MODIFIED_DATE = DateTime.Now;
                    int i = Rep_tr_xml_trans.DBHelper.Insert<tr_xml_trans>(tr_xml_trans);
                    Rep_ms_euc_cc_input.UpdateFlag_1_input(euc_cc_input.SAS_ID);

                    //  trans.Commit();
                    Thread.Sleep(500);
                    _log.Info($"{ euc_cc_input.SAS_ID} successfuly create xml  at" + DateTime.Now);
                }
                catch (Exception ex)
                {
                    _log.Error("An error occured while create xml.");
                    _log.Error(ex);
                }
                
            }
        }
    }
}

