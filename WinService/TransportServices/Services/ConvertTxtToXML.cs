using Common.Model;
using Common.Repository;
using Common.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TransportServices.Services
{
    public class ConvertTxtToXML
    {
        private static string mFolderTxtToXmlAgunan = string.Empty;
        private static string mFolderTxtToXmlDebitur = string.Empty;
        private static string mFolderTxtToXmlInput = string.Empty;
        private static string mFolderTxtToXmlAlamat = string.Empty;
        private static string mFolderTxtToXmlKolek = string.Empty;
        private static string mFolderTxtToXmlPekerjaan = string.Empty;
        private static string mFolderTxtToXmlSumber = string.Empty;
        private static string mFolderTxtToXmlSummary = string.Empty;
        
        public static void ConvertTxtToXML_EUC_CC_SID_AGUNAN(string path)
        {
            Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter();
            ms_system_parameter o = rep.Find("mFolderTxtToXmlAgunan");
            mFolderTxtToXmlAgunan = o != null ? o.ParameterValue : string.Empty;

            
            //string fullPath = Path.Combine(path);
            string[] lines = File.ReadAllLines(path);
                List<euc_cc_sid_agunan> list = new List<euc_cc_sid_agunan>();

                foreach (string line in lines.Skip(1))
                {
                    try
                    {
                        string[] contents = line.Split(new char[] { '|' });

                        var agunan = new euc_cc_sid_agunan
                        {
                            //IDIFILE = contents[0],
                            //TGL_LAPORAN = contents[1],
                            //PROGRAM = contents[2],
                            //DIN = contents[3],
                            //NO = contents[4],
                            //PELAPOR = contents[5],
                            //JENIS = contents[6],
                            //UPDATE = contents[7],
                            //NILAI_BANK = contents[8],
                            //NILAI_TGL = contents[9],
                            //NILAI_INDPDNT = contents[10],
                            //PENILAI = contents[11],
                            //NJOP = contents[12],
                            //PARIPASU = contents[13],
                            //PEMILIK = contents[14],
                            //BUKTI = contents[15],
                            //PENGIKATAN = contents[16],
                            //ALAMAT = contents[17],
                            //DATI_II = contents[18],
                            //SSB = contents[19],
                            //ASURANSI = contents[20],
                            //ID_CREDIT = contents[21],
                            //TGL_PENGIKATAN = contents[22],
                            //TGL_PENILAI_INDEPENDENT = contents[23],
                        };
                        list.Add(agunan);
                    }
                    catch (Exception ex)
                    {
                    //DBHelper db = new DBHelper();
                    //LogUtil.AddLogXMLError(db, path, "ConvertTxtToXML", "ConvertTxtToXML_EUC_CC_SID_AGUNAN", "", ex.Message, ex.StackTrace);
                  //  throw ex;
                    }
                    finally
                    {

                    }
                }

                using (XmlWriter writer = XmlWriter.Create(mFolderTxtToXmlAgunan))//, new XmlWriterSettings { OmitXmlDeclaration = true }
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    new XmlSerializer(typeof(List<euc_cc_sid_agunan>), new XmlRootAttribute("EUC_CC_SID_AGUNAN_DATA")).Serialize(writer, list, ns);
                }
               // Save.SaveAllFilesXmlMasterToDatabase(path);
            
        }
        public static void ConvertTxtToXML_EUC_CC_SID_DEBITUR(string path)
        {
            Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter();
            ms_system_parameter o = rep.Find("mFolderTxtToXmlDebitur");
            o = rep.Find("mFolderTxtToXmlDebitur");
            mFolderTxtToXmlDebitur = o != null ? o.ParameterValue : string.Empty;
           

            // string fullPath = Path.Combine("@" + path);
            string[] lines = File.ReadAllLines(path);
                List<euc_cc_sid_debitur> list = new List<euc_cc_sid_debitur>();

                foreach (string line in lines.Skip(1))
                {
                try
                {
                    string[] contents = line.Split(new char[] { '|' });
                    var debitur = new euc_cc_sid_debitur
                    {
                        //IDIFILE = contents[0],
                        //TGL_LAPORAN = contents[1],
                        //PROGRAM = contents[2],
                        //DIN = contents[3],
                        //LAP_NO = contents[4],
                        //LAP_POSISIAKHIR = contents[5],
                        //LAP_USER = contents[6],
                        //PRM_TGL = contents[7],
                        //PRM_NO = contents[8],
                        //PRM_NAMA_DEBITUR = contents[9],
                        //PRM_TEMPAT_LAHIR = contents[10],
                        //PRM_TGL_LAHIR = contents[11],
                        //PRM_NPWP = contents[12],
                        //PRM_KTP = contents[13],
                        //PRM_PASSPORT = contents[14],
                    };
                    list.Add(debitur);
                }
                catch (Exception ex)
                {

                    //DBHelper db = new DBHelper();
                    //LogUtil.AddLogXMLError(db, path, "ConvertTxtToXML", "ConvertTxtToXML_EUC_CC_SID_DEBITUR", "", ex.Message, ex.StackTrace);
                  // throw ex;
                }
                finally
                {


                }
                    
                }
            using (XmlWriter writer = XmlWriter.Create(mFolderTxtToXmlDebitur))//, new XmlWriterSettings { OmitXmlDeclaration = true }
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                new XmlSerializer(typeof(List<euc_cc_sid_debitur>), new XmlRootAttribute("EUC_CC_SID_DEBITUR_DATA")).Serialize(writer, list, ns);
            }

            //using (FileStream fs = new FileStream("C:\\Downloads\\txtToXml\\EUC_CC_SID_DEBITUR.xml", FileMode.Create))
            //{
            //    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //    ns.Add("", "");
            //    new XmlSerializer(typeof(List<EUC_CC_SID_DEBITUR>), new XmlRootAttribute("EUC_CC_SID_DEBITUR_DATA")).Serialize(fs, list, ns);
            //}

            // Save.SaveAllFilesXmlMasterToDatabase(path);


        }


        public static void ConvertTxtToXML_EUC_CC_INPUT(string path)
        {
            //Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter();
            //ms_system_parameter o = rep.Find("mFolderTxtToXmlInput");
            //o = rep.Find("mFolderTxtToXmlInput");
            //mFolderTxtToXmlInput = o != null ? o.ParameterValue : string.Empty;
            
            //// string fullPath = Path.Combine("@" + path);
            //string[] lines = File.ReadAllLines(path);

            //    List<euc_cc_input> list = new List<euc_cc_input>();

            //    foreach (string line in lines.Skip(1))
            //    {
            //        try
            //        {
            //        string[] contents = line.Split(new char[] { '|' });
            //        var tblinput = new euc_cc_input
            //        {
            //            NAME = contents[0],
            //            DOB = contents[1],
            //            GENDER = contents[2],
            //            SAS_ID = contents[3],
            //            DOB2 = contents[4],
            //            NOMORCIF = contents[5],
            //            NATIONALITY = contents[6],
            //            SEGMENT = contents[7],
            //            LEADS_DATE = contents[8],
            //            POB = contents[9],
            //            DES = contents[10],
            //            EDU_DESC = contents[11],
            //            MR_DESC = contents[12],
            //            EMAIL = contents[13],
            //            HOME_ZIPCODE = contents[14],
            //            MGROSS_INCOME = contents[15],
            //            AGROSS_INCOME = contents[16],
            //            SALES_CH = contents[17],
            //            BUS_TYPE = contents[18],
            //            ADDRESS_1A = contents[19],
            //            ADDRESS_1B = contents[20],
            //            ADDRESS_1C = contents[21],
            //            ADDRESS_1D = contents[22],
            //            ADDRESS_1E = contents[23],
            //            ADDRESS_2A = contents[24],
            //            ADDRESS_2B = contents[25],
            //            ADDRESS_2C = contents[26],
            //            ADDRESS_2D = contents[27],
            //            ADDRESS_2E = contents[28],
            //            ADDRESS_3A = contents[29],
            //            ADDRESS_3B = contents[30],
            //            ADDRESS_3C = contents[31],
            //            ADDRESS_3D = contents[32],
            //            ADDRESS_3E = contents[33],
            //            ADDRESS_4A = contents[34],
            //            ADDRESS_4B = contents[35],
            //            ADDRESS_4C = contents[36],
            //            ADDRESS_4D = contents[37],
            //            ADDRESS_4E = contents[38],
            //            CITY_A = contents[39],
            //            CITY_B = contents[40],
            //            CITY_C = contents[41],
            //            CITY_D = contents[42],
            //            CITY_E = contents[43],
            //            PROVINCE_A = contents[44],
            //            PROVINCE_B = contents[45],
            //            PROVINCE_C = contents[46],
            //            PROVINCE_D = contents[47],
            //            PROVINCE_E = contents[48],
            //            ZIPCODE_A = contents[49],
            //            ZIPCODE_B = contents[50],
            //            ZIPCODE_C = contents[51],
            //            ZIPCODE_D = contents[52],
            //            ZIPCODE_E = contents[53],
            //            NPWP = contents[54],
            //            KTP1 = contents[55],
            //            KTP2 = contents[56],
            //            KTP3 = contents[57],
            //            KTP4 = contents[58],
            //            KTP5 = contents[59],
            //            KTP6 = contents[60],
            //            KTP7 = contents[61],
            //            KTP8 = contents[62],
            //            KTP9 = contents[63],
            //            KTP10 = contents[64],
            //            NO_OF_DEPENDANT = contents[65],
            //            FLAG_AUM = contents[66],
            //            BATCH = contents[67],
            //        };
            //        list.Add(tblinput);
            //    }
            //        catch (Exception ex)
            //        {

            //        DBHelper db = new DBHelper();
            //        LogUtil.AddLogXMLError(db, path, "ConvertTxtToXML", "ConvertTxtToXML_EUC_CC_INPUT", "", ex.Message, ex.StackTrace);
            //      //  throw ex;
            //    }
            //    finally
            //    {

            //    }
           
                    
            //    }
            //    using (FileStream fs = new FileStream(mFolderTxtToXmlInput, FileMode.Create))
            //    {
            //        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //        ns.Add("", "");
            //        new XmlSerializer(typeof(List<euc_cc_input>), new XmlRootAttribute("EUC_CC_INPUT_DATA")).Serialize(fs, list, ns);
            //    }
                //using (XmlWriter writer = XmlWriter.Create("C:\\Downloads\\txtToXml\\EUC_CC_INPUT.xml"))//, new XmlWriterSettings { OmitXmlDeclaration = true }
                //{
                //    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                //    ns.Add("", "");
                //    new XmlSerializer(typeof(List<EUC_CC_INPUT>), new XmlRootAttribute("EUC_CC_INPUT_DATA")).Serialize(writer, list, ns);
                //}
              //  Save.SaveAllFilesXmlMasterToDatabase(path);
        }

        public static void ConvertTxtToXML_EUC_CC_SID_ALAMAT(string path)
        {
            Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter();
            ms_system_parameter o = rep.Find("mFolderTxtToXmlAlamat");
            o = rep.Find("mFolderTxtToXmlAlamat");
            mFolderTxtToXmlAlamat = o != null ? o.ParameterValue : string.Empty;
           
            // string fullPath = Path.Combine("@" + path);
            string[] lines = File.ReadAllLines(path);
                List<euc_cc_sid_alamat> list = new List<euc_cc_sid_alamat>();

                foreach (string line in lines.Skip(1))
                {
                    try
                    {
                        string[] contents = line.Split(new char[] { '|' });
                        var alamat = new euc_cc_sid_alamat
                        {
                            //IDIFILE = contents[0],
                            //TGL_LAPORAN = contents[1],
                            //PROGRAM = contents[2],
                            //DIN = contents[3],
                            //NO = contents[4],
                            //ALAMAT = contents[5],
                            //KELURAHAN = contents[6],
                            //KECAMATAN = contents[7],
                            //DATI_II = contents[8],
                            //KODEPOS = contents[9],
                            //NEGARA = contents[10],
                            //UPDATE = contents[11],
                           // PELAPOR = contents[12],


                        };
                        list.Add(alamat);
                    }
                    catch (Exception ex)
                    {
                    //DBHelper db = new DBHelper();
                    //LogUtil.AddLogXMLError(db, path, "ConvertTxtToXML", "ConvertTxtToXML_EUC_CC_SID_ALAMAT", "", ex.Message, ex.StackTrace);
                   // throw ex;
                }
                finally
                {
                    Console.WriteLine("Finally");
                }
                }
            using (XmlWriter writer = XmlWriter.Create(mFolderTxtToXmlAlamat))//, new XmlWriterSettings { OmitXmlDeclaration = true }
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                new XmlSerializer(typeof(List<euc_cc_sid_alamat>), new XmlRootAttribute("EUC_CC_SID_ALAMAT_DATA")).Serialize(writer, list, ns);
            }

            //using (FileStream fs = new FileStream("C:\\Downloads\\txtToXml\\EUC_CC_SID_ALAMAT.xml", FileMode.Create))
            //{
            //    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //    ns.Add("", "");
            //    new XmlSerializer(typeof(List<EUC_CC_SID_ALAMAT>), new XmlRootAttribute("EUC_CC_SID_ALAMAT_DATA")).Serialize(fs, list, ns);
            //}


            //Save.SaveAllFilesXmlMasterToDatabase(path);


        }
        public static void ConvertTxtToXML_EUC_CC_SID_KOLEKTIBILITAS(string path)
        {
            Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter();
            ms_system_parameter o = rep.Find("mFolderTxtToXmlKolek");
            o = rep.Find("mFolderTxtToXmlKolek");
            mFolderTxtToXmlKolek = o != null ? o.ParameterValue : string.Empty;
            
            // string fullPath = Path.Combine("@" + path);
            string[] lines = File.ReadAllLines(path);
                List<euc_cc_sid_kolektibilitas> list = new List<euc_cc_sid_kolektibilitas>();

                foreach (string line in lines.Skip(1))
                {
                try
                {
                    string[] contents = line.Split(new char[] { '|' });
                    var kolektibilitas = new euc_cc_sid_kolektibilitas
                    {
                        //IDIFILE = contents[0],
                        //TGL_LAPORAN = contents[1],
                        //PROGRAM = contents[2],
                        //DIN = contents[3],
                        //NO_ = contents[4],
                        //PELAPOR = contents[5],
                        //SIFAT = contents[6],
                        //NO_REK = contents[7],
                        //UPDATE = contents[8],
                        //AKTIF = contents[9],
                        //VALUTA = contents[10],
                        //BUNGA = contents[11],
                        //PLAFON = contents[12],
                        //BAKI_DEBET = contents[13],
                        //TG_POKOK = contents[14],
                        //TG_FREQ = contents[15],
                        //TG_BUNGA_ON = contents[16],
                        //TG_BUNGA_OFF = contents[17],
                        //PG_SEKTOR_EK = contents[18],
                        //PG_JENIS = contents[19],
                        //ST_KONDISI = contents[20],
                        //ST_MACET = contents[21],
                        //ST_TGL_KONDISI = contents[22],
                        //ST_TGL_MACET = contents[23],
                        //JG_AKAD_AWAL = contents[24],
                        //JG_JATUH_TEMPO = contents[25],
                        //BL01 = contents[26],
                        //KK01 = contents[27],
                        //TG01 = contents[28],
                        //BL02 = contents[29],
                        //KK02 = contents[30],
                        //TG02 = contents[31],
                        //BL03 = contents[32],
                        //KK03 = contents[33],
                        //TG03 = contents[34],
                        //BL04 = contents[35],
                        //KK04 = contents[36],
                        //TG04 = contents[37],
                        //BL05 = contents[38],
                        //KK05 = contents[39],
                        //TG05 = contents[40],
                        //BL06 = contents[41],
                        //KK06 = contents[42],
                        //TG06 = contents[43],
                        //BL07 = contents[44],
                        //KK07 = contents[45],
                        //TG07 = contents[46],
                        //BL08 = contents[47],
                        //KK08 = contents[48],
                        //TG08 = contents[49],
                        //BL09 = contents[50],
                        //KK09 = contents[51],
                        //TG09 = contents[52],
                        //BL10 = contents[53],
                        //KK10 = contents[54],
                        //TG10 = contents[55],
                        //BL11 = contents[56],
                        //KK11 = contents[57],
                        //TG11 = contents[58],
                        //BL12 = contents[59],
                        //KK12 = contents[60],
                        //TG12 = contents[61],
                        //BL13 = contents[62],
                        //KK13 = contents[63],
                        //TG13 = contents[64],
                        //BL14 = contents[65],
                        //KK14 = contents[66],
                        //TG14 = contents[67],
                        //BL15 = contents[68],
                        //KK15 = contents[69],
                        //TG15 = contents[70],
                        //BL16 = contents[71],
                        //KK16 = contents[72],
                        //TG16 = contents[73],
                        //BL17 = contents[74],
                        //KK17 = contents[75],
                        //TG17 = contents[76],
                        //BL18 = contents[77],
                        //KK18 = contents[78],
                        //TG18 = contents[79],
                        //BL19 = contents[80],
                        //KK19 = contents[81],
                        //TG19 = contents[82],
                        //BL20 = contents[83],
                        //KK20 = contents[84],
                        //TG20 = contents[85],
                        //BL21 = contents[86],
                        //KK21 = contents[87],
                        //TG21 = contents[88],
                        //BL22 = contents[89],
                        //KK22 = contents[90],
                        //TG22 = contents[91],
                        //BL23 = contents[92],
                        //KK23 = contents[93],
                        //TG23 = contents[94],
                        //BL24 = contents[95],
                        //KK24 = contents[96],
                        //TG24 = contents[97],
                        //GOL_KREDIT = contents[97],
                        //ID_CREDIT = contents[99],
                        //KD_PG_JENIS = contents[100],
                        //JENIS_KREDIT_KET = contents[101],
                        //SIFAT_KREDIT = contents[102],
                        //SIFAT_KREDIT_KET = contents[103],
                        //AKAD_PEMBIAYAAN = contents[104],
                        //AKAD_PEMBIAYAAN_KET = contents[105],
                        //KATEGORI_DEBITUR_KET = contents[106],
                        //CABANG_PELAPOR = contents[107],
                        //TGL_MULAI = contents[108],
                        //KD_PG_SEKTOR_EK = contents[109],
                        //FREK_REST = contents[110],
                        //TGL_REST_AKHIR = contents[111],
                        //KODE_CARA_REST = contents[112],
                        //CARA_REST = contents[113],
                        //KODE_SUKU_BUNGA = contents[114],
                        //JENIS_SUKU_BUNGA = contents[115],
                        //PLAFON_AWAL = contents[116],
                        //TGL_AWAL_KREDIT = contents[117],
                    };
                    list.Add(kolektibilitas);
                }
                catch (Exception ex)
                {

                    //DBHelper db = new DBHelper();
                    //LogUtil.AddLogXMLError(db, path, "ConvertTxtToXML", "ConvertTxtToXML_EUC_CC_SID_KOLEKTIBILITAS", "", ex.Message, ex.StackTrace);
                   // throw ex;
                }
                finally
                {
                    Console.WriteLine("next");
                }
                    
                }
            using (FileStream fs = new FileStream(mFolderTxtToXmlKolek, FileMode.Create))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                new XmlSerializer(typeof(List<euc_cc_sid_kolektibilitas>), new XmlRootAttribute("EUC_CC_SID_KOLEKTIBILITAS_DATA")).Serialize(fs, list, ns);
            }
            //using (XmlWriter writer = XmlWriter.Create("C:\\Downloads\\txtToXml\\EUC_CC_SID_KOLEKTIBILITAS.xml"))//, new XmlWriterSettings { OmitXmlDeclaration = true }
            //{
            //    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //    ns.Add("", "");
            //    new XmlSerializer(typeof(List<EUC_CC_SID_KOLEKTIBILITAS>), new XmlRootAttribute("EUC_CC_SID_KOLEKTIBILITAS_DATA")).Serialize(writer, list, ns);
            //}


            //Save.SaveAllFilesXmlMasterToDatabase(path);


        }

        public static void ConvertTxtToXML_EUC_CC_SID_PEKERJAAN(string path)
        {
            Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter();
            ms_system_parameter o = rep.Find("mFolderTxtToXmlPekerjaan");
            o = rep.Find("mFolderTxtToXmlPekerjaan");
            mFolderTxtToXmlPekerjaan = o != null ? o.ParameterValue : string.Empty;
           
            // string fullPath = Path.Combine("@" + path);
            string[] lines = File.ReadAllLines(path);
                List<euc_cc_sid_pekerjaan> list = new List<euc_cc_sid_pekerjaan>();

                foreach (string line in lines.Skip(1))
                {
                try
                {
                    string[] contents = line.Split(new char[] { '|' });
                    var pekerjaan = new euc_cc_sid_pekerjaan
                    {
                        //IDIFILE = contents[0],
                        //TGL_LAPORAN = contents[1],
                        //PROGRAM = contents[2],
                        //DIN = contents[3],
                        //NO = contents[4],
                        //PEKERJAAN = contents[5],
                        //TEMPAT = contents[6],
                        //BIDANG_USAHA = contents[7],
                        //UPDATE = contents[8],
                    };
                    list.Add(pekerjaan);
                }
                catch (Exception ex)
                {

                   // DBHelper db = new DBHelper();
                   // LogUtil.AddLogXMLError(db, path, "ConvertTxtToXML", "ConvertTxtToXML_EUC_CC_SID_PEKERJAAN", "", ex.Message, ex.StackTrace);
                   // throw ex;
                }
                finally
                {
                    Console.WriteLine("next");
                }
                   
                }
                using (XmlWriter writer = XmlWriter.Create(mFolderTxtToXmlPekerjaan))//, new XmlWriterSettings { OmitXmlDeclaration = true }
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    new XmlSerializer(typeof(List<euc_cc_sid_pekerjaan>), new XmlRootAttribute("EUC_CC_SID_PEKERJAAN_DATA")).Serialize(writer, list, ns);
                }
                //Save.SaveAllFilesXmlMasterToDatabase(path);
                //using (FileStream fs = new FileStream("C:\\Downloads\\txtToXml\\EUC_CC_SID_PEKERJAAN.xml", FileMode.Create))
                //{
                //    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                //    ns.Add("", "");
                //    new XmlSerializer(typeof(List<EUC_CC_SID_PEKERJAAN>), new XmlRootAttribute("EUC_CC_SID_PEKERJAAN_DATA")).Serialize(fs, list, ns);
                //}
      

        }

        public static void ConvertTxtToXML_EUC_CC_SID_SUMBER(string path)
        {
            Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter();
            ms_system_parameter o = rep.Find("mFolderTxtToXmlSumber");
            o = rep.Find("mFolderTxtToXmlSumber");
            mFolderTxtToXmlSumber = o != null ? o.ParameterValue : string.Empty;
            
            ///  string fullPath = Path.Combine("@" + path);
            string[] lines = File.ReadAllLines(path);
                List<euc_cc_sid_sumber> list = new List<euc_cc_sid_sumber>();

                foreach (string line in lines.Skip(1))
                {
                try
                {
                    string[] contents = line.Split(new char[] { '|' });
                    var sumber = new euc_cc_sid_sumber
                    {
                        //IDIFILE = contents[0],
                        //TGL_LAPORAN = contents[1],
                        //PROGRAM = contents[2],
                        //DIN = contents[3],
                        //KODE = contents[4],
                        //NAMA = contents[5],
                        //CABANG_PELAPOR = contents[6],

                    };
                    list.Add(sumber);
                }
                catch (Exception ex)
                {

                    DBHelper db = new DBHelper();
                  //  LogUtil.AddLogXMLError(db, path, "ConvertTxtToXML", "ConvertTxtToXML_EUC_CC_SID_SUMBER", "", ex.Message, ex.StackTrace);
                  //  throw ex;
                  //  Console.WriteLine(line + ex);
                }
                finally
                {
                    Console.WriteLine("next");
                }
                   
                }
                using (XmlWriter writer = XmlWriter.Create(mFolderTxtToXmlSumber))//, new XmlWriterSettings { OmitXmlDeclaration = true }
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    new XmlSerializer(typeof(List<euc_cc_sid_sumber>), new XmlRootAttribute("EUC_CC_SID_SUMBER_DATA")).Serialize(writer, list, ns);
                }
                //Save.SaveAllFilesXmlMasterToDatabase(path);
                //using (FileStream fs = new FileStream("C:\\Downloads\\txtToXml\\EUC_CC_SID_SUMBER.xml", FileMode.Create))
                //{
                //    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                //    ns.Add("", "");
                //    new XmlSerializer(typeof(List<EUC_CC_SID_SUMBER>), new XmlRootAttribute("EUC_CC_SID_SUMBER_DATA")).Serialize(fs, list, ns);
                //}
        }

        public static void ConvertTxtToXML_EUC_CC_SID_SUMMARY(string path)
        {
            //Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter();
            //ms_system_parameter o = rep.Find("mFolderTxtToXmlSummary");
            //o = rep.Find("mFolderTxtToXmlSummary");
            //mFolderTxtToXmlSummary = o != null ? o.ParameterValue : string.Empty;
            //string fullPath = Path.Combine("@" + path);
            //    string[] lines = File.ReadAllLines(path);
            //    List<euc_cc_sid_summary> list = new List<euc_cc_sid_summary>();

            //    foreach (string line in lines.Skip(1))
            //    {
            //    try
            //    {
            //        string[] contents = line.Split(new char[] { '|' });
            //        var summary = new euc_cc_sid_summary
            //        {
            //            IDIFILE = contents[0],
            //            TGL_LAPORAN = contents[1],
            //            PROGRAM = contents[2],
            //            DIN = contents[3],
            //            No = contents[4],
            //            PLAFON_KREDIT = contents[5],
            //            PLAFON_LC = contents[6],
            //            PLAFON_GYD = contents[7],
            //            PLAFON_LAINNYA = contents[8],
            //            PLAFON_TOTAL = contents[9],
            //            BAKIDEBET_KREDIT = contents[10],
            //            BAKIDEBET_LC = contents[11],
            //            BAKIDEBET_BG = contents[12],
            //            BAKIDEBET_LAINNYA = contents[13],
            //            BAKIDEBET_TOTAL = contents[14],
            //            KOLEK_TERBURUK = contents[15],
            //            KOLEK_BULAN = contents[16],


            //        };
            //        list.Add(summary);
            //    }
            //    catch (Exception ex)
            //    {

            //        DBHelper db = new DBHelper();
            //        LogUtil.AddLogXMLError(db, path, "ConvertTxtToXML", "ConvertTxtToXML_EUC_CC_SID_SUMMARY", "", ex.Message, ex.StackTrace);
            //      //  throw ex;
            //    }
            //    finally
            //    {
            //        Console.WriteLine("next");
            //    }
            
                    
            //    }
            //    using (XmlWriter writer = XmlWriter.Create(mFolderTxtToXmlSummary))//, new XmlWriterSettings { OmitXmlDeclaration = true }
            //    {
            //        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //        ns.Add("", "");
            //        new XmlSerializer(typeof(List<euc_cc_sid_summary>), new XmlRootAttribute("EUC_CC_SID_SUMMARY_DATA")).Serialize(writer, list, ns);
            //    }
                //Save.SaveAllFilesXmlMasterToDatabase(path);
                //using (FileStream fs = new FileStream("C:\\Downloads\\txtToXml\\EUC_CC_SID_SUMMARY.xml", FileMode.Create))
                //{
                //    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                //    ns.Add("", "");
                //    new XmlSerializer(typeof(List<EUC_CC_SID_SUMMARY>), new XmlRootAttribute("EUC_CC_SID_SUMMARY_DATA")).Serialize(fs, list, ns);
                //}
          

        }
    }
}
