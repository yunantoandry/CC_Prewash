using Common.Model;
using Common.Repository;
using Common.Services.FTP;
using Common.Utils;
using Common.XML;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BP_1_services
{
    public partial class Service1 : ServiceBase
    {
        private readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);     
        private readonly IFTPS _FTPS;
        private readonly ReadAndSaveToDatabase _readAndSaveToDatabase;
        private System.Timers.Timer TimerSchedular;
        private int count = 0;
        private int intervalTimerConfig = ServiceConfiguration.IntervalTimerConfig;
        private int serviceTimeSleep = ServiceConfiguration.ServiceTimeSleep;
        private bool isRunJob = false;
        private static string mExtentionFileToRead = string.Empty;
        private static string mFolderLocalDirectoryInput = string.Empty;       
        private static string mFolderLocalDirectoryDump = string.Empty;
        private static string mFolderLocalDirectoryOutput = string.Empty;
        private static string mFolderLocalDirectoryDumpInput = string.Empty;
        private static string mFolderLocalDirectoryDumpOutput = string.Empty;
        private static string mFolderDownload = string.Empty;
        private readonly GenerateXML _generateXML;

        public Service1()
        {
            InitializeComponent();
            _FTPS = new FTPS();
            _readAndSaveToDatabase = new ReadAndSaveToDatabase();
            _generateXML = new GenerateXML();
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
        protected override void OnStop()
        {
            _log.Info("Stopping service.");
            this.TimerSchedular.Stop();
            this.TimerSchedular = null;
        }
        public void StartWithNoArguments()
        {
            _log.Debug($"Running {nameof(OnStart)} without arguments.");
            OnStart(null);
        }
        public void ScheduleService()
        {
            if (!isRunJob)
            {
                TimerSchedular.Stop();

                Initilize();
                read_file_and_save_in_db();

                Thread.Sleep(serviceTimeSleep);
                TimerSchedular.Start();
                isRunJob = false;
            }
        }
        private void Initilize()
        {
            try
            {
                using (Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter())
                {
                    ms_system_parameter o = rep.Find("mExtentionFileToRead");
                    mExtentionFileToRead = o != null ? o.ParameterValue : string.Empty;                  
                    o = rep.Find("mFolderLocalDirectoryOutput");
                    mFolderLocalDirectoryOutput = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("mFolderLocalDirectoryDump");
                    mFolderLocalDirectoryDump = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("mFolderLocalDirectoryDumpInput");
                    mFolderLocalDirectoryDumpInput = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("mFolderLocalDirectoryDumpOutput");
                    mFolderLocalDirectoryDumpOutput = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("mFolderLocalDirectoryInput");
                    mFolderLocalDirectoryInput = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("mFolderDownload");
                    mFolderDownload = o != null ? o.ParameterValue : string.Empty;

                    try
                    {
                        if (!Directory.Exists(mFolderDownload)) Directory.CreateDirectory(mFolderDownload);
                        if (!Directory.Exists(mFolderLocalDirectoryInput)) Directory.CreateDirectory(mFolderLocalDirectoryInput);
                        if (!Directory.Exists(mFolderLocalDirectoryOutput)) Directory.CreateDirectory(mFolderLocalDirectoryOutput);
                        if (!Directory.Exists(mFolderLocalDirectoryDump)) Directory.CreateDirectory(mFolderLocalDirectoryDump);
                        if (!Directory.Exists(mFolderLocalDirectoryDumpInput)) Directory.CreateDirectory(mFolderLocalDirectoryDumpInput);
                        if (!Directory.Exists(mFolderLocalDirectoryDumpOutput)) Directory.CreateDirectory(mFolderLocalDirectoryDumpOutput);           
                    }
                    catch { }

                    _log.Info($"mFolderLocalDirectoryInput = '{mFolderLocalDirectoryInput}' , mFolderLocalDirectoryOutput = '{mFolderLocalDirectoryOutput}', mFolderLocalDirectoryDump = '{mFolderLocalDirectoryDump}', mFolderLocalDirectoryDumpInput = '{mFolderLocalDirectoryDumpInput}', mFolderLocalDirectoryDumpOutput = '{mFolderLocalDirectoryDumpOutput}' mFolderDownload = '{mFolderDownload} ");
                }
            }
            catch (Exception ex)
            {
                _log.Error($"Error : {ex.StackTrace}");
                this.OnStop();
            }
        }
        private void read_file_and_save_in_db()
        {
            //string csv_file_path = @"C:\Downloads\input//testfile.txt";
            //_readAndSaveToDatabase.Handle(csv_file_path);
            _log.Info("Starting program as service.");

           _FTPS.handle_download();      

            _log.Debug($"Checking if '{mFolderLocalDirectoryInput}' is empty.");

            if (!IsDirectoryEmpty(mFolderLocalDirectoryInput))  //find text file
            {

                string[] filePaths = Directory.GetFiles(mFolderLocalDirectoryInput, mExtentionFileToRead, SearchOption.AllDirectories);

                DirectoryInfo info = new DirectoryInfo(mFolderLocalDirectoryInput);
                FileInfo[] files = info.GetFiles(mExtentionFileToRead, SearchOption.AllDirectories).OrderBy(p => p.Name).ToArray();

                int totalFiles = filePaths.Count();

                _log.Debug($"Total files with extension '{mExtentionFileToRead}' is {totalFiles}.");
            
                if (totalFiles > 0)
                {
                   
                    foreach (string name in filePaths)
                    {
                        if (Utils.IsFileIsReady(name))
                        {
                            _log.Info($"Trying read Filename :{name}, extension '{mExtentionFileToRead} and saving it in DB."); _readAndSaveToDatabase.Handle(name);
                        }
                    }
                }
                _log.Info("Succesfully read,save at" + DateTime.Now);
            }

            _log.Info("trying generate xml at" + DateTime.Now);
            _generateXML.Handle();
            _log.Info("Succesfully generate xml at" + DateTime.Now);
        }
        public bool IsDirectoryEmpty(string path)
        {
            try
            {
                string pattern = "*.txt";
                string[] dirs = System.IO.Directory.GetDirectories(path);
                string[] files = System.IO.Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
                return dirs.Length == 0 && files.Length == 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
