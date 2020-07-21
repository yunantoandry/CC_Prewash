using Common.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public class Repository : IDisposable
    {
        private DBHelper _dBHelper = null;
        private bool _isNewInstance = false;
        
        public DBHelper DBHelper
        {
            get
            {

                if (_dBHelper == null)
                {
                    DBHelper db = new DBHelper();
                    _dBHelper = db;
                    _isNewInstance = true;
                }
                else
                {
                    _isNewInstance = false;
                }
                return _dBHelper;
            }
            set { _dBHelper = value; }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Finalization is now unnecessary
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_isNewInstance)
                {
                    if (_dBHelper != null && _dBHelper.Connection != null)
                    {
                        if (_dBHelper.Connection.State == ConnectionState.Open)
                            _dBHelper.Connection.Close();
                    }
                    _dBHelper.Dispose();
                    _dBHelper = null;
                }
            }
        }

        //~Repository()
        //{
        //    Dispose(true);
        //}

    }
}
