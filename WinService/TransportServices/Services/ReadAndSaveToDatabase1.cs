using Common.Model;
using Common.Repository;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TransportServices.Services
{
    public class ReadAndSaveToDatabase1 : IJob
    {
        private static string mFolderToReadTxt = string.Empty;
        private static string mExtentionFileToRead = string.Empty;

        
        public void Handle()
        {
            Rep_ms_System_Parameter rep = new Rep_ms_System_Parameter();
            ms_system_parameter o = rep.Find("mFolderToReadTxt");
            mFolderToReadTxt = o != null ? o.ParameterValue : string.Empty;
            o = rep.Find("mExtentionFileToRead");
            mExtentionFileToRead = o != null ? o.ParameterValue : string.Empty;

          //  string[] filePaths = Directory.GetFiles(mFolderToReadTxt, mExtentionFileToRead, SearchOption.AllDirectories);
            DirectoryInfo d = new DirectoryInfo(mFolderToReadTxt);
            FileInfo[] Files = d.GetFiles(mExtentionFileToRead, SearchOption.AllDirectories).OrderBy(p => p.CreationTime).ToArray();
            string str = "";
            foreach (FileInfo file in Files)
            {
                str = mFolderToReadTxt + "/"+ file.Name;
                if (str.Contains("AGUNAN") == true)
                {
                    ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_AGUNAN(str);
                    Save.SaveAllFilesXmlMasterToDatabase(str);
                }
                else if (str.Contains("ALAMAT") == true)
                {
                    ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_ALAMAT(str);
                    Save.SaveAllFilesXmlMasterToDatabase(str);
                }
                else if (str.Contains("DEBITUR") == true)
                {
                    ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_DEBITUR(str);
                    Save.SaveAllFilesXmlMasterToDatabase(str);
                }
                else if (str.Contains("KOLEKTIBILITAS") == true)
                {
                    ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_KOLEKTIBILITAS(str);
                    Save.SaveAllFilesXmlMasterToDatabase(str);
                }
                else if (str.Contains("SUMBER") == true)
                {
                    ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_SUMBER(str);
                    Save.SaveAllFilesXmlMasterToDatabase(str);
                }
                else if (str.Contains("SUMMARY") == true)
                {
                    ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_SUMMARY(str);
                    Save.SaveAllFilesXmlMasterToDatabase(str);
                }
                else if (str.Contains("input") == true)
                {
                    ConvertTxtToXML.ConvertTxtToXML_EUC_CC_INPUT(str);
                    Save.SaveAllFilesXmlMasterToDatabase(str);
                }
                else if (str.Contains("PEKERJAAN") == true)
                {
                    ConvertTxtToXML.ConvertTxtToXML_EUC_CC_SID_PEKERJAAN(str);
                    Save.SaveAllFilesXmlMasterToDatabase(str);
                }
            }
        }

        public async Task Execute(IJobExecutionContext context)
        {
            this.Handle();
        }
    }
}
