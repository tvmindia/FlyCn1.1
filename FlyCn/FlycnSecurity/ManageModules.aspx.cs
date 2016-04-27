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
    public partial class ManageModules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClicking";
            SecurityCheck();
            if(!IsPostBack)
            {
                Session["selectedID"] = null;
                BindDropDownProjectNo();
            }
        }

        #region BindDropDownProjectNo
        public void BindDropDownProjectNo()
        {
            FlyCnDAL.ProjectParameters projectObj = new FlyCnDAL.ProjectParameters();
            DataTable dt = new DataTable();
            dt = projectObj.BindProjectNo();
            ddlProjects.DataSource = dt;
            ddlProjects.DataTextField = "ProjectNo";
            ddlProjects.DataBind();
        }
        #endregion BindDropDownProjectNo

        #region ToolBar_onClick
        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            FlyCn.FlyCnDAL.ErrorHandling eObj = new FlyCn.FlyCnDAL.ErrorHandling();
            DataTable ds,dp = new DataTable();
            try
            {
                string functionName = e.Item.Value;
                string project = ddlProjects.SelectedValue;
                string str = "";
                ds = userObj.GetAllModulesToManage();
                dp = userObj.GetAllModulesByProjectNo(ddlProjects.SelectedItem.Value);
                int count = ds.Rows.Count;
                if (e.Item.Value == "Save")
                {
                    foreach (GridDataItem item in dtgManageModules.Items)
                    {

                        CheckBox checkColumnAdd = (CheckBox)item["Modulescheck"].Controls[0];
                        if (checkColumnAdd.Checked == true)
                        {
                            string Id = item.GetDataKeyValue("ModuleID").ToString();
                           
                              
                                    
                                        if(str=="")
                                        {
                                            str = item.GetDataKeyValue("ModuleID").ToString();
                                        }
                                        else
                                        {
                                            str += "," + item.GetDataKeyValue("ModuleID").ToString();
                                        }
                                   
                            userObj.InsertProjectModules(Id,project);

                        }

                        if (checkColumnAdd.Checked == false)
                        {
                            foreach (DataRow dr in dp.Rows)
                            {


                                string Id = item.GetDataKeyValue("ModuleID").ToString();
                                    if (Id == Convert.ToString(dr["ModuleID"]))
                                    {
                                        userObj.DeleteModule(Id, project);
                                    }
                              
                            }
                        }
                    }
                }
             
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                // throw ex;
            }
        }
        #endregion ToolBar_onClick

        #region SecurityCheck
        public void SecurityCheck()
        {
            string logicalObject = "ManageModules";

            FlyCnDAL.Security.PageSecurity PS = new Security.PageSecurity(logicalObject, this);

            if (PS.isWrite == true)
            {
                dtgManageModules.MasterTableView.GetColumn("Modulescheck").Display = true;
                ToolBar.Visible = true;
            }
            else
                if (PS.isEdit == true)
                {
                    dtgManageModules.MasterTableView.GetColumn("Modulescheck").Display = false;
                    ToolBar.Visible = false;
                }
                else if (PS.isAdd == true)
                {
                    dtgManageModules.MasterTableView.GetColumn("Modulescheck").Display = true;
                    ToolBar.Visible = true;
                }
                else if (PS.isRead == true)
                {
                    dtgManageModules.MasterTableView.GetColumn("Modulescheck").Display = false;
                    ToolBar.Visible = false;
                }

                else if (PS.isDenied == true)
                {
                    HttpContext.Current.Response.Redirect("~/General/UnderConstruction.aspx?cause=accessdenied", true);
                }
            if (PS.isDelete == true)
            {
               
            }

        }
        #endregion SecurityCheck

        protected void dtgManageModules_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable ds = new DataTable();
            ds = userObj.GetAllModulesToManage();
            dtgManageModules.DataSource = ds;
           
        }

        protected void dtgManageModules_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                CheckBox checkBoxAdd = (CheckBox)item["Modulescheck"].Controls[0];
                //checkBoxAdd.Checked = true;
                checkBoxAdd.Enabled = true;
                checkBoxAdd.AutoPostBack = true;
               // (item["Modulescheck"].Controls[0] as CheckBox).Checked = true;
            }
            //FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            //DataTable dt = new DataTable();
            //string project = ddlProjects.SelectedItem.Value;
            //dt = userObj.GetAllModulesByProjectNo(project);

            //string Id = "";

            //foreach (DataRow dr in dt.Rows)
            //{
            //    foreach (GridDataItem colName in dtgManageModules.Items)
            //    {
            //        CheckBox checkColumnAdd = colName.FindControl("chkModuleSelect") as CheckBox;
            //        Id = colName.GetDataKeyValue("ModuleID").ToString();

            //        if (Id == Convert.ToString(dr["ModuleID"]))
            //        {
            //            // CheckBox chkbx = (CheckBox)colName["ModuleID"].FindControl("chkModuleSelect");
            //            checkColumnAdd.Checked = true;

            //        }
            //    }

           // }
        }

        protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridDataItem colName in dtgManageModules.Items)
            {
                CheckBox checkColumnAdd = (CheckBox)colName["Modulescheck"].Controls[0];
                checkColumnAdd.Checked = false;
                //colName.Selected = false;
            }
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable dt = new DataTable();
            string project = ddlProjects.SelectedItem.Value;
            dt = userObj.GetAllModulesByProjectNo(project);

            string Id = "";

            foreach (DataRow dr in dt.Rows)
            {
                foreach (GridDataItem colName in dtgManageModules.Items)
                {
                   
                    CheckBox checkColumnAdd = colName["Modulescheck"].Controls[0] as CheckBox;
                    Id = colName.GetDataKeyValue("ModuleID").ToString();

                    if (Id.Contains(Convert.ToString(dr["ModuleID"])))
                    {
                        // CheckBox chkbx = (CheckBox)colName["ModuleID"].FindControl("chkModuleSelect");
                       // colName.Selected = true;
                        checkColumnAdd.Checked = true;

                    }
                }

            }
        }

        protected void dtgManageModules_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            RememberSelected();
        }

        private void RememberSelected()
        {
            string strIds = ",";

            if (Session["selectedID"] != null)
            {
                strIds = Convert.ToString(Session["selectedID"]);
            }

            foreach (GridDataItem item in dtgManageModules.MasterTableView.Items)
            {
                CheckBox checkColumn = (CheckBox)item["Modulescheck"].Controls[0];
                string Id = item.GetDataKeyValue("ModuleID").ToString();

                if (checkColumn != null && checkColumn.Checked)
                {
                    strIds += Id.ToString() + ",";
                }
                else
                {
                    strIds = strIds.Replace("," + Id.ToString() + ",", ",");
                }
            }

            Session["selectedID"] = strIds;
        }

        //protected void Unnamed_PreRender(object sender, EventArgs e)
        //{
           
        //}

        protected void dtgManageModules_PreRender(object sender, EventArgs e)
        {
            //string strIds = ",";

            //if (Session["selectedID"] != null)
            //{
            //    strIds = Convert.ToString(Session["selectedID"]);
            //}

            //foreach (GridDataItem item in dtgManageModules.MasterTableView.Items)
            //{
            //    CheckBox checkColumn = (CheckBox)item["Modulescheck"].Controls[0];
            //    string Id = item.GetDataKeyValue("ModuleID").ToString();

            //    if (checkColumn != null)
            //    {
            //        if (strIds.IndexOf("," + Id.ToString() + ",") >= 0)
            //        {
            //            checkColumn.Checked = true;
            //        }
            //        else
            //        {
            //            checkColumn.Checked = false;
            //        }
            //    }
            //}
            
        }

        protected void dtgManageModules_ItemDataBound(object sender, GridItemEventArgs e)
        {
          
        }
    }
}