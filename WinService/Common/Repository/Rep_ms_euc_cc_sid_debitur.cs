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
    public class Rep_ms_euc_cc_sid_debitur : Repository, IDisposable
    {
        public Rep_ms_euc_cc_sid_debitur()
        {
        }
        public Rep_ms_euc_cc_sid_debitur(DBHelper db)
        {
            this.DBHelper = db;
        }

        public List<euc_cc_sid_debitur> GetAll()
        {
            List<euc_cc_sid_debitur> list = GetAll(string.Empty);
            return list;
        }

        public List<euc_cc_sid_debitur> GetAll(string condition)
        {
            List<euc_cc_sid_debitur> list = null;
            if (string.IsNullOrEmpty(condition))
                list = DBHelper.Connection.Query<euc_cc_sid_debitur>("Select * From euc_cc_sid_debitur").ToList();
            else
                list = DBHelper.Connection.Query<euc_cc_sid_debitur>("select  deb.IDIFILE,deb.TGL_LAPORAN,deb.PROGRAM,deb.DIN,deb.LAP_NO,deb.LAP_POSISIAKHIR,deb.LAP_USER,deb.PRM_TGL,deb.PRM_NO,deb.PRM_NAMA_DEBITUR,deb.PRM_TEMPAT_LAHIR,deb.PRM_TGL_LAHIR,deb.PRM_NPWP,deb.PRM_KTP,deb.PRM_PASSPORT from EUC_CC_INPUT unpivot (FlagValueKtp for FlagsKtp in (KTP1, KTP2, KTP3, KTP4, KTP5, KTP6, KTP7, KTP8, KTP9, KTP10)) input Join(select * from EUC_CC_SID_DEBITUR)deb on input.FlagValueKtp = deb.PRM_KTP " + condition).ToList();

            return list;
        }

        public euc_cc_sid_debitur Find(string prm_ktp)
        {
            euc_cc_sid_debitur model = null;
            model = DBHelper.Connection.Query<euc_cc_sid_debitur>("Select * From euc_cc_sid_debitur  WHERE prm_ktp = @prm_ktp", new { prm_ktp }).SingleOrDefault();
            return model;
        }
        public bool Delete(int param)
        {
            bool sts = false;

            int rowsAffected = this.DBHelper.Connection.Execute(@"DELETE FROM euc_cc_sid_debitur WHERE CREATED_DATE < DATEADD(day, @param, GETDATE())", new { param = param });
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }
    }
}
