using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Common.Repository
{
    public class Rep_Reporting_risk : Repository, IDisposable
    {
        public Rep_Reporting_risk() { }
        public Rep_Reporting_risk(DBHelper db)
        {
            this.DBHelper = db;
        }
        public List<Reporting_risk> GetAll()
        {
            List<Reporting_risk> list = GetAll(string.Empty);
            return list;
        }

        public List<Reporting_risk> GetAll(string condition)
        {
            List<Reporting_risk> list = null;
            if (string.IsNullOrEmpty(condition))
                list = DBHelper.Connection.Query<Reporting_risk>("Select * From Reporting_risk").ToList();
            else
                list = DBHelper.Connection.Query<Reporting_risk>("Select * From Reporting_risk  " + condition).ToList();

            return list;
        }

        public Reporting_risk Find(string SAS_ID)
        {
            Reporting_risk model = null;
            model = DBHelper.Connection.Query<Reporting_risk>("Select * From Reporting_risk WHERE SAS_ID = @SAS_ID", new { SAS_ID }).SingleOrDefault();
            return model;
        }


        public List<Reporting_risk> report_month_risk()
        {
            var v_CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(v_CS))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand com = new SqlCommand("sp_reporting_risk", con)
                {
                    CommandType = CommandType.StoredProcedure
                };


                SqlDataReader dr = com.ExecuteReader();
                List<Reporting_risk> list = new List<Reporting_risk>();
                while (dr.Read())
                {
                    Reporting_risk bl = new Reporting_risk();

                    bl.Tanggal_batch = dr["tanggal_batch"].ToString();
                    bl.Batch_Output = dr["batch_output"].ToString();
                    bl.time_ = Convert.ToInt32(dr["time_"].ToString());
                    bl.Data_Count= Convert.ToInt32(dr["data_counts"].ToString());
                    bl.bnf = Convert.ToInt32(dr["bnf"].ToString());
                    bl.bf = Convert.ToInt32(dr["bf"].ToString());
                    bl.bf_persen = Convert.ToDecimal(dr["bf_persen"].ToString());
                    bl.Offer = Convert.ToInt32(dr["Offer"].ToString());
                    bl.drop_ = Convert.ToInt32(dr["drop_"].ToString());
                    bl.Offer_rate = Convert.ToDecimal(dr["Offer_rate"].ToString());                  
                   // bl.NON_NTC_CUSTOMER = Convert.ToInt32(dr["NON_NTC_CUSTOMER"].ToString());
                    bl.rac_max_2_cc_issuers = Convert.ToInt32(dr["rac_max_2_cc_issuers"].ToString());
                    bl.rac_age = Convert.ToInt32(dr["rac_age"].ToString());
                    bl.rac_minimum_income = Convert.ToInt32(dr["rac_minimum_income"].ToString());
                    bl.bad_bureau = Convert.ToInt32(dr["bad_bureau"].ToString());
                    bl.highest_cc_limit_kurang_dari_3mio = Convert.ToInt32(dr["highest_cc_limit_kurang_dari_3mio"].ToString());
                    bl.rac_very_high_risk_segment = Convert.ToInt32(dr["rac_very_high_risk_segment"].ToString());
                    bl.mue_3x = Convert.ToInt32(dr["mue_3x"].ToString());
                    bl.mue_7x = Convert.ToInt32(dr["mue_7x"].ToString());
                    bl.final_limit_kurang_dari_3mio = Convert.ToInt32(dr["final_limit_kurang_dari_3mio"].ToString());


                    list.Add(bl);
                }
                return list;
            }
        }
    }
}
