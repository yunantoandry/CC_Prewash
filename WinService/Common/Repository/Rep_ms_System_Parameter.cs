using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using Common.Utils;
using Common.Model;
using System.Data;


namespace Common.Repository
{
    public class Rep_ms_System_Parameter : Repository, IDisposable
    {
        public Rep_ms_System_Parameter()
        {

        }
        public Rep_ms_System_Parameter(DBHelper db)
        {
            this.DBHelper = db;
        }

        public List<ms_system_parameter> GetAll()
        {
            List<ms_system_parameter> list = GetAll(string.Empty);
            return list;
        }

        //public List<ms_system_parameter> GetAll(string condition)
        //{
        //    List<ms_system_parameter> list = null;
        //    list = DBHelper.Connection.Query<ms_system_parameter>("spa_ms_system_parameter_load", new { sqlquery = condition }, commandType: System.Data.CommandType.StoredProcedure).ToList();
        //    return list;
        //}

        public List<ms_system_parameter> GetAll(string condition)
        {
            List<ms_system_parameter> list = null;
            if (string.IsNullOrEmpty(condition))
                list = DBHelper.Connection.Query<ms_system_parameter>("Select * From ms_system_parameter ").ToList();
            else
                list = DBHelper.Connection.Query<ms_system_parameter>("select * from ms_system_parameter " + condition).ToList();

            return list;
        }



        public ms_system_parameter Find(string ParameterCode)
        {
            ms_system_parameter model = null;
            model = DBHelper.Connection.Query<ms_system_parameter>("Select * From ms_system_parameter  WHERE ParameterCode = @ParameterCode", new { ParameterCode }).SingleOrDefault();
            return model;
        }

        //NOTE: This is used in an ashx file.
        public ms_system_parameter FindP(string ParameterCode)
        {
            ms_system_parameter model = null;
            model = DBHelper.Connection.Query<ms_system_parameter>("Select ParameterValue From ms_system_parameter  WHERE ParameterCode = @ParameterCode", new { ParameterCode }).SingleOrDefault();
            return model;
        }

        public string FindParameterValue(string parameterCode)
        {
            var parameterValues = DBHelper.Connection.Query<string>(@"
SELECT ParameterValue 
FROM ms_system_parameter 
WHERE ParameterCode = @parameterCode", new { parameterCode });

            if (!parameterValues.Any())
            {
                throw new InvalidOperationException($"Could not find ParameterValue for ParameterCode '{parameterCode}'.");
            }
            else if (parameterValues.Count() > 1)
            {
                throw new InvalidOperationException($"Found more than 1 ParameterValue for ParameterCode '{parameterCode}'.");
            }
            else
            {
                return parameterValues.Single();
            }
        }

        public ms_system_parameter GetById(int Id)
        {
            ms_system_parameter model = null;
            model = DBHelper.Connection.Query<ms_system_parameter>("Select * From ms_system_parameter  WHERE Id = @Id", new { Id }).SingleOrDefault();
            return model;
        }


        public int Add(ms_system_parameter model)
        {
            int rowsAffected = 0;
            try
            {
                string sqlQuery = @"INSERT into ms_system_parameter (ParameterCode,Category,SubCategory,ParameterValue,Remarks,CreatedDate,CreatedBy) Values 
                    (@ParameterCode,@Category,@SubCategory,@ParameterValue,@Remarks,@CreatedDate,@CreatedBy)";
                rowsAffected = DBHelper.Connection.Execute(sqlQuery, model);

            }
            catch (Exception)
            {
                throw;
            }

            return rowsAffected;
        }

        public int Update(ms_system_parameter model)
        {
            int rowsAffected = 0;
            try
            {
                ms_system_parameter prevModel = Find(model.ParameterCode);
                model.CreatedDate = prevModel.CreatedDate;
                model.CreatedBy = prevModel.CreatedBy;
                model.ModifiedDate = DateTime.Now;

                string sqlQuery = @"UPDATE ms_system_parameter SET ParameterCode = @ParameterCode, 
                     Category = @Category, SubCategory = @SubCategory, ParameterValue=@ParameterValue, Remarks=@Remarks,
                     CreatedDate=@CreatedDate,CreatedBy=@CreatedBy, ModifiedDate=@ModifiedDate, ModifiedBy=@ModifiedBy
                     WHERE Id = @Id";

                rowsAffected = DBHelper.Connection.Execute(sqlQuery, model);

            }
            catch (Exception)
            {
                throw;
            }

            return rowsAffected;
        }

        public bool Delete(int id)
        {
            bool sts = false;

            int rowsAffected = DBHelper.Connection.Execute(@"DELETE FROM ms_system_parameter WHERE ID = @ID", new { ID = id });
            if (rowsAffected > 0)
            {
                sts = true;
            }

            return sts;
        }

    }
}
