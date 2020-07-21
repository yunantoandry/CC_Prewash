using Common.Model;
using Common.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public class Rep_log_error:Repository,IDisposable
    {
        public Rep_log_error() { }
        public Rep_log_error(DBHelper db)
        {
            this.DBHelper = db;
        }
        public List<log_error> GetAll()
        {
            List<log_error> list = GetAll(string.Empty);
            return list;
        }

        public List<log_error> GetAll(string condition)
        {
            List<log_error> list = null;
            if (string.IsNullOrEmpty(condition))
                list = DBHelper.Connection.Query<log_error>("Select * From log_error").ToList();
            else
                list = DBHelper.Connection.Query<log_error>("Select * From log_error  " + condition).ToList();

            return list;
        }

        public log_error Find(string SAS_ID)
        {
            log_error model = null;
            model = DBHelper.Connection.Query<log_error>("Select * From log_error WHERE SAS_ID = @SAS_ID", new { SAS_ID }).SingleOrDefault();
            return model;
        }
        public bool Delete(int param)
        {
            bool sts = false;

            int rowsAffected = this.DBHelper.Connection.Execute(@"DELETE FROM log_error WHERE CREATED_DATE < DATEADD(day, @param, GETDATE())", new { param = param });
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }
    }
}
