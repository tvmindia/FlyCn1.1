using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using FlyCn.FlyCnDAL;
using Telerik.Web.UI;

namespace FlyCn.ExcelImport
{
    public partial class ImportStatusList : System.Web.UI.Page
    {
        string StatusID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
               
            }

        }
        public void BindData()
        {
            DataSet ds = new DataSet();

            //FlyCnDAL.ExcelImport detailsObj = new FlyCnDAL.ExcelImport();
            ImportFile detailsObj = new ImportFile();

            ds = detailsObj.getExcelImportDetailsById("ef4958d2-1f76-4fdb-ad0d-011864373a0b");
            RadGrid1.DataSource = ds.Tables[0];
            try
            {
                RadGrid1.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    GridDataItem item = e.Item as GridDataItem;
                    string StatusId = item.GetDataKeyValue("Status_Id").ToString();
                    Response.Redirect("ImportStatus.aspx?StatusId=" + StatusId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            BindData();
        }

        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            BindCompletedDetails();
        }

        #region BindCompletedDetails()
        public void BindCompletedDetails()
        {
   
            //FlyCnDAL.ExcelImport detailsObj = new FlyCnDAL.ExcelImport();
            ImportFile detailsObj = new ImportFile();
            DataSet ds = new DataSet();
            ds = detailsObj.getDistictExcelImportDetails("4cd93ccc-7c83-4ca7-8641-3cea4b30d3d3");
            RadGrid2.DataSource = ds.Tables[0];
            try
            {
                RadGrid1.DataBind();
            }
            catch (Exception)
            {

                //  throw;
            }


        }
        #endregion BindCompletedDetails()

      
    }
}