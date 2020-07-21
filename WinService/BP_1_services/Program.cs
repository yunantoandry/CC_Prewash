using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BP_1_services
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

                    var svc = new Service1();

                    svc.StartWithNoArguments();

                    _log.Info("Service Start succesfully.");
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
                _log.Info($"Adding {nameof(Service1)} to be run by {nameof(ServiceBase)}.");

                ServiceBase.Run(new ServiceBase[]
                {
                    new Service1()
                });
            }
        }
    }
}
