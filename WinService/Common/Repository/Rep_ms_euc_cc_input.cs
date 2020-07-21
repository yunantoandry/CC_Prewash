using Common.Model;
using Dapper;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.Repository
{
    public class Rep_ms_euc_cc_input : Repository, IDisposable
    {
        public Rep_ms_euc_cc_input()
        {
        }
        public Rep_ms_euc_cc_input(DBHelper db)
        {
            this.DBHelper = db;
        }

        public List<euc_cc_input> GetAll()
        {
            List<euc_cc_input> list = GetAll(string.Empty);
            return list;
        }

        public List<euc_cc_input> GetAll(string condition)
        {
            List<euc_cc_input> list = null;
            if (string.IsNullOrEmpty(condition))
                list = DBHelper.Connection.Query<euc_cc_input>("Select * From euc_cc_input").ToList();
            else
                list = DBHelper.Connection.Query<euc_cc_input>("Select * From euc_cc_input  " + condition).ToList();

            return list;
        }

        public euc_cc_input Find(string SAS_ID)
        {
            euc_cc_input model = null;
            model = DBHelper.Connection.Query<euc_cc_input>("Select * From euc_cc_input  WHERE SAS_ID = @SAS_ID", new { SAS_ID }).SingleOrDefault();
            return model;
        }

        public bool NotSendXMLtoHitCRDE(string SAS_ID)
        {
            bool sts = false;

            var rowsAffected = DBHelper.Connection.ExecuteScalar<int>(@"select count(distinct input.FlagValueKtp) from EUC_CC_INPUT unpivot ( FlagValueKtp for FlagsKtp in (KTP1, KTP2, KTP3, KTP4, KTP5, KTP6, KTP7, KTP8, KTP9, KTP10)) input join( select substring(KEY_ID,9,16) as a from log_error err) err on FlagValueKtp = err.a where input.FlagValueKtp <>'' and input.FlagValueKtp is not null and input.SAS_ID = @SAS_ID ", new { SAS_ID });
            if (rowsAffected == 0 )
            {
                sts = true;
            }
            return sts;
        }

        public bool UpdateFlag_1_input(string SAS_ID)
        {
            bool sts = false;
            DateTime MODIFIED_DATE = DateTime.Now;
            int rowsAffected = DBHelper.Connection.Execute(@"update euc_cc_input set FLAG = '1',modified_date=@MODIFIED_DATE,MODIFIED_BY= 'services' where SAS_ID = @SAS_ID", new { SAS_ID = SAS_ID, MODIFIED_DATE = MODIFIED_DATE });
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }
        public bool Delete(int param)
        {
            bool sts = false;
            int rowsAffected = this.DBHelper.Connection.Execute(@"DELETE FROM euc_cc_input WHERE CREATED_DATE < DATEADD(day, @param, GETDATE())", new { param = param });
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }
    }
}
