

using Common.Model;
using Common.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WinSCP;


namespace Common.Utils
{
    public class FtpUtils : IDisposable
    {
        public string FtpHost { get; set; }
        public int FtpPort { get; set; }
        public string FtpUsername { get; set; }
        public string FtpUserPassword { get; set; }
        public string FtpFilePath { get; set; }
        public string FtpSshHostKeyFingerprint { get; set; }
        public string FTPMethod { get; set; }
        public string TlsHostCertificateFingerprint { get; set; }
        
        public string FtpPrivateKeyPassphrase { get; set; }

        public string FolderToWatch { get; set; }
        public string FolderDumpToSP { get; set; }
        public string FolderPrewashToLocal { get; set; }
        public string FolderRMSToSP { get; set; }
        public string FolderWMOSToSP { get; set; }
        public string FolderSPToBMS { get; set; }

        public string FolderSPToWMOS_1 { get; set; }
        public string FolderSPToWMOS_2 { get; set; }
        public string FolderSPToRMS { get; set; }

        private bool isConnect { get; set; }

        private DBHelper db = null;
        private bool IsUseExistingConnection = false;

        SessionOptions sessionOptions = null;

        public FtpUtils(DBHelper db)
        {
            this.db = db;
            IsUseExistingConnection = true;

            Init();
        }

        public FtpUtils()
        {
            IsUseExistingConnection = false;
            Init();
        }

        private void Init()
        {
            try
            {
                if (db == null)
                {
                    db = new DBHelper();
                }

              //  Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter(db);
               // ms_system_parameter o = rep.Find("");
                //HostName = o != null ? o.ParameterValue : string.Empty;
                //o = rep.Find("");
                //PortNumber = o != null ? o.ParameterValue : string.Empty;
                //o = rep.Find("");
                //UserName = o != null ? o.ParameterValue : string.Empty;
                //o = rep.Find("");
                //Password = o != null ? o.ParameterValue : string.Empty;
                //o = rep.Find("");
                //TlsHostCertificateFingerprint = o != null ? o.ParameterValue : string.Empty;
                //o = rep.Find("mFolderFtpInput");
                //mFolderFtpInput = o != null ? o.ParameterValue : string.Empty;
                //o = rep.Find("mFolderDownload");
                //mFolderDownload = o != null ? o.ParameterValue : string.Empty;
                //o = rep.Find("mFolderFtpOutput");
                //mFolderFtpOutput = o != null ? o.ParameterValue : string.Empty;
                //o = rep.Find("mFolderLocalDirectorySend");
                //mFolderLocalDirectorySend = o != null ? o.ParameterValue : string.Empty;
                //o = rep.Find("mFolderFtpOutputReporting");
                //mFolderFtpOutputReporting = o != null ? o.ParameterValue : string.Empty;
                //o = rep.Find("mFolderLocalDirectoryReporting");
                //mFolderLocalDirectoryReporting = o != null ? o.ParameterValue : string.Empty;

                Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter(db);

                FTPMethod = rep.Find("FTPMethod").ParameterValue;
                FtpHost = rep.Find("HostName").ParameterValue;
                FtpPort = Convert.ToInt32(rep.Find("PortNumber").ParameterValue);
                FtpUsername = rep.Find("UserName").ParameterValue;
                FtpUserPassword = rep.Find("Password").ParameterValue;
              //  FtpFilePath = rep.Find("FtpFilePath").ParameterValue;
               // FtpFilePath = rep.Find("FtpFilePathLocal").ParameterValue;
                TlsHostCertificateFingerprint = rep.Find("TlsHostCertificateFingerprint").ParameterValue;

                FolderPrewashToLocal = rep.Find("mFolderFtpInput").ParameterValue;

                //FolderToWatch = rep.Find("FolderToWatch").ParameterValue;
                //FolderDumpToSP = rep.Find("FolderDumpToSP").ParameterValue;
                //FolderBMSToSP = rep.Find("BMSToSP").ParameterValue;
                //FolderRMSToSP = rep.Find("RMSToSP").ParameterValue;
                //FolderWMOSToSP = rep.Find("WMOSToSP").ParameterValue;

                //FolderSPToBMS = rep.Find("SPToBMS").ParameterValue;
                //FolderSPToWMOS_1 = rep.Find("SPToWMOS_1").ParameterValue;
                //FolderSPToWMOS_2 = rep.Find("SPToWMOS_2").ParameterValue;
                //FolderSPToRMS = rep.Find("SPToRMS").ParameterValue;

                rep = null;

                if (FTPMethod.ToUpper() == "SFTP")
                {
                    sessionOptions = new SessionOptions
                    {

                        Protocol = Protocol.Sftp,
                        HostName = FtpHost,
                        UserName = FtpUsername,
                        PortNumber = FtpPort,
                        SshHostKeyFingerprint = FtpSshHostKeyFingerprint,
                        SshPrivateKeyPath = FtpFilePath
                    };
                }
                else
                {
                    sessionOptions = new SessionOptions
                    {
                        Protocol = Protocol.Ftp,
                        HostName = FtpHost,
                        PortNumber = Convert.ToInt32(FtpPort),
                        UserName = FtpUsername,
                        Password = FtpUserPassword,
                        FtpSecure = FtpSecure.Implicit,
                        TlsHostCertificateFingerprint = TlsHostCertificateFingerprint,
                    };
                }

                using (Session session = new Session())
                {
                    session.Open(sessionOptions);
                    isConnect = session.Opened;
                    session.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool IsConnect()
        {
            return isConnect;
        }

        public bool DownloadAllFiles(
            string SourceFolder,
            string destFolder,
            bool IsSourceFileRemoved,
            out Dictionary<string, string> outPut
        )
        {
            bool sts = false;

            try
            {
                outPut = new Dictionary<string, string>();

                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);
                    RemoteDirectoryInfo directory = session.ListDirectory(SourceFolder);

                    foreach (RemoteFileInfo fileInfo in directory.Files)
                    {
                        if (fileInfo.FullName.ToLower().Contains(".txt"))
                        {
                            // Download files
                            TransferOptions transferOptions = new TransferOptions();
                            transferOptions.TransferMode = TransferMode.Binary;
                            transferOptions.ResumeSupport.State = TransferResumeSupportState.Smart;
                            transferOptions.ResumeSupport.Threshold = 1000;

                            TransferOperationResult transferResult = null;

                            transferResult = session.GetFiles(fileInfo.FullName, destFolder + "\\" + fileInfo.Name, IsSourceFileRemoved, transferOptions);
                            transferResult.Check();

                            foreach (TransferEventArgs transfer in transferResult.Transfers)
                            {
                                outPut.Add(transfer.FileName, "true");

                                tr_log_xml o = new tr_log_xml();
                                o.FILENAME = transfer.FileName;
                                o.METHOD = SourceFolder;
                                o.CREATED_BY = "Services";
                                o.CREATED_DATE = DateTime.Now;
                                o.STATUS = "Download";
                                bool stsInsert = new Rep_tr_log_xml(db).Insert(o);
                            }
                        }
                    }
                    session.Close();
                    sts = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sts;
        }

        public bool DownloadCrdePrewashToLocal(bool IsSourceFileRemoved, out Dictionary<string, string> outPut)
        {
            string fld = "PREWASH";
            bool sts = false;
            outPut = new Dictionary<string, string>();
            Dictionary<string, string> toutPut = null;

            string[] source = FolderPrewashToLocal.Trim().Split('*');

            foreach (string folder in source)
            {
                if (!string.IsNullOrEmpty(folder.Trim()))
                {
                    toutPut = new Dictionary<string, string>();
                    DownloadAllFiles(
                        folder.Trim(),
                        FolderDumpToSP + "\\" + fld,
                        IsSourceFileRemoved,
                        out toutPut
                    );
                    outPut.Union(toutPut).ToDictionary(x => x.Key, x => x.Value);
                }
            }

            return sts;
        }

        //public bool DownloadRMSToSP(bool IsSourceFileRemoved, out Dictionary<string, string> outPut)
        //{
        //    string fld = "RMS";
        //    bool sts = false;
        //    outPut = new Dictionary<string, string>();
        //    Dictionary<string, string> toutPut = null;

        //    string[] source = FolderRMSToSP.Trim().Split(';');

        //    foreach (string folder in source)
        //    {
        //        if (!string.IsNullOrEmpty(folder.Trim()))
        //        {
        //            toutPut = new Dictionary<string, string>();
        //            DownloadAllFiles(
        //               folder.Trim(),
        //               FolderDumpToSP + "\\" + fld,
        //               IsSourceFileRemoved,
        //               out toutPut
        //           );
        //            outPut.Union(toutPut).ToDictionary(x => x.Key, x => x.Value);
        //        }
        //    }

        //    return sts;
        //}

        //public bool DownloadWMOSToSP(bool IsSourceFileRemoved, out Dictionary<string, string> outPut)
        //{
        //    string fld = "WMOS";
        //    bool sts = false;
        //    outPut = new Dictionary<string, string>();
        //    Dictionary<string, string> toutPut = null;

        //    string[] source = FolderWMOSToSP.Trim().Split(';');

        //    foreach (string folder in source)
        //    {
        //        if (!string.IsNullOrEmpty(folder.Trim()))
        //        {
        //            toutPut = new Dictionary<string, string>();

        //            DownloadAllFiles(
        //                folder.Trim(),
        //                FolderDumpToSP + "\\" + fld,
        //                IsSourceFileRemoved,
        //                out toutPut
        //            );

        //            outPut.Union(toutPut).ToDictionary(x => x.Key, x => x.Value);
        //        }
        //    }

        //    return sts;
        //}

        //public bool UploadSPToBMS(bool IsSourceFileRemoved, out Dictionary<string, string> outPut)
        //{

        //    bool sts = false;
        //    outPut = new Dictionary<string, string>();

        //    string[] source = FolderSPToBMS.Trim().Split(';');
        //    sts = UploadAllFiles(source[0].Trim(), source[1].Trim(), true, out outPut);

        //    return sts;
        //}

        //public bool UploadSPToRMS(bool IsSourceFileRemoved, out Dictionary<string, string> outPut)
        //{

        //    bool sts = false;
        //    outPut = new Dictionary<string, string>();

        //    string[] source = FolderSPToRMS.Trim().Split(';');
        //    sts = UploadAllFiles(source[0].Trim(), source[1].Trim(), true, out outPut);

        //    return sts;
        //}

        //public bool UploadSPToWMOS(bool IsSourceFileRemoved, out Dictionary<string, string> outPut)
        //{

        //    bool sts = false;
        //    outPut = new Dictionary<string, string>();
        //    Dictionary<string, string> toutPut = new Dictionary<string, string>();

        //    string[] source = FolderSPToWMOS_1.Trim().Split(';');
        //    sts = UploadAllFiles(source[0].Trim(), source[1].Trim(), true, out outPut);


        //    string[] source2 = FolderSPToWMOS_2.Trim().Split(';');
        //    sts = UploadAllFiles(source2[0].Trim(), source2[1].Trim(), true, out outPut);

        //    return sts;
        //}


        //public bool UploadAllFiles(string SourceFolder, string destFolderFTP, bool IsSourceFileRemoved, out Dictionary<string, string> outPut)
        //{
        //    bool sts = false;
        //    outPut = new Dictionary<string, string>();
        //    try
        //    {
        //        using (Session session = new Session())
        //        {
        //            if (Directory.Exists(SourceFolder))
        //            {
        //                // Connect
        //                session.Open(sessionOptions);

        //                DirectoryInfo info = new DirectoryInfo(SourceFolder);
        //                FileInfo[] files = info.GetFiles("*.xml").OrderBy(p => p.CreationTime).ToArray();

        //                foreach (FileInfo file in files)
        //                {
        //                    // Download files
        //                    TransferOptions transferOptions = new TransferOptions();
        //                    transferOptions.TransferMode = TransferMode.Binary;
        //                    transferOptions.ResumeSupport.State = TransferResumeSupportState.Smart;
        //                    transferOptions.ResumeSupport.Threshold = 1000;

        //                    TransferOperationResult transferResult;
        //                    transferResult = session.PutFiles(file.FullName, destFolderFTP, IsSourceFileRemoved, transferOptions);

        //                    foreach (TransferEventArgs transfer in transferResult.Transfers)
        //                    {
        //                        outPut.Add(transfer.FileName, "true");

        //                        tr_log_xml o = new tr_log_xml();
        //                        o.FILENAME = transfer.FileName;
        //                        o.METHOD = destFolderFTP;
        //                        o.CREATED_BY = "Services";
        //                        o.CREATED_DATE = DateTime.Now;
        //                        o.STATUS = "Upload";
        //                       // bool stsInsert = new Rep_tr_log_xml(db).Insert(o);
        //                    }
        //                }
        //                session.Close();

        //            }
        //            sts = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return sts;
        //}


        //public bool UploadAFile(string SourceFile, string destFolderFTP, bool IsSourceFileRemoved, out Dictionary<string, string> outPut)
        //{
        //    bool sts = false;
        //    outPut = new Dictionary<string, string>();

        //    using (Session session = new Session())
        //    {
        //        if (File.Exists(SourceFile))
        //        {
        //            // Connect
        //            session.Open(sessionOptions);

        //            // Download files
        //            TransferOptions transferOptions = new TransferOptions();
        //            transferOptions.TransferMode = TransferMode.Binary;
        //            transferOptions.ResumeSupport.State = TransferResumeSupportState.Smart;
        //            transferOptions.ResumeSupport.Threshold = 1000;

        //            TransferOperationResult transferResult;
        //            transferResult = session.PutFiles(SourceFile, destFolderFTP, IsSourceFileRemoved, transferOptions);

        //            foreach (TransferEventArgs transfer in transferResult.Transfers)
        //            {
        //                outPut.Add(transfer.FileName, "true");

        //                tr_log_xml o = new tr_log_xml();
        //                o.FILENAME = transfer.FileName;
        //                o.METHOD = destFolderFTP;
        //                o.CREATED_BY = "Services";
        //                o.CREATED_DATE = DateTime.Now;
        //                o.STATUS = "Upload";
        //             //   bool stsInsert = new Rep_tr_log_xml(db).Insert(o);
        //            }

        //            session.Close();

        //        }
        //        sts = true;

        //    }

        //    return sts;
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Finalization is now unnecessary
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                sessionOptions = null;

                if (!IsUseExistingConnection)
                {
                    if (db.Connection.State == System.Data.ConnectionState.Open)
                        db.Connection.Close();

                    db.Dispose();
                }

            }
        }

        ~FtpUtils()
        {
            Dispose(true);
        }
    }
}