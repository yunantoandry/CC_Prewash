using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Constants
    {
        //=== AppSettings for background services ===

        public static readonly string ShouldLogPollingAppSettingName = "ShouldLogPolling";


        //=== Delimiter Seperated Values (DSV) ===

        /// <summary>
        /// The standard character used to seperate legacy database columns
        /// that are multivalued but seperated by some seperator character.
        /// </summary>
        public static readonly char MultivalueColumnSeparator = ';';

        /// <summary>
        /// The standard character used to seperate delimiter-seperated-values.
        /// </summary>
        public static readonly string DsvSeparator = "|";

        /// <summary>
        /// The standard DateTime format for DSVs.
        /// </summary>
        public static readonly string DsvFileNameDateFormat = "ddMMyyyyHHmmss";


        //=== Exceptions ===

        /// <summary>
        /// A user friendly Exception should ideally show the details of an
        /// error only if they are safe to show. Othewrise, display this
        /// message.
        /// </summary>
        public static readonly string StandardUserFriendlyExceptionMessage = "An internal server error occured.";


        /// <summary>
        /// If a dev accidentally forgets to declare a user friendly message,
        /// make a change to the standard user friendly message that will  make
        /// it clear that they forgot.
        /// </summary>
        public static readonly string StandardUserFriendlyExceptionMessageIfFriendlyMessageIsMissing = "An internal server error occured and no user-friendly message was supplied.";

        public static readonly string WmosTransactionsReadySubFolder = @"WMOS\transactions\ready";
    }
    public static class ConstsTable
    {
        public static readonly string input = "EUC_CC_INPUT";
        public static readonly string agunan = "EUC_CC_SID_AGUNAN";
        public static readonly string alamat = "EUC_CC_SID_ALAMAT";
        public static readonly string debitur = "EUC_CC_SID_DEBITUR";
        public static readonly string kolektibilitas = "EUC_CC_SID_KOLEKTIBILITAS";
        public static readonly string sumber = "EUC_CC_SID_SUMBER";
        public static readonly string summary = "EUC_CC_SID_SUMMARY";
        public static readonly string pekerjaan = "EUC_CC_SID_PEKERJAAN";
    }
    public static class SystemConsts
    {
        //=== FTP Crdentials ===

        public static readonly string FtpMethod = "FTPMethod";
        public static readonly string FtpHost = "FtpHost";
        public static readonly string FtpPort = "FtpPort";
        public static readonly string FtpUsername = "FtpUsername";
        public static readonly string FtpUserPassword = "FtpUserPassword";
        public static readonly string FtpFilePath = "FtpFilePath";
        public static readonly string FtpSshHostKeyFingerprint = "FtpSshHostKeyFingerprint";
        public static readonly string FtpPrivateKeyPassphrase = "FtpPrivateKeyPassphrase";

        //=== Folders that store XML files downloaded from other servers ===

        public static readonly string BMSToSP = "BMSToSP";
        public static readonly string RMSToSP = "RMSToSP";
        public static readonly string WMOSToSP = "WMOSToSP";
        public static readonly string WMOSToSP_SHF = "WMOSToSP_SHF";
        public static readonly string WMOSToSP_WTI = "WMOSToSP_WTI"; //new BU

        //=== Folders that store XML files uploaded to other servers ===

        public static readonly string SPToBMS = "SPToBMS";
        public static readonly string SPToWMOS_1 = "SPToWMOS_1";
        public static readonly string SPToWMOS_2 = "SPToWMOS_2";
        public static readonly string SPToRMS = "SPToRMS";
        public static readonly string SPToWMOS_SHI1 = "SPToWMOS_SHI1";
        public static readonly string SPToWMOS_SHI2 = "SPToWMOS_SHI2";
        public static readonly string SPToWMOS_SHF1 = "SPToWMOS_SHF1";
        public static readonly string SPToWMOS_SHF2 = "SPToWMOS_SHF2";
        public static readonly string SPToWMOS_WTI1 = "SPToWMOS_WTI1"; //new BU
        public static readonly string SPToWMOS_WTI2 = "SPToWMOS_WTI2";
        //=== SMTP Credentials ===

        public static readonly string SmtpServer = "SmtpServer";
        public static readonly string SmtpUser = "SmtpUser";
        public static readonly string SmtpPassword = "SmtpPassword";
        public static readonly string SmtpDefaultCredentials = "SmtpDefaultCredentials";
        public static readonly string SmtpSsl = "SmtpSsl";
        public static readonly string SmtpPort = "SmtpPort";

        //=== Default Email Settings ===

        public static readonly string EmailFrom = "EmailFrom";

        //=== DSV System Parameters ===

        public static readonly string FolderToExportDSV = "FolderToExportDSV";
        public static readonly string WMOSFolderToReceiveDSV = "WMOSFolderToReceiveDSV";

        //=== XML System Parameters ===

        public static readonly string FolderToWatch = "FolderToWatch";
        public static readonly string FolderToWatchSuccess = "FolderToWatchSuccess";
        public static readonly string FolderToWatchError = "FolderToWatchError";

        // NOTE: This typo ("extention" instead of "extension") exists in the
        // database. Do not "fix" it until you can change the DB safely.
        public static readonly string ExtentionFileToWatch = "ExtentionFileToWatch";
        public static readonly string FolderDumpToSP = "FolderDumpToSP";
        public static readonly string FolderToExportXML = "FolderToExportXML";
        public static readonly string BMSToSPArchive = "BMSToSPArchive";
        public static readonly string RMSToSPArchive = "RMSToSPArchive";
        public static readonly string WMOSToSPArchive = "WMOSToSPArchive";

        //=== Email System Parameters ===

        public static readonly string DPSubjectVendorGetSlot = "DPSubjectVendorGetSlot";
        public static readonly string DPEmailVendorGetSlot = "DPEmailVendorGetSlot";
        public static readonly string DPSubjectAdmin = "DPSubjectAdmin";
        public static readonly string DPEmailAdmin = "DPEmailAdmin";
        public static readonly string DPAdminEmailTo = "DPAdminEmailTo";

        public static readonly string DPEmailBodyVendorBookingRejected = "DPEmailBodyVendorBookingRejected";
        public static readonly string DPEmailSubjectVendorBookingRejected = "DPEmailSubjectVendorBookingRejected";

        public static readonly string ScheduleCreateDPFile = "ScheduleCreateDPFile";

        //=== Email System Parameters 3pl email ===

        public static readonly string InventoryInformation = "3plSubjectInventoryInformation";
        public static readonly string _3plEmailVendorGetSlot = "_3plEmailVendorGetSlot";
    }

}
