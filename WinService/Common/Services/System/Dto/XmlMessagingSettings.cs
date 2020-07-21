
using System.Collections.Generic;
using System.IO;

namespace Common.Services.System.Dto
{
    /// <summary>
    /// Represents the settings for running XML messages.
    ///
    /// The locations of all the folders used by this Windows
    /// Service for creating and transferring XML files.
    /// 
    /// The email parameters.
    /// 
    /// The file extension to watch.
    /// </summary>
    public class XmlMessagingSettings 
    {
        // Input/output folders
        // Where to save the XMLs.

        public string FolderToWatch { get; set; }
        public string FolderToWatchSuccess { get; set; }
        public string FolderDumpToSP { get; set; }
        public string FolderToWatchError { get; set; }
        public string FolderToExportXML { get; set; }

      //  public string FolderForPoLockXmls => Path.Combine(FolderToExportXML, Constants.RmsSubFolder);
        public string FolderForDistributorOrderXmls => Path.Combine(FolderToExportXML, Constants.WmosTransactionsReadySubFolder);
        public string FolderForAsnXmls => Path.Combine(FolderToExportXML, Constants.WmosTransactionsReadySubFolder);

        public HourAndMinuteDto ScheduleCreateDPFile { get; set; }

        // Email parameters
        // Who to email when the XMLs complete.

        public string DPSubjectVendorGetSlot { get; set; }
        public string DPEmailVendorGetSlot { get; set; }
        public string DPSubjectAdmin { get; set; }
        public string DPEmailAdmin { get; set; }
        public IList<string> DPAdminEmailTo { get; set; }

        public IList<string> threePLAdminEmailTo { get; set; }

        //Filter parameters

        public string ExtentionFileToWatch { get; set; }
    }
}
