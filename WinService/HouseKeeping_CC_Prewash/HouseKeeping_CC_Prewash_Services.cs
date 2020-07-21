using Common.Services.HouseKeeping;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace HouseKeeping_CC_Prewash
{
    public partial class HouseKeeping_CC_Prewash_Services : ServiceBase
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(HouseKeeping_CC_Prewash_Services));
        
        private readonly HK_CcPrewash _hk_CcPrewash;
        public HouseKeeping_CC_Prewash_Services()
        {
            InitializeComponent();
            _hk_CcPrewash = new HK_CcPrewash();
        }

        protected override void OnStart(string[] args)
        {
            HouseKeeping_CC_Prewash();
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
        private void HouseKeeping_CC_Prewash()
        {
            _log.Info("Starting House Keeping CC Prewash");

            _hk_CcPrewash.handle();

        }
    }
}
