
using Common.Repository;
using System;
using System.Configuration;

namespace Common.Utils
{
    public class ServiceConfiguration
    {
        public static string GetConnectionstring()
        {
            string connectionStringName = "ConnectionString";
            var connectionStringElement = ConfigurationManager.ConnectionStrings[connectionStringName];
            if(connectionStringElement == null)
            {
                throw new InvalidOperationException($"The Web.config is missing a connection string called '{connectionStringName}'.");
            }
            return connectionStringElement.ConnectionString;
        }

        public static int IntervalTimerConfig
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["IntervalTimerConfig"]);
            }
        }
        public static int ServiceTimeSleep
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["ServiceTimeSleep"]);
            }
        }

        public static int IntervalDayConfig
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["IntervalDayConfig"]);
            }
        }

        public static string GetUrlWebservices()
        {
            
            return String.Format(ConfigurationManager.AppSettings["UrlWebService"]);
            //string url = string.Empty;
            //using (DBHelper db = new DBHelper())
            //{
            //    using (Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter(db))
            //    {
            //        url = rep.Find("UrlWebService").ParameterValue;
            //    }
            //}
            //return url;
        }
        public static string GetAppSettingValue(string paramName)
        {
            return String.Format(ConfigurationManager.AppSettings[paramName]);
        }
        public static int MaxActionsToRunInParallel_HitWsCRDE
        {
            get
            {
                int maxActionsToRunInParallel_HitWsCRDE = 0;
                int.TryParse(ConfigurationManager.AppSettings["MaxActionsToRunInParallel_HitWsCRDE"].ToString(), out maxActionsToRunInParallel_HitWsCRDE);
                return maxActionsToRunInParallel_HitWsCRDE;
            }
        }
        public static int MaxActionsToRunInParallel_GenerateXML
        {
            get
            {
                int maxActionsToRunInParallel_GenerateXML = 0;
                int.TryParse(ConfigurationManager.AppSettings["MaxActionsToRunInParallel_GenerateXML"].ToString(), out maxActionsToRunInParallel_GenerateXML);
                return maxActionsToRunInParallel_GenerateXML;
            }
        }
    }
        
        //public static string GetAppSettingValue(string paramName)
        //{
        //    return String.Format(ConfigurationManager.AppSettings[paramName]);
        //}

    
}
