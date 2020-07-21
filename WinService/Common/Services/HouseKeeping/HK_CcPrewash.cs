using Common.Model;
using Common.Repository;
using Common.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.HouseKeeping
{
    public class HK_CcPrewash
    {
        DateTime now = DateTime.Now;
        private int intervalDayConfig = ServiceConfiguration.IntervalDayConfig;
        private static string mFolderLocalDirectoryDumpOutput = string.Empty;
        private static string mFolderLocalDirectoryDumpInput = string.Empty;
        public void handle()
        {
          //  DateTime date = DateTime.Now.AddDays(intervalDayConfig);
            using (DBHelper db = new DBHelper())
            {
                Rep_ms_System_Parameter rep_ms_System_Parameter = new Rep_ms_System_Parameter(db);
                Rep_log_error rep_log_error = new Rep_log_error(db);
                Rep_tr_log_xml_error rep_tr_log_xml_error = new Rep_tr_log_xml_error(db);
                Rep_tr_log_xml_success rep_tr_log_xml_success = new Rep_tr_log_xml_success(db);
                Rep_tr_log_xml rep_tr_log_xml = new Rep_tr_log_xml(db);
                Rep_Table_RAC rep_Table_RAC = new Rep_Table_RAC(db);
                Rep_tr_xml_trans rep_tr_xml_trans = new Rep_tr_xml_trans(db);
                Rep_ms_euc_cc_sid_agunan rep_ms_euc_cc_sid_agunan = new Rep_ms_euc_cc_sid_agunan(db);
                Rep_ms_euc_cc_input rep_ms_euc_cc_input = new Rep_ms_euc_cc_input(db);
                Rep_ms_euc_cc_sid_alamat rep_ms_euc_cc_sid_alamat = new Rep_ms_euc_cc_sid_alamat(db);
                Rep_ms_euc_cc_sid_debitur rep_ms_euc_cc_sid_debitur = new Rep_ms_euc_cc_sid_debitur(db);
                Rep_ms_euc_cc_sid_kolektibilitas rep_ms_euc_cc_sid_kolektibilitas = new Rep_ms_euc_cc_sid_kolektibilitas(db);
                Rep_ms_euc_cc_sid_pekerjaan rep_ms_euc_cc_sid_pekerjaan = new Rep_ms_euc_cc_sid_pekerjaan(db);
                Rep_ms_euc_cc_sid_sumber rep_ms_euc_cc_sid_sumber = new Rep_ms_euc_cc_sid_sumber(db);
                Rep_ms_euc_cc_sid_summary rep_ms_euc_cc_sid_summary = new Rep_ms_euc_cc_sid_summary(db);

                rep_log_error.Delete(intervalDayConfig);
                rep_tr_log_xml_error.Delete(intervalDayConfig);
                rep_tr_log_xml_success.Delete(intervalDayConfig);
                rep_tr_log_xml.Delete(intervalDayConfig);
                rep_Table_RAC.Delete(intervalDayConfig);
                rep_tr_xml_trans.Delete(intervalDayConfig);
                rep_ms_euc_cc_sid_agunan.Delete(intervalDayConfig);
                rep_ms_euc_cc_input.Delete(intervalDayConfig);
                rep_ms_euc_cc_sid_alamat.Delete(intervalDayConfig);
                rep_ms_euc_cc_sid_debitur.Delete(intervalDayConfig);
                rep_ms_euc_cc_sid_kolektibilitas.Delete(intervalDayConfig);
                rep_ms_euc_cc_sid_pekerjaan.Delete(intervalDayConfig);
                rep_ms_euc_cc_sid_sumber.Delete(intervalDayConfig);
                rep_ms_euc_cc_sid_summary.Delete(intervalDayConfig);

                ms_system_parameter o = rep_ms_System_Parameter.Find("mFolderLocalDirectoryDumpOutput"); 
                mFolderLocalDirectoryDumpOutput = o != null ? o.ParameterValue : string.Empty;
                o = rep_ms_System_Parameter.Find("mFolderLocalDirectoryDumpInput");
                mFolderLocalDirectoryDumpInput = o != null ? o.ParameterValue : string.Empty;
                string[] files_output = Directory.GetFiles(mFolderLocalDirectoryDumpOutput);
                foreach (string file in files_output)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.LastAccessTime < DateTime.Now.AddDays(intervalDayConfig))
                        fi.Delete();
                }
                string[] files_input = Directory.GetFiles(mFolderLocalDirectoryDumpInput);
                foreach (string file in files_input)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.LastAccessTime < DateTime.Now.AddDays(intervalDayConfig))
                        fi.Delete();
                }
            }
        }
    }
}
