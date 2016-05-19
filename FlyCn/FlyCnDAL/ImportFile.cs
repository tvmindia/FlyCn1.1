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
using System.Web.Caching;
using System.IO;
using System.Diagnostics;
using ExcelProp = FlyCn.DocumentSettings.DocumentStatusSettings;
namespace FlyCn.FlyCnDAL
{
    #region classImportFile
    public class ImportFile
    {
        public ErrorInformation ErrorInfoObj = new ErrorInformation();
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
            
        }

        public ImportFile(Guid StatusId)
        {

            status_Id = StatusId;
            ErrorInfoObj.Status_ID = status_Id;

        }
        public string ExcelFileName
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

      

     
        public int InsertStatus
        {
            get;
            set;
        }

        public enum excelImportstatus
        {
            started = 1,
            Processing = 2,
            Finished = 3,
            Aborted = 4
        }
        public string SheetName
        {
            get;
            set;
        }
        public string SheetDescription
        {
            get;
            set;
        }

        public string ExcelConnectionString
        {
            get;
            set;
        }
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
        public int WarningCount
        {
            get;
            set;
        }
        public string fileName
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
        #endregion Public Properties

           
        #region methods

       

        #region InitializeExcelImportDetails
        /// <summary>
        /// Initialize the values of Excel import details table 
        /// </summary>
        /// <param name="ExcelFileName"></param>
        public void InitializeExcelImportDetails(string ExcelFileName, int totalCount,dbConnection dcon)
        {

           // SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            //dbConnection dcon = new dbConnection();
            try
            {
                //con = dcon.GetDBConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertExcelImportDetails";
                cmd.Connection = dcon.SQLCon;//con
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
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
              
            }

        }

        #endregion InitializeExcelImportDetails

        #region Update Excel Import Details
        /// <summary>
        /// Update the values of Excel import details table
        /// </summary>
        /// <param name="ExcelFileName"></param>
        /// <param name="InsertCount"></param>
        /// <param name="UpdateCount"></param>
        /// <param name="ErrorCount"></param>
        /// <param name="Remarks"></param>
        public void UpdateExcelImportDetails(string userName, string ProjNo, string TableName, string ExcelFileName, int InsertCount, int UpdateCount, string Remarks, excelImportstatus processStatus, dbConnection dcon=null)
        {
          
            SqlCommand cmd = new SqlCommand();
            if(dcon==null)
            {
                dcon = new dbConnection();
                dcon.GetDBConnection();
            }
      
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateExcelImportDetails";
                cmd.Connection = dcon.SQLCon;
                cmd.Parameters.AddWithValue("@Status_Id", status_Id);
                cmd.Parameters.AddWithValue("@ProjNo", ProjNo);
                cmd.Parameters.AddWithValue("@File_Name", ExcelFileName);
                cmd.Parameters.AddWithValue("@Table_Name", TableName);
                cmd.Parameters.AddWithValue("@Insert_Count", InsertCount);
                cmd.Parameters.AddWithValue("@Update_Count", UpdateCount);
               // cmd.Parameters.AddWithValue("@Error_Count", ErrorCount);
                cmd.Parameters.AddWithValue("@User_Name", userName);
                cmd.Parameters.AddWithValue("@InsertStatus", processStatus);
                cmd.Parameters.AddWithValue("@Remarks", Remarks);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
              
            }


        }
        #endregion Update Excel Import Details

       

        #region getAllExcelImportDetails
        public DataSet getAllExcelImportDetails(string userName,string projectNO)
        {
            DataSet datatableobj = null;

            dbConnection dcon = null;
            try
            {
                dcon = new dbConnection();
                dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("SelectAllExcelImportDetails", dcon.SQLCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@ProjNo", projectNO);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                datatableobj = new DataSet();
                adapter.Fill(datatableobj);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(dcon.SQLCon!=null)
                {
                    dcon.GetDBConnection();
                }
            }
                
         
            
            return datatableobj;
        }
        #endregion getAllExcelImportDetails

        #region getDistictExcelImportDetailsByUserName
        public DataSet getDistictExcelImportDetailsByUserName(string userName, string projectNO,bool checkCase)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataSet myRec = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[SelectCompletedAndAbortedExcelImportDetails]";
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@ProjectNO",projectNO);
            cmd.Parameters.Add("@Case", SqlDbType.Bit).Value = checkCase;

            cmd.Connection = con;
            da.SelectCommand = cmd;

            da.Fill(myRec);
            con.Close();
            return myRec;
        }
        #endregion getDistictExcelImportDetailsByUserName


        #region getExcelImportDetailsById
        /// <summary>
        /// Get All Excel Import Details By Status_ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DataSet</returns>

        public DataSet getExcelImportDetailsById(string statusID)
        {
            Guid statID=Guid.Empty;
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            dbConnection dcon = new dbConnection();
            try
            {
                if (statusID!="")
                {
                    statID = Guid.Parse(statusID);
                }
                
                con = dcon.GetDBConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAllExcelImportDetailsById";
                cmd.Parameters.AddWithValue("@StatusId", statID);
                cmd.Connection = con;
                da.SelectCommand = cmd;
                da.Fill(ds);
                if ((ds.Tables[0].Rows.Count > 0)&&(ds!=null))
                {
                    UpdateCount = (ds.Tables[0].Rows[0]["Update_Count"].ToString()!=null?(Convert.ToInt32(ds.Tables[0].Rows[0]["Update_Count"])):0);
                    TimeRemaining = (!DBNull.Value.Equals(ds.Tables[0].Rows[0]["Time_Remaining"]) ? (TimeSpan.FromMilliseconds(Convert.ToDouble(ds.Tables[0].Rows[0]["Time_Remaining"])).ToString(@"hh\:mm\:ss")) : "00:00:00");
                    InsertCount = (ds.Tables[0].Rows[0]["Insert_Count"].ToString()!=null?(Convert.ToInt32(ds.Tables[0].Rows[0]["Insert_Count"])):0);
                    ErrorCount = (ds.Tables[0].Rows[0]["Error_Count"].ToString()!=null?(Convert.ToInt32(ds.Tables[0].Rows[0]["Error_Count"])):0);
                    LastUpdatedTime =(ds.Tables[0].Rows[0]["Last_Updated_Time"].ToString()!=null?(Convert.ToDateTime(ds.Tables[0].Rows[0]["Last_Updated_Time"])):DateTime.MinValue);
                    TimeElapsed = (ds.Tables[0].Rows[0]["Time_Elapsed"].ToString() != null ? (TimeSpan.FromMilliseconds(Convert.ToDouble(ds.Tables[0].Rows[0]["Time_Elapsed"])).ToString(@"hh\:mm\:ss")):"00:00:00");
                    ProjectNo = (ds.Tables[0].Rows[0]["ProjNo"].ToString()!=null ? (ds.Tables[0].Rows[0]["ProjNo"].ToString()):"");
                    FileName = (ds.Tables[0].Rows[0]["File_Name"].ToString()!=null ?(ds.Tables[0].Rows[0]["File_Name"].ToString()):"");
                    TableName = (ds.Tables[0].Rows[0]["Table_Name"].ToString()!=null?(ds.Tables[0].Rows[0]["Table_Name"].ToString()):"");
                    TotalCount = (ds.Tables[0].Rows[0]["Total_Count"].ToString()!=null?(Convert.ToInt32(ds.Tables[0].Rows[0]["Total_Count"].ToString())):0);
                    StartTime = (ds.Tables[0].Rows[0]["Start_Time"].ToString()!=null?(Convert.ToDateTime(ds.Tables[0].Rows[0]["Start_Time"].ToString())):DateTime.MinValue);
                    UserName = ds.Tables[0].Rows[0]["User_Name"].ToString();
                    InsertStatus =(ds.Tables[0].Rows[0]["InsertStatus"].ToString()!=null?(Convert.ToInt32(ds.Tables[0].Rows[0]["InsertStatus"].ToString())):0);
                    Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    // IsDeleted = Convert.ToByte(ds.Tables[0].Rows[0]["IsDeleted"].ToString());
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
            return ds;
        }
        #endregion getExcelImportDetailsById

        

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

        #region GetExcelData
        public DataSet GetExcelData(DataSet dsTable)
        {
            var Request = request;
            string tempFolder = temporaryFolder;
            DataSet dsFile = new DataSet();
            String[] excelSheets;
           try
            {
               if (ExcelFileName.Length > 0)
                {
                    //DataSet dsTable=new DataSet();//temporry
                    excelSheets = OpenExcelFile();
                    dsFile = ScanExcelFileToDS(excelSheets,dsTable);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

            return dsFile;
        }
        #endregion GetExcelData

        #region ScanExcelFileToDS
        public DataSet ScanExcelFileToDS(string[] excelSheets,DataSet dsTable)
        {
            
            DataSet dsFile = new DataSet();
            OleDbConnection excelConnection1 = new OleDbConnection(ExcelConnectionString);
            try
            {
                   excelConnection1.Open();
                   var command = excelConnection1.CreateCommand();
               
                    //command.CommandText = "SELECT * FROM " + excelSheets[0];
                   command.CommandText = string.Format("Select * from [{0}]", SheetName + "$");
                    var conditions = "";
                    foreach (DataRow dr in dsTable.Tables[0].Rows)
                    {
                     conditions += "[" + dr["Field_Description"].ToString()+ "]" + " IS NOT NULL OR ";
                    }
                    if (conditions != "")
                    {
                        command.CommandText += " WHERE " + conditions.Remove(conditions.Length - 4);
                    }
              
               // string query = string.Format("Select * from [{0}]", excelSheets[0]);
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command.CommandText, excelConnection1))
                {
                    dataAdapter.Fill(dsFile);
                }
                //working
                //if ((dsFile.Tables[0] != null) && (dsFile.Tables[0].Rows.Count > 0))
                //{
                //    List<System.Data.DataRow> removeRowIndex = new List<System.Data.DataRow>();
                //    for (int i = dsFile.Tables[0].Rows.Count - 1; i >= 0; i--)
                //    {
                //        k = 0;
                //        for (int index = 0; index < dsFile.Tables[0].Columns.Count; index++)
                //        {
                //            if((dsFile.Tables[0].Rows[i][index]==DBNull.Value)||(string.IsNullOrEmpty(dsFile.Tables[0].Rows[i][index].ToString().Trim())))
                //            {
                //                k++;
                //            }
                        
                //        }
                //        if(k==dsFile.Tables[0].Columns.Count)
                //        {
                //            removeRowIndex.Add(dsFile.Tables[0].Rows[i]);
                //        }
                //   }
                //    // Remove all blank of in-valid rows
                //    foreach (System.Data.DataRow rowIndex in removeRowIndex)
                //    {
                //        dsFile.Tables[0].Rows.Remove(rowIndex);
                //    }
                //}
                //working
                //catch(Exception e)
               // {
               //     WPFMessageBox.Show(e.Message, Globalization.GetValue("Import_ImportOption_FormHeader"), WPFMessageBoxButtons.OK, WPFMessageBoxImage.Error);
               // }
                //  FreshTable = dsFile.Tables[0].AsEnumerable().Where(row => String.IsNullOrEmpty(row.Field<string>)).ToList().ForEach(row.
                //  to prevent null rows
                //  foreach (DataRow dr in dsFile.Tables[0].Rows)
                //  {
                //   FreshTable = dsFile.Tables[0].Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull)).CopyToDataTable();
                //   FreshTable.AcceptChanges();
                //   dsFile.Tables[0].AsEnumerable()Where(Function(row) row.ItemArray.All(Function(field) field Is Nothing Or field Is DBNull.Value Or field.Equals(""))).ToList().ForEach(Sub(row) row.Delete())  
                //   DtSet.Tables(0).AcceptChanges()  
                //  }
                //to prevent null rows
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                excelConnection1.Close();
            }

            return dsFile;
        }

        #endregion ScanExcelFileToDS

        #region OpenExcelFile
        public string[] OpenExcelFile()
        {
            string fileExtension = Path.GetExtension(fileName);
            ExcelConnectionString = string.Empty;
            if (fileExtension == ".xls")
            {
                ExcelConnectionString = System.Configuration.ConfigurationManager.AppSettings["XLS_ConnectionString"];
                ExcelConnectionString = ExcelConnectionString.Replace("$fileLocation$", fileLocation);
            }
            //connection String for xlsx file format.
            else if (fileExtension == ".xlsx")
            {
                ExcelConnectionString = System.Configuration.ConfigurationManager.AppSettings["XLSX_ConnectionString"];
                ExcelConnectionString = ExcelConnectionString.Replace("$fileLocation$", fileLocation);
            }
            //Create Connection to Excel work book and add oledb namespace
            OleDbConnection excelConnection = new OleDbConnection(ExcelConnectionString);
            String[] excelSheets = null;
            try
            {
                if (excelConnection.State != ConnectionState.Open)
                {
                    excelConnection.Open();
                }
                DataTable dt = new DataTable();

                dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if ((dt.Rows.Count == 2) && (dt != null))
                {
                    excelSheets = new String[dt.Rows.Count];
                    int t = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if ("'" + ExcelProp.FileDescriptionSheetName + "$" + "'"  == row["TABLE_NAME"].ToString())
                        {
                            SheetDescription = row["TABLE_NAME"].ToString();
                            SheetDescription = SheetDescription.TrimEnd('$');
                        }
                        else
                        {
                             SheetName = row["TABLE_NAME"].ToString();
                             SheetName = SheetName.TrimEnd('$');
                        }
                       excelSheets[t] = row["TABLE_NAME"].ToString();
                       t++;
                    }
                                     
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                excelConnection.Close();
            }
            return excelSheets;
        }
        #endregion OpenExcelFile


        #region ImportExcelData
        /// <summary>
        /// Insert Excel File is Data validated first then inserted  to Database 
        /// </summary>
        /// <param name="dsFile"></param>
        /// <returns>success or failure</returns>
        public int ImportExcelData(DataSet dsFile)
        {
            dbConnection dbcon = null;
            try
            {
                int insertResult;
                List<string> MasterColumns = new List<string>();
                DataSet dsTable = new DataSet();
                CommonDAL tblDef = new CommonDAL();
                dsTable = tblDef.GetTableDefinition(TableName);//temp table name
                DataSet MasterDS = null;
                MasterDS = tblDef.SelectAllMastersDataByTableName(TableName, ProjectNo);//Get all the master table values by union
                dbcon = new dbConnection();
                dbcon.GetDBConnection();
                ValidationExcel validationObj = new ValidationExcel();
                validationObj.statusID =status_Id.ToString();
                totalCount = dsFile.Tables[0].Rows.Count;
                InitializeExcelImportDetails(ExcelFileName, totalCount, dbcon);


              //  DataTable uniqueCols = dsTable.Tables[0].DefaultView.ToTable(true, "Ref_TableName", "Field_Description");

                DataRow[] MasterFieldDetails = dsTable.Tables[0].Select("Ref_TableName IS NOT NULL");
               
               // DataTable tempDT = new DataTable();
 
                //MasterFieldDetails.Distinct<>();
                foreach (DataRow row in MasterFieldDetails)//storing master having columns
                {
                    //MasterFieldDetails.AsEnumerable().Distinct(row);
                    MasterColumns.Add(row["Field_Description"].ToString());//column 2 field descrption
                }

                //------------------------------------Main Import Loop----------------------------------------------------------//
                int counter = 0;
                for (int i = dsFile.Tables[0].Rows.Count - 1; i >= 0; i--)
                {
                    // Thread.Sleep(200);
                    if((validationObj.DataValidation(dsFile.Tables[0].Rows[i], MasterDS, dsTable, MasterColumns, UserName,i+2,dbcon)==1))
                    {
                        continue;
                    }
                    insertResult = ImportExcelRow(dsTable, dsFile.Tables[0].Rows[i], dbcon);
                    if (insertResult == 1)
                    {
                        insertcount = insertcount + 1;
                    }
                    else if (insertResult == 0)
                    {
                        updateCount = updateCount + 1;
                    }
                    UpdateExcelImportDetails(UserName, ProjectNo, TableName, ExcelFileName, insertcount, updateCount, Remarks, excelImportstatus.Processing, dbcon);
                    counter = i;//for checking abort or finished
                }
                if(counter!=0)//means loop stopped in between importing iteration
                {
                    //this updates table with 'aborted' status if something happened in
                    UpdateExcelImportDetails(UserName, ProjectNo, TableName, ExcelFileName, insertcount, updateCount, Remarks, excelImportstatus.Aborted, dbcon);
                }
                else//import finished
                {
                    UpdateExcelImportDetails(UserName, ProjectNo, TableName, ExcelFileName, insertcount, updateCount, Remarks, excelImportstatus.Finished, dbcon); 
                }
            }
            catch
            {
               
               //this updates table with 'aborted' status if something happened in
               // UpdateExcelImportDetails(UserName, ProjectNo, TableName, ExcelFileName, insertcount, updateCount, errorCount, Remarks, excelImportstatus.Aborted, dbcon);
               // throw ex;
            }
            finally
            {
                if (dbcon != null)
                {
                    dbcon.DisconectDB();
                }
            }
            return 1;
        }
        #endregion ImportExcelData



        #region ImportExcelRow
        /// <summary>
        /// Insert Excel File Datas in Dataset to Database
        /// </summary>
        /// <param name="dsFile"></param>
        /// <returns>success or failure</returns>
        public int ImportExcelRow(DataSet dsTable, DataRow dr, dbConnection dbcon = null)
        {

            try
            {
                if (dbcon == null)
                {
                    dbcon = new dbConnection();
                    dbcon.GetDBConnection();
                }
                SqlCommand cmd = new SqlCommand();
                CommonDAL tblDef = new CommonDAL();
                //dbcon = new dbConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = dbcon.SQLCon;
                cmd.CommandText = tblDef.GetProcedureName(TableName);

                for (int j = 0; j < dsTable.Tables[0].Rows.Count; j++)
                {
                    //string paramName = dsTable.Tables[0].Rows[j]["Field_Name"].ToString();
                    string excelColName = dsTable.Tables[0].Rows[j]["Field_Description"].ToString();
                    string paramName = dsTable.Tables[0].Rows[j]["Field_Name"].ToString();
                    string type = dsTable.Tables[0].Rows[j]["Field_DataType"].ToString();
                    if ((dr.Table.Columns.Contains(excelColName)) != true)
                    {
                        continue;
                    }
                    else
                    {
                        object paramValue = dr[excelColName];
                        if (type == "D")
                        {
                            cmd.Parameters.AddWithValue(paramName, Convert.ToDateTime(paramValue));
                        }
                        else
                            cmd.Parameters.AddWithValue(paramName, paramValue);
                    }

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
        #endregion ImportExcelRow

        #region GetCableScheduleMaster
        public DataSet GetCableScheduleMaster(string projectNo, string moduleID, string category, string cableNo,dbConnection dbCon=null)
        {
               SqlCommand cmd = null;
               DataSet ds = null; 
               SqlDataAdapter da = null; 
             
          
            try
            {
                ds = new DataSet();
                cmd = new SqlCommand();
                da = new SqlDataAdapter();
                if (dbCon.SQLCon == null)
                {
                 dbCon = new dbConnection();
                 dbCon.GetDBConnection();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllCableScheduleDetails";
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@ModuleID", SqlDbType.NVarChar, 10).Value = moduleID;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 25).Value = category;
                cmd.Parameters.Add("@Cable_No", SqlDbType.NVarChar, 50).Value = cableNo;
                cmd.Connection = dbCon.SQLCon;
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
              
            }
            return ds;
        }

        #endregion GetCableScheduleMaster
        #region GetDrumMaster
        public DataSet GetDrumMaster(string projectNo, string moduleID, string category, string drumNo, string cableTypeCatg, string cableTypeCode, dbConnection dbCon = null)
        {
            SqlCommand cmd = null;
            DataSet ds = null;
            SqlDataAdapter da = null;
            try
            {
                ds = new DataSet();
                cmd = new SqlCommand();
                da = new SqlDataAdapter();
                if (dbCon.SQLCon == null)
                {
                    dbCon = new dbConnection();
                    dbCon.GetDBConnection();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllDrumDetails";
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@ModuleID", SqlDbType.NVarChar, 10).Value = moduleID;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 25).Value = category;
                cmd.Parameters.Add("@DrumNo", SqlDbType.NVarChar, 50).Value = drumNo;
                cmd.Parameters.Add("@CableTypeCatg", SqlDbType.NVarChar, 5).Value = cableTypeCatg;
                cmd.Parameters.Add("@CableTypeCode", SqlDbType.NVarChar, 50).Value = cableTypeCode;
                cmd.Connection = dbCon.SQLCon;
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds;
        }
        #endregion GetDrumMaster

        #region GetCableTotalPullLength
        public int GetCableTotalPullLength(string projectNo, string moduleID, string category, string cableNo, dbConnection dbCon = null)
        {
            SqlCommand cmd = null;
            DataSet ds = null;
            SqlDataAdapter da = null;
          
            int length;

            try
            {
                ds = new DataSet();
                cmd = new SqlCommand();
                da = new SqlDataAdapter();
              
                if (dbCon.SQLCon == null)
                {
                    dbCon = new dbConnection();
                    dbCon.GetDBConnection();
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetCableTotalPullLength";
                cmd.Parameters.Add("@ProjectNo", SqlDbType.NVarChar, 7).Value = projectNo;
                cmd.Parameters.Add("@ModuleID", SqlDbType.NVarChar, 10).Value = moduleID;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 25).Value = category;
                cmd.Parameters.Add("@Cable_No", SqlDbType.NVarChar, 50).Value = cableNo;
                SqlParameter outPutTotalLength = cmd.Parameters.Add("@OutPullLength", SqlDbType.Int);
                outPutTotalLength.Direction = ParameterDirection.Output;
                cmd.Connection = dbCon.SQLCon;
                cmd.ExecuteNonQuery();
                length=(int)(outPutTotalLength.Value);//returns -1 if no records find
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
              
            }
            return length;
        }
        #endregion GetCableTotalPullLength

        #endregion methods

    }
    #endregion classImportFile
}