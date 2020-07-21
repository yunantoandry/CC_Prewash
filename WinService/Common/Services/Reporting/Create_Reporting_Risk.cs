using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.Data;
using Common.Repository;
using Common.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Spreadsheet;
using log4net;
using Common.Services.FTP;

namespace Common.Services.Reporting
{
    public class Create_Reporting_Risk
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(Create_Reporting_Risk));
        private readonly FTPS _FTPS;
        private string mFolderLocalDirectoryOutput = string.Empty;
        public Create_Reporting_Risk()
        {
            _FTPS = new FTPS();
        }
        public void handle()
        {
            _log.Info("Trying create report.");

            var aCode = 65;
            DateTime now = DateTime.Now;
            using (Rep_Reporting_risk rep = new Rep_Reporting_risk())
            {
                List<Reporting_risk> list = rep.report_month_risk();
                var json = JsonConvert.SerializeObject(list);
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(string.Format("Reporting_risk_{0}_{1}", now.ToString("MMM"), now.ToString("yyyy")));
                    _log.Info($"Created Worksheets : {ws} succesfully.");
                  
                    var datenow = ws.Range("A1:C1");
                    datenow.Style.Font.Bold = true;
                    datenow.Value = string.Format("Tanggal : {0}", DateTime.Now.ToString("dd-MM-yyyy"));
                    datenow.Merge();
                    _log.Info($"Created colom : {datenow} succesfully.");

                    var FINAL_DECISION = ws.Range("H3:J3");
                    FINAL_DECISION.Value = "FINAL DECISION";
                    FINAL_DECISION.Merge();
                    FINAL_DECISION.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    FINAL_DECISION.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    FINAL_DECISION.Style.Font.FontColor = XLColor.White;
                    FINAL_DECISION.Style.Fill.BackgroundColor = XLColor.DavysGrey;
                    _log.Info($"Created colom : {FINAL_DECISION} succesfully.");

                    var REJECT_CAUSE = ws.Range("K3:S3");
                    REJECT_CAUSE.Value = "REJECT CAUSE";
                    REJECT_CAUSE.Merge();
                    REJECT_CAUSE.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    REJECT_CAUSE.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    REJECT_CAUSE.Style.Font.FontColor = XLColor.White;
                    REJECT_CAUSE.Style.Fill.BackgroundColor = XLColor.Red;
                    _log.Info($"Created colom : {REJECT_CAUSE} succesfully.");

                    var Tanggal = ws.Range("A4:A5");
                    Tanggal.Value = "Tanggal";
                    Tanggal.Merge();
                    Tanggal.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    // .Style.Fill.BackgroundColor = XLColor.Red;
                    Tanggal.Style.Font.FontColor = XLColor.White;
                    Tanggal.Style.Fill.BackgroundColor = XLColor.DavysGrey;
                    _log.Info($"Created colom : {Tanggal} succesfully.");

                    var Batch_Output = ws.Range("B4:B5");
                    Batch_Output.Value = "Batch Output";
                    Batch_Output.Merge();
                    Batch_Output.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    Batch_Output.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    Batch_Output.Style.Font.FontColor = XLColor.White;
                    Batch_Output.Style.Fill.BackgroundColor = XLColor.DavysGrey;
                    _log.Info($"Created colom : {Batch_Output} succesfully.");

                    var Time = ws.Range("C4:C5");
                    Time.Value = "Time";
                    Time.Merge();
                    Time.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    Time.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    Time.Style.Font.FontColor = XLColor.White;
                    Time.Style.Fill.BackgroundColor = XLColor.DavysGrey;
                    _log.Info($"Created colom : {Time} succesfully.");

                    var Data_Count = ws.Range("D4:D5");
                    Data_Count.Value = "Data Count";
                    Data_Count.Merge();
                    Data_Count.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    Data_Count.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    Data_Count.Style.Font.FontColor = XLColor.White;
                    Data_Count.Style.Fill.BackgroundColor = XLColor.DavysGrey;
                    _log.Info($"Created colom : {Data_Count} succesfully.");

                    var bnf = ws.Range("E4:E5");
                    bnf.Value = "BNF";
                    bnf.Merge();
                    bnf.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    bnf.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    bnf.Style.Font.FontColor = XLColor.White;
                    bnf.Style.Fill.BackgroundColor = XLColor.DavysGrey;
                    _log.Info($"Created colom : {bnf} succesfully.");

                    var bf = ws.Range("F4:F5");
                    bf.Value = "BF";
                    bf.Merge();
                    bf.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    bf.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    bf.Style.Font.FontColor = XLColor.White;
                    bf.Style.Fill.BackgroundColor = XLColor.DavysGrey;
                    _log.Info($"Created colom : {bf} succesfully.");

                    var bf_persen = ws.Range("G4:G5");
                    bf_persen.Value = "BF %";
                    bf_persen.Merge();
                    bf_persen.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    bf_persen.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    bf_persen.Style.Font.FontColor = XLColor.White;
                    bf_persen.Style.Fill.BackgroundColor = XLColor.DavysGrey;
                    _log.Info($"Created colom : {bf_persen} succesfully.");

                    var Offer = ws.Range("H4:H5");
                    Offer.Value = "Offer";
                    Offer.Merge();
                    Offer.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    Offer.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    Offer.Style.Font.FontColor = XLColor.White;
                    Offer.Style.Fill.BackgroundColor = XLColor.DavysGrey;
                    _log.Info($"Created colom : {Offer} succesfully.");

                    var drop_ = ws.Range("I4:I5");
                    drop_.Value = "DROP";
                    drop_.Merge();
                    drop_.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    drop_.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    drop_.Style.Font.FontColor = XLColor.White;
                    drop_.Style.Fill.BackgroundColor = XLColor.DavysGrey;
                    _log.Info($"Created colom : {drop_} succesfully.");

                    var Offer_rate = ws.Range("J4:J5");
                    Offer_rate.Value = "Offer Rate";
                    Offer_rate.Merge();
                    Offer_rate.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    Offer_rate.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    Offer_rate.Style.Font.FontColor = XLColor.White;
                    Offer_rate.Style.Fill.BackgroundColor = XLColor.DavysGrey;
                    _log.Info($"Created colom : {Offer_rate} succesfully.");                    

                    //var NON_NTC_CUSTOMER = ws.Range("K4:K5");
                    //NON_NTC_CUSTOMER.Value = "NON NTC CUSTOMER";
                    //NON_NTC_CUSTOMER.Merge();
                    //NON_NTC_CUSTOMER.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    //NON_NTC_CUSTOMER.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    //NON_NTC_CUSTOMER.Style.Font.FontColor = XLColor.White;
                    //NON_NTC_CUSTOMER.Style.Fill.BackgroundColor = XLColor.Red;
                    //_log.Info($"Created colom : {NON_NTC_CUSTOMER} succesfully.");

                    var rac_max_2_cc_issuers = ws.Range("K4:K5");
                    rac_max_2_cc_issuers.Value = "RAC MAX 2 CC ISSUERS";
                    rac_max_2_cc_issuers.Merge();
                    rac_max_2_cc_issuers.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    rac_max_2_cc_issuers.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    rac_max_2_cc_issuers.Style.Font.FontColor = XLColor.White;
                    rac_max_2_cc_issuers.Style.Fill.BackgroundColor = XLColor.Red;
                    _log.Info($"Created colom : {rac_max_2_cc_issuers} succesfully.");

                    var rac_age = ws.Range("L4:L5");
                    rac_age.Value = "RAC AGE";
                    rac_age.Merge();
                    rac_age.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    rac_age.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    rac_age.Style.Font.FontColor = XLColor.White;
                    rac_age.Style.Fill.BackgroundColor = XLColor.Red;
                    _log.Info($"Created colom : {rac_age} succesfully.");

                    var rac_minimum_income = ws.Range("M4:M5");
                    rac_minimum_income.Value = "RAC MINIMUM INCOME";
                    rac_minimum_income.Merge();
                    rac_minimum_income.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    rac_minimum_income.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    rac_minimum_income.Style.Font.FontColor = XLColor.White;
                    rac_minimum_income.Style.Fill.BackgroundColor = XLColor.Red;
                    _log.Info($"Created colom : {rac_minimum_income} succesfully.");

                    var bad_bureau = ws.Range("N4:N5");
                    bad_bureau.Value = "BAD BUREAU";
                    bad_bureau.Merge();
                    bad_bureau.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    bad_bureau.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    bad_bureau.Style.Font.FontColor = XLColor.White;
                    bad_bureau.Style.Fill.BackgroundColor = XLColor.Red;
                    _log.Info($"Created colom : {bad_bureau} succesfully.");

                    var highest_cc_limit_kurang_dari_3mio = ws.Range("O4:O5");
                    highest_cc_limit_kurang_dari_3mio.Value = "HIGHEST CC LIMIT < 3 MIO";
                    highest_cc_limit_kurang_dari_3mio.Merge();
                    highest_cc_limit_kurang_dari_3mio.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    highest_cc_limit_kurang_dari_3mio.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    highest_cc_limit_kurang_dari_3mio.Style.Font.FontColor = XLColor.White;
                    highest_cc_limit_kurang_dari_3mio.Style.Fill.BackgroundColor = XLColor.Red;
                    _log.Info($"Created colom : {highest_cc_limit_kurang_dari_3mio} succesfully.");

                    var rac_very_high_risk_segment = ws.Range("P4:P5");
                    rac_very_high_risk_segment.Value = "RAC VERY HIGH RISK SEGMENT";
                    rac_very_high_risk_segment.Merge();
                    rac_very_high_risk_segment.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    rac_very_high_risk_segment.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    rac_very_high_risk_segment.Style.Font.FontColor = XLColor.White;
                    rac_very_high_risk_segment.Style.Fill.BackgroundColor = XLColor.Red;
                    _log.Info($"Created colom : {rac_very_high_risk_segment} succesfully.");

                    var mue_3x = ws.Range("Q4:Q5");
                    mue_3x.Value = "MUE 3X";
                    mue_3x.Merge();
                    mue_3x.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    mue_3x.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    mue_3x.Style.Font.FontColor = XLColor.White;
                    mue_3x.Style.Fill.BackgroundColor = XLColor.Red;
                    _log.Info($"Created colom : {mue_3x} succesfully.");

                    var mue_7x = ws.Range("R4:R5");
                    mue_7x.Value = "MUE 7X";
                    mue_7x.Merge();
                    mue_7x.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    mue_7x.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    mue_7x.Style.Font.FontColor = XLColor.White;
                    mue_7x.Style.Fill.BackgroundColor = XLColor.Red;
                    _log.Info($"Created colom : {mue_7x} succesfully.");

                    var final_limit_kurang_dari_3mio = ws.Range("S4:S5");
                    final_limit_kurang_dari_3mio.Value = "FINAL LIMIT < 3 MIO";
                    final_limit_kurang_dari_3mio.Merge();
                    final_limit_kurang_dari_3mio.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    final_limit_kurang_dari_3mio.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    final_limit_kurang_dari_3mio.Style.Font.FontColor = XLColor.White;
                    final_limit_kurang_dari_3mio.Style.Fill.BackgroundColor = XLColor.Red;
                    _log.Info($"Created colom : {final_limit_kurang_dari_3mio} succesfully.");

                    int rowIndex = 6;
                    // int columnIndex = 0;
                    //foreach (DataColumn column in dt.Columns)
                    //{
                    //    ws.Cell(string.Format("{0}{1}", Char.ConvertFromUtf32(aCode + columnIndex), rowIndex)).Value = column.ColumnName;
                    //    ws.Cell(string.Format("{0}{1}", Char.ConvertFromUtf32(aCode + columnIndex), rowIndex)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    //    ws.Cell(string.Format("{0}{1}", Char.ConvertFromUtf32(aCode + columnIndex), rowIndex)).Style.Fill.BackgroundColor = XLColor.Blue;

                    //    columnIndex++;
                    //}
                    // rowIndex++;
                    _log.Info($"trying created row ");
                    foreach (DataRow row in dt.Rows)
                    {
                        int valueCount = 0;
                        foreach (object rowValue in row.ItemArray)
                        {
                            ws.Cell(string.Format("{0}{1}", Char.ConvertFromUtf32(aCode + valueCount), rowIndex)).Value = rowValue;
                            ws.Cell(string.Format("{0}{1}", Char.ConvertFromUtf32(aCode + valueCount), rowIndex)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            valueCount++;                          
                        }
                        rowIndex++;
                    }
                    _log.Info($"succesfully created row ");

                    Rep_ms_System_Parameter reps = new Rep_ms_System_Parameter();
                    ms_system_parameter o = new ms_system_parameter();
                    o = reps.Find("mFolderLocalDirectoryOutput");
                    mFolderLocalDirectoryOutput = o != null ? o.ParameterValue : string.Empty;

                    string filename = string.Format("Laporan Summary Data Retail Risk CC A Score {0}.xlsx", now.ToString("dd MMMM yyyy HHmmss"));
                    string fullFilePath = string.Format(mFolderLocalDirectoryOutput + "{0}", filename);
                    string savePath = Path.Combine(mFolderLocalDirectoryOutput, filename);
                    wb.SaveAs(savePath, false);

                    _log.Info($"Successfully Create Filename in {fullFilePath}");
                }
            }

        }

    }
}
