using Common.Model;
using Dapper;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Common.Repository
{
    public class Rep_tr_xml_trans : Repository, IDisposable
    {
        public Rep_tr_xml_trans() { }
        public Rep_tr_xml_trans(DBHelper db)
        {
            this.DBHelper = db;
        }
        public List<tr_xml_trans> GetAll()
        {
            List<tr_xml_trans> list = GetAll(string.Empty);
            return list;
        }

        public List<tr_xml_trans> GetAll(string condition)
        {
            List<tr_xml_trans> list = null;
            if (string.IsNullOrEmpty(condition))
                list = DBHelper.Connection.Query<tr_xml_trans>("Select * From tr_xml_trans").ToList();
            else
                list = DBHelper.Connection.Query<tr_xml_trans>("Select sas_id,XML_REQUEST From tr_xml_trans  " + condition).ToList();

            return list;
        }

       

        public tr_xml_trans Find(string SAS_ID)
        {
            tr_xml_trans model = null;
            model = DBHelper.Connection.Query<tr_xml_trans>("Select * From tr_xml_trans WHERE SAS_ID = @SAS_ID", new { SAS_ID }).SingleOrDefault();
            return model;
            
        }
        public int SumTimeResponse(string STATUS_XML)
        {
            int model = 0;
            model = DBHelper.Connection.ExecuteScalar<int>("select sum( DATEPART(SECOND, response_time) + 60 * DATEPART(MINUTE, response_time) + 3600 * DATEPART(HOUR, response_time) ) as 'TotalTime'  from tr_xml_trans WHERE STATUS_XML = @STATUS_XML", new { STATUS_XML = STATUS_XML });
            return model;
        }

        public Tuple<int, int> ddd(int a, int b)
        {
            int min, max;
            if (a > b)
            {
                max = a;
                min = b;
            }
            else
            {
                max = b;
                min = a;
            }
            return new Tuple<int, int>(min, max);
        }

        public Tuple<int, int,int,int> MultipleReturns(string status_xml)
        {
            int total_BNF;
            int total_BF;
            int total_Offer;
            int total_Drop;

            List<tr_xml_trans> list_total_BNF = null;
            List<tr_xml_trans> list_total_BF = null;
            List<tr_xml_trans> list_total_Offer = null;
            List<tr_xml_trans> list_total_drop = null;
            list_total_BNF = DBHelper.Connection.Query<tr_xml_trans>("Select * From tr_xml_trans  " + string.Format("WHERE status_xml = '{0}' And Flag_Bureau ='N' OR Flag_Bureau IS NULL ", status_xml)).ToList();
            list_total_BF = DBHelper.Connection.Query<tr_xml_trans>("Select * From tr_xml_trans  " + string.Format("WHERE status_xml = '{0}' And Flag_Bureau ='Y'", status_xml)).ToList();
                list_total_Offer = DBHelper.Connection.Query<tr_xml_trans>("Select * From tr_xml_trans  " + string.Format("WHERE status_xml = '{0}' And FinalRemarks ='OFFER'", status_xml)).ToList();
            list_total_drop = DBHelper.Connection.Query<tr_xml_trans>("Select * From tr_xml_trans  " + string.Format("WHERE status_xml = '{0}' And FinalRemarks ='DROP' OR FinalRemarks IS NULL", status_xml)).ToList();
            total_BNF = list_total_BNF.Count();
            total_BF = list_total_BF.Count();
            total_Offer = list_total_Offer.Count();
            total_Drop = list_total_drop.Count();

            return new Tuple<int,int,int,int>(total_BNF, total_BF, total_Offer, total_Drop);
        }

        //    public float GetTotalBnf_BF_BF(string status_xml)
        //{
        //    float total_BF = 0;
        //    float total_BNF = 0;
        //    List<tr_xml_trans> list = null;

        //    list = DBHelper.Connection.Query<tr_xml_trans>("Select * From tr_xml_trans  " + string.Format("WHERE status_xml = '{0}' And Flag_Bureau ='N'", status_xml )).ToList();

        //    foreach (tr_xml_trans o in list)
        //    {      
                
        //        if( o.FLAG_BUREAU =="N" || o.FLAG_BUREAU == "")
        //        {
        //            total_BNF += float.Parse(o.FLAG_BUREAU);
        //        }
        //        else
        //        {
        //            total_BF += float.Parse(o.FLAG_BUREAU);
        //        }
              
        //    }

        //    return total_BNF;
        //}

        //public int UpdateStatusSuccess(tr_xml_trans Reportingrisk)
        //{
        //    int rowsAffected = 0;
            
        //    try
        //    {
        //        string sqlQuery = @"
        //                    update tr_xml_trans set STATUS_XML = 'Success',modified_date=@MODIFIED_DATE where STATUS_XML = 'Waiting'";
        //        rowsAffected = this.DBHelper.Connection.Execute(sqlQuery, Reportingrisk);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return rowsAffected;
        //}

        public bool UpdateStatusSuccess_FromStatusWaiting()
        {
            bool sts = false;
            DateTime MODIFIED_DATE = DateTime.Now;
            int rowsAffected = DBHelper.Connection.Execute(@"update tr_xml_trans set STATUS_XML = 'Success',modified_date=@MODIFIED_DATE where STATUS_XML ='Waiting' ", new { MODIFIED_DATE = MODIFIED_DATE });
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }

        public bool UpdateStatusSent_FromStatusNotyetsent()
        {
            bool sts = false;
            DateTime MODIFIED_DATE = DateTime.Now;
            int rowsAffected = DBHelper.Connection.Execute(@"update tr_xml_trans set Flag_sent='Sent',modified_date=@MODIFIED_DATE where Flag_sent='Not yet sent'", new { MODIFIED_DATE = MODIFIED_DATE });
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }

        public bool UpdateStatusFailed(string SAS_ID)
        {
            bool sts = false;
            DateTime MODIFIED_DATE = DateTime.Now;
            string Flag_sent = "Not yet sent";
            int rowsAffected = DBHelper.Connection.Execute(@"UPDATE tr_xml_trans SET STATUS_XML='failed',Flag_sent=@Flag_sent, MODIFIED_DATE=@MODIFIED_DATE,MODIFIED_BY= 'services'
                     WHERE SAS_ID = @SAS_ID", new { SAS_ID = SAS_ID, MODIFIED_DATE = MODIFIED_DATE, Flag_sent= Flag_sent });
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }

        public bool UpdateXmlReponse(string SAS_ID,string XML_RESPONSE, TimeSpan Response_time)
        {
            bool sts = false;
            DateTime MODIFIED_DATE = DateTime.Now;
            int rowsAffected = DBHelper.Connection.Execute(@"UPDATE tr_xml_trans SET XML_RESPONSE=@XML_RESPONSE,Response_time = @Response_time, modified_date=@MODIFIED_DATE,MODIFIED_BY= 'services'
                     WHERE SAS_ID = @SAS_ID", new { SAS_ID = SAS_ID, MODIFIED_DATE = MODIFIED_DATE, XML_RESPONSE = XML_RESPONSE, Response_time = Response_time }, commandTimeout: 500000000);
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
           
        }

        public bool UpdateXmlReponsePmOutput(string sas_id, string UniqueKey, string DIN, string BATCH, decimal Final_Limit, string Status, string Flag_KKBL, string Score_G, decimal TotalScore, string score_cat, decimal jml_issuer, decimal NPWP_Status, string Drop_Reason, string FinalRemarks, string XML_RESPONSE, TimeSpan Response_time)
        {
            bool sts = false;
            DateTime MODIFIED_DATE = DateTime.Now;
            string Flag_sent = "Not yet sent";
            string STATUS_XML = "Waiting";
            int rowsAffected = DBHelper.Connection.Execute(@"update tr_xml_trans set UniqueKey=@UniqueKey,DIN=@DIN,BATCH=@BATCH,STATUS_XML=@STATUS_XML,Final_Limit=@Final_Limit,Flag_bureau=@Status,Flag_KKBL=@Flag_KKBL,LA_Segment_New=@Score_G,TotalScore=@TotalScore,Score_Category=@score_cat,jml_issuer=@jml_issuer,NPWP_Status=@NPWP_Status,Drop_Reason=@Drop_Reason,FinalRemarks=@FinalRemarks, XML_RESPONSE=@XML_RESPONSE,Response_time = @Response_time,modified_by ='services',Flag_sent=@Flag_sent,MODIFIED_DATE = @MODIFIED_DATE where sas_id = @sas_id", new { SAS_ID = sas_id, UniqueKey= UniqueKey, DIN= DIN, BATCH= BATCH, Final_Limit= Final_Limit, Status = Status, Flag_KKBL= Flag_KKBL, Score_G = Score_G, TotalScore= TotalScore, score_cat = score_cat, jml_issuer= jml_issuer, NPWP_Status= NPWP_Status, Drop_Reason= Drop_Reason, FinalRemarks= FinalRemarks, MODIFIED_DATE = MODIFIED_DATE , Flag_sent = Flag_sent, STATUS_XML= STATUS_XML, XML_RESPONSE= XML_RESPONSE, Response_time= Response_time }, commandTimeout: 500000000);
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }
        public bool Delete(int param)
        {
            bool sts = false;

            int rowsAffected = this.DBHelper.Connection.Execute(@"DELETE FROM tr_xml_trans WHERE CREATED_DATE < DATEADD(day, @param, GETDATE())", new { param = param });

            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }




    }
}
