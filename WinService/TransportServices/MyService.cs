using Common.Model;
using Common.Repository;
using Common.Services.FTP;
using Common.Utils;
using Common.XML;
using DansCSharpLibrary.Threading;
using log4net;
using Quartz.Impl;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TransportServices
{
    public class MyService
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ReadAndSaveToDatabase _readAndSaveToDatabase;
        private readonly XmlHitCrde _xmlHitCrde;
        private readonly GenerateXML _generateXML;
        private readonly SendFileToFTP _sendFileToFTP;

        private readonly IFTPS _FTPS;

        private static string mFolderDownload = string.Empty;
        private static string mExtentionFileToRead = string.Empty;
        private static string mFolderLocalDirectoryDump = string.Empty;
        private static string mFolderLocalDirectoryRead = string.Empty;


        

        private static string sas_id = string.Empty;
        private static string xml_request = string.Empty;

        public MyService()
        {
            _readAndSaveToDatabase = new ReadAndSaveToDatabase();
            _xmlHitCrde = new XmlHitCrde();
            _generateXML = new GenerateXML();
            _sendFileToFTP = new SendFileToFTP();
            _FTPS = new FTPS();

        }

        void work1(string mFolderToReadTxt)
        {
            _readAndSaveToDatabase.Handle(mFolderToReadTxt);
          //  _generateXML.Handle();
        }
        void work2()
        {
            _generateXML.Handle();
        }
        void work3()
        {
            _xmlHitCrde.Handle();
        }

        public void Start()
        {
            // string csv_file_path = @"C:\Downloads\input//tblinput.txt";
            //  _FTPS.handle_download();
            // _readAndSaveToDatabase.Handle(csv_file_path);
           // _generateXML.Handle();
            // _xmlHitCrde.Handle();
            //   _sendFileToFTP.Handle();
            // StdSchedulerFactory.GetDefaultScheduler().Result.Start();
            // _readAndSaveToDatabase.bbb();
             RunJob();
           //  RunJob2();
          // RunJob3();


        }

        

        public void Stop()
        {
            // write code here that runs when the Windows Service stops.
        }
       // static Int32 _threadFinished = 0;
        //private void RunJob2()
        //{
        //    int howManyUsers = 2;
        //    for (Int32 x = 0; x < howManyUsers; x++)
        //    {
        //        Thread t = new Thread(new ThreadStart(this.work3));
        //        t.Start();
        //    }
        //    Thread.Sleep(5000);
      
        //}

        private void RunJob3()
        {
            Thread.CurrentThread.Name = "Main";
            Parallel.Invoke(

              () =>
              {
                  //start the file copy operation
                  _generateXML.Handle();
              }

            );

           
        }

        private void performRequest(object obj)
        {
            //work3();
        }

        private void RunJob()
        {
            //_log.Info("Starting program as service.");

            //_log.Info("Trying download file from ftp.");
            //_FTPS.handle_download();

            //_log.Info("Succesfully download at" + DateTime.Now);
            //using (Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter())
            //{

            //    ms_system_parameter o = rep.Find("mFolderDownload");
            //    mFolderDownload = o != null ? o.ParameterValue : string.Empty;
            //    o = rep.Find("mExtentionFileToRead");
            //    mExtentionFileToRead = o != null ? o.ParameterValue : string.Empty;
            //    o = rep.Find("mFolderLocalDirectoryDump");
            //    mFolderLocalDirectoryDump = o != null ? o.ParameterValue : string.Empty;
            //    o = rep.Find("mFolderLocalDirectoryRead");
            //    mFolderLocalDirectoryRead = o != null ? o.ParameterValue : string.Empty;


            //    //
            //    //  CancellationToken cancellationToken = new CancellationToken();

            //    //  var listOfTasks = new List<Task>();

            //    _log.Debug($"Checking if '{mFolderLocalDirectoryRead}' is empty.");

            //    if (!IsDirectoryEmpty(mFolderLocalDirectoryRead))  //find xml
            //    {
            //        string[] filePaths = Directory.GetFiles(mFolderLocalDirectoryRead, mExtentionFileToRead, SearchOption.AllDirectories);

            //        DirectoryInfo info = new DirectoryInfo(mFolderLocalDirectoryRead);
            //        FileInfo[] files = info.GetFiles(mExtentionFileToRead, SearchOption.AllDirectories).OrderBy(p => p.CreationTime).ToArray();

            //        int totalFiles = filePaths.Count();

            //        _log.Debug($"Total files with extension '{mExtentionFileToRead}' is {totalFiles}.");

            //        if (totalFiles > 0)
            //        {
            //            int cnt = 1;
            //            // Thread.CurrentThread.Name = "FileWatcherTask";
            //            foreach (string name in filePaths)
            //            {
            //                //work1(name);
            //                //if (cnt <= maxActionsToRunInParallel)
            //                //{
            //                if (Utils.IsFileIsReady(name))
            //                {
            //                    //listOfTasks.Add(new Task(() => work1(name)));
            //                    ////listOfTasks.Add(new Task(() => work2()));
            //                    //cnt = cnt + 1;
            //                    work1(name);
            //                }

            //                //}
            //                //else
            //                //{
            //                //    break;
            //                //}

            //            }

            //            //if (cnt2 <= maxActionsToRunInParallel)
            //            //{
            //            //    listOfTasks.Add(new Task(() => work2()));
            //            //    cnt2 = cnt2 + 1;
            //            //}


            //            //  listOfTasks.Add(new Task(() => work3()));
            //            // await Task.WhenAll(work1);
            //            // Tasks.StartAndWaitAllThrottled(listOfTasks, maxActionsToRunInParallel, -1, cancellationToken);

            //            _log.Info("Succesfully read,save at" + DateTime.Now);

            //        }

            //        //int cnt2 = 1;


            //        //Tasks.StartAndWaitAllThrottled(listOfTasks, maxActionsToRunInParallel, -1, cancellationToken);
            //    }
                _log.Info("trying generate xml at" + DateTime.Now);
                RunJob3();
                _log.Info("Succesfully generate xml at" + DateTime.Now);

                //_log.Info("Starting for hit web service.");
                //try
                //{
                //    _log.Debug("Method call at" + DateTime.Now);

                //    CancellationToken cancellationToken = new CancellationToken();
                //    var listOfTasks = new List<Task>();
                //    Thread.CurrentThread.Name = "FileWatcherTask";

                //    for (Int32 x = 0; x < maxActionsToRunInParallel; x++)
                //    {

                //        listOfTasks.Add(new Task(() => _xmlHitCrde.Handle()));
                //    }
                //    Thread.Sleep(TimeSpan.FromSeconds(2));
                //    Tasks.StartAndWaitAllThrottled(listOfTasks, maxActionsToRunInParallel, -1, cancellationToken);
                //    _log.Info("Succesfully hit crde service at" + DateTime.Now);

                //}
                //catch (Exception ex)
                //{
                //    _log.Error("An error occured while hit crde the service.");
                //    _log.Error(ex);
                //}
           // }
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
                //throw ex;
                return false;
            }
        }
    }
}
