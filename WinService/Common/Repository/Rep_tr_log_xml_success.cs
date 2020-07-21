using Common.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public class Rep_tr_log_xml_success : Repository, IDisposable
    {
        public Rep_tr_log_xml_success()
        {
        }
        public Rep_tr_log_xml_success(DBHelper db)
        {
            this.DBHelper = db;
        }

        public bool Insert(tr_log_xml_success o)
        {
            bool sts = false;
            int i = DBHelper.Insert<tr_log_xml_success>(o);
            sts = i > 0 ? true : false;
            return sts;
        }

        public bool Delete(int param)
        {
            bool sts = false;

            int rowsAffected = this.DBHelper.Connection.Execute(@"DELETE FROM tr_log_xml_success WHERE CREATED_DATE < DATEADD(day, @param, GETDATE())", new { param = param });
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }
    }
}
