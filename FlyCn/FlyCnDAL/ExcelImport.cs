using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace FlyCn.FlyCnDAL
{
    public class ExcelImport
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
        public ExcelImport()
        {

            status_Id = Guid.NewGuid();

        }

        public ExcelImport(Guid StatusId)
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

        public string ProjNo 
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

            dbConnection dcon=new dbConnection();
            con = dcon.GetDBConnection();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertExcelImportDetails";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Status_Id", status_Id);
            cmd.Parameters.AddWithValue("@ProjNo", ProjNo);
            cmd.Parameters.AddWithValue("@File_Name", ExcelFileName);
            cmd.Parameters.AddWithValue("@Table_Name", TableName);
            cmd.Parameters.AddWithValue("@Total_Count", totalCount);
            cmd.Parameters.AddWithValue("@Insert_Count", 0);
            cmd.Parameters.AddWithValue("@Update_Count", 0);
            cmd.Parameters.AddWithValue("@Error_Count", 0);
            cmd.Parameters.AddWithValue("@User_Name", UserName);
            cmd.Parameters.AddWithValue("@InsertStatus", excelImportstatus.started);
            cmd.Parameters.AddWithValue("@Remarks", "");
            //cmd.Parameters.AddWithValue("@Updated_Date",DateTime.Now);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
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
        public void UpdateExcelImportDetails(string userName,string ProjNo,string TableName,string ExcelFileName, int InsertCount, int UpdateCount, int ErrorCount, string Remarks, excelImportstatus processStatus)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            dbConnection dcon=new dbConnection();
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
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        #endregion Update Excel Import Details

        #region Error Details
        public DataTable getErrorDetails(string statusID)
        {
             DataTable datatableobj = null;
            SqlConnection con = null;
            dbConnection dcon = new dbConnection();
            con = dcon.GetDBConnection();
            SqlCommand cmd = new SqlCommand("SelectExcelImportErrorDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;   
            cmd.Parameters.AddWithValue("@Status_Id",statusID);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            datatableobj = new DataTable();
            adapter.Fill(datatableobj);
            con.Close();
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

            dbConnection dcon=new dbConnection();
            con = dcon.GetDBConnection();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SelectAllExcelImportDetailsById";
            cmd.Parameters.AddWithValue("@StatusId", id);
            cmd.Connection = con;
            da.SelectCommand = cmd;
            con.Open();
            da.Fill(myRec);
            con.Close();

            if (myRec.Tables[0].Rows.Count > 0) 
            {
                UpdateCount = Convert.ToInt32(myRec.Tables[0].Rows[0]["Update_Count"]);
                TimeRemaining = TimeSpan.FromMilliseconds(Convert.ToDouble(myRec.Tables[0].Rows[0]["Time_Remaining"])).ToString(@"hh\:mm\:ss");
                InsertCount =Convert.ToInt32(myRec.Tables[0].Rows[0]["Insert_Count"]);
                ErrorCount = Convert.ToInt32(myRec.Tables[0].Rows[0]["Error_Count"]);
                LastUpdatedTime = Convert.ToDateTime(myRec.Tables[0].Rows[0]["Last_Updated_Time"]);
                TimeElapsed = TimeSpan.FromMilliseconds(Convert.ToDouble(myRec.Tables[0].Rows[0]["Time_Elapsed"])).ToString(@"hh\:mm\:ss");
                ProjNo = myRec.Tables[0].Rows[0]["ProjNo"].ToString();
                FileName = myRec.Tables[0].Rows[0]["File_Name"].ToString();
                TableName = myRec.Tables[0].Rows[0]["Table_Name"].ToString();
                TotalCount = Convert.ToInt32(myRec.Tables[0].Rows[0]["Total_Count"].ToString());
                StartTime = Convert.ToDateTime(myRec.Tables[0].Rows[0]["Start_Time"].ToString());
                UserName = myRec.Tables[0].Rows[0]["User_Name"].ToString();
                InsertStatus = Convert.ToInt32(myRec.Tables[0].Rows[0]["InsertStatus"].ToString());
                Remarks = myRec.Tables[0].Rows[0]["Remarks"].ToString();
               // IsDeleted = Convert.ToByte(myRec.Tables[0].Rows[0]["IsDeleted"].ToString());
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
           
           dbConnection dcon=new dbConnection();
            con = dcon.GetDBConnection();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertExcelImportErrorDetails";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Import_Status_Id", status_Id);
            cmd.Parameters.AddWithValue("@Key_Field", KeyField);
            cmd.Parameters.AddWithValue("@Error_Description", ErrorDescription);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

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
            
            dbConnection dcon=new dbConnection();
            con = dcon.GetDBConnection();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateImportErrorDetails";
            cmd.Parameters.AddWithValue("@Status_Id", id);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        #endregion UpdateExcelImportDetails

        #region Method to get Procedure Name
        /// <summary>
        /// Get The Procedure Name From DataBase
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns>Procedure Name</returns>
        public string getProcedureName(string TableName)
        {
            string procName = "";
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
           
             dbConnection dcon=new dbConnection();
            con = dcon.GetDBConnection();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetProcedureName";
            cmd.Parameters.Add("@tablename", SqlDbType.NVarChar).Value = TableName;
            cmd.Parameters.Add("@propertyName", SqlDbType.NVarChar).Value = ImportProperty;
            cmd.Connection = con;

            try
            {
                con.Open();
                procName = cmd.ExecuteScalar().ToString();
                return procName;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        #endregion Method to get Procedure Name

        #region Method to get table definition
        /// <summary>
        /// Get The Table Definition
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns>Dataset</returns>
        public DataSet getTableDefinition(string TableName)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet myRec = new DataSet();

             dbConnection dcon=new dbConnection();
            con = dcon.GetDBConnection();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SelectTable";
            cmd.Parameters.Add("@tablename", SqlDbType.NVarChar).Value = TableName;
            cmd.Connection = con;
            da.SelectCommand = cmd;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                da.Fill(myRec);
                return myRec;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }
        #endregion Method to get table definition


#endregion methods
    }
}