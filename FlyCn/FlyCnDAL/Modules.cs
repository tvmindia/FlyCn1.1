using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;

namespace FlyCn.FlyCnDAL
{
    public class Modules
    {
        ErrorHandling eObj = new ErrorHandling();
        DataSet dataset = null;
        SqlConnection con = null;
        //previous
        public string cmbTextField = "ModuleID";
        public string cmbValueField = "ModuleDesc";
        //previous

        public string ModuleID
        {
            get;
            set;
        }

        public string ModuleDesc
        {
            get;
            set;
        }

        public string ModuleType//nvarchar(1) type
        {
            get;
            set;
        }
        public string CreateCategory_YN//nvarchar(1) type
        {
            get;
            set;
        }
        public string BaseTable
        {
            get;
            set;
        }
        public string TrackingTable
        {
            get;
            set;
        }
        public string ModuleUniqueKey
        {
            get;
            set;
        }
        public string ModuleWebForm
        {
            get;
            set;
        }

        public string MenuLevel_1_Page
        {
            get;
            set;
        }
        public string ReportModuleLink
        {
            get;
            set;
        }
        public int DisplayOrder
        {
            get;
            set;
        }
        public string ModuleIconURL
        {
            get;
            set;
        }
        public string ModuleIconURLsmall
        {
            get;
            set;
        }
        public string ImportProperty
        {
            get;
            set;
        }

        public string IS_ALLOWED_FOR_SCOPE_DEFN//nvarchar(1)
        {
            get;
            set;
        }


        public DataSet GetModules()
        {
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetAllModules", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                dataset = new DataSet();
                adapter.Fill(dataset);
            }
            catch(Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

          
            return dataset;
       
        }

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

            dbConnection dcon = new dbConnection();
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

            dbConnection dcon = new dbConnection();
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





    }
}