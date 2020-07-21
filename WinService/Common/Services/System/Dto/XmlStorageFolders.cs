using System.Collections.Generic;

namespace Common.Services.System.Dto
{
    public class XmlStorageFolders : IHasFoldersToStoreXmlLocally
    {
        //=== Pairs of their external sources and our destinations ===

        public IEnumerable<string> BMSToSPFolders { get; set; }
        public string BMSDumpFolder { get; set; }

        public IEnumerable<string> RMSToSPFolders { get; set; }
        public string RMSDumpFolder { get; set; }

        public IEnumerable<string> WMOSToSPFolders { get; set; }
        public string WMOSDumpFolder { get; set; }

        public IEnumerable<string> WMOSToSP_SHFFolders { get; set; }

        public IEnumerable<string> WMOSToSP_WTIFolders { get; set; } //new BU : WTI

        //=== Pairs of our folders and our folders ===

        public string FolderDumpToSP { get; set; }
        public string FolderToWatch { get; set; }
        public string FileExtensionToWatch { get; set; }

        //=== Pairs of our sources and their external destinations ===

        public string SourceFolderSPToBMS { get; set; }
        public string DestinationFolderSPToBMS { get; set; }

        /// <summary>
        /// The source folder for masterdata, named in the database as WMOS_1.
        /// </summary>
        public string SourceFolderSPToWMOS_1 { get; set; }
        public string DestinationFolderSPToWMOS_1 { get; set; }

        /// <summary>
        /// The source folder for transactions, named in the database as WMOS_2.
        /// </summary>
        public string SourceFolderSPToWMOS_2 { get; set; }
        public string DestinationFolderSPToWMOS_2 { get; set; }

        /// <summary>
        /// The source folder for masterdata 3PL, named in the database as SHI1.
        /// </summary>
        public string SourceFolderSPToWMOS_SHI1 { get; set; }
        public string DestinationFolderSPToWMOS_SHI1 { get; set; }

        ///// <summary>
        ///// The source folder for transactions 3PL, named in the database as SHI2.
        ///// </summary>
        public string SourceFolderSPToWMOS_SHI2 { get; set; }
        public string DestinationFolderSPToWMOS_SHI2 { get; set; }

        ///// <summary>
        ///// The source folder for masterdata 3PL, named in the database as SHF1.
        ///// </summary>
        public string SourceFolderSPToWMOS_SHF1 { get; set; }
        public string DestinationFolderSPToWMOS_SHF1 { get; set; }

        ///// <summary>
        ///// The source folder for transactions 3PL, named in the database as SHF2.
        ///// </summary>
        public string SourceFolderSPToWMOS_SHF2 { get; set; }
        public string DestinationFolderSPToWMOS_SHF2 { get; set; }

        #region new BU : WTI
        ///// <summary>
        ///// The source folder for masterdata 3PL, named in the database as WTI1.
        ///// </summary>
        public string SourceFolderSPToWMOS_WTI1 { get; set; }
        public string DestinationFolderSPToWMOS_WTI1 { get; set; }

        ///// <summary>
        ///// The source folder for transactions 3PL, named in the database as WTI2.
        ///// </summary>
        public string SourceFolderSPToWMOS_WTI2 { get; set; }
        public string DestinationFolderSPToWMOS_WTI2 { get; set; }
        #endregion

        public string SourceFolderSPToRMS { get; set; }
        public string DestinationFolderSPToRMS { get; set; }

        //=== Other Folders ===

        //TODO: Need to figure out how these folders work.

        // Input/output folders
        // Where to save the XMLs.

        public string FolderToWatchSuccess { get; set; }
        public string FolderToWatchError { get; set; }
        public string FolderToExportXML { get; set; }

        public string FolderForPoLockXmls => SourceFolderSPToRMS;
        public string DestinationForPoLockXmls => DestinationFolderSPToRMS;

        public string FolderForAsnsAndDistributionOrders => SourceFolderSPToWMOS_2;
        public string DestinationForAsnsAndDistributionOrders => DestinationFolderSPToWMOS_2;

        public string FolderForDistributorOrderXmls => FolderForAsnsAndDistributionOrders;
        public string DestinationForDistributorOrderXmls => DestinationForAsnsAndDistributionOrders;

        public string FolderForAsnXmls => FolderForAsnsAndDistributionOrders;
        public string DestinationForAsnXmls => DestinationForAsnsAndDistributionOrders;

        // Ad-hoc archive folders
        // These folders are to satisfy requirements made by someone that
        // processed files be sent back via FTP to their servers.

        public string DestinationFolderForRMSToSPArchive { get; set; }
        public string DestinationFolderForBMSToSPArchive { get; set; }
        public string DestinationFolderForWMOSToSPArchive { get; set; }

        //Filter parameters

        public string ExtentionFileToWatch { get; set; }

        public XmlStorageFolders()
        {
            BMSToSPFolders = new List<string>();
            RMSToSPFolders = new List<string>();
            WMOSToSPFolders = new List<string>();
            WMOSToSP_SHFFolders = new List<string>();
            WMOSToSP_WTIFolders = new List<string>(); //new BU : WTI
        }
    }
}
