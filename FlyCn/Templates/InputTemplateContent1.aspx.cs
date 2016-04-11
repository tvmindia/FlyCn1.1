using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data.SqlClient;
using System.Data;
using FlyCn.FlyCnDAL;

namespace FlyCn.Templates
{
    public partial class InputTemplateContent1 : System.Web.UI.Page
    {
        FlyCnDAL.PunchList pObj = new FlyCnDAL.PunchList();
        protected void Page_Load(object sender, EventArgs e)
        {
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
        }

        #region dtgManageProjectGrid_NeedDataSource1
        protected void dtgManageProjectGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dt;
            dt = pObj.GetPunchList("CEIL");
            dtgManageProjectGrid.DataSource = dt;

        }
        #endregion dtgManageProjectGrid_NeedDataSource1

        #region dtgManageProjectGrid_DeleteCommand
        private void dtgManageProjectGrid_DeleteCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
              
        }
        #endregion dtgManageProjectGrid_DeleteCommand

        #region dtgManageProjectGrid_ItemCommand
        protected void dtgManageProjectGrid_ItemCommand(object source, GridCommandEventArgs e)
        {
        }
        #endregion dtgManageProjectGrid_ItemCommand

        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {


            ErrorHandling eObj = new ErrorHandling();

            if (e.Item.Value == "Delete")
            {
                eObj.DeleteSuccessData(this);
            }
            else
            {
                eObj.ErrorData(new Exception("Procedure not found !"), this);
            }
        }
    }
}