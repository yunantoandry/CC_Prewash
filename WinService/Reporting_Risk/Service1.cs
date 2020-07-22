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
using Common.Utils;
using System.Configuration;
using Common.Repository;
using Common.Model;

namespace Reporting_Risk
{
    public partial class Service1 : ServiceBase
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(Service1));
        private readonly Create_Reporting_Risk _reporting_Risk;
        private readonly SmtpUtil _smtpUtil;

        
        //  private readonly SendEmailsReportingRiskCommander _sendEmailsReportingRiskCommander;
        private string mFolderLocalDirectoryOutput = string.Empty;
     //   private readonly SendEmail _sendEmail;
        

        public Service1()
        {
            InitializeComponent();
            _reporting_Risk = new Create_Reporting_Risk();
            // _sendEmail = new SendEmail();
            _smtpUtil = new SmtpUtil();


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

            // var toAddressesAppSettingsName = "SendEmailsToAddresses";

            using (DBHelper db = new DBHelper())
            {
                Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter(db);
                ms_system_parameter o = new ms_system_parameter();
                o = rep.Find("mFolderLocalDirectoryOutput");
                mFolderLocalDirectoryOutput = o != null ? o.ParameterValue : string.Empty;
            }
                string toAddressesCsv = "andry.yunanto0623@gmail.com";
            string subject = "test email";
            string Message = "body email";

            //  bool sts = false;
         //   SendEmail v = new SendEmail();

            _smtpUtil.SendEmail_With_Attachment(toAddressesCsv, subject, mFolderLocalDirectoryOutput);


        }
    }
}
