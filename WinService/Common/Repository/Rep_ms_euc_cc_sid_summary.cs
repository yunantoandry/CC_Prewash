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
    public class Rep_ms_euc_cc_sid_summary : Repository, IDisposable
    {
        public Rep_ms_euc_cc_sid_summary()
        {
        }
        public Rep_ms_euc_cc_sid_summary(DBHelper db)
        {
            this.DBHelper = db;
        }

        public List<euc_cc_sid_summary> GetAll()
        {
            List<euc_cc_sid_summary> list = GetAll(string.Empty);
            return list;
        }

        public List<euc_cc_sid_summary> GetAll(string condition)
        {
            List<euc_cc_sid_summary> list = null;
            if (string.IsNullOrEmpty(condition))
                list = DBHelper.Connection.Query<euc_cc_sid_summary>("Select * From euc_cc_sid_summary").ToList();
            else
                list = DBHelper.Connection.Query<euc_cc_sid_summary>("select * from (select distinct b.idifile,a.SAS_ID from(select * from EUC_CC_INPUT    input    unpivot        (        FlagValueKtp        for FlagsKtp in (KTP1, KTP2, KTP3, KTP4, KTP5, KTP6, KTP7, KTP8, KTP9, KTP10)        ) input)a join( select * from EUC_CC_SID_DEBITUR deb)b on a.FlagValueKtp = b.PRM_KTP)c join(select * from euc_cc_sid_summary )d on c.IDIFILE = d.IDIFILE  " + condition).ToList();

            return list;
        }

        public euc_cc_sid_summary Find(int AUTO_ID)
        {
            euc_cc_sid_summary model = null;
            model = DBHelper.Connection.Query<euc_cc_sid_summary>("Select * From euc_cc_sid_summary  WHERE AUTO_ID = @AUTO_ID", new { AUTO_ID }).SingleOrDefault();
            return model;
        }

        public bool Delete(int param)
        {
            bool sts = false;

            int rowsAffected = this.DBHelper.Connection.Execute(@"DELETE FROM euc_cc_sid_summary WHERE CREATED_DATE < DATEADD(day, @param, GETDATE())", new { param = param });
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }
    }
}
