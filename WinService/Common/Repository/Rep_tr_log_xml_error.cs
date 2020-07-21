using Common.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{

    public class Rep_tr_log_xml_error : Repository, IDisposable
    {
        public Rep_tr_log_xml_error()
        {
        }
        public Rep_tr_log_xml_error(DBHelper db)
        {
            this.DBHelper = db;
        }

        public bool Insert(tr_log_xml_error o)
        {
            bool sts = false;
            int i = DBHelper.Insert<tr_log_xml_error>(o);
            sts = i > 0 ? true : false;
            return sts;
        }

        public List<tr_log_xml_error> ListXmlError()
        {
            List<tr_log_xml_error> list = null;
            list = DBHelper.Connection.Query<tr_log_xml_error>("sp_send_log_xml_error", commandType: CommandType.StoredProcedure).ToList();

            return list;
        }

        public bool Delete(int param)
        {
            bool sts = false;

            int rowsAffected = this.DBHelper.Connection.Execute(@"DELETE FROM tr_log_xml_error WHERE CREATED_DATE < DATEADD(day, @param, GETDATE())", new { param = param });
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }
    }

}
