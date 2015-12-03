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
        DataSet ds = null;
        SqlConnection con = null;
        //previous
        public string cmbTextField = "ModuleID";
        public string cmbValueField = "ModuleDesc";
        //previous

        #region ModulesProperties

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

        public string IS_ALLOWED_FOR_SCOPE_DEFN//nvarchar(1)
        {
            get;
            set;
        }

        #endregion ModulesProperties


        #region ModulesMethods
        #region GetModules
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
                ds = new DataSet();
                adapter.Fill(ds);
            }
            catch (Exception ex)
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
            return ds;
        }
        #endregion GetModules

        #region GetModuleByModuleID
        public DataSet GetModule(string moduleID)
        {
            try
            {
                dbConnection dcon = new dbConnection();
                con = dcon.GetDBConnection();
                SqlCommand cmd = new SqlCommand("GetModuleByModuleID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ModuleID", SqlDbType.NVarChar, 10).Value = moduleID;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                ds = new DataSet();
                adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ModuleID = ds.Tables[0].Rows[0]["ModuleID"].ToString();
                    ModuleDesc = ds.Tables[0].Rows[0]["ModuleDesc"].ToString();
                    ModuleType = ds.Tables[0].Rows[0]["ModuleType"].ToString();
                    CreateCategory_YN = ds.Tables[0].Rows[0]["CreateCategory_YN"].ToString();
                    BaseTable = ds.Tables[0].Rows[0]["BaseTable"].ToString();
                    TrackingTable = ds.Tables[0].Rows[0]["TrackingTable"].ToString();
                    ModuleUniqueKey = ds.Tables[0].Rows[0]["ModuleUniqueKey"].ToString();
                    ModuleWebForm = ds.Tables[0].Rows[0]["ModuleWebForm"].ToString();
                    MenuLevel_1_Page = ds.Tables[0].Rows[0]["MenuLevel_1_Page"].ToString();
                    ReportModuleLink = ds.Tables[0].Rows[0]["ReportModuleLink"].ToString();
                    int disorder;
                    int.TryParse(ds.Tables[0].Rows[0]["DisplayOrder"].ToString(), out disorder);
                    DisplayOrder = disorder;
                    ModuleIconURL = ds.Tables[0].Rows[0]["ModuleIconURL"].ToString();
                    ModuleIconURLsmall = ds.Tables[0].Rows[0]["ModuleIconURLsmall"].ToString();
                    IS_ALLOWED_FOR_SCOPE_DEFN = ds.Tables[0].Rows[0]["IS_ALLOWED_FOR_SCOPE_DEFN"].ToString();
                }

            }
            catch (Exception ex)
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
            return ds;
        }

        #endregion GetModuleByModuleID


        #endregion ModulesMethods



    }
}