using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using FlyCn.FlyCnDAL;

namespace FlyCn.UserControls
{
    public partial class MasterPopupGridview : System.Web.UI.Page
    {
        FlyCnDAL.CommonDAL CommonDALobj = new FlyCnDAL.CommonDAL();
        MasterPersonal objMasterPersonal = new MasterPersonal();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = null;
            string tableName = Request.QueryString["tableName"];
            string textField = Request.QueryString["textField"];
            string valueField = Request.QueryString["valueField"];

            string codeHeader = Request.QueryString["codeHeader"];
            string nameHeader = Request.QueryString["nameHeader"];

            CommonDALobj.tableName = tableName;
            CommonDALobj.textField = textField;
            CommonDALobj.valueField = valueField;
            ds = new DataSet();
            ds = CommonDALobj.getTableDetails();
           
            gvTableDetails.DataSource = ds.Tables[0];
            gvTableDetails.DataBind();

            gvTableDetails.HeaderRow.Cells[1].Text = codeHeader;
            gvTableDetails.HeaderRow.Cells[2].Text = nameHeader;

           
        }

        protected void gvTableDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRowName;
            string selectedRowCode;
            string textboxID = Request.QueryString["textboxid"];
            string divID = Request.QueryString["divID"];
            string iframeDiv = Request.QueryString["iframeDiv"];

            selectedRowCode = gvTableDetails.SelectedRow.Cells[1].Text;
            selectedRowName = gvTableDetails.SelectedRow.Cells[2].Text;

            //Session["Code"] = selectedRowCode;

            Response.Cookies["Code"].Value = selectedRowCode;


            //ViewState["Code"] = selectedRowCode;

            //objMasterPersonal.Code = selectedRowCode;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "passSelectedGridviewRowBankName", "passSelectedGridviewRowBankName('" + selectedRowName + "','" + selectedRowCode + "','" + textboxID + "','" + divID + "','" + iframeDiv + "');", true);

        }
    }
}