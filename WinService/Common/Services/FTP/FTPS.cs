using Common.Model;
using Common.Repository;
using Common.Utils;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace Common.Services.FTP
{

    public interface IFTPS
    {
        int handle_download();
        int handle_upload();
    }
    public class FTPS : IFTPS
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private string HostName = string.Empty;
        private string PortNumber = string.Empty;
        private string UserName = string.Empty;
        private string Password = string.Empty;
        private string TlsHostCertificateFingerprint = string.Empty;
        private string FtpSshHostKeyFingerprint = string.Empty;
        private string FtpFilePath = string.Empty;
        private string FtpMethod = string.Empty;
        private bool IsDownloadInProgress = false;
        private string mFolderLocalDirectoryInput = string.Empty;
        private string mFolderFtpInput = string.Empty;
        private string mFolderLocalDirectoryOutput = string.Empty;
        private string mFolderFtpOutput = string.Empty;
        private int ErrorStatus;
        
        public FTPS()
        {
        }
        public void inizialize()
        {
            using (DBHelper db = new DBHelper())
            {
                try
                {
                    Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter(db);
                    ms_system_parameter o = rep.Find("HostName");
                    HostName = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("PortNumber");
                    PortNumber = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("UserName");
                    UserName = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("Password");
                    Password = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("TlsHostCertificateFingerprint");
                    TlsHostCertificateFingerprint = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("FtpSshHostKeyFingerprint");
                    FtpSshHostKeyFingerprint = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("FtpFilePath");
                    FtpFilePath = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("FtpMethod");
                    FtpMethod = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("mFolderLocalDirectoryInput");
                    mFolderLocalDirectoryInput = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("mFolderFtpInput");
                    mFolderFtpInput = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("mFolderLocalDirectoryOutput");
                    mFolderLocalDirectoryOutput = o != null ? o.ParameterValue : string.Empty;
                    o = rep.Find("mFolderFtpOutput");
                    mFolderFtpOutput = o != null ? o.ParameterValue : string.Empty;
                   }
                catch (Exception ex)
                {
                    _log.Error($"Error : {ex.StackTrace}");
                }
            }
        }
        public int handle_download()
        {
            using (DBHelper db = new DBHelper())
            {
                inizialize();
                
                try
                {                   
                        _log.Info("Trying download from ftp to local directory");
                        using (var session = CreateOpenFtpSession())
                        {
                            RemoteDirectoryInfo directory = session.ListDirectory(mFolderFtpInput);

                            foreach (RemoteFileInfo fileInfo in directory.Files)
                            {
                                if (fileInfo.FullName.ToLower().Contains(".txt"))
                                {
                                    // Download files
                                    TransferOptions transferOptions = new TransferOptions();
                                    transferOptions.TransferMode = TransferMode.Binary;
                                    transferOptions.FilePermissions = null;
                                    transferOptions.PreserveTimestamp = false;
                                    transferOptions.ResumeSupport.State = TransferResumeSupportState.Off;
                                    transferOptions.ResumeSupport.Threshold = 1000;

                                   // session.FileTransferred += OnFileTransferComplete;
                                   // IsDownloadInProgress = true;

                                    TransferOperationResult transferResult = null;
                                   
                                    transferResult = session.GetFiles(fileInfo.FullName, mFolderLocalDirectoryInput + "\\" + fileInfo.Name, true, transferOptions);
                                    transferResult.Check();
                                    int lineCount = File.ReadLines(mFolderLocalDirectoryInput + "\\" + fileInfo.Name).Count() - 2;
                                    if (transferResult.Transfers.Count > 0)
                                    {
                                        foreach (TransferEventArgs transfer in transferResult.Transfers)
                                        {
                                            LogUtil.AddLogDownloadAndUpload(db, transfer.FileName, mFolderLocalDirectoryInput, "Download", lineCount);

                                        _log.Info($"download file from FTPS : '{mFolderFtpInput}' to local directory :'{mFolderLocalDirectoryInput}' Succesfuly at {DateTime.Now} Filename: { transfer.FileName}, Count : {lineCount}");
                                        }
                                        
                                    }
                                    else
                                    {
                                        _log.Info($"no file in FTPS : '{mFolderFtpInput}',count: {transferResult.Transfers.Count} ");
                                    }
                                }
                            }
                            session.Close();
                        }

                        // Setup session options
                        //SessionOptions sessionOptions = new SessionOptions
                        //{
                        //    Protocol = Protocol.Ftp,
                        //    HostName = HostName,
                        //    PortNumber = Convert.ToInt32(PortNumber),
                        //    UserName = UserName,
                        //    Password = Password,
                        //    FtpSecure = FtpSecure.Implicit,
                        //    TlsHostCertificateFingerprint = TlsHostCertificateFingerprint,
                        //};
                        //using (Session session = new Session())
                        //{
                        //    // Connect
                        //    session.Open(sessionOptions);

                        //}
                        return 0;
                    
                }
                catch (Exception ex)
                {
                    string _errorMsg = "";
                    // Setting Sales Status values
                    if (ex.InnerException != null)
                    {
                        if (ex.InnerException.Message.Contains("Authentication failed"))
                        {
                            _errorMsg = ex.InnerException.Message;
                            _log.Error("wrong username/password");
                            ErrorStatus = 2;
                        }
                        else if (ex.InnerException.Message.Contains("No such file or directory"))
                        {
                            _errorMsg = ex.InnerException.Message;
                            _log.Error("File is not Available");
                            ErrorStatus = 3;
                        }
                    }
                    else
                    {
                        _errorMsg = ex.Message;
                        _log.Error($"General SFTP Error { _errorMsg}");
                        ErrorStatus = 4;
                    }


                    //Create log error file
                    if (!File.Exists(mFolderFtpInput))
                    {
                        // create SFTP LocalErrorFlag
                        _log.Error("Creating SFTP flag file");
                        _log.Error($"SFTP Error: " + mFolderFtpInput);
                    }
                    else
                    {
                        _log.Error("SFTP error Flag file already exists");
                    }


                }
                return ErrorStatus;
            
            }
        }
        public int handle_upload()
        {
            using (DBHelper db = new DBHelper())
            {
                inizialize();
                _log.Info("Trying upload from local directory to ftps");
                try
                {
                    using (var session = CreateOpenFtpSession())
                    {
                        if (Directory.Exists(mFolderLocalDirectoryOutput))
                        {
                            // Connect
                           // session.Open(sessionOptions);

                            DirectoryInfo info = new DirectoryInfo(mFolderLocalDirectoryOutput);
                            FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();

                            foreach (FileInfo file in files)
                            {
                                // Download files
                                TransferOptions transferOptions = new TransferOptions();
                                transferOptions.TransferMode = TransferMode.Binary;
                                transferOptions.ResumeSupport.State = TransferResumeSupportState.Smart;
                                transferOptions.ResumeSupport.Threshold = 1000;

                                TransferOperationResult transferResult;
                                transferResult = session.PutFiles(file.FullName, mFolderFtpOutput, false, transferOptions);

                               // int lineCount = File.ReadLines(mFolderFtpOutput + "\\" + fileInfo.Name).Count() - 2;
                                var lineCount = 0;

                                if (file.FullName.Contains("Laporan Summary Data Retail Risk CC"))
                                {
                                    lineCount = 0;
                                }
                                else
                                {
                                    lineCount = File.ReadLines(file.FullName).Count() - 2;
                            
                                }
                                foreach (TransferEventArgs transfer in transferResult.Transfers)
                                {
                                    LogUtil.AddLogDownloadAndUpload(db, transfer.FileName, mFolderFtpOutput, "Upload", lineCount);
                                    _log.Info($"Upload succeeded : { transfer.FileName}, Count : {lineCount}");
                                }
                            }
                            _log.Info($"Upload file from local directory{mFolderLocalDirectoryOutput} to ftps{mFolderFtpOutput} Succesfuly");
                            session.Close();
                        }
                        else
                        {
                            _log.Info("No File to upload from local directory to ftps");
                        }
                    }

                    //    // Setup session options
                    //    SessionOptions sessionOptions = new SessionOptions
                    //{
                    //    Protocol = Protocol.Ftp,
                    //    HostName = HostName,
                    //    PortNumber = Convert.ToInt32(PortNumber),
                    //    UserName = UserName,
                    //    Password = Password,
                    //    FtpSecure = FtpSecure.Implicit,
                    //    TlsHostCertificateFingerprint = TlsHostCertificateFingerprint,
                    //};

                    //using (Session session = new Session())
                    //{
                       
                    //}
                    return 0;
                }
                catch (Exception ex)
                {
                    _log.Error("An error occured while upload from local to ftp.");
                    _log.Error($"Error : {ex}");
                    return 1;
                }
            }
        }

        public Session CreateOpenFtpSession()
        {
           // if (settings == null) throw new ArgumentNullException(nameof(settings));

            SessionOptions sessionOptions;

            if (FtpMethod != null && FtpMethod.Equals("SFTP", StringComparison.InvariantCultureIgnoreCase))
            {
                sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = HostName,
                    UserName = UserName,
                    PortNumber = Convert.ToInt32(PortNumber),
                    SshHostKeyFingerprint = FtpSshHostKeyFingerprint,
                    SshPrivateKeyPath = FtpFilePath
                };
            }
            else if(FtpMethod != null && FtpMethod.Equals("FTPS", StringComparison.InvariantCultureIgnoreCase))
            {
                 sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Ftp,
                    HostName = HostName,
                    PortNumber = Convert.ToInt32(PortNumber),
                    UserName = UserName,
                    Password = Password,
                    FtpSecure = FtpSecure.Implicit,
                    TlsHostCertificateFingerprint = TlsHostCertificateFingerprint,
                };
            }
            else
            {
                sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Ftp,
                    HostName = HostName,
                    UserName = UserName,
                    Password = Password,
                    PortNumber = Convert.ToInt32(PortNumber)
                };
            }

            var session = new Session();
            try
            {
                session.Open(sessionOptions);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Could not connect to {HostName}:{PortNumber} as {UserName}.", ex);
            }

            return session;
        }

        private void OnFileTransferComplete(object sender, TransferEventArgs e)
        {
            IsDownloadInProgress = false;
            ((Session)sender).FileTransferred -= OnFileTransferComplete;
        }
    }
}



//// Connect
//session.Open(sessionOptions);

//// Upload files
//TransferOptions transferOptions = new TransferOptions();
//transferOptions.TransferMode = TransferMode.Binary;


//if (name == "output")
//{
//    TransferOperationResult transferResult;
//    transferResult =
//                        session.PutFiles(mFolderLocalDirectorySend, mFolderFtpOutput, false, transferOptions);

//    // Throw on any error
//    transferResult.Check();

//    // Print results
//    foreach (TransferEventArgs transfer in transferResult.Transfers)
//    {
//        // Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
//        _log.Info($"Upload succeeded : { transfer.FileName}");
//    }
//}
//else if (name == "report")
//{
//    TransferOperationResult transferResult;
//    transferResult =
//                        session.PutFiles(mFolderLocalDirectoryReporting, mFolderFtpOutputReporting, false, transferOptions);

//    // Throw on any error
//    transferResult.Check();

//    // Print results
//    foreach (TransferEventArgs transfer in transferResult.Transfers)
//    {
//        // Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
//        _log.Info($"Upload succeeded : { transfer.FileName}");
//    }
//}
