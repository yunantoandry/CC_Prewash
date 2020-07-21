using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HouseKeeping_CC_Prewash
{
    static class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (AppSettings.RunAsConsoleApp)
            {
                try
                {
                    _log.Info("Starting program as console app.");
                    _log.Info($"Reading config from {AppDomain.CurrentDomain.SetupInformation.ConfigurationFile}.");

                    var svc = new HouseKeeping_CC_Prewash_Services();

                    svc.StartWithNoArguments();

                    _log.Info("Service Ended succesfully.");
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }

                Console.ReadLine();
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
                // Thread.Sleep(Timeout.Infinite);
            }
            else
            {
                _log.Info("Starting program as service.");
                _log.Info($"Reading config from {AppDomain.CurrentDomain.SetupInformation.ConfigurationFile}.");
                _log.Info($"Adding {nameof(HouseKeeping_CC_Prewash_Services)} to be run by {nameof(ServiceBase)}.");

                ServiceBase.Run(new ServiceBase[]
                {
                    new HouseKeeping_CC_Prewash_Services()
                });
            }
        }
    }
}
