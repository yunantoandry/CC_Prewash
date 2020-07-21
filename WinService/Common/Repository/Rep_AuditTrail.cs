using Common.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public class Rep_AuditTrail : Repository, IDisposable
    {
        public Rep_AuditTrail()
        {

        }

        public Rep_AuditTrail(DBHelper db)
        {
            this.DBHelper = db;
        }

        public List<th_audit_trail> GetAll()
        {
            List<th_audit_trail> list = GetAll(string.Empty);
            return list;
        }

        public List<th_audit_trail> GetAll(string condition)
        {
            List<th_audit_trail> list = null;
            if (string.IsNullOrEmpty(condition))
                list = this.DBHelper.Connection.Query<th_audit_trail>("Select * From th_audit_trail").ToList();
            else
                list = this.DBHelper.Connection.Query<th_audit_trail>("Select * From th_audit_trail  " + condition).ToList();

            return list;
        }

        public int Add(th_audit_trail model)
        {
            int rowsAffected = 0;
            int isError = model.IsError ? 1 : 0;
            try
            {
                string sqlQuery = @"INSERT into th_audit_trail (UserName,Module,ActionDate,Description,IsError,CreatedDate,CreatedBy) Values 
                               (@UserName,@Module,@ActionDate,@Description,@IsError,@CreatedDate,@CreatedBy)";

                rowsAffected = this.DBHelper.Connection.Execute(sqlQuery, new { model.UserName, model.Module, model.ActionDate, model.Description, isError, model.CreatedDate, model.CreatedBy });

            }
            catch (Exception)
            {
                throw;
            }

            return rowsAffected;
        }


        public th_audit_trail Find(int id)
        {
            th_audit_trail model = null;
            model = this.DBHelper.Connection.Query<th_audit_trail>("Select * From th_audit_trail  WHERE Id = @ID", new { ID = id }).SingleOrDefault();
            return model;
        }

        public bool Delete(int id)
        {
            bool sts = false;

            int rowsAffected = this.DBHelper.Connection.Execute(@"DELETE FROM th_audit_trail WHERE ID = @ID", new { ID = id });
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }
    }
}
