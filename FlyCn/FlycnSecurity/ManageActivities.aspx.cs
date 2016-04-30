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
    public partial class ManageActivities : System.Web.UI.Page
    {
        ErrorHandling eObj = new ErrorHandling();
        FlyCn.FlyCnDAL.Users userObj = new FlyCn.FlyCnDAL.Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            SecurityCheck();
            if (!IsPostBack)
            {
                BindDropDownActivityProjectNo();
                BindDropDownCreateNewProjectNo();
            }
            RegisterToolBox();

            ToolBar.AddButton.Visible = false;
            ToolBar.EditButton.Visible = false;
            ToolBar.DeleteButton.Visible = true;
            ToolBar.UpdateButton.Visible = false;
            ToolBar.SaveButton.Visible = false;

            ToolBar1.AddButton.Visible = false;
            ToolBar1.EditButton.Visible = false;
            ToolBar1.DeleteButton.Visible = false;
            ToolBar1.UpdateButton.Visible = false;
            ToolBar1.SaveButton.Visible = true;
        }

        #region Register ToolBox

        public void RegisterToolBox()
        {
            ToolBar.onClick += new RadToolBarEventHandler(ToolBar_onClick);
            ToolBar.OnClientButtonClicking = "OnClientButtonClickingDetail";

            ToolBar1.onClick += new RadToolBarEventHandler(ToolBar1_onClick);
            ToolBar1.OnClientButtonClicking = "OnClientButtonClicking";
        }
        #endregion Register ToolBox

        #region SecurityCheck
        public void SecurityCheck()
        {
            string logicalObject = "ManageActivities";

            FlyCnDAL.Security.PageSecurity PS = new Security.PageSecurity(logicalObject, this);

            if (PS.isWrite == true)
            {
                dtgManageActivities.MasterTableView.GetColumn("Modulescheck").Display = false;
                dtgManageActivities.MasterTableView.GetColumn("Manage").Display = true;
                ToolBar.Visible = true;
                ToolBar.DeleteButton.Visible = false;
                ToolBar1.Visible = true;
                tabs2.Visible = true;
            }

            else
                if (PS.isEdit == true)
                {
                    dtgManageActivities.MasterTableView.GetColumn("Modulescheck").Display = false;
                    dtgManageActivities.MasterTableView.GetColumn("Manage").Display = true;
                    ToolBar.Visible = true;
                    ToolBar.DeleteButton.Visible = false;
                    ToolBar1.Visible = true;
                    tabs2.Visible = true;
                }
                else if (PS.isAdd == true)
                {
                    dtgManageActivities.MasterTableView.GetColumn("Modulescheck").Display = false;
                    dtgManageActivities.MasterTableView.GetColumn("Manage").Display = false;
                    ToolBar.Visible = true;
                    ToolBar.DeleteButton.Visible = false;
                    ToolBar1.Visible = true;
                    tabs2.Visible = true;
                }
                else if (PS.isRead == true)
                {
                    dtgManageActivities.MasterTableView.GetColumn("Modulescheck").Display = false;
                    dtgManageActivities.MasterTableView.GetColumn("Manage").Display = false;
                    ToolBar.Visible = false;
                    ToolBar.DeleteButton.Visible = false;
                    ToolBar1.Visible = false;
                    tabs2.Visible = false;
                }

                else if (PS.isDenied == true)
                {
                    HttpContext.Current.Response.Redirect("~/General/UnderConstruction.aspx?cause=accessdenied", true);
                }
            if (PS.isDelete == true)
            {
                dtgManageActivities.MasterTableView.GetColumn("Modulescheck").Display = true;
                ToolBar.Visible = true;
                ToolBar.DeleteButton.Visible = true;
            }

        }
        #endregion SecurityCheck

        protected void ToolBar_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string project = ddlProjects.SelectedItem.Text;
            string module = ddlModule.SelectedItem.Value;
            string category = ddlManageCategory.SelectedItem.Text;
            string functionName = e.Item.Value;
            if (e.Item.Value == "Delete")
            {
                foreach (GridDataItem item in dtgManageActivities.Items)
                {

                    CheckBox checkColumnAdd = item["Modulescheck"].Controls[0] as CheckBox;
                    if (checkColumnAdd.Checked == true)
                    {
                        string fullDesc = item.GetDataKeyValue("FullDesc").ToString();
                        userObj.DeleteManageActivities(project, module, fullDesc,category);
                        dtgManageActivities.Rebind();

                    }
                }
            }
        }

        protected void ToolBar1_onClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            string functionName = e.Item.Value;
            if (e.Item.Value == "Save")
            {
                FillActivities();
                dtgManageActivities.Rebind();
            }
        }
        #region FillActivities
        public void FillActivities()
        {
            userObj.fullDesc = txtFullDesc.Text;
            userObj.shortDesc = txtShortDesc.Text;
            if (chkIsFailApplicable.Checked == true)
            {
                userObj.failApplicable = true;
            }
            else
            {
                userObj.failApplicable = false;
            }
            userObj.startDateCaption = txtActualStartDateCaption.Text;
            userObj.statusCaption = txtStatusCaption.Text;
            userObj.completeDateCaption = txtActualCompleteDateCaption.Text;
            if (chkPlannedStartDate.Checked == true)
            {
                userObj.plannedStartDate = true;
            }
            else
            {
                userObj.plannedStartDate = false;
            }
            if (chkPlannedCmpltDate.Checked == true)
            {
                userObj.plannedCompleteDate = true;
            }
            else
            {
                userObj.plannedCompleteDate = false;
            }
            if (chkForeCastStartDate.Checked == true)
            {
                userObj.forecastStartDate = true;
            }
            else
            {
                userObj.forecastStartDate = false;
            }
            if (chkForeCastEndDate.Checked == true)
            {
                userObj.forecastEndDate = true;
            }
            else
            {
                userObj.forecastEndDate = false;
            }
            if (chkActualStartDate.Checked == true)
            {
                userObj.ActualStartDate = true;
            }
            else
            {
                userObj.ActualStartDate = false;
            }
            if (chkStatus.Checked == true)
            {
                userObj.status = true;
            }
            else
            {
                userObj.status = false;
            }
            if (chkActualCompleteDate.Checked == true)
            {
                userObj.ActualCompleteDate = true;
            }
            else
            {
                userObj.ActualCompleteDate = false;
            }
            if (chkWBSID.Checked == true)
            {
                userObj.wbsId = true;
            }
            else
            {
                userObj.wbsId = false;
            }
            if (chkActivityID.Checked == true)
            {
                userObj.ActivityId = true;
            }
            else
            {
                userObj.ActivityId = false;
            }
            if (chkBudgetHours.Checked == true)
            {
                userObj.budgetHours = true;
            }
            else
            {
                userObj.budgetHours = false;
            }
            if (chkSpentHoursProductive.Checked == true)
            {
                userObj.spentHoursProductive = true;
            }
            else
            {
                userObj.spentHoursProductive = false;
            }
            if (chkSpentHoursNonProductive.Checked == true)
            {
                userObj.spentHoursNonProductive = true;
            }
            else
            {
                userObj.spentHoursNonProductive = false;
            }
            if (chkActivityWeight.Checked == true)
            {
                userObj.activityWeight = true;
            }
            else
            {
                userObj.activityWeight = false;
            }
            if (chkQtyToInstall.Checked == true)
            {
                userObj.quantitytoInstall = true;
            }
            else
            {
                userObj.quantitytoInstall = false;
            }
            if (chkQuantityInstalled.Checked == true)
            {
                userObj.quantityInstalled = true;
            }
            else
            {
                userObj.quantityInstalled = false;
            }
            if (chkUnitOfMeasure.Checked == true)
            {
                userObj.unitOfMeasure = true;
            }
            else
            {
                userObj.unitOfMeasure = false;
            }
            if (chkCompleted.Checked == true)
            {
                userObj.completedBy = true;
            }
            else
            {
                userObj.completedBy = false;
            }
            if (chkRFIRef_No.Checked == true)
            {
                userObj.rfiRef_No = true;
            }
            else
            {
                userObj.rfiRef_No = false;
            }
            if (chkRFIDate.Checked == true)
            {
                userObj.rfiDate = true;
            }
            else
            {
                userObj.rfiDate = false;
            }
            if (chkAFIRef_No.Checked == true)
            {
                userObj.afiRef_No = true;
            }
            else
            {
                userObj.afiRef_No = false;
            }
            if (chkAFIDate.Checked == true)
            {
                userObj.afiDate = true;
            }
            else
            {
                userObj.afiDate = false;
            }
            if (chkRemarks.Checked == true)
            {
                userObj.remarks = true;
            }
            else
            {
                userObj.remarks = false;
            }
            userObj.totalCaption = txtTotalCaption.Text;
            userObj.passedCaption = txtPassedCaption.Text;
            userObj.failedCapton = txtFailedCaption.Text;
            userObj.inProgressCaption = txtInProgressCaption.Text;
            userObj.testedCaption = txtTestedCaption.Text;
            userObj.readyCaption = txtReadyCaption.Text;
            userObj.notReadyCaption = txtNotReadyCaption.Text;
            userObj.notTestedCaption = txtNotTested.Text;
            userObj.balanceCaption = txtBalanceCaption.Text;
            if (chkQuantityVerified.Checked == true)
            {
                userObj.quantityVerified = true;
            }
            else
            {
                userObj.quantityVerified = false;
            }
            userObj.projectNo = ddlSelectProject.SelectedItem.Text;
            userObj.moduleId = ddlSelectModule.SelectedItem.Text;
            userObj.Managecategory = ddlCategory.SelectedItem.Value;
            if (txtModuleActId.Text != "")
            {
                userObj.moduleActId = Convert.ToInt32(txtModuleActId.Text);
            }
            if(chkKpiQuantity.Checked==true)
            {
                userObj.KpiQty = true;
            }
            else
            {
                userObj.KpiQty = false;
            }
            DataTable dt = new DataTable();
            string project = ddlSelectProject.SelectedItem.Text;
            string module = ddlSelectModule.SelectedItem.Value;
         //   string category = ddlCategory.SelectedItem.Value;
            string desc = ddlActivity.SelectedItem.Text;
            dt = userObj.GetActivitiesToFindActCode(project, module);
            if (dt.Rows.Count>0)
            {
                int actCode = Convert.ToInt32(dt.Rows[0]["ActCode"]);
                if (actCode == 0)
                {
                    userObj.actCode = 10;
                }
                else
                {
                    userObj.actCode = actCode + 10;
                }
            }
            else
            {
                userObj.actCode = 10;
            }
            userObj.InsertManageActivities();
        }
        #endregion FillActivities

        #region BindDropDownCreateNewProjectNo
        public void BindDropDownCreateNewProjectNo()
        {
            FlyCnDAL.ProjectParameters projectObj = new FlyCnDAL.ProjectParameters();
            DataTable dt = new DataTable();
            dt = projectObj.BindProjectNo();
            ddlSelectProject.DataSource = dt;
            ddlSelectProject.DataTextField = "ProjectNo";
          
            ddlSelectProject.DataBind();
            ddlSelectProject.Items.Insert(0, new ListItem("--select project--", "-1"));
            ddlSelectModule.Items.Insert(0, new ListItem("--select module--", "-1"));
        }
        #endregion BindDropDownCreateNewProjectNo

        #region BindDropDownActivityProjectNo
        public void BindDropDownActivityProjectNo()
        {
            FlyCnDAL.ProjectParameters projectObj = new FlyCnDAL.ProjectParameters();
            DataTable dt = new DataTable();
            dt = projectObj.BindProjectNo();
            ddlProjects.DataSource = dt;
            ddlProjects.DataTextField = "ProjectNo";
            ddlProjects.DataBind();
        }
        #endregion BindDropDownActivityProjectNo

        protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dtmodules = null;
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            try
            {
                dtmodules = new DataTable();
                string project = ddlProjects.SelectedValue;
                dtmodules = userObj.GetAllModulesToManage();

                ddlModule.DataSource = dtmodules;
                ddlModule.DataTextField = "ModuleDesc";
                ddlModule.DataValueField = "ModuleID";
                ddlModule.DataBind();
             
                ddlModule.Items.Insert(0, new ListItem("--select module--", "-1"));
               
              
            }
            catch (Exception)
            {


            }
        }

        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtCategory = null;
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            try
            {
                dtCategory = new DataTable();
                string project = ddlProjects.SelectedValue;
                string module = ddlModule.SelectedItem.Value;
                dtCategory = userObj.GetAllCategory(project, module);
                if ((dtCategory.Rows.Count > 0) && (dtCategory !=null))
                {
                   
                    ddlManageCategory.DataSource = dtCategory;
                    ddlManageCategory.DataTextField = "CategoryDesc";
                    ddlManageCategory.DataValueField = "Category";

                    ddlManageCategory.DataBind();
                    ddlManageCategory.Items.Insert(0, new ListItem("--select category--", "-1"));
                    ddlManageCategory.ClearSelection();
                   
                }
                else
                {
                //    ddlManageCategory.Items.Insert(0, new ListItem("--select category--", "-1"));
                }
            }
            catch (Exception)
            {


            }
        }

        protected void ddlSelectProject_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dtmodules = null;
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            try
            {
                dtmodules = new DataTable();
                string project = ddlProjects.SelectedValue;
                dtmodules = userObj.GetAllModulesToManage();

                ddlSelectModule.DataSource = dtmodules;
                ddlSelectModule.DataTextField = "ModuleDesc";
               ddlSelectModule.DataValueField = "ModuleID";
                ddlSelectModule.DataBind();

                ddlSelectModule.Items.Insert(0, new ListItem("--select module--", "-1"));
                ddlCategory.Items.Insert(0, new ListItem("--select category--", "-1"));
            }
            catch (Exception)
            {


            }
            ddlSelectProject.Enabled = true;
            ddlSelectModule.Enabled = true;
            ddlCategory.Enabled = true;
            ddlActivity.Enabled = true;
            txtModuleActId.Enabled = false;
        }

        protected void ddlSelectModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtCategory, dtActivity = null;
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            try
            {
                dtCategory = new DataTable();
                string project = ddlSelectProject.SelectedValue;
                string module = ddlSelectModule.SelectedItem.Value;
                dtCategory = userObj.GetAllCategory(project,module);

                ddlCategory.DataSource = dtCategory;
                ddlCategory.DataTextField = "CategoryDesc";
                ddlCategory.DataValueField =  "Category";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("--select category--", "-1"));

            }
            catch (Exception)
            {


            }
            try
            {
                dtActivity = new DataTable();
                string project = ddlSelectProject.SelectedValue;
                string module = ddlSelectModule.SelectedItem.Value;
                //string category = ddlCategory.SelectedItem.Value;
                dtActivity = userObj.GetAllModuleActivities(project, module);

                ddlActivity.DataSource = dtActivity;
                ddlActivity.DataTextField = "FullDesc";
                ddlActivity.DataBind();
                ddlActivity.Items.Insert(0, new ListItem("--select Activity--", "-1"));

            }
            catch (Exception)
            {


            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            //DataTable dtActivity = null;
            //FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            
        }

        protected void ddlManageCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable ds = new DataTable();

            string module = ddlModule.SelectedValue;
            string project = ddlProjects.SelectedItem.Text;
            string category = ddlManageCategory.SelectedItem.Value;
            if (category != "--select category--")
            {
                ds = userObj.GetAllActivities(project,module,category);
                dtgManageActivities.DataSource = ds;
                int count = ds.Rows.Count;
                if (count > 0)
                {
                    dtgManageActivities.DataBind();
                }

            }
            if (dtgManageActivities.DataSource == null)
            {
                dtgManageActivities.DataSource = new string[] { };
            }
        }

        protected void dtgManageActivities_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable ds = new DataTable();
            DataTable dtCategory = new DataTable();
            string module = ddlModule.SelectedValue;
            string project = ddlProjects.SelectedItem.Text;
            string category = ddlManageCategory.SelectedItem.Text;
            dtCategory = userObj.GetAllCategory(project, module);
            if (dtCategory.Rows.Count > 0)
            {

            }
            else
            {
                ddlManageCategory.Items.Clear();
                ddlManageCategory.Items.Insert(0, new ListItem("--select category--", "-1"));
            }
            if (category != "--select category--")
            {
                ds = userObj.GetAllActivities(project, module, category);
                dtgManageActivities.DataSource = ds;
            }
            if (dtgManageActivities.DataSource == null)
            {
                dtgManageActivities.DataSource = new string[] { };
            }
        }

        protected void dtgManageActivities_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                CheckBox checkBoxAdd = (CheckBox)item["Modulescheck"].Controls[0];
                checkBoxAdd.Enabled = true;

            }
       
           
        }

        #region FillAllBoxes()
        public void FillAllBoxes()
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable dt = new DataTable();
            string project = ddlSelectProject.SelectedItem.Text;
            if (project == "--select project--")
            {
                project = ddlProjects.SelectedItem.Text;
                ddlSelectProject.SelectedItem.Text = project;
            }
            string module = ddlModule.SelectedItem.Value;
            if (module == "--select module--")
            {
                module = ddlSelectModule.SelectedItem.Value;
                ddlSelectModule.SelectedItem.Text = module;
            }
            else
            {
                ddlSelectModule.SelectedItem.Text = module;
            }
            string category = ddlCategory.SelectedItem.Value;
            if (category == "--select category--")
            {
                category=ddlManageCategory.SelectedItem.Value;
                ddlCategory.SelectedItem.Text = category;
            }
            string desc = ddlActivity.SelectedItem.Text;
            if (desc == "--select Activity--")
            {
                foreach (GridDataItem item in dtgManageActivities.Items)
                {
                    desc = item.GetDataKeyValue("FullDesc").ToString();
                }
                ddlActivity.SelectedItem.Text = desc;
            }
            dt = userObj.GetAllSys_Activities(project, module,desc,category);
            if (dt.Rows.Count > 0)
            {
                txtFullDesc.Text = dt.Rows[0]["FullDesc"].ToString();
                txtShortDesc.Text = dt.Rows[0]["ShortDesc"].ToString();
                if (dt.Columns.Contains("FailApplicable"))
                {
                    if (dt.Rows[0]["FailApplicable"] == DBNull.Value)
                    {
                        chkIsFailApplicable.Checked = false;
                    }

                    else
                    {
                        if (dt.Rows[0]["FailApplicable"] == DBNull.Value)
                        {
                            bool failApplicable = Convert.ToBoolean(dt.Rows[0]["FailApplicable_YN"]);
                            if (failApplicable == true)
                            {
                                chkIsFailApplicable.Checked = true;
                            }
                            else
                            {
                                chkIsFailApplicable.Checked = false;
                            }
                        }
                        else
                        {
                            chkIsFailApplicable.Checked = false;
                        }
                    }
                }
                else
                {
                    chkIsFailApplicable.Checked = false;
                }
                
                txtActualStartDateCaption.Text = dt.Rows[0]["Actual_StartDate_Caption"].ToString();
                if (dt.Columns.Contains("CompStatus_Caption"))
                {
                    txtStatusCaption.Text = dt.Rows[0]["CompStatus_Caption"].ToString();
                }
                else
                {
                    txtStatusCaption.Text = dt.Rows[0]["Status_Caption"].ToString();
                }
                txtActualCompleteDateCaption.Text = dt.Rows[0]["Actual_ComplDate_Caption"].ToString();
                if (dt.Rows[0]["Planned_StartDate_OnOff"] == DBNull.Value)
                {
                    chkPlannedStartDate.Checked = false;
                }
                else
                {
                    bool plannedStartDate = Convert.ToBoolean(dt.Rows[0]["Planned_StartDate_OnOff"]);
                    if (plannedStartDate == true)
                    {
                        chkPlannedStartDate.Checked = true;
                    }
                    else
                    {
                        chkPlannedStartDate.Checked = false;
                    }
                }
                if (dt.Rows[0]["Planned_ComplDate_OnOff"] == DBNull.Value)
                {
                    chkPlannedCmpltDate.Checked = false;
                }
                else
                {
                    bool plannedCmpltDate = Convert.ToBoolean(dt.Rows[0]["Planned_ComplDate_OnOff"]);
                    if (plannedCmpltDate == true)
                    {
                        chkPlannedCmpltDate.Checked = true;
                    }
                    else
                    {
                        chkPlannedCmpltDate.Checked = false;
                    }
                }
                if (dt.Rows[0]["Forecast_StartDate_OnOff"] == DBNull.Value)
                {
                    chkForeCastStartDate.Checked = false;
                }
                else
                {
                    bool foreCastStartDate = Convert.ToBoolean(dt.Rows[0]["Forecast_StartDate_OnOff"]);
                    if (foreCastStartDate == true)
                    {
                        chkForeCastStartDate.Checked = true;
                    }
                    else
                    {
                        chkForeCastStartDate.Checked = false;
                    }
                }
                if (dt.Rows[0]["Forecast_EndDate_OnOff"] == DBNull.Value)
                {
                    chkForeCastEndDate.Checked = false;
                }
                else
                {
                    bool foreCastEndDate = Convert.ToBoolean(dt.Rows[0]["Forecast_EndDate_OnOff"]);
                    if (foreCastEndDate == true)
                    {
                        chkForeCastEndDate.Checked = true;
                    }
                    else
                    {
                        chkForeCastEndDate.Checked = false;
                    }
                }
                if (dt.Rows[0]["Actual_StartDate_OnOff"] == DBNull.Value)
                {
                    chkActualStartDate.Checked = false;
                }
                else
                {
                    bool actualStartDate = Convert.ToBoolean(dt.Rows[0]["Actual_StartDate_OnOff"]);
                    if (actualStartDate == true)
                    {
                        chkActualStartDate.Checked = true;
                    }
                    else
                    {
                        chkActualStartDate.Checked = false;
                    }
                }
                if (dt.Rows[0]["Status_OnOff"] == DBNull.Value)
                {
                    chkStatus.Checked = false;
                }
                else
                {
                    bool status = Convert.ToBoolean(dt.Rows[0]["Status_OnOff"]);
                    if (status == true)
                    {
                        chkStatus.Checked = true;
                    }
                    else
                    {
                        chkStatus.Checked = false;
                    }
                }
                if (dt.Rows[0]["Actual_ComplDate_OnOff"] == DBNull.Value)
                {
                    chkActualCompleteDate.Checked = false;
                }
                else
                {
                    bool actualCompleteDate = Convert.ToBoolean(dt.Rows[0]["Actual_ComplDate_OnOff"]);
                    if (actualCompleteDate == true)
                    {
                        chkActualCompleteDate.Checked = true;
                    }
                    else
                    {
                        chkActualCompleteDate.Checked = false;
                    }
                }
                if (dt.Rows[0]["WBS_ID_OnOff"] == DBNull.Value)
                {
                    chkWBSID.Checked = false;
                }
                else
                {
                    bool wbdId = Convert.ToBoolean(dt.Rows[0]["WBS_ID_OnOff"]);
                    if (wbdId == true)
                    {
                        chkWBSID.Checked = true;
                    }
                    else
                    {
                        chkWBSID.Checked = false;
                    }
                }
                if (dt.Rows[0]["Activity_ID_OnOff"] == DBNull.Value)
                {
                    chkActivityID.Checked = false;
                }
                else
                {
                    bool activityID = Convert.ToBoolean(dt.Rows[0]["Activity_ID_OnOff"]);
                    if (activityID == true)
                    {
                        chkActivityID.Checked = true;
                    }
                    else
                    {
                        chkActivityID.Checked = false;
                    }
                }
                if (dt.Rows[0]["Budget_Hrs_OnOff"] == DBNull.Value)
                {
                    chkBudgetHours.Checked = false;
                }
                else
                {
                    bool budgetHours = Convert.ToBoolean(dt.Rows[0]["Budget_Hrs_OnOff"]);
                    if (budgetHours == true)
                    {
                        chkBudgetHours.Checked = true;
                    }
                    else
                    {
                        chkBudgetHours.Checked = false;
                    }
                }
                if (dt.Rows[0]["Spent_Hrs_Productive_OnOff"] == DBNull.Value)
                {
                    chkSpentHoursProductive.Checked = false;
                }
                else
                {
                    bool spentHoursProductive = Convert.ToBoolean(dt.Rows[0]["Spent_Hrs_Productive_OnOff"]);
                    if (spentHoursProductive == true)
                    {
                        chkSpentHoursProductive.Checked = true;
                    }
                    else
                    {
                        chkSpentHoursProductive.Checked = false;
                    }
                }
                if (dt.Rows[0]["Spent_Hrs_NonProductive_OnOff"] == DBNull.Value)
                {
                    chkSpentHoursNonProductive.Checked = false;
                }
                else
                {
                    bool spentHoursNonProductive = Convert.ToBoolean(dt.Rows[0]["Spent_Hrs_NonProductive_OnOff"]);
                    if (spentHoursNonProductive == true)
                    {
                        chkSpentHoursNonProductive.Checked = true;
                    }
                    else
                    {
                        chkSpentHoursNonProductive.Checked = false;
                    }
                }
                if(dt.Rows[0]["Activity_Weight_OnOff"]==DBNull.Value)
                {
                    chkActivityWeight.Checked = false;
                }
                else
                { 
                bool activityWeight = Convert.ToBoolean(dt.Rows[0]["Activity_Weight_OnOff"]);
                if (activityWeight == true)
                {
                    chkActivityWeight.Checked = true;
                }
                else
                {
                    chkActivityWeight.Checked = false;
                }
                    }
                if (dt.Rows[0]["QtyTo_Install_OnOff"] == DBNull.Value)
                {
                    chkQtyToInstall.Checked = false;
                }
                else
                {
                    bool qtyToInstall = Convert.ToBoolean(dt.Rows[0]["QtyTo_Install_OnOff"]);
                    if (qtyToInstall == true)
                    {
                        chkQtyToInstall.Checked = true;
                    }
                    else
                    {
                        chkQtyToInstall.Checked = false;
                    }
                }
                if (dt.Rows[0]["Qty_Installed_OnOff"] == DBNull.Value)
                {
                    chkQuantityInstalled.Checked = false;
                }
                else
                {
                    bool quantityInstalled = Convert.ToBoolean(dt.Rows[0]["Qty_Installed_OnOff"]);
                    if (quantityInstalled == true)
                    {
                        chkQuantityInstalled.Checked = true;
                    }
                    else
                    {
                        chkQuantityInstalled.Checked = false;
                    }
                }
                if (dt.Rows[0]["UnitOfMeasure_OnOff"] == DBNull.Value)
                {
                    chkUnitOfMeasure.Checked = false;
                }
                else
                {
                    bool unitOfMeasure = Convert.ToBoolean(dt.Rows[0]["UnitOfMeasure_OnOff"]);
                    if (unitOfMeasure == true)
                    {
                        chkUnitOfMeasure.Checked = true;
                    }
                    else
                    {
                        chkUnitOfMeasure.Checked = false;
                    }
                }
                if (dt.Rows[0]["Completed_By_OnOff"] == DBNull.Value)
                {
                    chkCompleted.Checked = false;
                }
                else
                {
                    bool completed = Convert.ToBoolean(dt.Rows[0]["Completed_By_OnOff"]);
                    if (completed == true)
                    {
                        chkCompleted.Checked = true;
                    }
                    else
                    {
                        chkCompleted.Checked = false;
                    }
                }
                if (dt.Rows[0]["RFI_RefNo_OnOff"] == DBNull.Value)
                {
                    chkRFIRef_No.Checked = false;
                }
                else
                {
                    bool rFIRef_No = Convert.ToBoolean(dt.Rows[0]["RFI_RefNo_OnOff"]);
                    if (rFIRef_No == true)
                    {
                        chkRFIRef_No.Checked = true;
                    }
                    else
                    {
                        chkRFIRef_No.Checked = false;
                    }
                }
                if (dt.Rows[0]["RFI_Date_OnOff"] == DBNull.Value)
                {
                    chkRFIDate.Checked = false;
                }
                else
                {
                    bool rFIDate = Convert.ToBoolean(dt.Rows[0]["RFI_Date_OnOff"]);
                    if (rFIDate == true)
                    {
                        chkRFIDate.Checked = true;
                    }
                    else
                    {
                        chkRFIDate.Checked = false;
                    }
                }
                if (dt.Rows[0]["AFI_RefNo_OnOff"] == DBNull.Value)
                {
                    chkAFIRef_No.Checked = false;
                }
                else
                {
                    bool aFIRef_No = Convert.ToBoolean(dt.Rows[0]["AFI_RefNo_OnOff"]);
                    if (aFIRef_No == true)
                    {
                        chkAFIRef_No.Checked = true;
                    }
                    else
                    {
                        chkAFIRef_No.Checked = false;
                    }
                }
                //update from here onwards
                if (dt.Rows[0]["AFI_Date_OnOff"] == DBNull.Value)
                {
                    chkAFIDate.Checked = false;
                }
                else
                {
                    bool aFIDate = Convert.ToBoolean(dt.Rows[0]["AFI_Date_OnOff"]);
                    if (aFIDate == true)
                    {
                        chkAFIDate.Checked = true;
                    }
                    else
                    {
                        chkAFIDate.Checked = false;
                    }
                }
                if (dt.Rows[0]["Remarks_OnOff"] == DBNull.Value)
                {
                    chkRemarks.Checked = false;
                }
                else
                {
                    bool remarks = Convert.ToBoolean(dt.Rows[0]["Remarks_OnOff"]);
                    if (remarks == true)
                    {
                        chkRemarks.Checked = true;
                    }
                    else
                    {
                        chkRemarks.Checked = false;
                    }
                }
                txtTotalCaption.Text = dt.Rows[0]["Total_Caption"].ToString();
                txtPassedCaption.Text = dt.Rows[0]["Passed_Caption"].ToString();
                txtFailedCaption.Text = dt.Rows[0]["Failed_Caption"].ToString();
                txtInProgressCaption.Text = dt.Rows[0]["InProgress_Caption"].ToString();
                txtTestedCaption.Text = dt.Rows[0]["Tested_Caption"].ToString();
                txtReadyCaption.Text = dt.Rows[0]["Ready_Caption"].ToString();
                txtNotReadyCaption.Text = dt.Rows[0]["Not_Ready_Caption"].ToString();
                txtNotTested.Text = dt.Rows[0]["Not_Tested_Caption"].ToString();
                txtBalanceCaption.Text = dt.Rows[0]["Balance_Caption"].ToString();
                if (dt.Columns.Contains("Qty_Verified_OnOff"))
                {
                    if (dt.Rows[0]["Qty_Verified_OnOff"] == DBNull.Value)
                    {
                        chkQuantityVerified.Checked = false;
                    }
                    else
                    {
                        bool quantityVerified = Convert.ToBoolean(dt.Rows[0]["Qty_Verified_OnOff"]);
                        if (quantityVerified == true)
                        {
                            chkQuantityVerified.Checked = true;
                        }
                        else
                        {
                            chkQuantityVerified.Checked = false;
                        }
                    }
                }
                else
                {
                    chkQuantityVerified.Checked = false;
                }
               
                //userObj.projectNo = ddlSelectProject.SelectedItem.Text;
                //userObj.moduleId = ddlSelectModule.SelectedItem.Value;
                //userObj.Managecategory = ddlCategory.SelectedItem.Value;
                txtModuleActId.Text = Convert.ToString(dt.Rows[0]["ModuleActID"]);
                //if (txtModuleActId.Text != "")
                //{
                //    userObj.moduleActId = Convert.ToInt32(txtModuleActId.Text);
                //}
                if (dt.Columns.Contains("KPI_Qty_YN"))
                {
                    bool kpiQuantity = Convert.ToBoolean(dt.Rows[0]["KPI_Qty_YN"]);
                    if (kpiQuantity == true)
                    {
                        chkKpiQuantity.Checked = true;
                    }
                    else
                    {
                        chkKpiQuantity.Checked = false;
                    }
                }
                else
                {
                    chkKpiQuantity.Checked = false;
                }
                
            }

        }
        #endregion FillAllBoxes()
        protected void ddlActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAllBoxes();
        }

        protected void dtgManageActivities_PreRender(object sender, EventArgs e)
        {
            try
            {
                dtgManageActivities.Rebind();
              
            }
            catch (Exception ex)
            {
                var page = HttpContext.Current.CurrentHandler as Page;
                eObj.ErrorData(ex, page);
                throw ex;
            }
        }

        #region ValidateDescriptions
        [System.Web.Services.WebMethod]
        public static bool ValidateFullDescription(string fullDesc,string moduleDesc,string project,string category)
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable dt = new DataTable();
            dt = userObj.GetModuleId(moduleDesc);
            string moduleId = Convert.ToString(dt.Rows[0]["ModuleID"]);

            if (userObj.ValidateFullDesc(fullDesc, moduleId, project, category))
            {
                return true;
            }
            return false;
        }

        #endregion ValidateDescriptions

        #region ValidateShortDesc
         [System.Web.Services.WebMethod]
        public static bool ValidateShortDescription(string shortDesc, string moduleDesc, string project, string category)
        {
            FlyCnDAL.Users userObj = new FlyCnDAL.Users();
            DataTable dt = new DataTable();
            dt = userObj.GetModuleId(moduleDesc);
            string moduleId = Convert.ToString(dt.Rows[0]["ModuleID"]);

            if (userObj.ValidateFullDesc(shortDesc, moduleId, project, category))
            {
                return true;
            }
            return false;
        }
        #endregion ValidateShortDesc

        protected void dtgManageActivities_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Manage")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "NavigateManage();", true);
                FillAllBoxes();
                ddlSelectProject.Enabled = false;
                ddlSelectModule.Enabled = false;
                ddlCategory.Enabled = false;
                ddlActivity.Enabled = false;
                txtModuleActId.Enabled = false;
                tabs2.InnerHtml = "Edit";
            }
        }
    }
}