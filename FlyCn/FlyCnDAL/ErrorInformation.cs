using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FlyCn.FlyCnDAL
{

    #region privateproperties
    public class ErrorInformation
    {


        public int Sl_No
        {
            get;
            set;
        }
        //public Guid status_Id
        //{
        //    get;
        //    set;
        //}
        //public string Status_ID
        //{
        //    get;
        //    set;
        //}

        public Guid Status_ID
        {
            get;
            set;
        }


        public int Excel_RowNO
        {
            get;
            set;
        }
        public string Key_Field
        {
            get;
            set;
        }

        public string Error_Description
        {
            get;
            set;
        }


        public bool IsError
        {
            get;
            set;
        }
        public int ErrorCount
        {
            get;
            set;
        }


        public int WarningCount
        {
            get;
            set;
        }
    #endregion privateproperties

        #region methods
        #region  GetAllErrorDetails
        public DataSet GetAllErrorDetails(string userName,string projectNo)
        {
            DataSet ds = null;

            dbConnection dbCon = null;
          
                try
                {
                    dbCon = new dbConnection();
                    dbCon.GetDBConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "[SelectDistinctExcelImportErrorDetails]";
                    cmd.Connection = dbCon.SQLCon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userName", SqlDbType.VarChar, 100).Value = userName;
                    cmd.Parameters.Add("@projectNo", SqlDbType.NVarChar,7).Value = projectNo;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    ds = new DataSet();
                    adapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (dbCon.SQLCon != null)
                    {
                        dbCon.DisconectDB();
                    }
                }
           

            return ds;
        }
        #endregion GetAllErrorDetails
        #region getErrorDetails
        public DataSet getErrorDetails(string status_Id)
        {
            DataSet ds = null;
            Guid statid = Guid.Empty;
            dbConnection dbCon = null;
            if (status_Id != "")
            {
                statid = Guid.Parse(status_Id);


                try
                {
                    dbCon = new dbConnection();
                    dbCon.GetDBConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SelectExcelImportErrorDetails";
                    cmd.Connection = dbCon.SQLCon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Status_Id", SqlDbType.UniqueIdentifier).Value = statid;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    ds = new DataSet();
                    adapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (dbCon.SQLCon != null)
                    {
                        dbCon.DisconectDB();
                    }
                }

            }
            return ds;
        }
        #endregion getErrorDetails


        #region InsertExcelImportErrorDetails
        /// <summary>
        /// Insert the values of Excel import error details table
        /// </summary>
        /// <param name="ExcelFileName"></param>
        /// <param name="InsertCount"></param>

        public Int16 InsertExcelImportErrorDetails(string KeyField, string ErrorDescription, Boolean isError, int rowNO, dbConnection dbCon)
        {

            SqlCommand cmd = new SqlCommand();
            SqlParameter outputparamIsUpdate = cmd.Parameters.Add("@IsUpdate", SqlDbType.TinyInt);

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertExcelImportErrorDetails";
                cmd.Connection = dbCon.SQLCon;
                cmd.Parameters.Add("@Import_Status_Id", SqlDbType.UniqueIdentifier).Value = Status_ID;
                cmd.Parameters.Add("@Key_Field", SqlDbType.NVarChar, 50).Value = KeyField;
                cmd.Parameters.Add("@Excel_RowNO", SqlDbType.Int).Value = rowNO;//excel error row number
                cmd.Parameters.Add("@Error_Description", SqlDbType.NVarChar, 250).Value = ErrorDescription;
                cmd.Parameters.Add("@IsError", SqlDbType.Bit).Value = isError;
                outputparamIsUpdate.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return Convert.ToInt16(outputparamIsUpdate.Value);
        }
        #endregion InsertExcelImportErrorDetails

        #region DeleteExcelErrorDetails
        /// <summary>
        /// Deletes validation error details 
        /// </summary>
        /// <param name="StatusID"></param>
        public void DeleteExcelErrorDetails(string StatusID)
        {
            SqlCommand cmd = null;
            dbConnection dbCon = null;
            Guid statusid;
            try
            {
                Guid.TryParse(StatusID, out statusid);
                cmd = new SqlCommand();
                dbCon = new dbConnection();
                dbCon.GetDBConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteExcelErrorDetails";
                cmd.Connection = dbCon.SQLCon;
                cmd.Parameters.Add("@StatusID", SqlDbType.UniqueIdentifier).Value = statusid;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(dbCon.SQLCon!=null)
                {
                    dbCon.DisconectDB();
                }

            }
        }
        #endregion DeleteExcelErrorDetails



        #endregion methods





    }
}