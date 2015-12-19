using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Text.RegularExpressions;
using System.Text;
using System.Data.OleDb;
using System.Threading;

namespace FlyCn.FlyCnDAL
{
    #region classImportFile
    public class ImportFile
    {

        #region Public Properties
        public Guid status_Id
        {
            get;
            set;
        }
        public string ImportProperty
        {
            get;
            set;
        }
        public ImportFile()
        {

            status_Id = Guid.NewGuid();

        }

        public ImportFile(Guid StatusId)
        {

            status_Id = StatusId;

        }
        public string ExcelFileName
        {
            get;
            set;
        }
        public string StatusId
        {
            get;
            set;
        }

        public string ProjectNo
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }

        public string TableName
        {
            get;
            set;
        }

        public int TotalCount
        {
            get;
            set;
        }

        public int InsertCount
        {
            get;
            set;
        }


        public int UpdateCount
        {
            get;
            set;
        }

        public int ErrorCount
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public DateTime LastUpdatedTime
        {
            get;
            set;
        }

        public DateTime StartTime
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }

        public string TimeRemaining
        {
            get;
            set;
        }

        public string TimeElapsed
        {
            get;
            set;
        }

        public byte IsDeleted
        {
            get;
            set;
        }

        public int Processed_Count
        {
            get;
            set;
        }
        public int InsertStatus
        {
            get;
            set;
        }

        public enum excelImportstatus
        {
            started = 1,
            Processing = 2,
            Finished = 3
        }
        #endregion Public Properties

        //properties from javad updatedExcelimport
        #region JavadProperties
        ValidationExcel validationObj = new ValidationExcel();
        public string errorMessage
        {
            get;
            set;
        }
        public string successMessage
        {
            get;
            set;
        }
        public string failureMessage
        {
            get;
            set;
        }
        //public List<ExcelValidationModel> invalidItems
        //{
        //    get;
        //    set;
        //}
        public int insertcount
        {
            get;
            set;
        }
        public int totalCount
        {
            get;
            set;
        }
        public int updateCount
        {
            get;
            set;
        }

        public int errorCount
        {
            get;
            set;
        }
        public string ProjNum
        {
            get;
            set;
        }
        public string Code
        {
            get;
            set;
        }
          
        public string fileName
        {
            get;
            set;
        }

        public int importStatus
        {
            get;
            set;
        }

        public HttpRequestBase request
        {
            get;
            set;
        }
        public string temporaryFolder
        {
            get;
            set;
        }
        //public string ExcelFileName
        //{
        //    get;
        //    set;
        //}

        public string testFile
        {
            get;
            set;
        }
        public string fileLocation
        {
            get;
            set;
        }

        #endregion JavadProperties
        //properties from javad updatedExcelimport
        #region methods

        #region Initialize Excel Import Details
        /// <summary>
        /// Initialize the values of Excel import details table 
        /// </summary>
        /// <param name="ExcelFileName"></param>
        public void InitializeExcelImportDetails(string ExcelFileName, int totalCount)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertExcelImportDetails";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Status_Id", status_Id);
                cmd.Parameters.AddWithValue("@ProjNo", ProjectNo);
                cmd.Parameters.AddWithValue("@File_Name", ExcelFileName);
                cmd.Parameters.AddWithValue("@Table_Name", TableName);
                cmd.Parameters.AddWithValue("@Total_Count", totalCount);
                cmd.Parameters.AddWithValue("@Insert_Count", 0);
                cmd.Parameters.AddWithValue("@Update_Count", 0);
                cmd.Parameters.AddWithValue("@Error_Count", 0);
                cmd.Parameters.AddWithValue("@User_Name",UserName);
                cmd.Parameters.AddWithValue("@InsertStatus", excelImportstatus.started);
                cmd.Parameters.AddWithValue("@Remarks", Remarks);
                //cmd.Parameters.AddWithValue("@Updated_Date",DateTime.Now);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }

        #endregion Initialize Excel Import Details

        #region Update Excel Import Details
        /// <summary>
        /// Update the values of Excel import details table
        /// </summary>
        /// <param name="ExcelFileName"></param>
        /// <param name="InsertCount"></param>
        /// <param name="UpdateCount"></param>
        /// <param name="ErrorCount"></param>
        /// <param name="Remarks"></param>
        public void UpdateExcelImportDetails(string userName, string ProjNo, string TableName, string ExcelFileName, int InsertCount, int UpdateCount, int ErrorCount, string Remarks, excelImportstatus processStatus)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            dbConnection dcon = new dbConnection();
            try
            {


                con = dcon.GetDBConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateExcelImportDetails";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Status_Id", status_Id);
                cmd.Parameters.AddWithValue("@ProjNo", ProjNo);
                cmd.Parameters.AddWithValue("@File_Name", ExcelFileName);
                cmd.Parameters.AddWithValue("@Table_Name", TableName);
                cmd.Parameters.AddWithValue("@Insert_Count", InsertCount);
                cmd.Parameters.AddWithValue("@Update_Count", UpdateCount);
                cmd.Parameters.AddWithValue("@Error_Count", ErrorCount);
                cmd.Parameters.AddWithValue("@User_Name", userName);
                cmd.Parameters.AddWithValue("@InsertStatus", processStatus);
                cmd.Parameters.AddWithValue("@Remarks", Remarks);
                //cmd.Parameters.AddWithValue("@Updated_Date", DateTime.Now);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }


        }
        #endregion Update Excel Import Details

        #region Error Details
        public DataTable getErrorDetails()
        {
            DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("SelectExcelImportErrorDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Parameters.AddWithValue("@Status_Id",statusID);
                cmd.Parameters.AddWithValue("@userName", UserName);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                datatableobj = new DataTable();
                adapter.Fill(datatableobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return datatableobj;
        }
        #endregion Error Details

        #region getExcelImportDetailsById
        /// <summary>
        /// Get All Excel Import Details By Status_ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DataSet</returns>

        public DataSet getExcelImportDetailsById(string id)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataSet myRec = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllExcelImportDetailsById";
                cmd.Parameters.AddWithValue("@StatusId", id);
                cmd.Connection = con;
                da.SelectCommand = cmd;
                //con.Open();
                da.Fill(myRec);
                if (myRec.Tables[0].Rows.Count > 0)
                {
                    UpdateCount = Convert.ToInt32(myRec.Tables[0].Rows[0]["Update_Count"]);
                    TimeRemaining = TimeSpan.FromMilliseconds(Convert.ToDouble(myRec.Tables[0].Rows[0]["Time_Remaining"])).ToString(@"hh\:mm\:ss");
                    InsertCount = Convert.ToInt32(myRec.Tables[0].Rows[0]["Insert_Count"]);
                    ErrorCount = Convert.ToInt32(myRec.Tables[0].Rows[0]["Error_Count"]);
                    LastUpdatedTime = Convert.ToDateTime(myRec.Tables[0].Rows[0]["Last_Updated_Time"]);
                    TimeElapsed = TimeSpan.FromMilliseconds(Convert.ToDouble(myRec.Tables[0].Rows[0]["Time_Elapsed"])).ToString(@"hh\:mm\:ss");
                    ProjectNo = myRec.Tables[0].Rows[0]["ProjNo"].ToString();
                    FileName = myRec.Tables[0].Rows[0]["File_Name"].ToString();
                    TableName = myRec.Tables[0].Rows[0]["Table_Name"].ToString();
                    TotalCount = Convert.ToInt32(myRec.Tables[0].Rows[0]["Total_Count"].ToString());
                    StartTime = Convert.ToDateTime(myRec.Tables[0].Rows[0]["Start_Time"].ToString());
                    UserName = myRec.Tables[0].Rows[0]["User_Name"].ToString();
                    InsertStatus = Convert.ToInt32(myRec.Tables[0].Rows[0]["InsertStatus"].ToString());
                    Remarks = myRec.Tables[0].Rows[0]["Remarks"].ToString();
                    // IsDeleted = Convert.ToByte(myRec.Tables[0].Rows[0]["IsDeleted"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return myRec;
        }
        #endregion getExcelImportDetailsById

        #region Insert Excel Import Error Details
        /// <summary>
        /// Insert the values of Excel import error details table
        /// </summary>
        /// <param name="ExcelFileName"></param>
        /// <param name="InsertCount"></param>

        public void InsertExcelImportErrorDetails(string KeyField, string ErrorDescription)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            dbConnection dcon = new dbConnection();
            try
            {
                con = dcon.GetDBConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertExcelImportErrorDetails";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Import_Status_Id", status_Id);
                cmd.Parameters.AddWithValue("@Key_Field", KeyField);
                cmd.Parameters.AddWithValue("@Error_Description", ErrorDescription);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }


        }
        #endregion Insert Excel Import Error Details

        #region UpdateExcelImportDetails
        /// <summary>
        ///  Set delete flag of Excel import details table
        /// </summary>
        /// <returns></returns>
        public int UpdateExcelImportDetails(string id)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateImportErrorDetails";
                cmd.Parameters.AddWithValue("@Status_Id", id);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return 1;
        }
        #endregion UpdateExcelImportDetails

        #region getDistictExcelImportDetails
        public DataSet getDistictExcelImportDetails(string StatusId)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataSet myRec = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectCompletedExcelImportDetails";
                cmd.Parameters.AddWithValue("@StatusId", StatusId);
                cmd.Connection = con;
                da.SelectCommand = cmd;
                da.Fill(myRec);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return myRec;
        }
        #endregion getDistictExcelImportDetails

        #region BindTree

        public void BindTree(RadTreeView myTree)
        {
            try
            {
                myTree.Nodes.Clear();
                RadTreeNode rtn = new RadTreeNode("ImportErrorList", "0");
                rtn.NavigateUrl = "../ExcelImport/ImportErrorList.aspx";
                rtn.Target = "contentPane";
                myTree.Nodes.Add(rtn);


                rtn = new RadTreeNode("ImportStatusList", "1");
                rtn.NavigateUrl = "../ExcelImport/ImportStatusList.aspx";
                rtn.Target = "contentPane";
                myTree.Nodes.Add(rtn);
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        #endregion BindTree

        #region LoadInputScreen
        public void LoadInputScreen(RadPane myContentPane)
        {
            myContentPane.ContentUrl = "InputTemplateContent1.aspx";
        }
        #endregion LoadInputScreen

        #endregion methods
        //methods from javad updatedExcelimport
        #region javadmethods
        #region ImportExcelFile
        public void ImportExcelFile()
        {


            var Request = request;
            string tempFolder = temporaryFolder;
            //string tempFolder = Path.Combine(HttpRuntime.AppDomainAppPath, "~/Content/");
            DataSet dsFile = new DataSet();
            //DataTable dtError;
            try
            {
                // Reading Excel File To Dataset
                if (fileName.Length > 0)
                {
                    int fileExtensionCheck;
                    //string fileExtension = System.IO.Path.GetExtension(Request.Files[fileName].FileName);
                    //ExcelFileName = Request.Files[fileName].FileName;
                    string fileExtension = System.IO.Path.GetExtension(testFile);

                    fileExtensionCheck = validationObj.ValidateFileExtension(fileExtension);

                    if (fileExtensionCheck == 0)
                    {
                        importStatus = -1;
                        return;
                    }

                    else
                    {
                        //string fileLocation = tempFolder + Request.Files[fileName].FileName;
                        fileLocation = tempFolder + testFile;
                        string excelConnectionString = string.Empty;
                        if (fileExtension == ".xls")
                        {
                            excelConnectionString = System.Configuration.ConfigurationManager.AppSettings["XLS_ConnectionString"];
                            excelConnectionString = excelConnectionString.Replace("$fileLocation$", fileLocation);
                        }
                        //connection String for xlsx file format.
                        else if (fileExtension == ".xlsx")
                        {
                            excelConnectionString = System.Configuration.ConfigurationManager.AppSettings["XLSX_ConnectionString"];
                            excelConnectionString = excelConnectionString.Replace("$fileLocation$", fileLocation);
                        }

                        //Create Connection to Excel work book and add oledb namespace
                        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                        excelConnection.Open();
                        DataTable dt = new DataTable();

                        dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        if (dt == null)
                        {
                            importStatus = -1;
                            return;
                        }

                        String[] excelSheets = new String[dt.Rows.Count];
                        int t = 0;
                        //excel data saves in temp file here.
                        foreach (DataRow row in dt.Rows)
                        {
                            excelSheets[t] = row["TABLE_NAME"].ToString();
                            t++;
                        }
                        OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);
                        string query = string.Format("Select * from [{0}]", excelSheets[1]);
                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                        {
                            dataAdapter.Fill(dsFile);
                            excelConnection.Close();

                            totalCount = dsFile.Tables[0].Rows.Count;

                            if (dsFile.Tables[0].Rows.Count == 0)
                            {
                                failureMessage = "No data found!";
                                importStatus = -1;
                                return;
                            }
                        }

                    }

                    //Reading Excel File To Dataset

                    int result = InsertExcelFile(dsFile);

                    if (result == -1)
                    {
                        errorMessage = "Invalid Excel";
                        importStatus = -1;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

            importStatus = 1;
            return;
        }
        #endregion ImportExcelFile

        #region Inserting Data From Dataset to Database

        /// <summary>
        /// Insert Excel File Datas in Dataset to Database
        /// </summary>
        /// <param name="dsFile"></param>
        /// <returns>success or failure</returns>
        public int InsertExcelFile(DataSet dsFile)
        {
            try
            {
                DataTable dtError = validationObj.CreateErrorTable();
                DataSet dsTable = new DataSet();
                //DAL.Constants constantList = new DAL.Constants();
                // DAL.ExcelImportDAL importDal = new DAL.ExcelImportDAL();
                dbConnection dbcon = new dbConnection();
                //ExcelImportDetailsDAL importDetailsObj = new ExcelImportDetailsDAL();
                CommonDAL tblDef = new CommonDAL();
                dsTable = tblDef.GetTableDefinition(TableName);//temp table name
                DataRow[] result = dsTable.Tables[0].Select("ExcelMustFields='Y'");
                DataRow[] keyFieldRow = dsTable.Tables[0].Select("Key_Field='Y'");
                //validationObj.status_Id = importDetailsObj.status_Id;
                bool columnExistCheck = validationObj.ValidateExcelDataStructure(dsFile, dsTable);

                if (columnExistCheck == false)
                {
                    return -1;
                }

                InitializeExcelImportDetails(testFile, totalCount);

                dbcon.ConnectDB();

                for (int i = dsFile.Tables[0].Rows.Count - 1; i >= 0; i--)
                {
                    //to know temp
                    string ProjectNoP = dsFile.Tables[0].Rows[i]["ProjectNo"].ToString();
                    string ModuleIDP = dsFile.Tables[0].Rows[i]["ModuleID"].ToString();
                    string TO_SystemP = dsFile.Tables[0].Rows[i]["TO_System"].ToString();
                    string TO_SubSystemP = dsFile.Tables[0].Rows[i]["TO_SubSystem"].ToString();
                    string Equipment_Nop = dsFile.Tables[0].Rows[i]["Equipment_No"].ToString();
                    //to know temp

                    Thread.Sleep(200);
                    
                    int res;

                    res = validationObj.excelDatasetValidation(dsFile.Tables[0].Rows[i], dsTable);
                    if (res == -1)
                    {
                        errorCount = errorCount + 1;
                    }
                    else if (res == 1)
                    {
                        int insertResult;
                        insertResult = InsertExcelFile(dsTable,dsFile.Tables[0].Rows[i]);
                        if (insertResult == 1)
                        {
                            insertcount = insertcount + 1;
                        }
                        else if (insertResult == 0)
                        {
                            updateCount = updateCount + 1;
                        }
                    }
                    UpdateExcelImportDetails(UserName,ProjectNo,TableName, testFile, insertcount, updateCount, errorCount, Remarks, excelImportstatus.Processing);

                }

                UpdateExcelImportDetails(UserName, ProjectNo, TableName, testFile, insertcount, updateCount, errorCount, Remarks, excelImportstatus.Finished);
                dbcon.DisconectDB();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return 1;
        }

        #endregion Inserting Excel data in Dataset to Database
        #endregion javadmethods

        //methods from javad updatedExcelimport

        //methods from javad DAL.ExcelImportDAL
        #region Inserting Data From Dataset to Database

        /// <summary>
        /// Insert Excel File Datas in Dataset to Database
        /// </summary>
        /// <param name="dsFile"></param>
        /// <returns>success or failure</returns>
        public int InsertExcelFile(DataSet dsTable,DataRow dr)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                //DAL.ExcelImportDAL stdDal = new DAL.ExcelImportDAL();
                CommonDAL tblDef = new CommonDAL();
                //DAL.Constants constantList = new DAL.Constants();
                dbConnection dbcon = new dbConnection();
               
            //   dsTable = tblDef.GetTableDefinition(TableName);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = tblDef.GetProcedureName(TableName);
                cmd.Connection = dbcon.GetDBConnection();
                for (int j = 0; j < dsTable.Tables[0].Rows.Count; j++)
                {
                    string paramName = dsTable.Tables[0].Rows[j]["Field_Name"].ToString();
                    string type = dsTable.Tables[0].Rows[j]["Field_DataType"].ToString();
              
                    object paramValue = dr[paramName];

                    if (type == "D")
                    {
                        cmd.Parameters.AddWithValue(paramName, Convert.ToDateTime(paramValue));
                    }
                    else
                        cmd.Parameters.AddWithValue(paramName, paramValue);
                }
                cmd.Parameters.AddWithValue("@Updated_By", UserName);
                cmd.Parameters.AddWithValue("@Updated_Date", System.DateTime.Now);
                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@isUpdate";
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;
                outPutParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outPutParameter);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                string IsUpdate = outPutParameter.Value.ToString();
                if (IsUpdate == "0")
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return 0;
        }

        #endregion Inserting Excel data in Dataset to Database

        //methods from javad DAL.ExcelImportDAL

    }//end of classImportFile
    #endregion classImportFile
}