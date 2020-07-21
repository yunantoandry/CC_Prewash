using Common.Utils;
using Common.XML;
using log4net;
using System;
using System.ServiceProcess;
using System.Threading;
using System.Timers;

namespace BP_2_services
{
    public partial class Service1 : ServiceBase
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(Service1));
        private readonly XmlHitCrde _xmlHitCrde;
        private System.Timers.Timer TimerSchedular;
        private int count = 0;
        private int intervalTimerConfig = ServiceConfiguration.IntervalTimerConfig;
        private int serviceTimeSleep = ServiceConfiguration.ServiceTimeSleep;
        private bool isRunJob = false;
        public Service1()
        {
            InitializeComponent();
            _xmlHitCrde = new XmlHitCrde();         
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                count = 1;
                _log.Info("On Start");

                TimerSchedular = new System.Timers.Timer();
                TimerSchedular = new System.Timers.Timer(intervalTimerConfig);
                TimerSchedular.Elapsed += new System.Timers.ElapsedEventHandler(TimerConfig_Elapsed);
                TimerSchedular.AutoReset = true;
                TimerSchedular.Start();
            }
            catch (Exception ex)
            {
                _log.Error($"Error : {ex.StackTrace}");
                this.OnStop();
            }
        }
        private void TimerConfig_Elapsed(object sender, ElapsedEventArgs e)
        {

            string str = "Timer tick " + count;
            count++;
            this.ScheduleService();
        }
        public void ScheduleService()
        {
            if (!isRunJob)
            {
                TimerSchedular.Stop();
                xml_hit_crde_ws();

                Thread.Sleep(serviceTimeSleep);
                TimerSchedular.Start();
                isRunJob = false;
            }
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
        private void xml_hit_crde_ws()
        {
            _log.Info("Starting for hit web service.");
            try
            {
                _xmlHitCrde.Handle();             
               // _log.Info("Succesfully hit crde service at" + DateTime.Now);
            }
            catch (Exception ex)
            {
                _log.Error("An error occured while hit crde the service.");
                _log.Error(ex);
            }
        }
    }
}

