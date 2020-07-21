using log4net;
using Common.Services.Reporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Common.Services.FTP;
using Common.Services.Email;

namespace Reporting_Risk
{
    public partial class Service1 : ServiceBase
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(Service1));
        private readonly Create_Reporting_Risk _reporting_Risk;
      //  private readonly SendEmailsReportingRiskCommander _sendEmailsReportingRiskCommander;
        private readonly SendEmail _sendEmail;
        

        public Service1()
        {
            InitializeComponent();
            _reporting_Risk = new Create_Reporting_Risk();
            _sendEmail = new SendEmail();
        }

        protected override void OnStart(string[] args)
        {
            Create_reporting_risk();
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
        private void Create_reporting_risk()
        {
            _log.Info("Starting Create reporting risk");

            // _reporting_Risk.handle();

            //   _sendEmailsReportingRiskCommander.Handle();
            //  email_send
            _sendEmail.email_send2();


        }
    }
}
