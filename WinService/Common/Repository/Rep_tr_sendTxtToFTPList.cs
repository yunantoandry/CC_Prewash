using Common.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public class Rep_tr_sendTxtToFTPList : Repository,IDisposable
    {
        public Rep_tr_sendTxtToFTPList()
        {
        }
        public Rep_tr_sendTxtToFTPList(DBHelper db)
        {
            this.DBHelper = db;
        }

        public List<tr_sendTxtToFTPList> GetAll()
        {
            List<tr_sendTxtToFTPList> list = GetAll(string.Empty);
            return list;
        }

        public List<tr_sendTxtToFTPList> GetAll(string condition)
        {
            List<tr_sendTxtToFTPList> list = null;
            if (string.IsNullOrEmpty(condition))
                list = DBHelper.Connection.Query<tr_sendTxtToFTPList>("Select * From tr_xml_trans").ToList();
            else
                list = DBHelper.Connection.Query<tr_sendTxtToFTPList>("select input.Name ,input.NOMORCIF ,xml_trans.BATCH ,xml_trans.UniqueKey ,input.DOB as TGLAHIR ,xml_trans.DIN ,input.SEGMENT as Cust_Segment ,xml_trans.TotalScore ,input.MGROSS_INCOME as MonthlyIncome ,xml_trans.LA_Segment_New as Score_G,xml_trans.FLAG_BUREAU as status ,xml_trans.FLAG_KKBL ,xml_trans.SCORE_CATEGORY as score_cat,xml_trans.jml_issuer,xml_trans.NPWP_Status,xml_trans.Final_Limit ,xml_trans.FinalRemarks,xml_trans.Drop_Reason from EUC_CC_INPUT input join tr_xml_trans xml_trans on input.SAS_ID = xml_trans.SAS_ID  " + condition).ToList();

            return list;
  //          xml_trans.score_cat ,
  //      xml_trans.jml_issuer ,
  //      xml_trans.NPWP_Status ,
		//xml_trans.FinalRemarks ,
  //     xml_trans.Drop_Reason ,
		//xml_trans.Score_G ,

        }

        public tr_sendTxtToFTPList Find(string SAS_ID)
        {
            tr_sendTxtToFTPList model = null;
            model = DBHelper.Connection.Query<tr_sendTxtToFTPList>("Select * From euc_cc_input  WHERE SAS_ID = @SAS_ID", new { SAS_ID }).SingleOrDefault();
            return model;
        }
    }
}
