using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FlyCn.FlycnSecurity
{
    public partial class ManageCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
            if (!IsPostBack)
            {
                Bindddlprojectmodule();
            }
        }

        #region ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            FlyCn.FlyCnDAL.ErrorHandling eObj = new FlyCn.FlyCnDAL.ErrorHandling();
            DataTable ds, dp = new DataTable();
            string functionName = e.Item.Value;
            string module = ddlModule.SelectedValue;
            string project = ddlProjects.SelectedValue;
            ds = userObj.GetAllCategories(module);
            //   dp = userObj.GetAllModulesByProjectNo(ddlProjects.SelectedItem.Value);
            int count = ds.Rows.Count;
            if (e.Item.Value == "Save")
            {
                FillUsers();
                dtgManageCategory.Rebind();

                foreach (GridDataItem item in dtgManageCategory.Items)
                {

                    CheckBox checkColumnAdd = item["Modulescheck"].Controls[0] as CheckBox;
                    checkColumnAdd.Checked = true;
                    if (checkColumnAdd.Checked == false)
                    {
                        foreach (DataRow dr in dp.Rows)
                        {


                            string Id = item.GetDataKeyValue("ModuleID").ToString();
                            if (Id == Convert.ToString(dr["ModuleID"]))
                            {
                                userObj.DeleteCategories(module, project);
                            }

                        }
                    }
                }
            }
        }
        #endregion ToolBar_onClick
        public void FillUsers()
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            userObj.category = txtCategory.Text;
            userObj.categoryDesc = txtCategoryDesc.Text;
            userObj.categoryHelp = txtCategoryHelp.Text;
            userObj.displayOrder = Convert.ToInt32(txtDisplayOrder.Text);
            userObj.categoryType = txtCategoryType.Text;
            userObj.keyField = txtKeyField.Text;
            string module = ddlModule.SelectedItem.Value;
            string project = ddlProjects.Text;
            if (chkIsActive.Checked)
            {
                userObj.keyFieldGrpBy = true;
            }
            else
            {
                userObj.keyFieldGrpBy = false;
            }
            userObj.InsertCategories(module, project);

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
            FlyCnDAL.ProjectParameters projectObj = new FlyCnDAL.ProjectParameters();
            DataTable dt = new DataTable();
            dt = projectObj.BindProjectNo();
            ddlProjects.DataSource = dt;
            ddlProjects.DataTextField = "ProjectNo";
            ddlProjects.DataBind();
        }
        #endregion Bind ddlprojectmodule

        protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtmodules = null;
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            try
            {
                dtmodules = new DataTable();
                string project = ddlProjects.SelectedValue;
                dtmodules = userObj.GetAllModules(project);

                ddlModule.DataSource = dtmodules;
                ddlModule.DataTextField = "ModuleDesc";
                ddlModule.DataValueField = "ModuleID";
                //ddlModule.Items.Insert(0, new ListItem("--Select Module--", "0"));
                ddlModule.DataBind();
               

            }
            catch (Exception)
            {


            }

        }

        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable ds = new DataTable();
            string module = ddlModule.SelectedValue;
            ds = userObj.GetAllCategories(module);
            dtgManageCategory.DataSource = ds;
            try
            {
                dtgManageCategory.DataBind();

                foreach (GridDataItem item in dtgManageCategory.Items)
                {

                    CheckBox checkColumnAdd = item["Modulescheck"].Controls[0] as CheckBox;
                    checkColumnAdd.Checked = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dtgManageCategory_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                CheckBox checkBoxAdd = (CheckBox)item["Modulescheck"].Controls[0];
                checkBoxAdd.Enabled = true;
            }
        }
    }
}
    
