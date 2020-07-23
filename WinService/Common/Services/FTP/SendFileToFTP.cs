using Common.Model;
using Common.Repository;
using Common.Services.Email;
using Common.Services.Reporting;
using Common.Utils;
using Common.XML;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace Common.Services.FTP
{
    public class SendFileToFTP : CreateFiles
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(SendFileToFTP));
        private readonly FTPS _FTPS;
        private readonly Create_Reporting_Risk _reporting_Risk;
        private readonly SmtpUtil _smtpUtil;

        private string toAddress_CC_Prewash_A_Score_in_CRDE = ServiceConfiguration.GetAppSettingValue("toAddress_CC_Prewash_A_Score_in_CRDE");
        private string bodyTempalate_bodyTempalate_CC_Prewash_A_Score_in_CRDE = ServiceConfiguration.GetAppSettingValue("bodyTempalate_CC_Prewash_A_Score_in_CRDE");
        private string subject_CC_Prewash_A_Score_in_CRDE = ServiceConfiguration.GetAppSettingValue("subject_CC_Prewash_A_Score_in_CRDE");

        // private readonly SendEmailsInventory3plCommander _SendEmailsInventory3pl;
        private static string fileName = string.Empty;       
        private static string fileName_RAC = string.Empty;
        private static string fileName_Failed = string.Empty;
        private static string fullFilePath = string.Empty;
        private static string fullFilePath_RAC = string.Empty;
        private static string fullFilePath_Failed = string.Empty;
        private string mFolderLocalDirectoryOutput = string.Empty;
        private string mFolderLocalDirectoryDumpOutput = string.Empty;
        public SendFileToFTP()
        {
            _FTPS = new FTPS();
            _reporting_Risk = new Create_Reporting_Risk();
            _smtpUtil = new SmtpUtil();
        }
        public void Handle()
        {
            using (DBHelper db = new DBHelper())
            {
                Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter(db);
                ms_system_parameter o = new ms_system_parameter();
                o = rep.Find("mFolderLocalDirectoryOutput");
                mFolderLocalDirectoryOutput = o != null ? o.ParameterValue : string.Empty;
                o = rep.Find("mFolderLocalDirectoryDumpOutput");
                mFolderLocalDirectoryDumpOutput = o != null ? o.ParameterValue : string.Empty;

                FileInfo file = null;
                FileInfo file2 = null;
                FileInfo file3 = null;
                string newFileName = string.Empty;
                string newFileName2 = string.Empty;
                string newFileName3 = string.Empty;
                string BATCH = string.Empty;

                Rep_tr_sendTxtToFTPList Rep_tr_sendTxtToFTPList = new Rep_tr_sendTxtToFTPList(db);
                Rep_tr_xml_trans Rep_tr_xml_trans = new Rep_tr_xml_trans(db);
                Rep_tr_log_xml_error rep_tr_log_xml_error = new Rep_tr_log_xml_error(db);
                Rep_Table_RAC rep_Table_RAC = new Rep_Table_RAC(db);
                List<Table_RAC> lisTable_RAC = rep_Table_RAC.GetAll(string.Format("WHERE STATUS_XML='Waiting' And Flag_sent ='Not yet sent'"));

                List<tr_sendTxtToFTPList> listXmlTranResponse = Rep_tr_sendTxtToFTPList.GetAll(string.Format("WHERE STATUS_XML='Waiting' And Flag_sent ='Not yet sent'"));

                // List<tr_xml_trans> list_output_success = Rep_tr_xml_trans.GetAll(string.Format("WHERE STATUS_XML='Waiting' And Flag_sent ='Not yet sent'"));
                List<tr_log_xml_error> list_xml_error = rep_tr_log_xml_error.ListXmlError();

                fileName = "CRDE_BATCH_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + listXmlTranResponse.Count;
                fullFilePath = string.Format(mFolderLocalDirectoryOutput + "{0}.txt", fileName);
                _log.Info($"Create Filename batch output : {fullFilePath} ");

                fileName_RAC = "CRDE_RAC_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                fullFilePath_RAC = string.Format(mFolderLocalDirectoryOutput + "{0}.txt", fileName_RAC);
                _log.Info($"Create Filename RAC: {fullFilePath_RAC} ");

                fileName_Failed = "CRDE_Failed_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + list_xml_error.Count;
                fullFilePath_Failed = string.Format(mFolderLocalDirectoryOutput + "{0}.txt", fileName_Failed);
                _log.Info($"Create Filename Error Batch: {fullFilePath_RAC} ");

                //  tr_xml_trans tr_xml_trans = new tr_xml_trans();

                file = new FileInfo(fullFilePath);
                newFileName = string.Format("{0}", file.Name);

                file2 = new FileInfo(fullFilePath_RAC);
                newFileName2 = string.Format("{0}", file2.Name);

                file3 = new FileInfo(fullFilePath_Failed);
                newFileName3 = string.Format("{0}", file3.Name);

                StringBuilder sb = new StringBuilder();
                sb.Append("Name|");
                sb.Append("NOMORCIF|");
                sb.Append("Batch|");
                sb.Append("UniqueKey|");
                sb.Append("TGLAHIR|");
                sb.Append("DIN|");
                sb.Append("Cust_Segment|");
                sb.Append("TotalScore|");
                sb.Append("MonthlyIncome|");
                sb.Append("Score_G|");
                sb.Append("Status|");
                sb.Append("FLAG_KKBL|");
                sb.Append("score_cat|");
                sb.Append("jml_issuer|");
                sb.Append("NPWP_Status|");
                sb.Append("Final_Limit|");
                sb.Append("FinalRemarks|");
                sb.Append("Drop_Reason");
                sb.Append("\n");
                foreach (var item in listXmlTranResponse)
                {
                    // item.BATCH ="BATCH_" +  DateTime.Now.ToString("yyyyMMdd");
                    sb.Append(item.Name + "|");
                    sb.Append(item.NOMORCIF + "|");
                    sb.Append(item.BATCH + "|");
                    sb.Append(item.UniqueKey + "|");
                    sb.Append(item.TGLAHIR.ToString("ddMMMyyyy") + "|");
                    sb.Append(item.DIN + "|");
                    sb.Append(item.Cust_Segment + "|");
                    sb.Append(item.TotalScore + "|");
                    sb.Append(item.MonthlyIncome + "|");
                    sb.Append(item.Score_G + "|");
                    sb.Append(item.Status + "|");
                    sb.Append(item.FLAG_KKBL + "|");
                    sb.Append(item.score_cat + "|");
                    sb.Append(item.jml_issuer + "|");
                    sb.Append(item.NPWP_Status + "|");
                    sb.Append(item.Final_Limit + "|");
                    sb.Append(item.FinalRemarks + "|");
                    if (string.IsNullOrEmpty(item.Drop_Reason))
                    {
                        sb.Append(item.Drop_Reason + "|");
                    }
                    else
                    {
                        sb.Append(item.Drop_Reason + "");
                    }
                    sb.Append("\n");
                }
                sb.Append("EOF|" + DateTime.Now.ToString("yyyyMMdd") + "|" + listXmlTranResponse.Count);
                Console.WriteLine(sb.ToString());
                if(listXmlTranResponse.Count > 0)
                {
                    CreateFile(fullFilePath, sb.ToString());
                    _log.Info($"Successfully Create Filename in {fullFilePath}");
                }

                StringBuilder sb2 = new StringBuilder();
                sb2.Append("ApplicationNumber|");
                sb2.Append("Sequence_Number|");
                sb2.Append("Reason_Code|");
                sb2.Append("Reason_Description|");
                sb2.Append("Criteria_Name|");
                sb2.Append("Mandatory ");
                sb2.Append("\n");

                foreach (var item in lisTable_RAC)
                {
                    sb2.Append(item.SAS_ID + "|");
                    sb2.Append(item.Sequence_Number + "|");
                    sb2.Append(item.Reason_Code + "|");
                    sb2.Append(item.Reason_Description + "|");
                    sb2.Append(item.Criteria_Name + "|");

                    if (string.IsNullOrEmpty(item.Mandatory))
                    {
                        sb2.Append(item.Mandatory + "|");
                    }
                    else
                    {
                        sb2.Append(item.Mandatory + "");
                    }
                    sb2.Append("\n");
                }
                sb2.Append("EOF|" + DateTime.Now.ToString("yyyyMMdd") + "|" + lisTable_RAC.Count);
                Console.WriteLine(sb2.ToString());
                if (lisTable_RAC.Count > 0)
                {
                    //CreateFile(fullFilePath_RAC, sb2.ToString());
                    //_log.Info($"Successfully Create Filename in {fullFilePath_RAC}");
                }


                _reporting_Risk.handle();

                StringBuilder sb3 = new StringBuilder();
                sb3.Append("Sas_ID|");
                sb3.Append("Field|");
                sb3.Append("Value|");
                sb3.Append("Description|");
                sb3.Append("Batch|");
                sb3.Append("\n");
                foreach (var item in list_xml_error)
                {
                    // item.BATCH ="BATCH_" +  DateTime.Now.ToString("yyyyMMdd");
                    sb3.Append(item.SAS_ID + "|");
                    sb3.Append(item.Field + "|");
                    sb3.Append(item.Value + "|");
                    sb3.Append(item.Description + "|");
                    if (string.IsNullOrEmpty(item.Batch))
                    {
                        sb3.Append(item.Batch + "|");
                    }
                    else
                    {
                        sb3.Append(item.Batch + "");
                    }
                    sb3.Append("\n");
                }
                sb3.Append("EOF|" + DateTime.Now.ToString("yyyyMMdd") + "|" + list_xml_error.Count);
                Console.WriteLine(sb3.ToString());
                if (list_xml_error.Count > 0)
                {
                    CreateFile(fullFilePath_Failed, sb3.ToString());
                    _log.Info($"Successfully Create Filename in {fullFilePath_Failed}");
                }

                _FTPS.handle_upload(); // if you want send to ftp

                //_smtpUtil.SendEmail_With_Attachment(toAddress_CC_Prewash_A_Score_in_CRDE, subject_CC_Prewash_A_Score_in_CRDE, bodyTempalate_bodyTempalate_CC_Prewash_A_Score_in_CRDE, mFolderLocalDirectoryOutput); // if you want send via email


                String directoryName = mFolderLocalDirectoryDumpOutput;
                DirectoryInfo dirInfo = new DirectoryInfo(directoryName);
                if (dirInfo.Exists == false)
                    Directory.CreateDirectory(directoryName);

                List<String> source = Directory
                                   .GetFiles(mFolderLocalDirectoryOutput, "*.*", SearchOption.AllDirectories).ToList();

                foreach (string file1 in source)
                {
                    FileInfo mFile = new FileInfo(file1);
                    // to remove name collisions
                    if (new FileInfo(dirInfo + "\\" + mFile.Name).Exists == false)
                    {
                        mFile.MoveTo(dirInfo + "\\" + mFile.Name);
                        _log.Info($"Move Filename :'{ mFile.Name}' To : '{mFolderLocalDirectoryDumpOutput}'");
                    }
                }
                //  string status_xml = "Waiting";
                Rep_tr_xml_trans.UpdateStatusSuccess_FromStatusWaiting();
                Rep_tr_xml_trans.UpdateStatusSent_FromStatusNotyetsent();

                // _log.Info($"update status_xml : {status_xml} to Success...");

            }




        }
    }
}
