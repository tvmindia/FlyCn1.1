using FlyCn.FlyCnDAL;
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
        ErrorHandling eObj = new ErrorHandling();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
            SecurityCheck();
            if (!IsPostBack)
            {
                Bindddlprojectmodule();
            }
        }

        #region ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
           
            DataTable ds, dp = new DataTable();
            string functionName = e.Item.Value;
            string module = ddlModule.SelectedValue;
            string project = ddlProjects.SelectedValue;
            ds = userObj.GetAllCategories(module);
            int count = ds.Rows.Count;
            if (e.Item.Value == "Save")
            {
                FillUsers();
                dtgManageCategory.Rebind();

                //foreach (GridDataItem item in dtgManageCategory.Items)
                //{

                //    CheckBox checkColumnAdd = item["Modulescheck"].Controls[0] as CheckBox;
                //    checkColumnAdd.Checked = false;

                //}
            }
            if (e.Item.Value == "Delete")
            {
                foreach (GridDataItem item in dtgManageCategory.Items)
                {

                    CheckBox checkColumnAdd = item["Modulescheck"].Controls[0] as CheckBox;
                    if (checkColumnAdd.Checked == true)
                    {
                        string category = item.GetDataKeyValue("Category").ToString();
                        userObj.DeleteCategories(category, project);
                                dtgManageCategory.Rebind();
                           
                    }
                }
               
            }
            txtCategory.Text = "";
            txtCategoryDesc.Text = "";
            txtCategoryHelp.Text = "";
            txtCategoryType.Text = "";
            txtDisplayOrder.Text = "";
            txtKeyField.Text = "";
            chkIsActive.Checked = false;
          
        }
        #endregion ToolBar_onClick

        #region SecurityCheck
        public void SecurityCheck()
        {
            string logicalObject = "ManageCategory";

            FlyCnDAL.Security.PageSecurity PS = new Security.PageSecurity(logicalObject, this);

            if (PS.isWrite == true)
            {
                dtgManageCategory.MasterTableView.GetColumn("Modulescheck").Display = true;
                ToolBar.Visible = true;
                ToolBar.SaveButton.Visible = true;
                ToolBar.DeleteButton.Visible = false;
            }
            else
            if (PS.isEdit == true)
                {
                    dtgManageCategory.MasterTableView.GetColumn("Modulescheck").Display = false;
                    ToolBar.Visible = false;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                }
                if (PS.isAdd == true)
                {
                    dtgManageCategory.MasterTableView.GetColumn("Modulescheck").Display = false;
                    ToolBar.Visible = true;
                    ToolBar.SaveButton.Visible = true;
                    ToolBar.DeleteButton.Visible = false;
                }
                 if (PS.isRead == true)
                {
                    dtgManageCategory.MasterTableView.GetColumn("Modulescheck").Display = false;
                    ToolBar.Visible = false;
                    ToolBar.SaveButton.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                }

                 if (PS.isDenied == true)
                {
                    HttpContext.Current.Response.Redirect("~/General/UnderConstruction.aspx?cause=accessdenied", true);
                }
            if (PS.isDelete == true)
            {
                dtgManageCategory.MasterTableView.GetColumn("Modulescheck").Display = true;
                ToolBar.DeleteButton.Visible = true;
            }

        }
        #endregion SecurityCheck

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
            DataTable dt = new DataTable();
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            string module = ddlModule.SelectedValue;
            if (module != "--select module--")
            {
                dt = userObj.GetAllCategories(module);
                dtgManageCategory.DataSource = dt;
                
            }
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
            //try
            //{
                dtgManageCategory.DataBind();

                //foreach (GridDataItem item in dtgManageCategory.Items)
                //{

                //    CheckBox checkColumnAdd = item["Modulescheck"].Controls[0] as CheckBox;
                //    checkColumnAdd.Checked = false;
                //}
          //  }
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
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

        protected void dtgManageCategory_PreRender(object sender, EventArgs e)
        {
            try
            {
                dtgManageCategory.Rebind();
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
        }
    }
}
    
