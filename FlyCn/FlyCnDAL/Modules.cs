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





    }
}