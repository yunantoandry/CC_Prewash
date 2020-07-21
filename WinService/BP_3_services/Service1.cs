using Common.Services.FTP;
using Common.Utils;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BP_3_services
{
    public partial class Service1 : ServiceBase
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(Service1));
        private readonly SendFileToFTP _sendFileToFTP;
        
        public Service1()
        {
            InitializeComponent();
            _sendFileToFTP = new SendFileToFTP();
        }

        protected override void OnStart(string[] args)
        {
            Send_File_To_FTP();           
        }
       
        protected override void OnStop()
        {
            _log.Info("Stopping service.");
        }

        public void StartWithNoArguments()
        {
            _log.Debug($"Running {nameof(OnStart)} without arguments.");

            OnStart(null);
        }
        private void Send_File_To_FTP()
        {
            _log.Info("Starting Send File To FTP");

            _sendFileToFTP.Handle();
        }
    }
}
