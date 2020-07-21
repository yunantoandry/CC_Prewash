using Common.Model;
using Common.XML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;

namespace Common.Repository
{
    public class Save
    {
        public static bool SaveAllFilesXmlMasterToDatabase(string action)
        {
            SaveXmlToDB SX = new SaveXmlToDB();
            bool a = SX.SaveAllFilesXmlMasterToDatabase(action);
            return a = true ? true : false;
        }
        public static bool SaveAllFilesXmlToDatabase(string sas_id, string xml)
        {
            SaveXmlToDB SX = new SaveXmlToDB();
            bool a = SX.SaveAllXmlToDatabase(sas_id, xml);
            return a = true ? true : false;
        }
        
        public static bool insert_from_staging_to_euc_cc_input(string pathInWatchFolder, string newFileName)
        {
            SaveXmlToDB SX = new SaveXmlToDB();
            bool a = SX.insert_from_staging_to_euc_cc_input(pathInWatchFolder, newFileName);
            return a = true ? true : false;
        }
        public static bool Update_status_success_sendXML()
        {
            SaveXmlToDB SX = new SaveXmlToDB();
            bool a = SX.Update_status_success_sendXML();
            return a = true ? true : false;
        }
        public static bool Save_reporting_risk(string date, string Batch, int time_total, string fileName, int listXmlTranResponse)
        {
            SaveXmlToDB SX = new SaveXmlToDB();
            bool a = SX.Save_reporting_risk(date, Batch, time_total, fileName, listXmlTranResponse);
            return a = true ? true : false;
        }

        public static bool SaveRAC(string sas_id, int Sequence_Number, string Criteria_Name, string Reason_Code, string Reason_Description)
        {
 
            SaveXmlToDB SX = new SaveXmlToDB();
            bool a = SX.SaveRAC(sas_id, Sequence_Number, Criteria_Name, Reason_Code, Reason_Description);
            return a = true ? true : false;
        }
        //public static bool SaveAllXmlHitResponse(string sas_id, string UniqueKey, string DIN, string BATCH, string Cust_Segment, float Final_Limit, string Status, string Flag_KKBL, string Score_G, float TotalScore, string score_cat, float jml_issuer, float NPWP_Status, string Drop_Reason, string FinalRemarks)

        //{
        //    //SaveXmlToDB SX = new SaveXmlToDB();
        //    //bool a = SX.SaveAllXmlHitResponse(sas_id, UniqueKey, DIN, BATCH, Cust_Segment, Final_Limit, Flag_KKBL, Flag_KKBL, Score_G, TotalScore, score_cat, jml_issuer, NPWP_Status, Drop_Reason, FinalRemarks);
        //    //return a = true ? true : false;
        //}

        public static void GetDataTabletFromCSVFile1(string pathInWatchFolder, string table,string filename)
        {
            SaveXmlToDB SX = new SaveXmlToDB();
            SX.GetDataTabletFromCSVFile1(pathInWatchFolder, table, filename);
        }
    }
}
