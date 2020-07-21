using Common.Services.FTP;
using Common.Utils;
using Common.XML;
using DansCSharpLibrary.Threading;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;
using Common.Repository;
using Common.Model;


namespace TransportServices
{

    public class Service : ServiceControl
    {
        // private Timer _Timer = new Timer();
        private System.Timers.Timer TimerSchedular;
        private readonly ILog _log = LogManager.GetLogger(typeof(Service));
        private string mFolderToWatch = string.Empty;
        private string mExtentionFileToWatch = string.Empty;

        private readonly ReadAndSaveToDatabase _readAndSaveToDatabase;
        private readonly XmlHitCrde _xmlHitCrde;
        public Service()
        {
            // _readAndSaveToDatabase = new ReadAndSaveToDatabase();
            _xmlHitCrde = new XmlHitCrde();
        }

        //private readonly DownloadFilesFromFTP _downloadFilesFromFTP;
        //private readonly SendFileToFTP _sendFileToFTP;
        //private readonly ReadAndSaveToDatabase _readAndSaveToDatabase;
        //private readonly XmlHitGetResponse _xmlHitGetResponse;
        public bool Start(HostControl hostControl)
        {

            //XmlConvert.GetFileFromLocalDirectory();
           // _readAndSaveToDatabase.Handle();
          //  _xmlHitCrde.Handle();
           // ReadAndSaveToDatabase.Handle();
           //  
           // Create XML
           //Rep_ms_euc_cc_input Rep_ms_euc_cc_input = new Rep_ms_euc_cc_input();
           //Rep_ms_euc_cc_sid_debitur rep_debitur = new Rep_ms_euc_cc_sid_debitur();
           //List<euc_cc_input> listEucCcInput = Rep_ms_euc_cc_input.GetAll(string.Format(string.Empty));
           //using (DBHelper db = new DBHelper())
           //{
           //    foreach (euc_cc_input oInput in listEucCcInput)
           //    {
           //        XMLCreateCRDE.CreateXML_CRDE(db, oInput);
           //    }
           //}
           //XmlHitCrde.xmlHitGetResponse();
           // SendFileToFTP.Handle();

            // RunJob();
            //Console.WriteLine("The Services was start");
            //Do Something Custom Here
            //_Timer.Interval = 1000;
            //_Timer.Elapsed += _Timer_Elapsed;
            //_Timer.Start();

            //_downloadFilesFromFTP.Handle();
            //_readAndSaveToDatabase.Handle();

            return true;
        }

        private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Thank you for spending this second of your life reading my article");
        }

        public bool Stop(HostControl hostControl)
        {
            Console.WriteLine("The Services was start");
            return true;
        }

        private void RunJob()
        {
            CancellationToken cancellationToken = new CancellationToken();

            var listOfTasks = new List<Task>();

            _log.Debug($"Checking if '{mFolderToWatch}' is empty.");

            if (!IsDirectoryEmpty(mFolderToWatch))  //find xml
            {
                string[] filePaths = Directory.GetFiles(mFolderToWatch, mExtentionFileToWatch, SearchOption.AllDirectories);

                DirectoryInfo info = new DirectoryInfo(mFolderToWatch);
                FileInfo[] files = info.GetFiles(mExtentionFileToWatch, SearchOption.AllDirectories).OrderBy(p => p.CreationTime).ToArray();

                int totalFiles = filePaths.Count();

                _log.Debug($"Total files with extension '{mExtentionFileToWatch}' is {totalFiles}.");

                //if (totalFiles > 0)
                //{
                //    int cnt = 1;
                //    Thread.CurrentThread.Name = "FileWatcherTask";
                //    foreach (string name in filePaths)
                //    {
                //        if (cnt <= maxActionsToRunInParallel)
                //        {
                //            if (Utils.IsFileIsReady(name))
                //            {
                //                listOfTasks.Add(new Task(() => ReadXmlAndSaveInDb(name)));
                //                cnt = cnt + 1;
                //            }
                //        }
                //        else
                //        {
                //            break;
                //        }

                //    }
                //    Tasks.StartAndWaitAllThrottled(listOfTasks, maxActionsToRunInParallel, -1, cancellationToken);
                //}
            }
        }

        public bool IsDirectoryEmpty(string path)
        {
            try
            {
                string pattern = "*.xml";
                string[] dirs = System.IO.Directory.GetDirectories(path);
                string[] files = System.IO.Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
                return dirs.Length == 0 && files.Length == 0;
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
        }

        private void ReadXmlAndSaveInDb(string pathInWatchFolder)
        {


        }
    }
}
