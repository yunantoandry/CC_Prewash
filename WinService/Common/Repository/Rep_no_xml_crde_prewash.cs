using Common.Model;
using Dapper;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public class Rep_no_xml_crde_prewash : Repository, IDisposable
    {
        public Rep_no_xml_crde_prewash()
        {

        }
        public Rep_no_xml_crde_prewash(DBHelper db)
        {
            this.DBHelper = db;
        }
        //public string GetSeqDpGeneral(DBHelper db, string type)
        //{
        //    string idNUmber = string.Empty;
        //    List<IdNumber> listIdNumber = db.Connection.Query<IdNumber>("spa_seq_dp_general", new { PARAM = type }, commandType: CommandType.StoredProcedure).ToList();
        //    if (listIdNumber.Count > 0) idNUmber = listIdNumber[0].ID_NUMBER;
        //    return idNUmber;
        //}

        public IdNumber id()
        {
            IdNumber no = null;
            no = DBHelper.Connection.Query<IdNumber>("Sequence_General_crde", commandType: CommandType.StoredProcedure).SingleOrDefault();
            return no;
        }
    }
}
