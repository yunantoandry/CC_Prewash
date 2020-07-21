using Common.Model;
using Common.Repository;
using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
//using static Common.Constants;

namespace Common.XML
{
    public class ReadAndSaveToDatabase
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);      
        private static string mFolderLocalDirectoryInput = string.Empty;
        private static string mFolderLocalDirectoryDumpInput = string.Empty;

        public void Initilize()
        {
            try
            {
                using (DBHelper db = new DBHelper())
                {
                    using (Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter(db))
                    {
                        ms_system_parameter o = rep.Find("mFolderLocalDirectoryInput");
                        mFolderLocalDirectoryInput = o != null ? o.ParameterValue : string.Empty;
                        o = rep.Find("mFolderLocalDirectoryDumpInput");
                        mFolderLocalDirectoryDumpInput = o != null ? o.ParameterValue : string.Empty;
                    }
                }              
            }
            catch (Exception ex)
            {
                _log.Error($"Error : {ex}");           
            }
        }
        public void Handle(string pathInWatchFolder)
        {
              Initilize();

            _log.Debug($"Begin ExecutionFile - Filename: '{pathInWatchFolder}' ");

            FileInfo file = null;
            string newFileName = string.Empty;

            try
            {
                file = new FileInfo(pathInWatchFolder);
                newFileName = string.Format("{0}", file.Name);
                string Data = File.ReadAllText(pathInWatchFolder);

                if (newFileName.ToLower().Contains("input") == true)
                {
                    //string table = ConstsTable.input;
                    string table = "Staging_EUC_CC_INPUT";
                    
                    //insert to staging (temp_table)
                    Save.GetDataTabletFromCSVFile1(pathInWatchFolder, table, newFileName);
                    // insert to euc_input,checker constraint and checker invalid format
                    Save.insert_from_staging_to_euc_cc_input(pathInWatchFolder, newFileName);

                    string filePath = pathInWatchFolder.ToLower();
                    filePath = filePath.Replace(mFolderLocalDirectoryInput.ToLower(), mFolderLocalDirectoryDumpInput.ToLower());

                    File.Copy(pathInWatchFolder, filePath, true);
                    File.Delete(pathInWatchFolder);

                    _log.Debug($"Successfully ExecutionFile - Filename: '{pathInWatchFolder}' ");
                    //  ConvertTxtToXML.ConvertTxtToXML_EUC_CC_INPUT(str);
                    //Save.SaveAllFilesXmlMasterToDatabase(str);
                }
                //else if (newFileName.Contains("test") == true)
                //{
                //    string table = "Table_1";
                //    Save.GetDataTabletFromCSVFile1(pathInWatchFolder, table);

                //    string filePath = pathInWatchFolder.ToLower();
                //    filePath = filePath.Replace(mFolderLocalDirectoryRead.ToLower(), mFolderLocalDirectoryDumpInput.ToLower());

                //    File.Copy(pathInWatchFolder, filePath, true);
                //    File.Delete(pathInWatchFolder);
                //    // ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_AGUNAN(str);
                //    // Save.SaveAllFilesXmlMasterToDatabase(str);
                //}
                else if (newFileName.ToLower().Contains("agunan") == true)
                {
                    string table = ConstsTable.agunan;
                    Save.GetDataTabletFromCSVFile1(pathInWatchFolder, table, newFileName);

                    string filePath = pathInWatchFolder.ToLower();
                    filePath = filePath.Replace(mFolderLocalDirectoryInput.ToLower(), mFolderLocalDirectoryDumpInput.ToLower());

                    File.Copy(pathInWatchFolder, filePath, true);
                    File.Delete(pathInWatchFolder);
                    // ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_AGUNAN(str);
                    // Save.SaveAllFilesXmlMasterToDatabase(str);

                    _log.Debug($"Successfully ExecutionFile - Filename: '{pathInWatchFolder}' ");
                }
                else if (newFileName.ToLower().Contains("alamat") == true)
                {

                    string table = ConstsTable.alamat;
                    Save.GetDataTabletFromCSVFile1(pathInWatchFolder, table, newFileName);

                    string filePath = pathInWatchFolder.ToLower();
                    filePath = filePath.Replace(mFolderLocalDirectoryInput.ToLower(), mFolderLocalDirectoryDumpInput.ToLower());

                    File.Copy(pathInWatchFolder, filePath, true);
                    File.Delete(pathInWatchFolder);
                    // ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_ALAMAT(str);
                    // Save.SaveAllFilesXmlMasterToDatabase(str);

                    _log.Debug($"Successfully ExecutionFile - Filename: '{pathInWatchFolder}' ");
                }
                else if (newFileName.ToLower().Contains("debitur") == true)
                {
                    string table = ConstsTable.debitur;
                    Save.GetDataTabletFromCSVFile1(pathInWatchFolder, table, newFileName);

                    string filePath = pathInWatchFolder.ToLower();
                    filePath = filePath.Replace(mFolderLocalDirectoryInput.ToLower(), mFolderLocalDirectoryDumpInput.ToLower());

                    File.Copy(pathInWatchFolder, filePath, true);
                    File.Delete(pathInWatchFolder);
                    // ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_DEBITUR(str);
                    // Save.SaveAllFilesXmlMasterToDatabase(str);

                    _log.Debug($"Successfully ExecutionFile - Filename: '{pathInWatchFolder}' ");
                }
                else if (newFileName.ToLower().Contains("kolektibilitas") == true)
                {
                    string table = ConstsTable.kolektibilitas;
                    Save.GetDataTabletFromCSVFile1(pathInWatchFolder, table, newFileName);

                    string filePath = pathInWatchFolder.ToLower();
                    filePath = filePath.Replace(mFolderLocalDirectoryInput.ToLower(), mFolderLocalDirectoryDumpInput.ToLower());

                    File.Copy(pathInWatchFolder, filePath, true);
                    File.Delete(pathInWatchFolder);
                    // ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_KOLEKTIBILITAS(str);
                    // Save.SaveAllFilesXmlMasterToDatabase(str);

                    _log.Debug($"Successfully ExecutionFile - Filename: '{pathInWatchFolder}' ");
                }
                else if (newFileName.ToLower().Contains("sumber") == true)
                {
                    string table = ConstsTable.sumber;
                    Save.GetDataTabletFromCSVFile1(pathInWatchFolder, table, newFileName);

                    string filePath = pathInWatchFolder.ToLower();
                    filePath = filePath.Replace(mFolderLocalDirectoryInput.ToLower(), mFolderLocalDirectoryDumpInput.ToLower());

                    File.Copy(pathInWatchFolder, filePath, true);
                    File.Delete(pathInWatchFolder);
                    // ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_SUMBER(str);
                    //  Save.SaveAllFilesXmlMasterToDatabase(str);

                    _log.Debug($"Successfully ExecutionFile - Filename: '{pathInWatchFolder}' ");
                }
                else if (newFileName.ToLower().Contains("summary") == true)
                {
                    string table = ConstsTable.summary;
                    Save.GetDataTabletFromCSVFile1(pathInWatchFolder, table, newFileName);

                    string filePath = pathInWatchFolder.ToLower();
                    filePath = filePath.Replace(mFolderLocalDirectoryInput.ToLower(), mFolderLocalDirectoryDumpInput.ToLower());

                    File.Copy(pathInWatchFolder, filePath, true);
                    File.Delete(pathInWatchFolder);
                    //ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_SUMMARY(str);
                    //  Save.SaveAllFilesXmlMasterToDatabase(str);

                    _log.Debug($"Successfully ExecutionFile - Filename: '{pathInWatchFolder}' ");
                }

                else if (newFileName.ToLower().Contains("pekerjaan") == true)
                {
                    string table = ConstsTable.pekerjaan;
                    Save.GetDataTabletFromCSVFile1(pathInWatchFolder, table, newFileName);

                    string filePath = pathInWatchFolder.ToLower();
                    filePath = filePath.Replace(mFolderLocalDirectoryInput.ToLower(), mFolderLocalDirectoryDumpInput.ToLower());

                    File.Copy(pathInWatchFolder, filePath, true);
                    File.Delete(pathInWatchFolder);
                    //  ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_PEKERJAAN(str);
                    //  Save.SaveAllFilesXmlMasterToDatabase(str);

                    _log.Debug($"Successfully ExecutionFile - Filename: '{pathInWatchFolder}' ");
                }
            }
            catch (Exception ex)
            {
                _log.Error("An error occured while Read file and save to db.");
                _log.Error($"Error : {ex}");
              
            }
            Thread.Sleep(500);
        }
    }
}
