using Common.Connection;
using Common.Model;
using Common.Repository;
using Common.Utils;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Common.XML
{
    public class SaveXmlToDB
    {
        string VCS = Conection.koneksi();
        //private readonly DbDataReader dataTable;
        private static string IDIFILE;
        private static string[] colFields;
        private static int colFields1;



        public bool SaveAllXmlToDatabase(string SAS_ID, string XML_DATA)
        {
            bool i = false;
            using (SqlConnection con = new SqlConnection(VCS))
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand com = new SqlCommand("sp_saveXmldata", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter p_SAS_ID = new SqlParameter("@SAS_ID", SAS_ID);
                SqlParameter p_XML_DATA = new SqlParameter("@xml", XML_DATA);
                com.Parameters.Add(p_SAS_ID);
                com.Parameters.Add(p_XML_DATA);
                com.CommandTimeout = 0;
                com.ExecuteNonQuery();
                i = true;
                con.Close();
                return i;
            };
        }


        public bool insert_from_staging_to_euc_cc_input (string pathInWatchFolder, string newFileName)
        {
            bool i = false;
            using (SqlConnection con = new SqlConnection(VCS))
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand com = new SqlCommand("sp_staging_to_EUC_CC_INPUT", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter p_Path = new SqlParameter("@Path", pathInWatchFolder);
                SqlParameter p_Filename = new SqlParameter("@Filename", newFileName);

                com.Parameters.Add(p_Path);
                com.Parameters.Add(p_Filename);

                com.CommandTimeout = 0;
                com.ExecuteNonQuery();
                i = true;
                con.Close();
                return i;
            };
        }
        public bool Update_status_success_sendXML()
        {
            bool i = false;
            using (SqlConnection con = new SqlConnection(VCS))
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand com = new SqlCommand("sp_update_status_to_success_send", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                com.CommandTimeout = 0;
                com.ExecuteNonQuery();
                i = true;
                con.Close();
                return i;
            };
        }
        public bool Save_reporting_risk(string date, string Batch, int time_count, string fileName, int listXmlTranResponse)
        {
            bool i = false;
            using (SqlConnection con = new SqlConnection(VCS))
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand com = new SqlCommand("sp_saveXmldata", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //SqlParameter p_SAS_ID = new SqlParameter("@SAS_ID", SAS_ID);
                //SqlParameter p_XML_DATA = new SqlParameter("@xml", XML_DATA);
                //com.Parameters.Add(p_SAS_ID);
                //com.Parameters.Add(p_XML_DATA);
                com.CommandTimeout = 0;
                com.ExecuteNonQuery();
                i = true;
                con.Close();
                return i;
            };

        }
        public bool SaveRAC(string sas_id, int Sequence_Number, string Criteria_Name, string Reason_Code, string Reason_Description)
        {
            bool i = false;
            using (SqlConnection con = new SqlConnection(VCS))
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand com = new SqlCommand("sp_insert_RAC", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter p_sas_id = new SqlParameter("@sas_id", sas_id);
                SqlParameter p_Sequence_Number = new SqlParameter("@Sequence_Number", Sequence_Number);
                SqlParameter p_Criteria_Name = new SqlParameter("@Criteria_Name", Criteria_Name);
                SqlParameter p_Reason_Code = new SqlParameter("@Reason_Code", Reason_Code);
                SqlParameter p_Reason_Description = new SqlParameter("@Reason_Description", Reason_Description);


                com.Parameters.Add(p_sas_id);
                com.Parameters.Add(p_Sequence_Number);
                com.Parameters.Add(p_Criteria_Name);
                com.Parameters.Add(p_Reason_Code);
                com.Parameters.Add(p_Reason_Description);

                com.CommandTimeout = 0;
                com.ExecuteNonQuery();
                i = true;
                con.Close();
                return i;
            };
        }
        public bool SaveAllXmlHitResponse(string sas_id, string xml_response, string UniqueKey, string DIN, string BATCH, string Cust_Segment, float Final_Limit, string Status, string Flag_KKBL, string Score_G, float TotalScore, string score_cat, float jml_issuer, float NPWP_Status, string Drop_Reason, string FinalRemarks, TimeSpan responses_time)
        {
            bool i = false;
            using (SqlConnection con = new SqlConnection(VCS))
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand com = new SqlCommand("sp_update_xml_response_crde", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter p_sas_id = new SqlParameter("@sas_id", sas_id);
                SqlParameter p_xml_response = new SqlParameter("@xml_response", xml_response);
                SqlParameter p_UniqueKey = new SqlParameter("@UniqueKey", UniqueKey);
                SqlParameter p_DIN = new SqlParameter("@DIN", DIN);
                SqlParameter p_BATCH = new SqlParameter("@BATCH", BATCH);
                SqlParameter p_Cust_Segment = new SqlParameter("@Cust_Segment", Cust_Segment);
                SqlParameter p_Final_Limit = new SqlParameter("@Final_Limit", Final_Limit);
                SqlParameter p_Status = new SqlParameter("@Flag_bureau", Status);
                SqlParameter p_Flag_KKBL = new SqlParameter("@Flag_KKBL", Flag_KKBL);
                SqlParameter p_Score_G = new SqlParameter("@LA_Segment_New", Score_G);
                SqlParameter p_TotalScore = new SqlParameter("@TotalScore", TotalScore);
                SqlParameter p_Score_cat = new SqlParameter("@Score_Category", score_cat);
                SqlParameter p_Jml_issuer = new SqlParameter("@Jumlah_Issuer", jml_issuer);
                SqlParameter p_NPWP_Status = new SqlParameter("@Npwp_Status", NPWP_Status);
                SqlParameter p_Drop_Reason = new SqlParameter("@Drop_Reason", Drop_Reason);
                SqlParameter p_FinalRemarks = new SqlParameter("@Final_Decision", FinalRemarks);
                SqlParameter p_responses_time = new SqlParameter("@Response_time", responses_time);


                com.Parameters.Add(p_sas_id);
                com.Parameters.Add(p_xml_response);
                com.Parameters.Add(p_UniqueKey);
                com.Parameters.Add(p_DIN);
                com.Parameters.Add(p_BATCH);
                com.Parameters.Add(p_Cust_Segment);
                com.Parameters.Add(p_Final_Limit);
                com.Parameters.Add(p_Status);
                com.Parameters.Add(p_Flag_KKBL);
                com.Parameters.Add(p_Score_G);
                com.Parameters.Add(p_TotalScore);
                com.Parameters.Add(p_Score_cat);
                com.Parameters.Add(p_Jml_issuer);
                com.Parameters.Add(p_NPWP_Status);
                com.Parameters.Add(p_Drop_Reason);
                com.Parameters.Add(p_FinalRemarks);
                com.Parameters.Add(p_responses_time);

                com.CommandTimeout = 0;
                com.ExecuteNonQuery();
                i = true;
                con.Close();
                return i;
            };
        }

        public bool SaveAllFilesXmlMasterToDatabase(string action)
        {
            bool success = false;

            using (SqlConnection con = new SqlConnection(VCS))
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlTransaction trans = con.BeginTransaction();
                SqlCommand com = new SqlCommand("SaveAllFilesXml", con, trans)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter p_action = new SqlParameter("@Action", action);
                com.Parameters.Add(p_action);
                try
                {
                    com.CommandTimeout = 0;
                    com.ExecuteNonQuery();
                    success = true;
                    trans.Commit();
                    return success;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return success;
                }
                finally
                {
                    con.Close();
                }


            }


        }

        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "|" });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return csvData;

        }


        public void GetDataTabletFromCSVFile1(string pathInWatchFolder, string table, string filename)
        {
            using (DBHelper db = new DBHelper())
            {
                DataTable dt = new DataTable();

                if (File.Exists(pathInWatchFolder))
                {

                    using (TextFieldParser csvReader = new TextFieldParser(pathInWatchFolder))
                    {
                        string[] ignoreLines = { "EOF" };

                        csvReader.TextFieldType = FieldType.Delimited;
                        csvReader.Delimiters = new string[] { "|" };
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        csvReader.CommentTokens = ignoreLines;
                        colFields = csvReader.ReadFields();
                        colFields1 = colFields.Count();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;

                            dt.Columns.Add(datecolumn);

                        }
                        while (!csvReader.EndOfData)
                        {
                            string a = csvReader.ErrorLine;
                            try
                            {
                                string[] fieldData = csvReader.ReadFields();
                                IDIFILE = fieldData[0];

                                for (int i = 0; i < fieldData.Length; i++)
                                {
                                    if (fieldData[i] == "" || fieldData[i] == "-")
                                    {
                                        fieldData[i] = null;
                                    }
                                }
                                dt.Rows.Add(fieldData);

                            }
                            catch (Exception ex)
                            {

                                ex.ToString();
                                // DBHelper db = new DBHelper();
                                LogUtil.AddLogError(db, pathInWatchFolder, "Text File To DB", filename,"", IDIFILE, ex.Message, ex.StackTrace);
                                continue;
                            }
                        }
                        csvReader.Close();
                       
                        //using (SqlConnection dbConnection = new SqlConnection(VCS))
                        //{

                        //dbConnection.Open();
                        using (SqlBulkCopy s = new SqlBulkCopy(db.ConnectionString, SqlBulkCopyOptions.Default))
                        {
                            //s.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);
                            //s.NotifyAfter = 50; //Put your rowcount here
                            try
                            {
                                s.DestinationTableName = "dbo." + table;
                                //foreach (var column in dt.Columns)
                                //    s.ColumnMappings.Add(column.ToString(), column.ToString());
                                for (int i = 0; i < dt.Columns.Count; i++)
                                {

                                    s.ColumnMappings.Add(i, i + 1);

                                }
                                IDataReader reader = dt.CreateDataReader();
                                // SET BatchSize value.
                                s.BatchSize = 4000;
                                s.BulkCopyTimeout = 0;
                                s.WriteToServer(reader);

                                // dt.Close();
                            }
                            catch (Exception ex)
                            {

                                // loop through all inner exceptions to see if any relate to a constraint failure
                                //bool dataExceptionFound = false;
                                //Exception tmpException = ex;
                                //while (tmpException != null)
                                //{
                                //    if (tmpException is SqlException && tmpException.Message.Contains("constraint"))
                                //    {
                                //        dataExceptionFound = true;
                                //        break;
                                //    }
                                //    tmpException = tmpException.InnerException;
                                //}

                                //if (dataExceptionFound)
                                //{
                                //    // call the helper method to document the errors and invalid data
                                //    string errorMessage = GetBulkCopyFailedData(
                                //       db.ConnectionString,
                                //       s.DestinationTableName,
                                //       dt.CreateDataReader());
                                //    throw new Exception(errorMessage, ex);
                                //}


                                if (ex.Message.Contains("Received an invalid column length from the bcp client for colid"))
                                {
                                    string pattern = @"\d+";
                                    Match match = Regex.Match(ex.Message.ToString(), pattern);
                                    var index = Convert.ToInt32(match.Value) - 1;

                                    FieldInfo fi = typeof(SqlBulkCopy).GetField("_sortedColumnMappings", BindingFlags.NonPublic | BindingFlags.Instance);
                                    var sortedColumns = fi.GetValue(s);
                                    var items = (Object[])sortedColumns.GetType().GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(sortedColumns);

                                    FieldInfo itemdata = items[index].GetType().GetField("_metadata", BindingFlags.NonPublic | BindingFlags.Instance);
                                    var metadata = itemdata.GetValue(items[index]);

                                    var column = metadata.GetType().GetField("column", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(metadata);
                                    var length = metadata.GetType().GetField("length", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(metadata);
                                    // throw new DataFormatException(String.Format("Column: {0} contains data with a length greater than: {1}", column, length));
                                    ex.ToString();
                                    // DBHelper db = new DBHelper();
                                    LogUtil.AddLogError(db, pathInWatchFolder, "Text File To DB","", filename, IDIFILE, ex.Message, ex.StackTrace);
                                    s.WriteToServer(dt);
                                }
                                else
                                {
                                    ex.ToString();
                                    // DBHelper db = new DBHelper();
                                    LogUtil.AddLogError(db, pathInWatchFolder, "Text File To DB","", filename, IDIFILE, ex.Message, ex.StackTrace);
                                }
                            }
                            finally
                            {
                                // dbConnection.Close();
                                // dbConnection.Dispose();
                                csvReader.Close();
                                csvReader.Dispose();
                            }
                            s.Close();
                            // db.Dispose;
                        }
                        // }
                    }
                }

            }
        }

        private void OnSqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            Console.WriteLine("Copied {0} so far...", e.RowsCopied);
        }

        /// <summary>
        /// Build an error message with the failed records and their related exceptions.
        /// </summary>
        /// <param name="connectionString">Connection string to the destination database</param>
        /// <param name="tableName">Table name into which the data will be bulk copied.</param>
        /// <param name="dataReader">DataReader to bulk copy</param>
        /// <returns>Error message with failed constraints and invalid data rows.</returns>
        public static string GetBulkCopyFailedData(
           string connectionString,
           string tableName,
           IDataReader dataReader)
        {
            StringBuilder errorMessage = new StringBuilder("Bulk copy failures:" + Environment.NewLine);
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlBulkCopy bulkCopy = null;
            DataTable tmpDataTable = new DataTable();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
                bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.CheckConstraints, transaction);
                bulkCopy.DestinationTableName = tableName;

                // create a datatable with the layout of the data.
                DataTable dataSchema = dataReader.GetSchemaTable();
                foreach (DataRow row in dataSchema.Rows)
                {

                    tmpDataTable.Columns.Add(new DataColumn(
                       row["ColumnName"].ToString(),
                       (Type)row["DataType"]));
                }

                // create an object array to hold the data being transferred into tmpDataTable 
                //in the loop below.
                object[] values = new object[dataReader.FieldCount];

                // loop through the source data
                while (dataReader.Read())
                {
                    // clear the temp DataTable from which the single-record bulk copy will be done
                    tmpDataTable.Rows.Clear();

                    // get the data for the current source row
                    dataReader.GetValues(values);

                    // load the values into the temp DataTable
                    tmpDataTable.LoadDataRow(values, true);

                    // perform the bulk copy of the one row
                    try
                    {
                        bulkCopy.WriteToServer(tmpDataTable);
                    }
                    catch (Exception ex)
                    {
                        // an exception was raised with the bulk copy of the current row. 
                        // The row that caused the current exception is the only one in the temp 
                        // DataTable, so document it and add it to the error message.
                        DataRow faultyDataRow = tmpDataTable.Rows[0];
                        errorMessage.AppendFormat("Error: {0}{1}", ex.Message, Environment.NewLine);
                        errorMessage.AppendFormat("Row data: {0}", Environment.NewLine);
                        foreach (DataColumn column in tmpDataTable.Columns)
                        {
                            errorMessage.AppendFormat(
                               "\tColumn {0} - [{1}]{2}",
                               column.ColumnName,
                               faultyDataRow[column.ColumnName].ToString(),
                               Environment.NewLine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                   "Unable to document SqlBulkCopy errors. See inner exceptions for details.",
                   ex);
            }
            finally
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return errorMessage.ToString();
        }

        private void DT_Mapping(DataTable dt, string table)
        {

            string str = table;
            switch (str)
            {


                case "EUC_CC_INPUT":

                    dt.Columns.AddRange(new DataColumn[68] {
                     new DataColumn("Name", typeof(string)),
                     new DataColumn("dob", typeof(DateTime)),
                     new DataColumn("gender", typeof(string)),
                     new DataColumn("SAS_ID", typeof(string)),
                     new DataColumn("dob2", typeof(DateTime)),
                     new DataColumn("NOMORCIF", typeof(string)),
                     new DataColumn("Nationality", typeof(string)),
                     new DataColumn("Segment", typeof(string)),
                     new DataColumn("Leads_date", typeof(DateTime)),
                     new DataColumn("POB", typeof(string)),
                     new DataColumn("des", typeof(string)),
                     new DataColumn("edu_desc", typeof(string)),
                     new DataColumn("mr_desc", typeof(string)),
                     new DataColumn("email", typeof(string)),
                     new DataColumn("Home_zipcode", typeof(string)),
                     new DataColumn("MGross_income", typeof(string)),
                     new DataColumn("AGross_income", typeof(string)),
                     new DataColumn("Sales_Ch", typeof(string)),
                     new DataColumn("Bus_Type", typeof(string)),
                     new DataColumn("address_1a", typeof(string)),
                     new DataColumn("address_1b", typeof(string)),
                     new DataColumn("address_1c", typeof(string)),
                     new DataColumn("address_1d", typeof(string)),
                     new DataColumn("address_1e", typeof(string)),
                     new DataColumn("address_2a", typeof(string)),
                     new DataColumn("address_2b", typeof(string)),
                     new DataColumn("address_2c", typeof(string)),
                     new DataColumn("address_2d", typeof(string)),
                     new DataColumn("address_2e", typeof(string)),
                     new DataColumn("address_3a", typeof(string)),
                     new DataColumn("address_3b", typeof(string)),
                     new DataColumn("address_3c", typeof(string)),
                     new DataColumn("address_3d", typeof(string)),
                     new DataColumn("address_3e", typeof(string)),
                     new DataColumn("address_4a", typeof(string)),
                     new DataColumn("address_4b", typeof(string)),
                     new DataColumn("address_4c", typeof(string)),
                     new DataColumn("address_4d", typeof(string)),
                     new DataColumn("address_4e", typeof(string)),
                     new DataColumn("city_a", typeof(string)),
                     new DataColumn("city_b", typeof(string)),
                     new DataColumn("city_c", typeof(string)),
                     new DataColumn("city_d", typeof(string)),
                     new DataColumn("city_e", typeof(string)),
                     new DataColumn("province_a", typeof(string)),
                     new DataColumn("province_b", typeof(string)),
                     new DataColumn("province_c", typeof(string)),
                     new DataColumn("province_d", typeof(string)),
                     new DataColumn("province_e", typeof(string)),
                     new DataColumn("zipcode_a", typeof(string)),
                     new DataColumn("zipcode_b", typeof(string)),
                     new DataColumn("zipcode_c", typeof(string)),
                     new DataColumn("zipcode_d", typeof(string)),
                     new DataColumn("zipcode_e", typeof(string)),
                     new DataColumn("NPWP", typeof(string)),
                     new DataColumn("KTP1", typeof(string)),
                     new DataColumn("KTP2", typeof(string)),
                     new DataColumn("KTP3", typeof(string)),
                     new DataColumn("KTP4", typeof(string)),
                     new DataColumn("KTP5", typeof(string)),
                     new DataColumn("KTP6", typeof(string)),
                     new DataColumn("KTP7", typeof(string)),
                     new DataColumn("KTP8", typeof(string)),
                     new DataColumn("KTP9", typeof(string)),
                     new DataColumn("KTP10", typeof(string)),
                     new DataColumn("no_of_dependant", typeof(string)),
                     new DataColumn("flag_aum", typeof(string)),
                     new DataColumn("Batch", typeof(string)),
 });
                    break;

                case "EUC_CC_SID_AGUNAN":
                    Console.WriteLine("It is 2");
                    break;

                case "EUC_CC_SID_ALAMAT":

                    dt.Columns.AddRange(new DataColumn[13] {
                new DataColumn("idifile", typeof(string)),
                new DataColumn("TGL_LAPORAN",typeof(DateTime)),
                new DataColumn("PROGRAM", typeof(string)),
                new DataColumn("DIN", typeof(string)),
                new DataColumn("NO", typeof(string)),
                new DataColumn("ALAMAT", typeof(string)),
                new DataColumn("KELURAHAN", typeof(string)),
                new DataColumn("KECAMATAN", typeof(string)),
                new DataColumn("DATI_II", typeof(string)),
                new DataColumn("KODEPOS", typeof(string)),
                new DataColumn("NEGARA", typeof(string)),
                new DataColumn("UPDATE", typeof(DateTime)),
                new DataColumn("PELAPOR", typeof(string)),

                    });
                    break;

                case "EUC_CC_SID_DEBITUR":
                    Console.WriteLine("It is 2");
                    break;
                case "EUC_CC_SID_KOLEKTIBILITAS":
                    Console.WriteLine("It is 2");
                    break;
                case "EUC_CC_SID_SUMBER":
                    Console.WriteLine("It is 2");
                    break;
                case "EUC_CC_SID_SUMMARY":
                    Console.WriteLine("It is 2");
                    break;
                case "EUC_CC_SID_PEKERJAAN":
                    Console.WriteLine("It is 2");
                    break;


            }
        }
        //public void GetDataTabletFromCSVFile1(string pathInWatchFolder, string table)
        //{
        //    //DataTable dt = new DataTable();
        //    //string line = null;
        //    //int i = 0;
        //    //using (System.IO.StreamReader sr = System.IO.File.OpenText(pathInWatchFolder))
        //    //{

        //    //    while ((line = sr.ReadLine()) != null)
        //    //    {
        //    //        string[] data = line.Split('|');
        //    //        if (data.Length > 0)
        //    //        {
        //    //            if (i == 0)
        //    //            {
        //    //                foreach (var item in data)
        //    //                {
        //    //                    dt.Columns.Add(new DataColumn());
        //    //                }
        //    //                i++;
        //    //            }
        //    //            DataRow row = dt.NewRow();
        //    //            row.ItemArray = data;
        //    //            dt.Rows.Add(row);
        //    //        }
        //    //    }
        //    //}
        //    //using (System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(VCS))
        //    //{
        //    //    cn.Open();
        //    //    using (System.Data.SqlClient.SqlBulkCopy s = new System.Data.SqlClient.SqlBulkCopy(cn))
        //    //    {
        //    //        s.DestinationTableName = "dbo." + table;
        //    //        //foreach (var column in dt.Columns)
        //    //        //    s.ColumnMappings.Add(column.ToString(), column.ToString());
        //    //        for (int j = 0; j < dt.Columns.Count; j++)
        //    //        {

        //    //            s.ColumnMappings.Add(j, j);

        //    //        }
        //    //        // SET BatchSize value.
        //    //        s.BatchSize = 4000;
        //    //        s.BulkCopyTimeout = 0;
        //    //        s.WriteToServer(dt);
        //    //    }
        //    //}
        //    //int i = 0;

        //    //var dbConn = new SqlConnection(VCS);
        //    //var sr = new StreamReader(pathInWatchFolder);
        //    //string line = sr.ReadLine();

        //    //string[] strArray = line.Split('|');
        //    //var dt = new DataTable();

        //    //for (int index = 0; index < strArray.Length; index++)
        //    //    dt.Columns.Add(new DataColumn());

        //    //do
        //    //{
        //    //    DataRow row = dt.NewRow();

        //    //    string[] itemArray = line.Split('|');
        //    //    row.ItemArray = itemArray;
        //    //    dt.Rows.Add(row);
        //    //    i = i + 1;
        //    //    line = sr.ReadLine();
        //    //} while (!string.IsNullOrEmpty(line));


        //    //var bc = new SqlBulkCopy(dbConn)
        //    //{
        //    //    DestinationTableName = table,
        //    //    BatchSize = dt.Rows.Count
        //    //};
        //    //dbConn.Open();
        //    //bc.WriteToServer(dt);
        //    //dbConn.Close();
        //    //bc.Close();

        //    DataTable dt = new DataTable();

        //    if (File.Exists(pathInWatchFolder))
        //    {

        //        using (TextFieldParser csvReader = new TextFieldParser(pathInWatchFolder))
        //        {
        //            string[] ignoreLines = { "EOF" };

        //            csvReader.TextFieldType = FieldType.Delimited;
        //            csvReader.Delimiters = new string[] { "|" };
        //            csvReader.HasFieldsEnclosedInQuotes = true;
        //            csvReader.CommentTokens = ignoreLines;
        //            colFields = csvReader.ReadFields();
        //            colFields1 = colFields.Count();
        //            foreach (string column in colFields)
        //            {
        //                DataColumn datecolumn = new DataColumn(column);
        //                datecolumn.AllowDBNull = true;

        //                dt.Columns.Add(datecolumn);

        //            }
        //            while (!csvReader.EndOfData)
        //            {
        //                string a = csvReader.ErrorLine;
        //                try
        //                {
        //                    string[] fieldData = csvReader.ReadFields();
        //                    //int fielddata1 = fieldData.Count();
        //                    IDIFILE = fieldData[0];
        //                    //if (colFields1 == fielddata1)
        //                    //{
        //                    for (int i = 0; i < fieldData.Length; i++)
        //                    {
        //                        if (fieldData[i] == "" || fieldData[i] == "-")
        //                        {
        //                            fieldData[i] = null;
        //                        }
        //                    }
        //                    dt.Rows.Add(fieldData);

        //                }
        //                catch (Exception ex)
        //                {

        //                    ex.ToString();
        //                    DBHelper db = new DBHelper();
        //                    LogUtil.AddLogXMLError(db, pathInWatchFolder, "csvToDB", "ReadAndSaveToDB", IDIFILE, ex.Message, ex.StackTrace);
        //                    continue;
        //                }
        //            }
        //     //       csvReader.Close();

        //            using (SqlConnection dbConnection = new SqlConnection(VCS))
        //            {

        //                dbConnection.Open();
        //                using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
        //                {

        //                    try
        //                    {
        //                        s.DestinationTableName = "dbo." + table;
        //                        //foreach (var column in dt.Columns)
        //                        //    s.ColumnMappings.Add(column.ToString(), column.ToString());
        //                        for (int i = 0; i < dt.Columns.Count; i++)
        //                        {

        //                            s.ColumnMappings.Add(i, i + 1);

        //                        }
        //                        // SET BatchSize value.
        //                        s.BatchSize = 4000;
        //                        //s.BulkCopyTimeout = 0;
        //                        s.WriteToServer(dt);
        //                        s.Close();
        //                        // dt.Close();
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        if (ex.Message.Contains("Received an invalid column length from the bcp client for colid"))
        //                        {
        //                            string pattern = @"\d+";
        //                            Match match = Regex.Match(ex.Message.ToString(), pattern);
        //                            var index = Convert.ToInt32(match.Value) - 1;

        //                            FieldInfo fi = typeof(SqlBulkCopy).GetField("_sortedColumnMappings", BindingFlags.NonPublic | BindingFlags.Instance);
        //                            var sortedColumns = fi.GetValue(s);
        //                            var items = (Object[])sortedColumns.GetType().GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(sortedColumns);

        //                            FieldInfo itemdata = items[index].GetType().GetField("_metadata", BindingFlags.NonPublic | BindingFlags.Instance);
        //                            var metadata = itemdata.GetValue(items[index]);

        //                            var column = metadata.GetType().GetField("column", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(metadata);
        //                            var length = metadata.GetType().GetField("length", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(metadata);
        //                            // throw new DataFormatException(String.Format("Column: {0} contains data with a length greater than: {1}", column, length));
        //                            ex.ToString();
        //                            DBHelper db = new DBHelper();
        //                            LogUtil.AddLogXMLError(db, pathInWatchFolder, "csvToDB", column.ToString(), IDIFILE, ex.Message, ex.StackTrace);
        //                        }
        //                        else
        //                        {
        //                            ex.ToString();
        //                            DBHelper db = new DBHelper();
        //                            LogUtil.AddLogXMLError(db, pathInWatchFolder, "csvToDB", "ReadAndSaveToDB", IDIFILE, ex.Message, ex.StackTrace);
        //                        }
        //                    }
        //                    finally
        //                    {
        //                        dbConnection.Close();
        //                        dbConnection.Dispose();
        //                        csvReader.Close();
        //                        csvReader.Dispose();
        //                    }

        //                }

        //            }

        //        }

        //    }

        //}
    }
}







//public static void AddLogXMLTrans(string xml)
//{
//    using (DBHelper db = new DBHelper())
//    {
//        using (Rep_tr_log_xml_trans rep = new Rep_tr_log_xml_trans(db))
//        {
//            tr_log_xml_trans o = new tr_log_xml_trans();
//            o.XML_DATA = xml;                  
//            o.CREATED_BY = "Services";
//            o.MODIFIED_BY = "Services";
//            o.CREATED_DATE = DateTime.Now;
//            o.MODIFIED_DATE = DateTime.Now;
//            int i = rep.DBHelper.Insert<tr_log_xml_trans>(o);
//        }
//    }
//}
