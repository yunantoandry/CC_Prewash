using Common.Model;
using Common.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class LogUtil
    {
        public static void AddLogError(DBHelper db, string filePath, string fileCategory, string fileName, string batch, string keyID, string description1, string description2)
        {
            Rep_log_error rep = new Rep_log_error(db);
            log_error o = new log_error();
            o.FILE_PATH = filePath;
            o.FILE_CATEGORY = fileCategory;
            o.FILE_NAME = fileName;
            o.BATCH = batch;
            o.KEY_ID = keyID;
            o.DESCRIPTION_MESSAGE = description1;
            o.DESCRIPTION_TRACE = description2;
            o.CREATED_BY = "Services";
            o.MODIFIED_BY = "Services";
            o.CREATED_DATE = DateTime.Now;
            o.MODIFIED_DATE = DateTime.Now;
            int i = rep.DBHelper.Insert<log_error>(o);
        }

        public static void AddAuditTrail(DBHelper db, string UserName, string Module, string Description, bool IsError)
        {
            Rep_AuditTrail rep = new Rep_AuditTrail(db);
            th_audit_trail o = new th_audit_trail();
            o.UserName = UserName;
            o.Module = Module;
            o.Description = Description;
            o.IsError = IsError;
            o.CreatedDate = DateTime.Now;
            o.ActionDate = DateTime.Now;
            int i = rep.DBHelper.Insert<th_audit_trail>(o);
            rep = null;

        }

        public static void AddLogDownloadAndUpload(DBHelper db, string FileName, string Method, string Status, int count_data)
        {
            Rep_tr_log_xml rep = new Rep_tr_log_xml(db);
            tr_log_xml o = new tr_log_xml();
            o.FILENAME = FileName;
            o.METHOD = Method;
            o.CREATED_BY = "Services";
            o.CREATED_DATE = DateTime.Now;
            o.STATUS = Status;
            o.COUNT_DATA = count_data;
            int i = rep.DBHelper.Insert<tr_log_xml>(o);
            rep = null;
        }

        public static void AddLogXMLError(DBHelper db, string sas_id, string field, string value, string description, string batch)
        {
            Rep_tr_log_xml rep = new Rep_tr_log_xml(db);
            tr_log_xml_error o = new tr_log_xml_error();
            o.SAS_ID = sas_id;
            o.Field = field;
            o.Value = value;
            o.Description = description;
            o.Batch = batch;
            o.CREATED_BY = "Services";
            o.CREATED_DATE = DateTime.Now;
            int i = rep.DBHelper.Insert<tr_log_xml_error>(o);
            rep = null;
        }

        public static void AddLogXMLSuccess(DBHelper db, string sas_id, string batch, string description)
        {
            Rep_tr_log_xml rep = new Rep_tr_log_xml(db);
            tr_log_xml_success o = new tr_log_xml_success();
            o.SAS_ID = sas_id;
            o.Batch = batch;
            o.Description = description;
            o.CREATED_BY = "Services";
            o.CREATED_DATE = DateTime.Now;
            int i = rep.DBHelper.Insert<tr_log_xml_success>(o);
            rep = null;
        }
    }
}
