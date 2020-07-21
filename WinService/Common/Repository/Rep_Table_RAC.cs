using Common.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public class Rep_Table_RAC : Repository, IDisposable
    {
        public Rep_Table_RAC() { }
        public Rep_Table_RAC(DBHelper db)
        {
            this.DBHelper = db;
        }
        public List<Table_RAC> GetAll()
        {
            List<Table_RAC> list = GetAll(string.Empty);
            return list;
        }

        public List<Table_RAC> GetAll(string condition)
        {
            List<Table_RAC> list = null;
            if (string.IsNullOrEmpty(condition))
                list = DBHelper.Connection.Query<Table_RAC>("Select a.sas_id,a.Sequence_Number,a.Criteria_Name,a.Reason_Code,a.Reason_Description,a.Mandatory From Table_RAC a join tr_xml_trans b on a.sas_id = b.SAS_ID").ToList();
            else
                list = DBHelper.Connection.Query<Table_RAC>("Select a.sas_id,a.Sequence_Number,a.Criteria_Name,a.Reason_Code,a.Reason_Description,a.Mandatory From Table_RAC a join tr_xml_trans b on a.sas_id = b.SAS_ID  " + condition).ToList();

            return list;
        }

        public Table_RAC Find(string SAS_ID)
        {
            Table_RAC model = null;
            model = DBHelper.Connection.Query<Table_RAC>("Select * From Table_RAC WHERE SAS_ID = @SAS_ID", new { SAS_ID }).SingleOrDefault();
            return model;

        }

        public bool Delete(int param)
        {
            bool sts = false;

            int rowsAffected = this.DBHelper.Connection.Execute(@"DELETE FROM Table_RAC WHERE CREATED_DATE < DATEADD(day, @param, GETDATE())", new { param = param });
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }
    }
}
