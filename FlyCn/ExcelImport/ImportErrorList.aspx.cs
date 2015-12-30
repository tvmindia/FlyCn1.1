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
    public partial class ImportErrorList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }
        #region BindData()
        public void BindData()
        {
            DataTable ds = new DataTable();

            //FlyCnDAL.ExcelImport detailsObj = new FlyCnDAL.ExcelImport();
            ImportFile detailsObj = new ImportFile();
            ds = detailsObj.getErrorDetails("testuser");
            RadGrid1_ErrorList.DataSource = ds;
            try
            {
                RadGrid1_ErrorList.DataBind();
            }
            catch (Exception)
            {

            }
        }
        #endregion BindData()

        #region RadGrid1_ItemCommand()
        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    GridDataItem item = e.Item as GridDataItem;
                    string StatusId = item.GetDataKeyValue("Status_Id").ToString();
                    Response.Redirect("ImportErrorDetails.aspx?StatusId=" + StatusId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }//
        }
        #endregion RadGrid1_ItemCommand
    }
}