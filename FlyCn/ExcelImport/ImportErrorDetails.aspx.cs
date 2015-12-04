using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using FlyCn.FlyCnDAL;

namespace FlyCn.ExcelImport
{
    public partial class ImportErrorDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }

        }
        public void BindData()
        {
            DataTable ds = new DataTable();

           // FlyCnDAL.ExcelImport detailsObj = new FlyCnDAL.ExcelImport();
            ImportFile detailsObj = new ImportFile();
            ds = detailsObj.getErrorDetails();
            RadGrid1_ErrorDetails.DataSource = ds;
            try
            {
                RadGrid1_ErrorDetails.DataBind();
            }
            catch (Exception)
            {

            }
        }
    }
}