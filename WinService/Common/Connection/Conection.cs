using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Connection
{
    public class Conection
    {
        public static string koneksi()
        {
            string CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            return CS;
        }
    }
}
