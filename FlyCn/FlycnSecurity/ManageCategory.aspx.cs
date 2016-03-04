using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyCn.FlycnSecurity
{
    public partial class ManageCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bindddlprojectmodule();
            }
        }

        protected void dtgManageCategory_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (dtgManageCategory.DataSource == null)
            {
                dtgManageCategory.DataSource = new string[] { };
            }
        }

        #region Bind ddlprojectmodule
        public void Bindddlprojectmodule()
        {
            DataTable dtmodules = null;
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            try
            {
                dtmodules = new DataTable();
                dtmodules = userObj.GetAllModules();

                ddlProjects.DataSource = dtmodules;
                ddlProjects.DataTextField = "ModuleDesc";
                ddlProjects.DataValueField = "ModuleID";
                ddlProjects.DataBind();

                
            }
            catch (Exception)
            {
              

            }
        }
        #endregion Bind ddlprojectmodule

        protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable ds = new DataTable();
            string module = ddlProjects.SelectedValue;
            ds = userObj.GetAllCategories(module);
            dtgManageCategory.DataSource = ds;
            try
            {
                dtgManageCategory.DataBind();
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}