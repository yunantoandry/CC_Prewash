using System;
using Common.Repository;
using Common.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using Common.Utils;
using System.Diagnostics;
using log4net;
using System.Net;
using System.Threading;
using DansCSharpLibrary.Threading;

namespace Common.XML
{
    public class XmlHitCrde : CreateFiles
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private int maxActionsToRunInParallel_HitWsCRDE = ServiceConfiguration.MaxActionsToRunInParallel_HitWsCRDE;
        private string UrlWebservices = ServiceConfiguration.GetUrlWebservices();
        //private static string DIN = string.Empty;
        //private static string BATCH = string.Empty;
        //private static string Cust_Segment = string.Empty;
        //private static string Drop_Reason = string.Empty;
        //private static string Final_Decision = string.Empty;
        //private static float Final_Limit ;
        //private static string Flag_bureau = string.Empty;
        //private static string Flag_KKBL = string.Empty;
        //private static string Jumlah_Issuer = string.Empty;
        //private static string LA_Segment_New = string.Empty;
        ////  private static string MGROSS_INCOME = string.Empty;
        ////private static string NAME = string.Empty;
        ////  private static string NOMORCIF = string.Empty;
        //private static string Npwp_Status = string.Empty;
        //private static string Score_Category = string.Empty;
        //private static string TotalScore = string.Empty;
        ////private static string ApplicationNumber = string.Empty;
        //private static string Sequence_Number = string.Empty;
        ////private static string Reason_Decision = string.Empty;
        //private static string Reason_Code = string.Empty;
        //private static string Reason_Description = string.Empty;
        //private static string Criteria_Name = string.Empty;
        //private static string Mandatory = string.Empty;

        //private static string fileName = string.Empty;
        //private static string fullFilePath = string.Empty;
        //private static string xml_response = string.Empty;
       // private static string sas_id = string.Empty;
        //private static string xml_request = string.Empty;
        //private static string ktp = string.Empty;
        //private Int64 ValidityPeriodTicks { get; set; }
        public XmlHitCrde()
        {

        }
        public void Handle()
        {
            try
            {
                using (DBHelper db = new DBHelper())
                {                  
                    Rep_tr_xml_trans Rep_tr_xml_trans = new Rep_tr_xml_trans(db);
                    tr_xml_trans tr_log_xml_trans = new tr_xml_trans();
                    List<tr_xml_trans> listXmlTran = Rep_tr_xml_trans.GetAll(string.Format("where status_xml = 'ready' order by Created_Date "));
                    Rep_ms_euc_cc_input Rep_ms_euc_cc_input = new Rep_ms_euc_cc_input(db);
                    int listXmlTranCount = listXmlTran.Count();

                    if (listXmlTranCount > 0)
                    {
                      //  bool SAS_ID_Exist = Rep_ms_euc_cc_input.NotSendXMLtoHitCRDE(sas_id);

                        _log.Debug($"try CallProcessManager web service and get response");

                        CancellationToken cancellationToken = new CancellationToken();

                        var listOfTasks = new List<Task>();
                        int cnt = 1;
                        Thread.CurrentThread.Name = "FileWatcherTask";
                        foreach (var item in listXmlTran)
                        {
                            if (cnt <= maxActionsToRunInParallel_HitWsCRDE)
                            {                              
                                    listOfTasks.Add(new Task(() => Handle_1(item.SAS_ID,item.XML_REQUEST)));
                                    cnt = cnt + 1;                                
                            }
                            else
                            {
                                break;
                            }                         
                        }
                        Tasks.StartAndWaitAllThrottled(listOfTasks, maxActionsToRunInParallel_HitWsCRDE, -1, cancellationToken);
                        // );
                    }
                    else
                    {
                        _log.Info($"list for hit webservice count : {listXmlTranCount}");
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error("An error occured while hit crde the service.");
                _log.Error(ex);
            }
        }
        public void Handle_1(string SAS_ID, string XML_REQUEST)
        {
            svcCrde.ProcessManager PM = new svcCrde.ProcessManager();
            PM.Timeout = 600000; // 10 minutes
            PM.Url = UrlWebservices;
            using (DBHelper db = new DBHelper())
            {
                Rep_tr_xml_trans Rep_tr_xml_trans = new Rep_tr_xml_trans(db);
               //  tr_xml_trans o = Rep_tr_xml_trans.Find(SAS_ID);
                // string XML_REQUEST2 = o.XML_REQUEST;

                string BATCH = "";
                //sas_id = item.SAS_ID;
                //string xml_request = item.XML_REQUEST;
                BATCH = "BATCH_" + DateTime.Now.ToString("yyyyMMdd");
                string xml_response = "";
                //  string xml_response = item.XML_RESPONSE;

                //if (SAS_ID_Exist == true)
                //{
                // Stopwatch sw = Stopwatch.StartNew();
                //  System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                var watch = System.Diagnostics.Stopwatch.StartNew();
                string startTime = DateTime.Now.ToLongTimeString();

                _log.Info($"sas_id : {SAS_ID} Start time stopwatch.{startTime}");
                try
                {
                    xml_response = PM.CallProcessManager(XML_REQUEST);
                }
                catch (System.TimeoutException)
                {
                    _log.Debug($"Response Time Out Occured!");
                }

                watch.Stop();
                string timeEnd = DateTime.Now.ToLongTimeString();
                _log.Info($"sas_id :{SAS_ID} Stop time stopwatch.{timeEnd}");

                // sw.Stop();
                TimeSpan responses_time = watch.Elapsed;

                // Rep_tr_xml_trans.UpdateXmlReponse(sas_id, xml_response.ToString(), responses_time);
                //_log.Debug($"{item.SAS_ID} successfully hit ws crde, response time{sw.Elapsed}");

                XmlDocument xmldoc = new XmlDocument();

                //  string xml_response = "";
                xmldoc.LoadXml(xml_response);

                //error

                var ReturnError = xmldoc.SelectNodes(@"//Error");

                if (ReturnError.Count > 0)
                {
                    foreach (XmlNode xn in ReturnError)
                    {
                        string Description = xn["Description"].InnerText;
                        string Field = xn["Field"].InnerText;
                        string Value = xn["Value"].InnerText;

                        LogUtil.AddLogXMLError(db, SAS_ID, Field, Value, "ReturnError-XmlHitCrde", BATCH);
                        Rep_tr_xml_trans.UpdateStatusFailed(SAS_ID);
                        _log.Debug($"ReturnError/XmlHitCrde- sas_id : { SAS_ID} Field: '{Field}' Value:'{Value}' Description:'{Description}'  ");
                    }
                }
                else
                {
                    //PM_Outputs
                    var PM_Outputs = xmldoc.SelectNodes(@"//PM_Outputs/EUC_CC_INPUT");
                    if (PM_Outputs.Count > 0)
                    {
                        string DIN = "", Status = "", Flag_KKBL = "", Score_G = "", score_cat = "", FinalRemarks = "", Drop_Reason = "";
                        decimal TotalScore = 0, TotalScore2 = 0, Final_Limit = 0, jml_issuer = 0, NPWP_Status = 0;
                        // float TotalScore = 0;
                        XmlNodeList nodeListDin = xmldoc.GetElementsByTagName("DIN");
                        // XmlNodeList nodeListBATCH = xmldoc.GetElementsByTagName("BATCH");
                        XmlNodeList nodeListFinal_Limit = xmldoc.GetElementsByTagName("Final_Limit");
                        XmlNodeList nodeListFlag_bureau = xmldoc.GetElementsByTagName("Flag_bureau");
                        XmlNodeList nodeListFlag_KKBL = xmldoc.GetElementsByTagName("Flag_KKBL");
                        XmlNodeList nodeListLA_Segment_New = xmldoc.GetElementsByTagName("LA_Segment_New");
                        XmlNodeList nodeListTotalScore = xmldoc.GetElementsByTagName("TotalScore");
                        XmlNodeList nodeListScore_Category = xmldoc.GetElementsByTagName("Score_Category");
                        XmlNodeList nodeListJumlah_Issuer = xmldoc.GetElementsByTagName("Jumlah_Issuer");
                        XmlNodeList nodeListNpwp_Status = xmldoc.GetElementsByTagName("Npwp_Status");
                        XmlNodeList nodeListFinal_Decision = xmldoc.GetElementsByTagName("Final_Decision");
                        XmlNodeList nodeListDrop_Reason = xmldoc.GetElementsByTagName("Drop_Reason");

                        foreach (XmlNode node in nodeListDin)
                        {
                            DIN = node.InnerText;
                        }
                        //foreach (XmlNode node in nodeListBATCH)
                        //{
                        //    BATCH = node.InnerText;
                        //}
                        foreach (XmlNode node in nodeListFinal_Limit)
                        {
                            Final_Limit = Convert.ToDecimal(node.InnerText);//
                        }
                        foreach (XmlNode node in nodeListFlag_bureau)
                        {
                            Status = node.InnerText;
                        }
                        foreach (XmlNode node in nodeListFlag_KKBL)
                        {
                            Flag_KKBL = node.InnerText;
                        }
                        foreach (XmlNode node in nodeListLA_Segment_New)
                        {
                            Score_G = node.InnerText;
                        }
                        foreach (XmlNode node in nodeListTotalScore)
                        {
                            TotalScore = Convert.ToDecimal(node.InnerText);
                            TotalScore2 = Math.Floor(TotalScore);
                        }
                        foreach (XmlNode node in nodeListScore_Category)
                        {
                            score_cat = node.InnerText;
                        }
                        foreach (XmlNode node in nodeListJumlah_Issuer)
                        {
                            jml_issuer = Convert.ToDecimal(node.InnerText); //float.Parse(node.InnerText);
                        }
                        foreach (XmlNode node in nodeListNpwp_Status)
                        {
                            NPWP_Status = Convert.ToDecimal(node.InnerText); //float.Parse(node.InnerText);
                        }
                        foreach (XmlNode node in nodeListFinal_Decision)
                        {
                            FinalRemarks = node.InnerText;
                        }
                        foreach (XmlNode node in nodeListDrop_Reason)
                        {
                            Drop_Reason = node.InnerText;
                        }
                        Guid g = Guid.NewGuid();
                        string UniqueKey = Convert.ToBase64String(g.ToByteArray());
                        UniqueKey = UniqueKey.Replace("=", "");
                        UniqueKey = UniqueKey.Replace("+", "");

                        Rep_tr_xml_trans.UpdateXmlReponsePmOutput(SAS_ID, UniqueKey, DIN, BATCH, Final_Limit, Status, Flag_KKBL, Score_G, TotalScore2, score_cat, jml_issuer, NPWP_Status, Drop_Reason, FinalRemarks, xml_response.ToString(), responses_time);
                        LogUtil.AddLogXMLSuccess(db, SAS_ID, BATCH, "Tag : PM_Outputs");
                        _log.Debug($"{SAS_ID} successfully hit ws crde, response time{watch.Elapsed}");
                        Thread.Sleep(5000);

                        //RAC_CRDE
                        //var RAC_CRDE = xmldoc.SelectNodes(@"//Decision_Results [@name='Policy Rules Check']/PM_Reason_Codes_Data/PM_Reason_Codes");

                        //foreach (XmlNode xn in RAC_CRDE)
                        //{
                        //    // string Sequence_Number = xn["Sequence_Number"].InnerText;
                        //    int Sequence_Number = Convert.ToInt32(xn["Sequence_Number"].InnerText);
                        //    string Criteria_Name = xn["Criteria_Name"].InnerText;
                        //    string Reason_Code = xn["Reason_Code"].InnerText;
                        //    string Reason_Description = xn["Reason_Description"].InnerText;
                        //    string Mandatory = xn["Mandatory"].InnerText;


                        //    Table_RAC o = new Table_RAC();
                        //    o.SAS_ID = item.SAS_ID;
                        //    o.Sequence_Number = Sequence_Number;
                        //    o.Criteria_Name = Criteria_Name;
                        //    o.Reason_Code = Reason_Code;
                        //    o.Reason_Description = Reason_Description;
                        //    o.Mandatory = Mandatory;
                        //    o.CREATED_BY = "Services";
                        //    o.MODIFIED_BY = "Services";
                        //    o.CREATED_DATE = DateTime.Now;
                        //    o.MODIFIED_DATE = DateTime.Now;
                        //    int i = Rep_tr_xml_trans.DBHelper.Insert<Table_RAC>(o);

                        //  }

                        //foreach (XmlNode xn in PM_Outputs)
                        //{


                        //    DIN = xn.SelectSingleNode("DIN").InnerText;
                        //    BATCH = xn["BATCH"].InnerText;
                        //    Final_Limit = float.Parse(xn["Final_Limit"].InnerText);
                        //    Status = xn["Flag_bureau"].InnerText;
                        //    Flag_KKBL = xn["Flag_KKBL"].InnerText;
                        //    Score_G = xn["LA_Segment_New"].InnerText;
                        //    TotalScore = float.Parse(xn["TotalScore"].InnerText);
                        //    score_cat = xn["SCORE_CATEGORY"].InnerText;
                        //    jml_issuer = float.Parse(xn["NO_ISSUER"].InnerText);
                        //    NPWP_Status = float.Parse(xn["NPWP_STATUS"].InnerText);
                        //    FinalRemarks = xn["FINAL_DECISION"].InnerText;
                        //    Drop_Reason = xn["Drop_Reason"].InnerText;


                        //    Guid g = Guid.NewGuid();
                        //    string UniqueKey = Convert.ToBase64String(g.ToByteArray());
                        //    UniqueKey = UniqueKey.Replace("=", "");
                        //    UniqueKey = UniqueKey.Replace("+", "");
                        //    Rep_tr_xml_trans.UpdateXmlReponsePmOutput(item.SAS_ID, UniqueKey, DIN, BATCH, Final_Limit, Status, Flag_KKBL, Score_G, TotalScore, score_cat, jml_issuer, NPWP_Status, Drop_Reason, FinalRemarks);
                        //}
                    }
                    else
                    {
                        LogUtil.AddLogXMLError(db, SAS_ID, "", "", "Tag : PM_Outputs", BATCH);
                        Rep_tr_xml_trans.UpdateStatusFailed(SAS_ID);
                        _log.Debug($"Tag: PM_Outputs_no_result/XmlHitCrde- Sas_id: '{SAS_ID}'  ");
                    }
                }
                //}
                //else
                //{
                //    _log.Error($"sas_id not proces : {item.SAS_ID}");
                //    LogUtil.AddLogXMLError(db, item.SAS_ID, "", "", "sas_id cannot be process", BATCH);
                //    Rep_tr_xml_trans.UpdateStatusFailed(sas_id);
                //}
            }

        }

            public List<HttpWebRequest> CreateWebRequest(int no)
        {

            //reading an xml file from location which will be passed to WCF api as http post data
            var path = @"D:\PraveenUpadhyay\abc.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            List<HttpWebRequest> webRequest = new List<HttpWebRequest>();

            for (int i = 1; i <= no; i++)
            {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost/TestService.svc/rest/agent/asset");
                request.Method = "POST"; request.ContentType = "application/xml;";
                var data = Encoding.ASCII.GetBytes(doc.InnerXml);
                request.ContentLength = data.Length;
                request.Timeout = 1000 * 60 * 10;
                //request.KeepAlive = true;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                webRequest.Add(request);
            }

            return webRequest;
        }
        private static void TimeMultipleRequests(List<HttpWebRequest> requests)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (var request in requests)
            {

                request.GetResponse();
            }

            stopWatch.Stop();
            var timeSpan = stopWatch.Elapsed;
            string s = String.Format("{0:00} hours, {1:00} minutes, {2:00} seconds, {3:00} milliseconds", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
            Console.WriteLine(s);
        }
    }
}
